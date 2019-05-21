using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static finder_ui.SessionHandler.CustomAuthorization;

namespace finder_ui.Controllers
{
    //[Authorize]
    [CustomAuthorization]
    public class MessageController : Controller
    {
        MessageServiceReference.Service1Client messageClient = new MessageServiceReference.Service1Client();
        Group3ServiceReference.Service1Client adClient = new Group3ServiceReference.Service1Client();

        public ActionResult Index()
        {


            IEnumerable<MessageServiceReference.Messageinfo> messageList = messageClient.GetMessages().ToList();

            int sessId = Convert.ToInt32(Session["UserId"]);
            //viewbag testa sessionId
            ViewBag.sessId = Session["UserID"];

            //viewbag messagelist och annonsclient måste visas på båda metoderna för att visas upp i samma vy
            ViewBag.userMedd = messageClient.GetUserMessage(sessId);
            ViewBag.Lista = messageList;
            ViewBag.annonsClient = adClient.GetAllServiceData();
            ViewBag.annonsMessage = adClient.GetServiceById(7);
            return View();
        }

        [HttpPost]
        public ActionResult Index(MessageServiceReference.AddMessage newMessage)
        {
            //viewbag messagelist och annonsclient måste visas på båda metoderna för att visas upp i samma vy
            MessageServiceReference.Service1Client messageClient = new MessageServiceReference.Service1Client();
            int sessId = Convert.ToInt32(Session["UserId"]);
            messageClient.AddMessage(newMessage, sessId);
            IEnumerable<MessageServiceReference.Messageinfo> messagelist = messageClient.GetMessages().ToList();
            //IEnumerable<MeddelandeServiceReference.Messageinfo> messagelist = messageClient.GetMessages().ToList().Where(m => m.SendingUserId == 1);
            ViewBag.Lista = messagelist;
            ViewBag.annonsClient = adClient.GetAllServiceData();
            return RedirectToAction("index","message");
        }
    }
}