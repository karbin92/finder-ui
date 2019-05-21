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

           //konvertera sessionid från objekt till int
            int sessId = Convert.ToInt32(Session["UserId"]);
            IEnumerable<MessageServiceReference.Messageinfo> messageList = messageClient.GetMessages().ToList();
            ViewBag.Lista = messageList;

            //viewbag testa sessionId
            ViewBag.sessId = Session["UserID"];
            ViewBag.userMedd = messageClient.GetUserMessage(sessId);

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