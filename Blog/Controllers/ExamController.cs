using DataTables.Mvc;
using Blog.Common;
using Blog.Common.Paging;
using Blog.Entities.Contract;
using Blog.Entities.V1;
using Blog.Infrastructure;
using Blog.Pages;
using Blog.Services.Contract;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using static Blog.Infrastructure.Enums;
namespace Blog.Controllers
{
    public class ExamController : BaseController
    {
        #region Fields

        private readonly AbstractExamSubjectServices abstractExamSubjectServices;
        private readonly AbstractExamChapterServices abstractExamChapterServices;
        private readonly AbstractExamQuestionServices abstractExamQuestionServices;
        private readonly AbstractExamServices abstractExamServices;
        #endregion

        #region Ctor

        public ExamController(AbstractExamSubjectServices abstractExamSubjectServices, AbstractExamChapterServices abstractExamChapterServices
            , AbstractExamQuestionServices abstractExamQuestionServices, AbstractExamServices abstractExamServices)
        {
            this.abstractExamServices = abstractExamServices;
            this.abstractExamSubjectServices = abstractExamSubjectServices;
            this.abstractExamChapterServices = abstractExamChapterServices;
            this.abstractExamQuestionServices = abstractExamQuestionServices;
        }

        #endregion

        #region Methods
        public ActionResult Index()
        {
            if (TempData["openPopup"] != null)
                ViewBag.openPopup = TempData["openPopup"];
            return View();
        }

