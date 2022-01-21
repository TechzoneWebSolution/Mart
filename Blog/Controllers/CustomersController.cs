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
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Web.Mvc;
using static Blog.Infrastructure.Enums;
namespace Blog.Controllers
{
    public class CustomersController : BaseController
    {
        #region Fields

        private readonly AbstractCustomerServices abstractCustomerServices;
        private readonly AbstractStandardServices abstractStandardServices;
        #endregion

        #region Ctor

        public CustomersController(AbstractCustomerServices abstractCustomerServices, AbstractStandardServices abstractStandardServices)
        {
            this.abstractCustomerServices = abstractCustomerServices;
            this.abstractStandardServices = abstractStandardServices;
        }

        #endregion

        #region Methods
        public ActionResult Index()
        {
            if (TempData["openPopup"] != null)
                ViewBag.openPopup = TempData["openPopup"];
            ViewBag.Standard = BindStandardDropdown();
            ViewBag.Block = BindBlockDropdown();
            ViewBag.Blog = BindBlogDropdown();
            ViewBag.GroupName = BindGroupNameDropdown();
            ViewBag.Type = BindTypeDropdown();
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        [ActionName(Actions.CustomerEdit)]
        public ActionResult CustomerEdit(Customer obj)
        {
            var user = abstractCustomerServices.CustomerUpdateWebSide(obj);
            if (user.Code == 200)
            {
                TempData["openPopup"] = CommonHelper.ShowAlertMessageToastr(MessageType.success.ToString(), user.Message);
            }
            else
            {
                TempData["openPopup"] = CommonHelper.ShowAlertMessageToastr(MessageType.warning.ToString(), user.Message);
            }
            return RedirectToAction(Actions.Index, Pages.Controllers.Customers, new { Area = "" });
        }

        [HttpGet]
        public ActionResult Manage(string id = "MA==")
        {
            int decryptedId = Convert.ToInt32(ConvertTo.Base64Decode(id));
            AbstractCustomer objModel = new Customer();
            if (decryptedId > 0)
            {
                objModel = abstractCustomerServices.CustomerById(decryptedId).Item;
            }
            return View(objModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName(Actions.BindCustomers)]
        public JsonResult BindCustomers([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel, string StartDate = "", string EndDate = "", int StandardId = 0, int IsBlock = 0, int IsBlog = 0, string GroupName = "", string Type = "", string City = "", string ExpiryStartDate = "", string ExpiryEndDate = "", string SchoolName = "")
        {
            try
            {
                int totalRecord = 0;
                int filteredRecord = 0;
                PageParam pageParam = new PageParam();
                pageParam.Offset = requestModel.Start;
                pageParam.Limit = requestModel.Length;
                string Search = requestModel.Search.Value;

                var model = abstractCustomerServices.CustomerSelectAll(pageParam, Search, StartDate, EndDate, StandardId, IsBlock, IsBlog, GroupName, Type, City, ExpiryStartDate, ExpiryEndDate, SchoolName);
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
        [ActionName(Actions.ChangeStatus)]
        public JsonResult ChangeStatus(int Id)
        {
            var result = abstractCustomerServices.CustomerActiveInActive(Id);
            TempData["openPopup"] = CommonHelper.ShowAlertMessageToastr(MessageType.success.ToString(), "Customer Status Change successfully");
            return Json(1, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ActionName(Actions.Delete)]
        public JsonResult Delete(int Id)
        {
            var result = abstractCustomerServices.CustomerDelete(Id);
            TempData["openPopup"] = CommonHelper.ShowAlertMessageToastr(MessageType.success.ToString(), "Customer Delete successfully");
            return Json(1, JsonRequestBehavior.AllowGet);
        }

        public IList<SelectListItem> BindStandardDropdown()
        {
            PageParam pageParam = new PageParam();
            pageParam.Offset = 0;
            pageParam.Limit = 1000;
            var model = abstractStandardServices.StandardSelectAll(pageParam, "");
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var category in model.Values)
            {
                items.Add(new SelectListItem() { Text = category.Name.ToString(), Value = category.Id.ToString() });
            }
            return items;
        }

        public IList<SelectListItem> BindBlockDropdown()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem() { Text = "Block", Value = "1" });
            items.Add(new SelectListItem() { Text = "UnBlock", Value = "2" });
            return items;
        }


        public IList<SelectListItem> BindBlogDropdown()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem() { Text = "Blog Version", Value = "1" });
            items.Add(new SelectListItem() { Text = "Full Version", Value = "2" });
            return items;
        }

        public IList<SelectListItem> BindGroupNameDropdown()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem() { Text = "ગણિત", Value = "ગણિત" });
            items.Add(new SelectListItem() { Text = "જીવવિજ્ઞાન", Value = "જીવવિજ્ઞાન" });
            return items;
        }

