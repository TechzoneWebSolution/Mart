using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
    public class OrderController : BaseController
    {
        #region Fields
        private readonly AbstractOrderDetailsServices abstractOrderDetailsServices;

        public OrderController(AbstractOrderDetailsServices abstractOrderDetailsServices)
        {
            this.abstractOrderDetailsServices = abstractOrderDetailsServices;
        }
        #endregion

        #region Methods
        public ActionResult Index(string customerId = "MA==")
        {
            if (TempData["openPopup"] != null)
                ViewBag.openPopup = TempData["openPopup"];
            int CustomerId = Convert.ToInt32(ConvertTo.Base64Decode(customerId));
            ViewBag.CustomerId = CustomerId;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName(Actions.BindOrder)]
        public JsonResult BindOrder([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel, int CustomerId)
        {
            try
            {
                int totalRecord = 0;
                int filteredRecord = 0;
                PageParam pageParam = new PageParam();
                pageParam.Offset = requestModel.Start;
                pageParam.Limit = requestModel.Length;
                string Search = requestModel.Search.Value;
                var model = abstractOrderDetailsServices.OrderDetailsByCustomerWeb(pageParam, CustomerId, Search);
                totalRecord = (int)model.TotalRecords;
                filteredRecord = (int)model.TotalRecords;
                return Json(new DataTablesResponse(requestModel.Draw, model.Values, filteredRecord, totalRecord), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new object[] { null }, JsonRequestBehavior.AllowGet);
            }
        }


        //[HttpGet]
        //public ActionResult Manage(string id = "MA==")
        //{
        //    int decryptedId = Convert.ToInt32(ConvertTo.Base64Decode(id));
        //    AbstractStandard objModel = null;
        //    if (decryptedId > 0)
        //    {
        //        objModel = abstractStandardServices.StandardById(decryptedId).Item;
        //    }
        //    return View(objModel);
        //}

        #endregion
    }
}