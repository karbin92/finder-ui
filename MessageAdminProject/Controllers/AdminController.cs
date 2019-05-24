using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MessageAdminProject.Controllers
{
    //Test
    
    [SessionFilter.AuthorizeAdmin]
    public class AdminController : Controller
    {
        MeddelandeServiceReference.Service1Client messageClient = new MeddelandeServiceReference.Service1Client();
        public ActionResult Index()
        {
            IEnumerable<MeddelandeServiceReference.Messageinfo> messageList = messageClient.GetMessages().ToList();
            ViewBag.Lista = messageList;
            return View();
        }

        public ActionResult DeleteMessage(int Id)
        {
            messageClient.DeleteMessage(Id);
            IEnumerable<MeddelandeServiceReference.Messageinfo> messagelist = messageClient.GetMessages().ToList();
            ViewBag.Lista = messagelist;
            return RedirectToAction("Index", "Admin");//skickar användaren tillbaka till listan över meddelanden
        }
    }
}