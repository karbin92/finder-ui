using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MessageAdminProject.Models;

namespace MessageAdminProject.Controllers
{   
    public class HomeController : Controller
    {
        public ActionResult LogInAdmin()
        {
            if (Session["AdminIsLoggedIn"] != null)
            {
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return View();
            }
        }
            [HttpPost]
        public ActionResult LogInAdmin(LogInClass model)
        {
            AdminLogInServiceReference.LoginServiceClient client = new AdminLogInServiceReference.LoginServiceClient();
            bool UserOk = client.AdminLogin(model.adminUserame, model.adminPassword);
            if (UserOk == true)
            {
                Session["AdminIsLoggedIn"] = true;
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                ViewBag.error = "Fel inloggningsuppgifter :/";
            }
            return View();
        }
        public ActionResult SignOut()
        {
            Session["AdminIsLoggedIn"] = null;
            
            return RedirectToAction("LogInAdmin", "Home");
        }
    }
}