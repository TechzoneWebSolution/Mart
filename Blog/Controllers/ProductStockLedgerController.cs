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
using System.Web;

namespace Blog.Controllers
{
    public class ProductStockLedgerController : BaseController
    {
        #region Fields

        private readonly AbstractProductsServices abstractProductsServices;
        private readonly AbstractProductStockLedgerServices abstractProductStockLedgerServices;
        #endregion

        #region Ctor

        public ProductStockLedgerController(AbstractProductsServices abstractProductsServices, AbstractProductStockLedgerServices abstractProductStockLedgerServices)
        {
            this.abstractProductsServices = abstractProductsServices;
            this.abstractProductStockLedgerServices = abstractProductStockLedgerServices;
        }

        #endregion

        #region Methods
        public ActionResult Index(string ProductId)
        {
            if (TempData["openPopup"] != null)
                ViewBag.openPopup = TempData["openPopup"];
            var model = abstractProductsServices.ProductsById(Convert.ToInt32(ConvertTo.Base64Decode(ProductId)));
            if(model.Item != null && model.Item.ProductName != null) { 
            ViewBag.ProductName = model.Item.ProductName;
            }
            else
            {
                ViewBag.ProductName = "";
            }

            ViewBag.ProductId = ProductId;
            return View();
        }

        [HttpGet]
        public ActionResult Manage(string ProductId, string Id = "")
        {
            if (TempData["openPopup"] != null)
                ViewBag.openPopup = TempData["openPopup"];

            AbstractProductStockLedger objModel = new ProductStockLedger();
            if (Id != "")
            {
                objModel = abstractProductStockLedgerServices.ProductStockLedgerById(Convert.ToInt32(ConvertTo.Base64Decode(Id))).Item;
            }
            ViewBag.ProductId = ProductId;
            // ViewBag.ProductType = BindProductTypeDropdown();
            return View(objModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName(Actions.BindProductStockLedger)]
        public JsonResult BindProductStockLedger([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel, string ProductId)
        {
            try
            {
                int totalRecord = 0;
                int filteredRecord = 0;
                PageParam pageParam = new PageParam();
                pageParam.Offset = requestModel.Start;
                pageParam.Limit = requestModel.Length;
                string Search = requestModel.Search.Value;
                var model = abstractProductStockLedgerServices.ProductStockLedgerSelectAllByProductId(pageParam, Search, Convert.ToInt32(ConvertTo.Base64Decode(ProductId)));
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
        [ActionName(Actions.AddEditProductStockLedger)]
        public ActionResult AddEditProductStockLedger(ProductStockLedger productStockLedger)
        {
            productStockLedger.ProductId = Convert.ToInt32(ConvertTo.Base64Decode(productStockLedger.ProductIdstring));
            var result3 = abstractProductStockLedgerServices.ProductStockLedgerUpsert(productStockLedger);

            if (result3.Code == 200)
            {
                TempData["openPopup"] = CommonHelper.ShowAlertMessageToastr(MessageType.success.ToString(), result3.Message);
                return RedirectToAction(Actions.Index, Pages.Controllers.ProductStockLedger, new { Area = "", ProductId = Convert.ToString(ConvertTo.Base64Encode(productStockLedger.ProductId.ToString())) });
            }
            ViewBag.openPopup = CommonHelper.ShowAlertMessageToastr(MessageType.warning.ToString(), result3.Message);

            return PartialView("Manage");
        }

        [HttpPost]
        [ActionName(Actions.DeleteProductStockLedger)]
        public JsonResult DeleteProductStockLedger(string Id = "")
        {
            var result = abstractProductStockLedgerServices.ProductStockLedgerDelete(Convert.ToInt32(ConvertTo.Base64Decode(Id)));
            TempData["openPopup"] = CommonHelper.ShowAlertMessageToastr(MessageType.success.ToString(), "Product stock ledger deleted successfully");
            return Json(1, JsonRequestBehavior.AllowGet);
        }

        //public IList<SelectListItem> BindProductTypeDropdown()
        //{
        //    PageParam pageParam = new PageParam();
        //    pageParam.Offset = 0;
        //    pageParam.Limit = 0;
        //    var model = abstractProductTypeServices.ProductTypeSelectAll(pageParam, "");
        //    List<SelectListItem> items = new List<SelectListItem>();
        //    foreach (var category in model.Values)
        //    {
        //        items.Add(new SelectListItem() { Text = category.Name.ToString(), Value = category.Id.ToString() });
        //    }
        //    return items;
        //}
        #endregion
    }
}
