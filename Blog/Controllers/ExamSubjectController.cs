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
    public class ExamSubjectController : BaseController
    {
        #region Fields

        private readonly AbstractExamChapterServices abstractExamChapterServices;
        private readonly AbstractExamSubjectServices abstractExamSubjectServices;
        private readonly AbstractExamServices abstractExamServices;
        #endregion

        #region Ctor

        public ExamSubjectController(AbstractExamChapterServices abstractExamChapterServices,
            AbstractExamSubjectServices abstractExamSubjectServices, AbstractExamServices abstractExamServices)
        {
            this.abstractExamChapterServices = abstractExamChapterServices;
            this.abstractExamSubjectServices = abstractExamSubjectServices;
            this.abstractExamServices = abstractExamServices;
        }

        #endregion

        #region Methods
        public ActionResult Index()
        {
            if (TempData["openPopup"] != null)
                ViewBag.openPopup = TempData["openPopup"];
            ViewBag.Exam = BindExamDropdown();
            return View();
        }

        [HttpGet]
        public ActionResult Manage(string ExamKey = "",string SubjectKey ="")
        {
            AbstractExamSubject objModel = null;
            if(ExamKey != "" && SubjectKey != "") { 
                objModel = abstractExamSubjectServices.ExamSubjectById(ExamKey, SubjectKey).Item;
            }
            ViewBag.Exam = BindExamDropdown();
            return View(objModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName(Actions.BindExamSubject)]
        public JsonResult BindExamSubject([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel, string ExamKey = "")
        {
            try
            {
                int totalRecord = 0;
                int filteredRecord = 0;
                PageParam pageParam = new PageParam();
                pageParam.Offset = requestModel.Start;
                pageParam.Limit = requestModel.Length;
                string Search = requestModel.Search.Value;
                var model = abstractExamSubjectServices.ExamSubjectSelectAll(pageParam, Search, ExamKey);
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
        [ActionName(Actions.ExamSubjectAddEdit)]
        public ActionResult ExamSubjectAddEdit(ExamSubject examSubject)
        {
            var user = abstractExamSubjectServices.ExamSubjectUpsert(examSubject);
            if(user.Code == 200)
            {
                TempData["openPopup"] = CommonHelper.ShowAlertMessageToastr(MessageType.success.ToString(), user.Message);
            }
            else
            {
                TempData["openPopup"] = CommonHelper.ShowAlertMessageToastr(MessageType.warning.ToString(), user.Message);
            }
            
            return RedirectToAction(Actions.Index, Pages.Controllers.ExamSubject, new { Area = "" });
        }

        [HttpPost]
        [ActionName(Actions.Delete)]
        public JsonResult Delete(string ExamKey = "", string SubjectKey = "")
        {
            var result = abstractExamSubjectServices.ExamSubjectDelete(ExamKey, SubjectKey);
            TempData["openPopup"] = CommonHelper.ShowAlertMessageToastr(MessageType.success.ToString(), "Exam subject deleted successfully");
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
                if(category.IsSubject == 1)
                {
                    items.Add(new SelectListItem() { Text = category.Name.ToString(), Value = category.ExamKey.ToString() });
                }
            }
            return items;
        }
        #endregion
    }
}
