using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YazilimSinamaProje.Controllers
{
    public class ArticleController : Controller
    {
        ArticleManager am = new ArticleManager(new EfArticleDal());
        UserManager um = new UserManager(new EfUserDal());

        [Authorize]
        public ActionResult Index()
        {
            var articlevalues = am.GetList();
            return View(articlevalues);
            
        }

        [HttpGet]
        public ActionResult AddArticle(int id)
        {
            TempData["UserId"] = id;
            return View();
        }


        [HttpPost]
        public ActionResult AddArticle(Article p)
        {
            
            ArticleValidator articleValidator = new ArticleValidator();
            ValidationResult results = articleValidator.Validate(p);
            if (results.IsValid)
            {
                am.ArticleAdd(p);
                var user =um.GetByID((int)TempData["UserId"]);
                user.TotalCarbon += p.Carbon;
                um.UserUpdate(user);
                return RedirectToAction("Index");
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

        public ActionResult DeleteArticle(int id)
        {
            var articlevalue = am.GetByID(id);
            am.ArticleDelete(articlevalue);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditArticle(int id)
        {
            var articlevalue = am.GetByID(id);
            return View(articlevalue);
        }

        [HttpPost]
        public ActionResult EditArticle(Article p)
        {
            am.ArticleUpdate(p);
            return RedirectToAction("Index");
        }

    }
}