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
    public class ProductTypeController : BaseController
    {
        #region Fields

        private readonly AbstractProductTypeServices abstractProductTypeServices;
        #endregion

        #region Ctor

        public ProductTypeController(AbstractProductTypeServices abstractProductTypeServices)
        {
            this.abstractProductTypeServices = abstractProductTypeServices;
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
        public ActionResult Manage(string Id = "")
        {
            if (TempData["openPopup"] != null)
                ViewBag.openPopup = TempData["openPopup"];

            AbstractProductType objModel = new ProductType();
            if (Id != "")
            {
                objModel = abstractProductTypeServices.ProductTypeById(Convert.ToInt32(ConvertTo.Base64Decode(Id))).Item;
            }
            // ViewBag.Subject = BindSubjectDropdown();
            return View(objModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName(Actions.BindProductType)]
        public JsonResult BindProductType([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel)
        {
            try
            {
                int totalRecord = 0;
                int filteredRecord = 0;
                PageParam pageParam = new PageParam();
                pageParam.Offset = requestModel.Start;
                pageParam.Limit = requestModel.Length;
                string Search = requestModel.Search.Value;
                var model = abstractProductTypeServices.ProductTypeSelectAll(pageParam, Search);
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
        [ActionName(Actions.AddEditProductType)]
        public ActionResult AddEditProductType(ProductType productType)
        {
              
             var result3 = abstractProductTypeServices.ProductTypeUpsert(productType);

            if (result3.Code == 200)
            {
                TempData["openPopup"] = CommonHelper.ShowAlertMessageToastr(MessageType.success.ToString(), result3.Message);
                return RedirectToAction(Actions.Index, Pages.Controllers.ProductType, new { Area = "" });
            }

            ViewBag.openPopup = CommonHelper.ShowAlertMessageToastr(MessageType.warning.ToString(), result3.Message);

            return PartialView("Manage");
        }

        [HttpPost]
        [ActionName(Actions.Delete)]
        public JsonResult Delete(string Id = "")
        {
            var result = abstractProductTypeServices.ProductTypeDelete(Convert.ToInt32(ConvertTo.Base64Decode(Id)));
            TempData["openPopup"] = CommonHelper.ShowAlertMessageToastr(MessageType.success.ToString(), "Product Type deleted successfully");
            return Json(1, JsonRequestBehavior.AllowGet);
        }

        //public IList<SelectListItem> BindSubjectDropdown()
        //{
        //    PageParam pageParam = new PageParam();
        //    pageParam.Offset = 0;
        //    pageParam.Limit = 0;
        //    var model = abstractExamSubjectServices.ExamSubjectSelectAll(pageParam, "");
        //    List<SelectListItem> items = new List<SelectListItem>();
        //    foreach (var category in model.Values)
        //    {
        //        items.Add(new SelectListItem() { Text = category.SubjectName.ToString(), Value = category.SubjectKey.ToString() });
        //    }
        //    return items;
        //}
        #endregion
    }
}
