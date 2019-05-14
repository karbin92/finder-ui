using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using finder_ui.Models;

namespace finder_ui.Controllers
{
    public class UserProfileController : Controller
    {
        // GET: UserProfile
        public ActionResult Index()
        {
            using (var client = new UserProfileServiceReference.UserProfileServiceClient())
            {
                var User = client.GetUserByUserName("Clark");
                
            }
                

            return View();
        }
        public ActionResult EditProfile()
        {
            return View();
        }
    }
}