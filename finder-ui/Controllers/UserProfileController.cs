using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace finder_ui.Controllers
{
    public class UserProfileController : Controller
    {
        // GET: UserProfile
        public ActionResult Index()
        {
            UserProfileServiceReference.UserProfileServiceClient client = new UserProfileServiceReference.UserProfileServiceClient();
             

            return View();
        }
    }
}