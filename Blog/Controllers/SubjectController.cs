using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
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
    public class SubjectController : BaseController
    {
        #region Fields

        private readonly AbstractSubjectServices abstractSubjectServices;
        private readonly AbstractStandardServices abstractStandardServices;
        #endregion

        #region Ctor

        public SubjectController(AbstractSubjectServices abstractSubjectServices, AbstractStandardServices abstractStandardServices)
        {
            this.abstractSubjectServices = abstractSubjectServices;
            this.abstractStandardServices = abstractStandardServices;
        }

        #endregion

        #region Methods
        public ActionResult Index(string standardId = "MA==")
        {
            if (TempData["openPopup"] != null)
                ViewBag.openPopup = TempData["openPopup"];
            int decryptedId = Convert.ToInt32(ConvertTo.Base64Decode(standardId));
            string StandardName = "";
            if (decryptedId > 0)
            {
                var objModel = abstractStandardServices.StandardById(decryptedId).Item;
                if(objModel.Name != null)
                {
                    StandardName = objModel.Name;
                }
            }
            ViewBag.StandardName = StandardName;
            ViewBag.StandardId = standardId;
            return View();
        }

        [HttpGet]
        public ActionResult Manage(string id = "MA==", string standardId = "MA==")
        {
            int decryptedId = Convert.ToInt32(ConvertTo.Base64Decode(id));
            AbstractSubject objModel = null;
            if (decryptedId > 0)
            {
                objModel = abstractSubjectServices.SubjectById(decryptedId).Item;
            }

            int StandrdId = Convert.ToInt32(ConvertTo.Base64Decode(standardId));
            string StandardName = "";
            if (StandrdId > 0)
            {
                var modal = abstractStandardServices.StandardById(StandrdId).Item;
                if (modal.Name != null)
                {
                    StandardName = modal.Name;
                }
            }
            ViewBag.StandardName = StandardName;
            ViewBag.StandardId = standardId;
            ViewBag.StandardIdInt = StandrdId;
            return View(objModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName(Actions.BindSubject)]
        public JsonResult BindSubject([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel, string StandardId = "MA==")
        {
            try
            {
                int totalRecord = 0;
                int filteredRecord = 0;
                PageParam pageParam = new PageParam();
                pageParam.Offset = requestModel.Start;
                pageParam.Limit = requestModel.Length;
                string Search = requestModel.Search.Value;
                int decryptedId = Convert.ToInt32(ConvertTo.Base64Decode(StandardId));
                var model = abstractSubjectServices.SubjectSelectAll(pageParam, Search, decryptedId);
                totalRecord = (int)model.TotalRecords;
                filteredRecord = (int)model.TotalRecords;
                return Json(new DataTablesResponse(requestModel.Draw, model.Values, filteredRecord, totalRecord), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new object[] { null }, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        [ActionName(Actions.SubjectAddEdit)]
        public ActionResult SubjectAddEdit(Subject subject)
        {
            var user = abstractSubjectServices.SubjectUpsert(subject);
            if(user.Code == 200)
            {
                TempData["openPopup"] = CommonHelper.ShowAlertMessageToastr(MessageType.success.ToString(), user.Message);
                return RedirectToAction(Actions.Index, Pages.Controllers.Subject, new { Area = "", standardId = ConvertTo.Base64Encode(subject.StandardId.ToString()) });
            }
            else
            {
                TempData["openPopup"] = CommonHelper.ShowAlertMessageToastr(MessageType.warning.ToString(), user.Message);
            }
            
            return RedirectToAction(Actions.Index, Pages.Controllers.Standard, new { Area = "" });
        }

    

        #endregion
    }
}
