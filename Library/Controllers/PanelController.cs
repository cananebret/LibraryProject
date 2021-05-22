using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library.Models.Entity;

namespace Library.Controllers
{
    public class PanelController : Controller
    {
        // GET: Panel
        LIBRARYEntities db = new LIBRARYEntities();      
        [Authorize]
        public ActionResult Index()
        {
            var memmail = (string)Session["mail"];
            var listmem = db.MEMBERs.FirstOrDefault(x => x.MAIL == memmail);
            return View(listmem);
        }
        [HttpPost]
        public ActionResult Index2(MEMBER m)
        {
            var user = (string)Session["mail"];
            var member = db.MEMBERs.FirstOrDefault(x => x.MAIL == user);
            member.PASSWORD = m.PASSWORD;
            member.MEMBER_NAME = m.MEMBER_NAME;
            member.MEMBER_SURNAME = m.MEMBER_SURNAME;
            member.PASSWORD = m.PASSWORD;
            member.TEL = m.TEL;
            member.SCHOOL = m.SCHOOL;
            member.USER_NAME = m.USER_NAME;
            member.FOTO = m.FOTO;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MemBook()
        {
            var memmail = (string)Session["mail"];
            var memid = db.MEMBERs.Where(i => i.MAIL == memmail.ToString()).Select(z => z.MEMBER_ID).FirstOrDefault();
            var listbook = db.ACTIONs.Where(b => b.MEMBER== memid).ToList();
            return View(listbook);
        }

    }
}