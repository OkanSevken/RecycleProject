using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YazilimSinamaProje.Controllers
{
    public class UserController : Controller
    {
        UserManager um = new UserManager(new EfUserDal());
        ArticleManager am = new ArticleManager(new EfArticleDal());
        public ActionResult Index()
        {
            var UserValues = um.GetList();
            return View(UserValues);
        }
        public ActionResult Transfer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Transfer(TransferCarbon transferCarbon)
        {
            var userReceiver = um.GetBySha256(transferCarbon.ReceiverUser);
            var userSender = um.GetBySha256(transferCarbon.SenderUser);

            if (userSender != null && userReceiver != null)
            {
                if (userSender.TotalCarbon > transferCarbon.Amount)
                {
                    userReceiver.TotalCarbon += transferCarbon.Amount;
                    userSender.TotalCarbon -= transferCarbon.Amount;
                    um.UserUpdate(userSender);
                    um.UserUpdate(userReceiver);
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ViewBag.valid = "false";

                    return View();
                }


            }
            else
            {
                ViewBag.haveUser = "false";

                return View();
            }

        }


    }
}