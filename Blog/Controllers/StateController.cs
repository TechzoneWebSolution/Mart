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
    public class StateController : BaseController
    {
        #region Fields
        private readonly AbstractStateServices abstractStateServices;
        #endregion

        #region Ctor
        public StateController(AbstractStateServices abstractStateServices)
        {
            this.abstractStateServices = abstractStateServices;
        }
        #endregion

        #region Methods
        [ActionName(Actions.Index)]
        public ActionResult Index()
        {
            if (TempData["openPopup"] != null)
                ViewBag.openPopup = TempData["openPopup"];
            return View();
        }


        [HttpGet]
        [ActionName(Actions.Manage)]
        public ActionResult Manage(string StateId = null)
        {
            AbstractState State = new State() ;
           
                int decryptedId =(!string.IsNullOrEmpty(StateId))? Convert.ToInt32(ConvertTo.Base64Decode(StateId)):0;
                if (decryptedId > 0)
                {
                    State = abstractStateServices.StateById(decryptedId).Item;
                }
            return View(State);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName(Actions.BindState)]
        public JsonResult BindState([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel)
        {
            try
            {
                int totalRecord = 0;
                int filteredRecord = 0;

                PageParam pageParam = new PageParam();
                pageParam.Offset = requestModel.Start;
                pageParam.Limit = requestModel.Length;

                string search = requestModel.Search.Value;
                var model = abstractStateServices.StateSelectAll(pageParam, search);

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
        [ActionName(Actions.AddEditState)]
        public ActionResult AddState(State State)
        {
            try
            {
                State.CreatedBy = ProjectSession.AdminUserID;
                State.ModifiedBy = ProjectSession.AdminUserID;
                SuccessResult<AbstractState> result = abstractStateServices.StateUpsert(State);
                if (result.Item != null)
                {
                    TempData["openPopup"] = CommonHelper.ShowAlertMessageToastr(MessageType.success.ToString(), result.Message);
                }
                else
                {
                    TempData["openPopup"] = CommonHelper.ShowAlertMessageToastr(MessageType.danger.ToString(), result.Message);
                }
            }
            catch (Exception ex)
            {
                TempData["openPopup"] = CommonHelper.ShowAlertMessageToastr(MessageType.danger.ToString(),"");
            }
            return RedirectToAction("Index");
        }

       

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName(Actions.DeleteState)]
        public ActionResult DeleteState(int Id)
        {
            try
            {
                bool result = abstractStateServices.StateDelete(Id,ProjectSession.AdminUserID);
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