        [HttpGet]
        public ActionResult Manage(string ExamKey = "")
        {
            AbstractExam objModel = new Exam();
            if (ExamKey != "")
            {
                objModel = abstractExamServices.ExamById(ExamKey).Item;
                if (objModel.IsSubject == 1)
                {
                    objModel.IsSubjectCheckBox = true;
                }
                if (Convert.ToInt16(objModel.ExamViewNTA) == 1)
                {
                    objModel.ExamViewNTACheckBox = true;
                }
            }
            // ViewBag.Subject = BindSubjectDropdown();
            return View(objModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName(Actions.BindExam)]
        public JsonResult BindExam([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel)
        {
            try
            {
                int totalRecord = 0;
                int filteredRecord = 0;
                PageParam pageParam = new PageParam();
                pageParam.Offset = requestModel.Start;
                pageParam.Limit = requestModel.Length;
                string Search = requestModel.Search.Value;
                var model = abstractExamServices.ExamSelectAll(pageParam, Search);
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
        [ActionName(Actions.ExamAddEdit)]
        public ActionResult ExamAddEdit(Exam exam)
        {
            if (exam != null)
            {
                if (exam.IsSubjectCheckBox == true)
                {
                    exam.IsSubject = 1;
                }
                if (exam.ExamViewNTACheckBox == true)
                {
                    exam.ExamViewNTA = "1";
                }
                else
                {
                    exam.ExamViewNTA = "0";
                }
                if (exam.ExcelFile != null)
                {
                    if (exam.ExcelFile.ElementAt(0) != null)
                    {
                        string filepath = string.Empty;
                        string uploadfolder = Server.MapPath("~/UploadFiles/") + DateTime.Now.ToString("ddMMyyyyhhmmss");

                        var file = exam.ExcelFile.ElementAt(0);
                        filepath = uploadfolder + "\\" + file.FileName;
                        if (!Directory.Exists(uploadfolder))
                        {
                            Directory.CreateDirectory(uploadfolder);
                        }
                        exam.ExcelFile.ElementAt(0).SaveAs(filepath);
                        //Read the contents of CSV file.

                        FileInfo fileInfo = new FileInfo(filepath);
                        try
                        {
                            ExcelPackage package = new ExcelPackage(fileInfo);
                            ExcelWorksheet worksheet = package.Workbook.Worksheets[1];

                            // get number of rows and columns in the sheet
                            int rows = worksheet.Dimension.Rows; // 20
                            int columns = worksheet.Dimension.Columns; // 7
                            try
                            {
                                //List<ExportExcel> exportExcelsList = new List<ExportExcel>();

                                for (int i = 2; i <= rows; i++)
                                {
                                    if (exam.IsSubject == 1)
                                    {
                                        if (worksheet.Cells[i, 2].Value == null || worksheet.Cells[i, 3].Value == null || worksheet.Cells[i, 4].Value == null
                                            || worksheet.Cells[i, 5].Value == null || worksheet.Cells[i, 6].Value == null || worksheet.Cells[i, 7].Value == null
                                            || worksheet.Cells[i, 8].Value == null|| worksheet.Cells[i, 9].Value == null)
                                            continue;
                                    }
                                    else
                                    {
                                        if (worksheet.Cells[i, 6].Value == null || worksheet.Cells[i, 7].Value == null
                                           || worksheet.Cells[i, 8].Value == null || worksheet.Cells[i, 9].Value == null)
                                            continue;
                                    }

                                    ExportExcel exportExcel = new ExportExcel();
                                    exportExcel.SubjectKey = worksheet.Cells[i, 2].Value != null ? worksheet.Cells[i, 2].Value.ToString() : string.Empty;
                                    exportExcel.SubjectName = worksheet.Cells[i, 3].Value != null ? worksheet.Cells[i, 3].Value.ToString() : string.Empty;
                                    exportExcel.ChapterKey = worksheet.Cells[i, 4].Value != null ? worksheet.Cells[i, 4].Value.ToString() : string.Empty;
                                    exportExcel.ChapterName = worksheet.Cells[i, 5].Value != null ? worksheet.Cells[i, 5].Value.ToString() : string.Empty;
                                    exportExcel.QuestionKey = worksheet.Cells[i, 6].Value != null ? worksheet.Cells[i, 6].Value.ToString() : string.Empty;
                                    exportExcel.QuestionImage = worksheet.Cells[i, 7].Value != null ? worksheet.Cells[i, 7].Value.ToString() : string.Empty;
                                    exportExcel.AnswerOption = worksheet.Cells[i, 8].Value != null ? worksheet.Cells[i, 8].Value.ToString() : string.Empty;
                                    var optioncount = exportExcel.AnswerOption.Split(',');
                                    exportExcel.CorrectAnswer = worksheet.Cells[i, 9].Value != null ? worksheet.Cells[i, 9].Value.ToString() : string.Empty;
                                    if (optioncount.Count() >= Convert.ToInt32(exportExcel.CorrectAnswer))
                                    {
                                        AbstractExamQuestion abstractExamQuestion = new ExamQuestion();
                                        if (exam.IsSubject == 1)
                                        {
                                            AbstractExamSubject abstractExamSubject = new ExamSubject();
                                            abstractExamSubject.SubjectKey = exportExcel.SubjectKey;
                                            abstractExamSubject.SubjectName = exportExcel.SubjectName;
                                            abstractExamSubject.ExamKey = exam.ExamKey;
                                            var result1 = abstractExamSubjectServices.ExamSubjectUpsert(abstractExamSubject);

                                            AbstractExamChapter abstractExamChapter = new ExamChapter();
                                            abstractExamChapter.ChapterKey = exportExcel.ChapterKey;
                                            abstractExamChapter.ChapterName = exportExcel.ChapterName;
                                            abstractExamChapter.SubjectKey = exportExcel.SubjectKey;
                                            var result2 = abstractExamChapterServices.ExamChapterUpsert(abstractExamChapter);

                                            abstractExamQuestion.ExamSubjectKey = exportExcel.SubjectKey;
                                            abstractExamQuestion.ExamChapterKey = exportExcel.ChapterKey;
                                        }
                                        else
                                        {
                                            abstractExamQuestion.ExamSubjectKey = null;
                                            abstractExamQuestion.ExamChapterKey = null;
                                        }
                                        
                                        abstractExamQuestion.QuestionKey = exportExcel.QuestionKey;
                                        abstractExamQuestion.QuestionImage = exportExcel.QuestionImage;
                                        abstractExamQuestion.AnswerImage = exportExcel.QuestionImage;
                                        abstractExamQuestion.AnswerOptions = exportExcel.AnswerOption;
                                        abstractExamQuestion.CorrectAnswer = exportExcel.CorrectAnswer;
                                        abstractExamQuestion.ExamKey = exam.ExamKey;
                                        var result3 = abstractExamQuestionServices.ExamQuestionUpsert(abstractExamQuestion);
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                TempData["openPopup"] = CommonHelper.ShowAlertMessageToastr(MessageType.danger.ToString(), ex.Message.ToString());
                                return RedirectToAction(Actions.Index, Pages.Controllers.Exam, new { Area = "" });
                            }
                        }
                        catch (Exception ex)
                        {
                            TempData["openPopup"] = CommonHelper.ShowAlertMessageToastr(MessageType.danger.ToString(), ex.Message.ToString());
                            return RedirectToAction(Actions.Index, Pages.Controllers.Exam, new { Area = "" });
                        }
                    }
                }
                else
                {
                    TempData["openPopup"] = CommonHelper.ShowAlertMessageToastr(MessageType.success.ToString(), "Please upload excel file");
                }
            }
            var user = abstractExamServices.ExamUpsert(exam);
            if (user.Code == 200)
            {
                TempData["openPopup"] = CommonHelper.ShowAlertMessageToastr(MessageType.success.ToString(), user.Message);
            }
            else
            {
                TempData["openPopup"] = CommonHelper.ShowAlertMessageToastr(MessageType.warning.ToString(), user.Message);
            }

            return RedirectToAction(Actions.Index, Pages.Controllers.Exam, new { Area = "" });
        }

        [HttpPost]
        [ActionName(Actions.Delete)]
        public JsonResult Delete(string ExamKey = "")
        {
            var result = abstractExamServices.ExamDelete(ExamKey);
            TempData["openPopup"] = CommonHelper.ShowAlertMessageToastr(MessageType.success.ToString(), "Exam deleted successfully");
            return Json(1, JsonRequestBehavior.AllowGet);
        }

        public IList<SelectListItem> BindSubjectDropdown()
        {
            PageParam pageParam = new PageParam();
            pageParam.Offset = 0;
            pageParam.Limit = 0;
            var model = abstractExamSubjectServices.ExamSubjectSelectAll(pageParam, "");
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var category in model.Values)
            {
                items.Add(new SelectListItem() { Text = category.SubjectName.ToString(), Value = category.SubjectKey.ToString() });
            }
            return items;
        }
        #endregion
    }
}
