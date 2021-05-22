using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library.Models.Entity;

namespace Library.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        LIBRARYEntities db = new LIBRARYEntities();
        public ActionResult Index()
        {
            var mem_mail = (string)Session["mail"].ToString();
            var list_message = db.MEM_MESSAGE.Where(x=>x.RECEIVER== mem_mail.ToString()).ToList();
            return View(list_message);
        }
        public ActionResult Sending()
        {
            var mem_mail = (string)Session["mail"].ToString();
            var list_message = db.MEM_MESSAGE.Where(x => x.SENDER == mem_mail.ToString()).ToList();
            return View(list_message);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(MEM_MESSAGE m)
        {
            var mem_mail = (string)Session["mail"].ToString();
            m.SENDER = mem_mail.ToString();
            m.MESSAGE_DATE = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.MEM_MESSAGE.Add(m);
            db.SaveChanges();
            return RedirectToAction("Sending", "Message");    
        }

    }
}