using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TidyHome2.UI.Models;
using System.Web.Mvc;
using System.Web.Security;
using TidyHome2.DAL.Entities.Entities;
using TidyHome2.BLL.Service;

namespace TidyHome2.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserService _userService;

        public AccountController()
        {
            _userService = new UserService();
        }
        public ActionResult Login(string returnUrl)
        {
            if (string.IsNullOrWhiteSpace(returnUrl))
            {
                returnUrl = "";
            }
            ViewData.Add("ReturnUrl", returnUrl);
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserAccountAuthorizationModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (_userService.CheckUser(model.Email, model.Password))
                {
                    FormsAuthentication.RedirectFromLoginPage(model.Email, true);
                    if (!string.IsNullOrWhiteSpace(returnUrl))
                        return Redirect(returnUrl);
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else ModelState.AddModelError("Account", "Неправильная пара логин-пароль! Авторизоваться не удалось.");
            }

            return View(model);
        }

        public ActionResult Checkin(string ReturnUrl)
        {
            if (string.IsNullOrWhiteSpace(ReturnUrl))
            {
                ReturnUrl = "";
            }
            ViewData.Add("ReturnUrl", ReturnUrl);
            //ViewData["AllType"] = new ServiceController().GetAllTypeSelectListItem();
            return View();
        }

        [HttpPost]
        public ActionResult Checkin(UserAccountRegistrationModel model, string returnUrl)
        {
           
            if (ModelState.IsValid)
            {
                if (model.Password == model.RepeatPassword && _userService.Checkin((Users)model, model.GetRoles()))
                {
                    if (!model.Employee)
                        FormsAuthentication.RedirectFromLoginPage(model.Email, true);
                    if (!string.IsNullOrWhiteSpace(returnUrl))
                        return Redirect(returnUrl);
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            return View(model);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }



        [ChildActionOnly]
        public ActionResult _UserInfo()
        {
            return PartialView();
        }

        [HttpPost]
        public JsonResult CheckEmail(string email)
        {
            var result = _userService.CheckEmail(email);
            return Json(result);
        }
    }
}