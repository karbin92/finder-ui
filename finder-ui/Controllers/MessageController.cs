using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static finder_ui.SessionHandler.CustomAuthorization;

namespace finder_ui.Controllers
{
    // [Authorize]
    [CustomAuthorization]
    public class MessagesController : Controller
    {
        MessageServiceReference.Service1Client messageClient = new MessageServiceReference.Service1Client();
        Group3ServiceReference.Service1Client adClient = new Group3ServiceReference.Service1Client();
        public ActionResult Index()
        {
            ViewBag.sessId = Session["UserID"];
            IEnumerable<MessageServiceReference.Messageinfo> messageList = messageClient.GetMessages().ToList();
            ViewBag.Lista = messageList;

            ViewBag.annonsClient = adClient.GetAllServiceData();
            return View();
        }
        [HttpPost]
        public ActionResult Index(MessageServiceReference.AddMessage newMessage)
        {
            MessageServiceReference.Service1Client messageClient = new MessageServiceReference.Service1Client();
            messageClient.AddMessage(newMessage);
            IEnumerable<MessageServiceReference.Messageinfo> messagelist = messageClient.GetMessages().ToList();
            //IEnumerable<MeddelandeServiceReference.Messageinfo> messagelist = messageClient.GetMessages().ToList().Where(m => m.SendingUserId == 1);
            ViewBag.Lista = messagelist;
            return View();
        }
    }
}