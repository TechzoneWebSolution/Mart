using DataTables.Mvc;
using Blog.Common;
using Blog.Common.Paging;
using Blog.Infrastructure;
using Blog.Pages;
using Blog.Services.Contract;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using static Blog.Infrastructure.Enums;

namespace Blog.Controllers
{
    public class ExamQuestionController : BaseController
    {
        #region Fields
        private readonly AbstractExamQuestionServices abstractExamQuestionServices;
        private readonly AbstractExamSubjectServices abstractExamSubjectServices;
        private readonly AbstractExamChapterServices abstractExamChapterServices;
        private readonly AbstractExamServices abstractExamServices;
        #endregion

        #region Ctor
        public ExamQuestionController(AbstractExamQuestionServices abstractExamQuestionServices, AbstractExamSubjectServices abstractExamSubjectServices, AbstractExamChapterServices abstractExamChapterServices
            , AbstractExamServices abstractExamServices)
        {
            this.abstractExamQuestionServices = abstractExamQuestionServices;
            this.abstractExamSubjectServices = abstractExamSubjectServices;
            this.abstractExamChapterServices = abstractExamChapterServices;
            this.abstractExamServices = abstractExamServices;
        }
        #endregion

        #region Methods
        public ActionResult Index()
        {
            if (TempData["openPopup"] != null)
                ViewBag.openPopup = TempData["openPopup"];
            ViewBag.Exam = BindExamDropdown();
            ViewBag.Subject = BindSubjectDropdown();
            ViewBag.Chapter = BindChapterDropdown();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName(Actions.BindExamQuestion)]
        public JsonResult BindExamQuestion([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel, string ExamKey = "", string SubjectKey = "", string ChapterKey = "")
        {
            try
            {
                int totalRecord = 0;
                int filteredRecord = 0;
                PageParam pageParam = new PageParam();
                pageParam.Offset = requestModel.Start;
                pageParam.Limit = requestModel.Length;
                string Search = requestModel.Search.Value;
                var model = abstractExamQuestionServices.ExamQuestionSelectAll(pageParam, Search, ExamKey, SubjectKey, ChapterKey);
                if (model != null)
                {
                    foreach (var item in model.Values)
                    {
                        item.QuestionImage = Configurations.Exams3Url + item.QuestionImage + "" + item.QuestionKey + "Q.png";
                        item.AnswerImage = Configurations.Exams3Url + item.AnswerImage + "" + item.QuestionKey + "A.png";
                    }
                }
                totalRecord = (int)model.TotalRecords;
                filteredRecord = (int)model.TotalRecords;
                return Json(new DataTablesResponse(requestModel.Draw, model.Values, filteredRecord, totalRecord), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new object[] { null }, JsonRequestBehavior.AllowGet);
            }
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
        [HttpPost]
        [ActionName(Actions.Search1)]
        public JsonResult Search1(string ExamKey)
        {
            try
            {
                return Json(new object[] { Enums.MessageType.success.GetHashCode(), Enums.MessageType.success.ToString(), BindSubjectDropdown(ExamKey) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new object[] { Enums.MessageType.danger.GetHashCode(), Enums.MessageType.danger.ToString(), "Please Contact To Admin" }, JsonRequestBehavior.AllowGet);
            }
        }
        public IList<SelectListItem> BindSubjectDropdown(string ExamKey = "")
        {
            PageParam pageParam = new PageParam();
            pageParam.Offset = 0;
            pageParam.Limit = 0;
            var model = abstractExamSubjectServices.ExamSubjectSelectAll(pageParam, "", ExamKey);
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var category in model.Values)
            {
                items.Add(new SelectListItem() { Text = category.SubjectName.ToString(), Value = category.SubjectKey.ToString() });
            }
            return items;
        }
        [HttpPost]
        [ActionName(Actions.Search2)]
        public JsonResult Search2(string SubjectKey = "")
        {
            try
            {
                return Json(new object[] { Enums.MessageType.success.GetHashCode(), Enums.MessageType.success.ToString(), BindChapterDropdown(SubjectKey) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new object[] { Enums.MessageType.danger.GetHashCode(), Enums.MessageType.danger.ToString(), "Please Contact To Admin" }, JsonRequestBehavior.AllowGet);
            }
        }
        public IList<SelectListItem> BindChapterDropdown(string SubjectKey = "")
        {
            PageParam pageParam = new PageParam();
            pageParam.Offset = 0;
            pageParam.Limit = 0;
            var model = abstractExamChapterServices.ExamChapterSelectAll(pageParam, "", SubjectKey);
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var category in model.Values)
            {
                items.Add(new SelectListItem() { Text = category.ChapterName.ToString(), Value = category.ChapterKey.ToString() });
            }
            return items;
        }

        [HttpPost]
        [ActionName(Actions.Delete)]
        public JsonResult Delete(int Id)
        {
            var result = abstractExamQuestionServices.QuestionDelete(Id);
            TempData["openPopup"] = CommonHelper.ShowAlertMessageToastr(MessageType.success.ToString(), "Exam question deleted successfully");
            return Json(1, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}
