using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace YazilimSinamaProje.Controllers
{
    public class AccountController : Controller
    {
        UserManager um = new UserManager(new EfUserDal());
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User p)
        {
            Context c = new Context();
            var userinfo = c.Users.FirstOrDefault(x => x.UserName == p.UserName && x.UserPassword==p.UserPassword);
            if (userinfo != null)
            {
                FormsAuthentication.SetAuthCookie(userinfo.UserName,false);
                Session["UserName"] = userinfo.UserName;
                return RedirectToAction("Index", "User");
            }
            else
            {     
                return RedirectToAction("Login");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(User k)
        {
            UserValidator userValidator = new UserValidator();
            ValidationResult results = userValidator.Validate(k);
            if (results.IsValid)
            {
                k.ArticleID = 3;
                
                um.UserAdd(k);
                return RedirectToAction("Login","Account");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}