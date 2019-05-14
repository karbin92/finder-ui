using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using finder_ui.Models;

namespace finder_ui.Controllers
{
    public class AccountController : Controller
    {

        

        // GET: CreateAccount
        public ActionResult Index()
        {
            var CreateAccount = new CreateAccountViewModel();
            return View(CreateAccount);
        }

        public ActionResult UpdateProfile(UpdateProfileViewModel vm)
        {
            var UpdateProfile = new UpdateProfileViewModel();
            return View(UpdateProfile);
        }
        public ActionResult CreateAccount(CreateAccountViewModel vm)
        {
            using( var client = new UserProfileServiceReference.UserProfileServiceClient())
            {
                var newUser = new UserProfileServiceReference.NewUser()
                {
                    Email = vm.email,
                    FirstName = vm.firstname,
                    Surname = vm.surname,
                    Password = vm.password,
                    Username = vm.username,
                };

                var user = client.CreateUser(newUser);
            }

            return View("UpdateProfile");
            
        }

        public ActionResult UpdateAccountInformation(UpdateProfileViewModel vm)
        {
            using (var client = new UserProfileServiceReference.UserProfileServiceClient())
            {
                var updateUser = new UserProfileServiceReference.User()
                {
                    Address = vm.userAddress,
                    City = vm.userCity,
                    PersonalCodeNumber = vm.personalnumber,
                    Phonenumber = vm.userPhoneNumber,
                    Picture = vm.userProfilePicture,
                    ZipCode = vm.userZipCode,
                    Id = vm.id,
                    
                };

                var user = client.UpdateUser(updateUser);
            }

            return View("UpdateProfile");

        }

    }
}