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
        public ActionResult EditProfile(EditProfileViewModel vm)
        {
            var UpdateProfile = new EditProfileViewModel();
            return View(UpdateProfile);
        }
        public ActionResult UpdateAccountInformation(EditProfileViewModel vm)
        {
            using (var client = new UserProfileServiceReference.UserProfileServiceClient())
            {
                var updateUser = new UserProfileServiceReference.User()
                {
                    Address = vm.userAddress,
                    City = vm.userCity,
                    Email = vm.userEmail,
                    Phonenumber = vm.userPhoneNumber,
                    Picture = vm.userProfilePicture,
                    ZipCode = vm.userZipCode,
                    Id = vm.id,

                };

                var user = client.UpdateUser(updateUser);
            }

            return View("Index");

        }
    }
}