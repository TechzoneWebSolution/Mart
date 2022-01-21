using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using DataTables.Mvc;
using Blog.Common;
using Blog.Common.Paging;
using Blog.Entities.Contract;
using Blog.Entities.V1;
using Blog.Infrastructure;
using Blog.Pages;
using Blog.Services.Contract;
using static Blog.Infrastructure.Enums;

namespace Blog.Controllers
{
    public class DistrictController : BaseController
    {
        #region Fields
        private readonly AbstractDistrictServices abstractDistrictServices;
        private readonly AbstractStateServices abstractStateServices;
        #endregion

        #region Ctor
        public DistrictController(AbstractDistrictServices abstractDistrictServices, AbstractStateServices abstractStateServices)
        {
            this.abstractDistrictServices = abstractDistrictServices;
            this.abstractStateServices = abstractStateServices;
        }
        #endregion

        #region Methods
        [ActionName(Actions.Index)]
        public ActionResult Index(string StateId = null)
        {
            if (TempData["openPopup"] != null)
                ViewBag.openPopup = TempData["openPopup"];
           ViewBag.StateId = (!string.IsNullOrEmpty(StateId)) ? Convert.ToInt32(ConvertTo.Base64Decode(StateId)) : 0;
            return View();
        }


        [HttpGet]
        [ActionName(Actions.Manage)]
        public ActionResult Manage(string DistrictId = null,string StateId=null)
        {
            AbstractDistrict District = new District() ;
            int decryptedId =(!string.IsNullOrEmpty(DistrictId))? Convert.ToInt32(ConvertTo.Base64Decode(DistrictId)):0;
            int decStateId =(!string.IsNullOrEmpty(StateId))? Convert.ToInt32(ConvertTo.Base64Decode(StateId)):0;

                if (decryptedId > 0)
                {
                    District = abstractDistrictServices.DistrictById(decryptedId).Item;
                }
                if(decStateId > 0)
                {
                ViewBag.decStateId = decStateId;
                    var stateresult = abstractStateServices.StateById(decStateId).Item;
                    ViewBag.StateName = (stateresult != null) ? stateresult.Name : "";
                }

            return View(District);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName(Actions.BindDistrict)]
        public JsonResult BindDistrict([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel,int StateId=0)
        {
            try
            {
                int totalRecord = 0;
                int filteredRecord = 0;

                PageParam pageParam = new PageParam();
                pageParam.Offset = requestModel.Start;
                pageParam.Limit = requestModel.Length;

                string search = requestModel.Search.Value;
                var model = abstractDistrictServices.DistrictSelectAllByStateId(pageParam, search,StateId);

                totalRecord = (int)model.TotalRecords;
                filteredRecord = (int)model.TotalRecords;

                return Json(new DataTablesResponse(requestModel.Draw, model.Values, filteredRecord, totalRecord), JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new object[] { Enums.MessageType.danger.GetHashCode(), Enums.MessageType.danger.ToString(), Messages.CommonErrorMessage }, JsonRequestBehavior.AllowGet);
            }
        }

        
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        [ActionName(Actions.AddEditDistrict)]
        public ActionResult AddDistrict(District District)
        {
            try
            {
                District.CreatedBy = ProjectSession.AdminUserID;
                District.ModifiedBy = ProjectSession.AdminUserID;
                SuccessResult<AbstractDistrict> result = abstractDistrictServices.DistrictUpsert(District);
                if (result.Item != null)
                {
                    TempData["openPopup"] = CommonHelper.ShowAlertMessageToastr(MessageType.success.ToString(), result.Message);
                }
                else
                {
                    TempData["openPopup"] = CommonHelper.ShowAlertMessageToastr(MessageType.danger.ToString(), result.Message);
                }
                return RedirectToAction("Index", new { StateId = ConvertTo.Base64Encode(result.Item.StateId.ToString()) });

            }
            catch (Exception ex)
            {
                TempData["openPopup"] = CommonHelper.ShowAlertMessageToastr(MessageType.danger.ToString(),"");
                return RedirectToAction("Index");

            }
        }

       

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName(Actions.DeleteDistrict)]
        public ActionResult DeleteDistrict(int Id)
        {
            try
            {
                bool result = abstractDistrictServices.DistrictDelete(Id,ProjectSession.AdminUserID);
                if (result)
                {
                    return Json(new object[] { Enums.MessageType.success.GetHashCode(), Enums.MessageType.success.ToString(), Messages.RecordDeletedSuccessfully }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new object[] { Enums.MessageType.danger.GetHashCode(), Enums.MessageType.danger.ToString(), Messages.RecordNotDeleted }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new object[] { Enums.MessageType.danger.GetHashCode(), Enums.MessageType.danger.ToString(), Messages.ContactToAdmin }, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion
    }
}