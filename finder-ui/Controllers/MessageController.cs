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
            int sessId = Convert.ToInt32(Session["UserId"]);
            IEnumerable<MessageServiceReference.Messageinfo> messageList = messageClient.GetMessages().ToList();
            
            
            //viewbag testa sessionId
            //ViewBag.sessId = Session["UserID"];

            ViewBag.userMedd = messageClient.GetUserMessage(sessId);
            ViewBag.Lista = messageList;
            //ViewBag.annonsClient = adClient.AdvancedSearch(sessId);
            //Group3ServiceReference.Service svar = adClient.GetServiceById(7);
            ViewBag.annonsMessage = adClient.GetServiceById(7);
            
                        return View();
        }

        [HttpPost]
        public ActionResult Index(MessageServiceReference.AddMessage newMessage)
        {
            MessageServiceReference.Service1Client messageClient = new MessageServiceReference.Service1Client();
            int sessId = Convert.ToInt32(Session["UserId"]);
            messageClient.AddMessage(newMessage, sessId);
            IEnumerable<MessageServiceReference.Messageinfo> messagelist = messageClient.GetMessages().ToList();
            ViewBag.Lista = messagelist;
            return RedirectToAction("index","message");
        }
    }
}