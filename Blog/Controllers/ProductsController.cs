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
    public class ProductsController : BaseController
    {
        #region Fields

        private readonly AbstractProductsServices abstractProductsServices;
        private readonly AbstractProductTypeServices abstractProductTypeServices;
        #endregion

        #region Ctor

        public ProductsController(AbstractProductsServices abstractProductsServices, AbstractProductTypeServices abstractProductTypeServices)
        {
            this.abstractProductsServices = abstractProductsServices;
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

            AbstractProducts objModel = new Products();
            if (Id != "")
            {
                objModel = abstractProductsServices.ProductsById(Convert.ToInt32(ConvertTo.Base64Decode(Id))).Item;
            }
            ViewBag.ProductType = BindProductTypeDropdown();
            return View(objModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName(Actions.BindProducts)]
        public JsonResult BindProducts([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel)
        {
            try
            {
                int totalRecord = 0;
                int filteredRecord = 0;
                PageParam pageParam = new PageParam();
                pageParam.Offset = requestModel.Start;
                pageParam.Limit = requestModel.Length;
                string Search = requestModel.Search.Value;
                var model = abstractProductsServices.ProductsSelectAll(pageParam, Search);
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
        [ActionName(Actions.AddEditProducts)]
        public ActionResult AddEditProducts(Products Products, IEnumerable<HttpPostedFileBase> ProductImages)
        {
            var result3 = abstractProductsServices.ProductsUpsert(Products);

            if (ProductImages != null && ProductImages.Count() > 0)
            {
                foreach (var item in ProductImages)
                {
                    if (item != null)
                    {
                        string imgName = string.Empty;
                        var file = item;
                        string path = "Upload/productsImages/" + result3.Item.Id + @"/";
                        string avatarfolder = Server.MapPath("~/" + path);
                        if (!Directory.Exists(avatarfolder))
                        {
                            Directory.CreateDirectory(avatarfolder);
                        }
                        if (file != null && file.ContentLength > 0)
                        {
                            imgName = file.FileName;
                        }
                        if (!Directory.Exists(avatarfolder))
                        {
                            Directory.CreateDirectory(avatarfolder);
                        }

                        string avatarpath = avatarfolder + imgName;
                        Products.ProductImages = path + imgName;
                        Products.Id = result3.Item.Id;
                        item.SaveAs(avatarpath);
                        var result = abstractProductsServices.ProductsUpsert(Products);
                    }
                }
            }
            if (result3.Code == 200)
            {
                
                TempData["openPopup"] = CommonHelper.ShowAlertMessageToastr(MessageType.success.ToString(), result3.Message);
                return RedirectToAction(Actions.Index, Pages.Controllers.Products, new { Area = "" });
            }

            ViewBag.openPopup = CommonHelper.ShowAlertMessageToastr(MessageType.warning.ToString(), result3.Message);

            return PartialView("Manage");
        }

        [HttpPost]
        [ActionName(Actions.Delete)]
        public JsonResult Delete(string Id = "")
        {
            var result = abstractProductsServices.ProductsDelete(Convert.ToInt32(ConvertTo.Base64Decode(Id)));
            TempData["openPopup"] = CommonHelper.ShowAlertMessageToastr(MessageType.success.ToString(), "Product Type deleted successfully");
            return Json(1, JsonRequestBehavior.AllowGet);
        }

        public IList<SelectListItem> BindProductTypeDropdown()
        {
            PageParam pageParam = new PageParam();
            pageParam.Offset = 0;
            pageParam.Limit = 0;
            var model = abstractProductTypeServices.ProductTypeSelectAll(pageParam, "");
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var category in model.Values)
            {
                items.Add(new SelectListItem() { Text = category.Name.ToString(), Value = category.Id.ToString() });
            }
            return items;
        }
        #endregion
    }
}
