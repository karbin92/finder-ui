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

               if(client.UserLogin(vm.username, vm.userPassword) == true)
                {
                    Session["AuthorizedAsUser"] = "true";
                    //var UserInfo = client.GetUserByUserName(vm.username);
                    //Session["UserId"] = UserInfo.Id;
                   
                }
                else
                {

                }
            }

            return View();
        }
    }
}