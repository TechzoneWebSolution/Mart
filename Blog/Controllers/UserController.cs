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
    public class UserController : BaseController
    {
        #region Fields

        private readonly AbstractUserServices abstractUserServices;
        private readonly AbstractStateServices abstractStateServices;
        private readonly AbstractDistrictServices abstractDistrictServices;
        #endregion

        #region Ctor

        public UserController(AbstractUserServices abstractUserServices, AbstractStateServices abstractStateServices
            , AbstractDistrictServices abstractDistrictServices)
        {
            this.abstractUserServices = abstractUserServices;
            this.abstractStateServices = abstractStateServices;
            this.abstractDistrictServices = abstractDistrictServices;
        }

        #endregion

        #region Methods
        public ActionResult Profile()
        {
            if (TempData["openPopup"] != null)
                ViewBag.openPopup = TempData["openPopup"];
            
            AbstractUser objModel = new User();
            if (ProjectSession.UserID > 0)
            {
                objModel = abstractUserServices.UserById(ProjectSession.UserID).Item;
                ViewBag.State = BindStateDropdown();
                ViewBag.District = BindDistrictDropdown(objModel.StateId);
            }
            else
            {
                ViewBag.State = BindStateDropdown();
                ViewBag.District = BindDistrictDropdown(0);
            }
            return View(objModel);
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        [ActionName(Actions.UserEdit)]
        public ActionResult UserEdit(User obj)
        {
            var user = abstractUserServices.InsertUpdateUsers(obj);
            if (user.Code == 200)
            {
                TempData["openPopup"] = CommonHelper.ShowAlertMessageToastr(MessageType.success.ToString(), "Profile updated successfully !!");
            }
            else
            {
                TempData["openPopup"] = CommonHelper.ShowAlertMessageToastr(MessageType.warning.ToString(), user.Message);
            }
            return RedirectToAction(Actions.Index, Pages.Controllers.Dashboard, new { Area = "" });
        }
        [HttpPost]
        [ActionName(Actions.Search1)]
        public JsonResult Search1(string StateId)
        {
            try
            {
                return Json(new object[] { Enums.MessageType.success.GetHashCode(), Enums.MessageType.success.ToString(), BindDistrictDropdown(Convert.ToInt32(ConvertTo.Base64Decode(StateId))) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new object[] { Enums.MessageType.danger.GetHashCode(), Enums.MessageType.danger.ToString(), "Something went wrong Please contact administrator !" }, JsonRequestBehavior.AllowGet);
            }
        }

        public IList<SelectListItem> BindStateDropdown()
        {
            var model = abstractStateServices.StateSelectAllForDropdown();
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var category in model.Values)
            {
                items.Add(new SelectListItem() { Text = category.Name.ToString(), Value = category.Id.ToString() });
            }
            return items;
        }

        public IList<SelectListItem> BindDistrictDropdown(int StateId)
        {
            var model = abstractDistrictServices.DistrictSelectAllForDropdown(StateId);
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var category in model.Values)
            {
                items.Add(new SelectListItem() { Text = category.Name.ToString(), Value = category.Id.ToString() });
            }
            return items;
        }

        //[HttpGet]
        //public ActionResult Manage(string id = "MA==")
        //{
        //    int decryptedId = Convert.ToInt32(ConvertTo.Base64Decode(id));
        //    AbstractUser objModel = new User();
        //    if (decryptedId > 0)
        //    {
        //        objModel = abstractUserServices.CustomerById(decryptedId).Item;
        //    }
        //    return View(objModel);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[ActionName(Actions.BindCustomers)]
        //public JsonResult BindCustomers([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel, string StartDate = "", string EndDate = "", int StandardId = 0, int IsBlock = 0, int IsBlog = 0, string GroupName = "", string Type = "", string City = "", string ExpiryStartDate = "", string ExpiryEndDate = "", string SchoolName = "")
        //{
        //    try
        //    {
        //        int totalRecord = 0;
        //        int filteredRecord = 0;
        //        PageParam pageParam = new PageParam();
        //        pageParam.Offset = requestModel.Start;
        //        pageParam.Limit = requestModel.Length;
        //        string Search = requestModel.Search.Value;

        //        var model = abstractCustomerServices.CustomerSelectAll(pageParam, Search, StartDate, EndDate, StandardId, IsBlock, IsBlog, GroupName, Type, City, ExpiryStartDate, ExpiryEndDate, SchoolName);
        //        totalRecord = (int)model.TotalRecords;
        //        filteredRecord = (int)model.TotalRecords;
        //        return Json(new DataTablesResponse(requestModel.Draw, model.Values, filteredRecord, totalRecord), JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new object[] { null }, JsonRequestBehavior.AllowGet);
        //    }
        //}

        //[HttpPost]
        //[ActionName(Actions.ChangeStatus)]
        //public JsonResult ChangeStatus(int Id)
        //{
        //    var result = abstractUserServices.CustomerActiveInActive(Id);
        //    TempData["openPopup"] = CommonHelper.ShowAlertMessageToastr(MessageType.success.ToString(), "Customer Status Change successfully");
        //    return Json(1, JsonRequestBehavior.AllowGet);
        //}

        //[HttpPost]
        //[ActionName(Actions.Delete)]
        //public JsonResult Delete(int Id)
        //{
        //    var result = abstractUserServices.CustomerDelete(Id);
        //    TempData["openPopup"] = CommonHelper.ShowAlertMessageToastr(MessageType.success.ToString(), "Customer Delete successfully");
        //    return Json(1, JsonRequestBehavior.AllowGet);
        //}

        //[HttpPost]
        //[ActionName(Actions.SendNotification)]
        //public JsonResult SendNotification(string Ids, string Message = "",string Title="")
        //{
        //    if(string.IsNullOrEmpty(Message) || string.IsNullOrEmpty(Title))
        //    {
        //        return Json(0, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        var model = abstractCustomerServices.CustomerSelectAllForNotification(Ids);
        //        foreach (var item in model.Values)
        //        {
        //            if (item != null && item.DeviceToken != null && item.DeviceToken != "")
        //            {
        //                Thread.Sleep(1500);
        //                string response = string.Empty;
        //                string serverKey = Configurations.CustomerServerKey; // Something very long
        //                string deviceId = item.DeviceToken;
        //                WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
        //                tRequest.Method = "post";
        //                tRequest.ContentType = "application/json";
        //                string Subject = Title;
        //                if (Subject != null)
        //                {
        //                    Subject = Subject;
        //                }
        //                else
        //                {
        //                    Subject = "WelCome To Blog";
        //                }
        //                string json = string.Empty;
        //                dynamic data = null;
        //                //json = "{\"to\":\"" + deviceId + "\",\"data\":{\"message\":\"" + Message + "\",\"title\":\"" + Subject + "\",},\"priority\":\"high\"}";
        //                json = "{\"to\":\"" + deviceId + "\",\"data\":{\"body\":\"" + Message + "\",\"title\":\"" + Subject + "\",},\"priority\":\"high\"}";
        //                //else
        //                //{
        //                //    json = "{\"to\":\"" + deviceId + "\",\"notification\":{\"body\":\"" + Subject + "\",\"title\":\"" + item.NotificationText + "\",\"mutable_content\":true},\"mutable-content\":true," + item.IosPayload + "}";
        //                //}
        //                //var json = serializer.Serialize(data);
        //                byte[] byteArray = Encoding.UTF8.GetBytes(json);
        //                tRequest.Headers.Add(string.Format("Authorization: key={0}", serverKey));
        //                tRequest.ContentLength = byteArray.Length;
        //                using (Stream dataStream = tRequest.GetRequestStream())
        //                {
        //                    dataStream.Write(byteArray, 0, byteArray.Length);
        //                    using (WebResponse tResponse = tRequest.GetResponse())
        //                    {
        //                        using (Stream dataStreamResponse = tResponse.GetResponseStream())
        //                        {
        //                            using (StreamReader tReader = new StreamReader(dataStreamResponse))
        //                            {
        //                                string sResponseFromServer = tReader.ReadToEnd();
        //                                response = sResponseFromServer;
        //                            }
        //                        }
        //                    }
        //                }
        //            }

        //        }
        //    }

        //    return Json(1, JsonRequestBehavior.AllowGet);
        //}

        //[HttpPost]
        //[ActionName(Actions.SendNotificationForAllCustomer)]
        //public JsonResult SendNotificationForAllCustomer(string StartDate = "", string EndDate = "", int StandardId = 0, int IsBlock = 0, int IsBlog = 0, string GroupName = "", string Type = "", string City = "", string ExpiryStartDate = "", string ExpiryEndDate = "", string SchoolName = "", string Message = "",string Title="")
        //{
        //    PageParam pageParam = new PageParam();
        //    pageParam.Offset = 0;
        //    pageParam.Limit = 100000;
        //    var model = abstractCustomerServices.CustomerSelectAll(pageParam, "", StartDate, EndDate, StandardId, IsBlock, IsBlog, GroupName, Type, City, ExpiryStartDate, ExpiryEndDate, SchoolName);
        //    foreach (var item in model.Values)
        //    {
        //        if (item != null && item.DeviceToken != null && item.DeviceToken != "")
        //        {
        //            Thread.Sleep(1500);
        //            string response = string.Empty;
        //            string serverKey = Configurations.CustomerServerKey; // Something very long
        //            string deviceId = item.DeviceToken;
        //            WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
        //            tRequest.Method = "post";
        //            tRequest.ContentType = "application/json";
        //            string Subject = Title;
        //            if (Subject != null)
        //            {
        //                Subject = Subject;
        //            }
        //            else
        //            {
        //                Subject = "WelCome To Blog";
        //            }
        //            string json = string.Empty;
        //            dynamic data = null;
        //            //json = "{\"to\":\"" + deviceId + "\",\"data\":{\"message\":\"" + Message + "\",\"title\":\"" + Subject + "\",},\"priority\":\"high\"}";
        //            json = "{\"to\":\"" + deviceId + "\",\"data\":{\"body\":\"" + Message + "\",\"title\":\"" + Subject + "\",},\"priority\":\"high\"}";
        //            byte[] byteArray = Encoding.UTF8.GetBytes(json);
        //            tRequest.Headers.Add(string.Format("Authorization: key={0}", serverKey));
        //            tRequest.ContentLength = byteArray.Length;
        //            using (Stream dataStream = tRequest.GetRequestStream())
        //            {
        //                dataStream.Write(byteArray, 0, byteArray.Length);
        //                using (WebResponse tResponse = tRequest.GetResponse())
        //                {
        //                    using (Stream dataStreamResponse = tResponse.GetResponseStream())
        //                    {
        //                        using (StreamReader tReader = new StreamReader(dataStreamResponse))
        //                        {
        //                            string sResponseFromServer = tReader.ReadToEnd();
        //                            response = sResponseFromServer;
        //                        }
        //                    }
        //                }
        //            }
        //        }

        //    }
        //    return Json(1, JsonRequestBehavior.AllowGet);
        //}

        #endregion
    }
}
