using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using finder_ui.Models;

namespace finder_ui.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login(LoginViewModel vm)
        {
            using (var client = new UserLoginServiceReference.LoginServiceClient())
            {
                //var ExistingUser = new UserLoginServiceReference.Users()
                //{
                //    Password = vm.userPassword,
                //    Username = vm.username,
                //};
                

               if(client.UserLogin(vm.username, vm.userPassword))
                {
                    Session["AuthorizedAsUser"] = "true";
                    var userid = client.GetActiveUsers().FirstOrDefault(x => x.Email == vm.username).ID;
                    Session["UserID"] = userid;
                }
                else
                {
                    Session["AuthorizedAsUser"] = "false";
                    Session["UserID"] = null;
                }
            }

            return View();
        }
    }
}