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
    public class AccountController : Controller
    {
        #region Fields
        private readonly AbstractUserServices usersService;
        private readonly AbstractStateServices abstractStateServices;
        private readonly AbstractDistrictServices abstractDistrictServices;
        //private readonly AbstractOrganizationsServices abstractOrganizationsServices;
        #endregion

        #region Ctor
        public AccountController(AbstractUserServices usersService, AbstractStateServices abstractStateServices
            , AbstractDistrictServices abstractDistrictServices)
        {
            this.usersService = usersService;
            this.abstractStateServices = abstractStateServices;
            this.abstractDistrictServices = abstractDistrictServices;
        }
        #endregion

        #region Methods
        [HttpGet]
        [ActionName(Actions.LogIn)]
        public ActionResult LogIn()
        {
            if (TempData["openPopup"] != null)
                ViewBag.openPopup = TempData["openPopup"];
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName(Actions.LogIn)]
        public ActionResult LogIn(User objmodel)
        {
            SuccessResult<AbstractUser> userData = usersService.Login(objmodel.Email, objmodel.Password);
            if (userData != null && userData.Code == 200 && userData.Item != null)
            {
                Session.Clear();
                ProjectSession.UserID = userData.Item.Id;
                ProjectSession.UserName = userData.Item.FirstName + " " + userData.Item.LastName;
                ProjectSession.UserType = userData.Item.UserType;
                HttpCookie cookie = new HttpCookie("UserLogin");
                cookie.Values.Add("Id", objmodel.Id.ToString());
                cookie.Expires = DateTime.Now.AddHours(5);
                Response.Cookies.Add(cookie);
                return RedirectToAction(Actions.Index, Pages.Controllers.Dashboard, new { Area = "" });
            }
            else
            {
                ViewBag.openPopup = CommonHelper.ShowAlertMessageToastr(MessageType.danger.ToString(), userData.Message);
            }
            return View();
        }

        [HttpGet]
        [ActionName(Actions.Register)]
        public ActionResult Register()
        {
            if (TempData["openPopup"] != null)
                ViewBag.openPopup = TempData["openPopup"];
            ViewBag.State = BindStateDropdown();
            ViewBag.District = BindDistrictDropdown(0);
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName(Actions.Register)]
        public ActionResult Register(User objmodel)
        {
            objmodel.IsActive = true;
            objmodel.UserType = 2;
            SuccessResult<AbstractUser> userData = usersService.InsertUpdateUsers(objmodel);
            if (userData != null && userData.Code == 200 && userData.Item != null)
            {
                Session.Clear();
                ProjectSession.UserID = userData.Item.Id;
                ProjectSession.UserName = userData.Item.FirstName + " " + userData.Item.LastName;
                ProjectSession.UserType = userData.Item.UserType;
                HttpCookie cookie = new HttpCookie("UserLogin");
                cookie.Values.Add("Id", objmodel.Id.ToString());
                cookie.Expires = DateTime.Now.AddHours(5);
                Response.Cookies.Add(cookie);
                return RedirectToAction(Actions.Index, Pages.Controllers.Dashboard, new { Area = "" });
            }
            else
            {
                ViewBag.openPopup = CommonHelper.ShowAlertMessageToastr(MessageType.danger.ToString(), userData.Message);
                ViewBag.State = BindStateDropdown();
                ViewBag.District = BindDistrictDropdown(objmodel.StateId);
            }
            return PartialView("Register");
        }

        [AllowAnonymous]
        [ActionName(Actions.Logout)]
        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            return RedirectToAction(Actions.LogIn, Pages.Controllers.Account, new { Area = "" });
        }

        [HttpGet]
        [ActionName(Actions.ResetPSW)]
        public ActionResult ResetPSW(string Id = null)
        {
            if (TempData["openPopup"] != null)
                ViewBag.openPopup = TempData["openPopup"];
            ViewBag.userid = ConvertTo.Base64Decode(Id);
            ViewBag.userid = 9;
            return View();
        }

        [HttpGet]
        [ActionName(Actions.Success)]
        public ActionResult Success()
        {
            if (TempData["openPopup"] != null)
                ViewBag.openPopup = TempData["openPopup"];
            return View();
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
        #endregion
    }
}