        public IList<SelectListItem> BindTypeDropdown()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem() { Text = "Teacher", Value = "Teacher" });
            items.Add(new SelectListItem() { Text = "શિક્ષક", Value = "શિક્ષક" });
            items.Add(new SelectListItem() { Text = "Biology Teacher", Value = "Biology Teacher" });
            items.Add(new SelectListItem() { Text = "Student", Value = "Student" });
            items.Add(new SelectListItem() { Text = "વિદ્યાર્થી", Value = "વિદ્યાર્થી" });
            return items;
        }

        [HttpPost]
        [ActionName(Actions.SendNotification)]
        public JsonResult SendNotification(string Ids, string Message = "",string Title="")
        {
            if(string.IsNullOrEmpty(Message) || string.IsNullOrEmpty(Title))
            {
                return Json(0, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var model = abstractCustomerServices.CustomerSelectAllForNotification(Ids);
                foreach (var item in model.Values)
                {
                    if (item != null && item.DeviceToken != null && item.DeviceToken != "")
                    {
                        Thread.Sleep(1500);
                        string response = string.Empty;
                        string serverKey = Configurations.CustomerServerKey; // Something very long
                        string deviceId = item.DeviceToken;
                        WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                        tRequest.Method = "post";
                        tRequest.ContentType = "application/json";
                        string Subject = Title;
                        if (Subject != null)
                        {
                            Subject = Subject;
                        }
                        else
                        {
                            Subject = "WelCome To Blog";
                        }
                        string json = string.Empty;
                        dynamic data = null;
                        //json = "{\"to\":\"" + deviceId + "\",\"data\":{\"message\":\"" + Message + "\",\"title\":\"" + Subject + "\",},\"priority\":\"high\"}";
                        json = "{\"to\":\"" + deviceId + "\",\"data\":{\"body\":\"" + Message + "\",\"title\":\"" + Subject + "\",},\"priority\":\"high\"}";
                        //else
                        //{
                        //    json = "{\"to\":\"" + deviceId + "\",\"notification\":{\"body\":\"" + Subject + "\",\"title\":\"" + item.NotificationText + "\",\"mutable_content\":true},\"mutable-content\":true," + item.IosPayload + "}";
                        //}
                        //var json = serializer.Serialize(data);
                        byte[] byteArray = Encoding.UTF8.GetBytes(json);
                        tRequest.Headers.Add(string.Format("Authorization: key={0}", serverKey));
                        tRequest.ContentLength = byteArray.Length;
                        using (Stream dataStream = tRequest.GetRequestStream())
                        {
                            dataStream.Write(byteArray, 0, byteArray.Length);
                            using (WebResponse tResponse = tRequest.GetResponse())
                            {
                                using (Stream dataStreamResponse = tResponse.GetResponseStream())
                                {
                                    using (StreamReader tReader = new StreamReader(dataStreamResponse))
                                    {
                                        string sResponseFromServer = tReader.ReadToEnd();
                                        response = sResponseFromServer;
                                    }
                                }
                            }
                        }
                    }

                }
            }
          
            return Json(1, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ActionName(Actions.SendNotificationForAllCustomer)]
        public JsonResult SendNotificationForAllCustomer(string StartDate = "", string EndDate = "", int StandardId = 0, int IsBlock = 0, int IsBlog = 0, string GroupName = "", string Type = "", string City = "", string ExpiryStartDate = "", string ExpiryEndDate = "", string SchoolName = "", string Message = "",string Title="")
        {
            PageParam pageParam = new PageParam();
            pageParam.Offset = 0;
            pageParam.Limit = 100000;
            var model = abstractCustomerServices.CustomerSelectAll(pageParam, "", StartDate, EndDate, StandardId, IsBlock, IsBlog, GroupName, Type, City, ExpiryStartDate, ExpiryEndDate, SchoolName);
            foreach (var item in model.Values)
            {
                if (item != null && item.DeviceToken != null && item.DeviceToken != "")
                {
                    Thread.Sleep(1500);
                    string response = string.Empty;
                    string serverKey = Configurations.CustomerServerKey; // Something very long
                    string deviceId = item.DeviceToken;
                    WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                    tRequest.Method = "post";
                    tRequest.ContentType = "application/json";
                    string Subject = Title;
                    if (Subject != null)
                    {
                        Subject = Subject;
                    }
                    else
                    {
                        Subject = "WelCome To Blog";
                    }
                    string json = string.Empty;
                    dynamic data = null;
                    //json = "{\"to\":\"" + deviceId + "\",\"data\":{\"message\":\"" + Message + "\",\"title\":\"" + Subject + "\",},\"priority\":\"high\"}";
                    json = "{\"to\":\"" + deviceId + "\",\"data\":{\"body\":\"" + Message + "\",\"title\":\"" + Subject + "\",},\"priority\":\"high\"}";
                    byte[] byteArray = Encoding.UTF8.GetBytes(json);
                    tRequest.Headers.Add(string.Format("Authorization: key={0}", serverKey));
                    tRequest.ContentLength = byteArray.Length;
                    using (Stream dataStream = tRequest.GetRequestStream())
                    {
                        dataStream.Write(byteArray, 0, byteArray.Length);
                        using (WebResponse tResponse = tRequest.GetResponse())
                        {
                            using (Stream dataStreamResponse = tResponse.GetResponseStream())
                            {
                                using (StreamReader tReader = new StreamReader(dataStreamResponse))
                                {
                                    string sResponseFromServer = tReader.ReadToEnd();
                                    response = sResponseFromServer;
                                }
                            }
                        }
                    }
                }

            }
            return Json(1, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}
