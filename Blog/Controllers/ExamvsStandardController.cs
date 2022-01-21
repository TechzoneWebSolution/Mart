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
    public class ExamVSStandardController : BaseController
    {
        #region Fields

        private readonly AbstractExamQuestionServices abstractExamQuestionServices;
        private readonly AbstractExamServices abstractExamServices;
        private readonly AbstractExamVSStandardServices abstractExamVSStandardServices;
        private readonly AbstractStandardServices abstractStandardServices;
        #endregion

        #region Ctor

        public ExamVSStandardController(AbstractExamQuestionServices abstractExamQuestionServices, AbstractExamServices abstractExamServices, AbstractExamVSStandardServices abstractExamVSStandardServices, AbstractStandardServices abstractStandardServices)
        {
            this.abstractExamQuestionServices = abstractExamQuestionServices;
            this.abstractExamServices = abstractExamServices;
            this.abstractExamVSStandardServices = abstractExamVSStandardServices;
            this.abstractStandardServices = abstractStandardServices;
        }

        #endregion

        #region Methods
        public ActionResult Index()
        {
            if (TempData["openPopup"] != null)
                ViewBag.openPopup = TempData["openPopup"];
            ViewBag.Standard = BindExamStandardDropdown();
            ViewBag.Exam = BindExamDropdown();
            return View();
        }

        [HttpGet]
        public ActionResult Manage(string StandardKey = "",string ExamKey = "")
        {
            AbstractExamVSStandard objModel = null;
            if(StandardKey != "" && ExamKey != "") { 
                objModel = abstractExamVSStandardServices.ExamVSStandardById(StandardKey, ExamKey).Item;
            }
            ViewBag.Standard = BindExamStandardDropdown();
            ViewBag.Exam = BindExamDropdown();
            return View(objModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName(Actions.BindExamVSStandard)]
        public JsonResult BindExamVSStandard([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel,string ExamKey = "",string StandardKey = "")
        {
            try
            {
                int totalRecord = 0;
                int filteredRecord = 0;
                PageParam pageParam = new PageParam();
                pageParam.Offset = requestModel.Start;
                pageParam.Limit = requestModel.Length;
                string Search = requestModel.Search.Value;
                var model = abstractExamVSStandardServices.ExamVSStandardSelectAll(pageParam, Search, ExamKey,StandardKey);
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
        [ActionName(Actions.ExamVSStandardAddEdit)]
        public ActionResult ExamVSStandardAddEdit(ExamVSStandard ExamVSStandard)
        {
            var user = abstractExamVSStandardServices.ExamVSStandardUpsert(ExamVSStandard);
            if(user.Code == 200)
            {
                TempData["openPopup"] = CommonHelper.ShowAlertMessageToastr(MessageType.success.ToString(), user.Message);
            }
            else
            {
                TempData["openPopup"] = CommonHelper.ShowAlertMessageToastr(MessageType.warning.ToString(), user.Message);
            }
            
            return RedirectToAction(Actions.Index, Pages.Controllers.ExamVSStandard, new { Area = "" });
        }

        [HttpPost]
        [ActionName(Actions.Delete)]
        public JsonResult Delete(string StandardKey = "", string ExamKey = "")
        {
            var result = abstractExamVSStandardServices.ExamVSStandardDelete(StandardKey, ExamKey);
            TempData["openPopup"] = CommonHelper.ShowAlertMessageToastr(MessageType.success.ToString(), "Exam vs Question deleted successfully");
            return Json(1, JsonRequestBehavior.AllowGet);
        }

        public IList<SelectListItem> BindExamDropdown()
        {
            PageParam pageParam = new PageParam();
            pageParam.Offset = 0;
            pageParam.Limit = 0;
            var model = abstractExamServices.ExamSelectAll(pageParam, "");
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var category in model.Values)
            {
                items.Add(new SelectListItem() { Text = category.Name.ToString(), Value = category.ExamKey.ToString() });
            }
            return items;
        }

        public IList<SelectListItem> BindExamStandardDropdown()
        {
            PageParam pageParam = new PageParam();
            pageParam.Offset = 0;
            pageParam.Limit = 10000;
            var model = abstractStandardServices.StandardSelectAll(pageParam, "");
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var category in model.Values)
            {
                items.Add(new SelectListItem() { Text = category.Key.ToString(), Value = category.Key.ToString() });
            }
            return items;
        }
        #endregion
    }
}
