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
    public class SubScriptionController : BaseController
    {
        #region Fields

        private readonly AbstractSubScriptionServices abstractSubScriptionServices;
        private readonly AbstractSubjectServices abstractSubjectServices;
        #endregion

        #region Ctor

        public SubScriptionController(AbstractSubScriptionServices abstractSubScriptionServices, AbstractSubjectServices abstractSubjectServices)
        {
            this.abstractSubScriptionServices = abstractSubScriptionServices;
            this.abstractSubjectServices = abstractSubjectServices;
           
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
        public ActionResult Manage(string id = "MA==")
        {
            int decryptedId = Convert.ToInt32(ConvertTo.Base64Decode(id));
            ViewBag.Subject = BindSubject();
            AbstractSubScription objModel = new SubScription();
            if (decryptedId > 0)
            {
                objModel = abstractSubScriptionServices.SubScriptionById(decryptedId).Item;
            }
            return View(objModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName(Actions.BindSubScription)]
        public JsonResult BindSubScription([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel)
        {
            try
            {
                int totalRecord = 0;
                int filteredRecord = 0;
                PageParam pageParam = new PageParam();
                pageParam.Offset = requestModel.Start;
                pageParam.Limit = requestModel.Length;
                string Search = requestModel.Search.Value;

                var model = abstractSubScriptionServices.SubscriptionSelectAll(pageParam, Search);
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
        [ActionName(Actions.SubScriptionAddEdit)]
        public ActionResult SubScriptionAddEdit(SubScription subScription)
        {
            var user = abstractSubScriptionServices.SubScriptionUpsert(subScription);
            if (user.Code == 200)
            {
                TempData["openPopup"] = CommonHelper.ShowAlertMessageToastr(MessageType.success.ToString(), user.Message);
            }
            else
            {
                TempData["openPopup"] = CommonHelper.ShowAlertMessageToastr(MessageType.warning.ToString(), user.Message);
            }

            return RedirectToAction(Actions.Index, Pages.Controllers.SubScription, new { Area = "" });
        }

        public IList<SelectListItem> BindSubject()
        {
            var model = abstractSubjectServices.SubjectSelectAllForDropdown();

            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var category in model.Values)
            {
                if (!string.IsNullOrEmpty(category.Name))
                {
                    items.Add(new SelectListItem() { Text = (category.Name.ToString()), Value = category.Id.ToString() });
                }
            }
            return items;
        }


        #endregion
    }
}
