using DataTables.Mvc;
using Blog.Common;
using Blog.Common.Paging;
using Blog.Entities.Contract;
using Blog.Entities.V1;
using Blog.Infrastructure;
using Blog.Pages;
using Blog.Services.Contract;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using static Blog.Infrastructure.Enums;
namespace Blog.Controllers
{
    public class StandardController : BaseController
    {
        #region Fields

        private readonly AbstractStandardServices abstractStandardServices;
        //private readonly AbstractDashboardServices abstractDashboardServices;
        #endregion

        #region Ctor

        public StandardController(AbstractStandardServices abstractStandardServices)
        {
            this.abstractStandardServices = abstractStandardServices;
        }

        #endregion

        #region Methods
        public ActionResult Index()
        {
            if (TempData["openPopup"] != null)
                ViewBag.openPopup = TempData["openPopup"];
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName(Actions.BindStandard)]
        public JsonResult BindStandard([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel)
        {
            try
            {
                int totalRecord = 0;
                int filteredRecord = 0;
                PageParam pageParam = new PageParam();
                pageParam.Offset = requestModel.Start;
                pageParam.Limit = requestModel.Length;
                string Search = requestModel.Search.Value;
                var model = abstractStandardServices.StandardSelectAll(pageParam, Search);
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
        [ActionName(Actions.StandardAddEdit)]
        public ActionResult StandardAddEdit(Standard standard, IEnumerable<HttpPostedFileBase> news_Json, IEnumerable<HttpPostedFileBase> live_Json, IEnumerable<HttpPostedFileBase> Blog_Json)
        {
            var user = abstractStandardServices.InsertUpdateStandards(standard, news_Json, live_Json, Blog_Json);
            if (user.Code == 200)
            {
                TempData["openPopup"] = CommonHelper.ShowAlertMessageToastr(MessageType.success.ToString(), user.Message);
            }
            else
            {
                TempData["openPopup"] = CommonHelper.ShowAlertMessageToastr(MessageType.warning.ToString(), user.Message);
            }

            return RedirectToAction(Actions.Index, Pages.Controllers.Standard, new { Area = "" });
        }

        [HttpGet]
        public ActionResult Manage(string id = "MA==")
        {
            int decryptedId = Convert.ToInt32(ConvertTo.Base64Decode(id));
            AbstractStandard objModel = new Standard();
            if (decryptedId > 0)
            {
                objModel = abstractStandardServices.StandardById(decryptedId).Item;
            }
            return View(objModel);
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        [ActionName(Actions.Banner_json)]
        public ActionResult Banner_json(Standard standard, IEnumerable<HttpPostedFileBase> Banner_json)
        {
            var result = abstractStandardServices.StandardBannerJsonUpdate(standard.Id, Banner_json);
            TempData["openPopup"] = CommonHelper.ShowAlertMessageToastr(MessageType.success.ToString(), "Banner Json Change successfully");
            return RedirectToAction(Actions.Index, Pages.Controllers.Standard, new { Area = "" });
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        [ActionName(Actions.HomeScreen_json)]
        public ActionResult HomeScreen_json(Standard standard, IEnumerable<HttpPostedFileBase> HomeScreen_json = null)
        {
            var result = abstractStandardServices.StandardHomeScrrenJsonUpdate(standard.StandardId, HomeScreen_json);
            TempData["openPopup"] = CommonHelper.ShowAlertMessageToastr(MessageType.success.ToString(), "Home Screen Json Change successfully");
            return RedirectToAction(Actions.Index, Pages.Controllers.Standard, new { Area = "" });
        }


        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        [ActionName(Actions.StandardOtherAppDataJsonUpdate)]
        public ActionResult StandardOtherAppDataJsonUpdate(Standard standard, IEnumerable<HttpPostedFileBase> OtherAppData_JSON = null)
        {
            var result = abstractStandardServices.StandardOtherAppDataJsonUpdate(standard.StandardId2, OtherAppData_JSON);
            TempData["openPopup"] = CommonHelper.ShowAlertMessageToastr(MessageType.success.ToString(), "Other App Data Change successfully");
            return RedirectToAction(Actions.Index, Pages.Controllers.Standard, new { Area = "" });
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        [ActionName(Actions.StandardCompetativeExamsJsonUpdate)]
        public ActionResult StandardCompetativeExamsJsonUpdate(Standard standard, IEnumerable<HttpPostedFileBase> CompetativeExams_JSON = null)
        {
            var result = abstractStandardServices.StandardCompetativeExamsJsonUpdate(standard.StandardId3, CompetativeExams_JSON);
            TempData["openPopup"] = CommonHelper.ShowAlertMessageToastr(MessageType.success.ToString(), "Competative Exams Change successfully");
            return RedirectToAction(Actions.Index, Pages.Controllers.Standard, new { Area = "" });
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        [ActionName(Actions.StandardOtherPDFMeterialUpdate)]
        public ActionResult StandardOtherPDFMeterialUpdate(Standard standard, IEnumerable<HttpPostedFileBase> OtherPDFMeterialFile = null)
        {
            var result = abstractStandardServices.StandardOtherPDFMeterialUpdate(standard.StandardId4, OtherPDFMeterialFile);
            TempData["openPopup"] = CommonHelper.ShowAlertMessageToastr(MessageType.success.ToString(), "Other PDF Meterial saved successfully");
            return RedirectToAction(Actions.Index, Pages.Controllers.Standard, new { Area = "" });
        }

        #endregion
    }
}
