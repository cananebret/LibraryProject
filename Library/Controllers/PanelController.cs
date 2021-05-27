using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Library.Models.Entity;

namespace Library.Controllers
{
    [Authorize]
    public class PanelController : Controller
    {
        // GET: Panel
        LIBRARYEntities db = new LIBRARYEntities();            
        public ActionResult Index()
        {
            var memmail = (string)Session["mail"];
            //var listmem = db.MEMBERs.FirstOrDefault(x => x.MAIL == memmail);
            var listNotice = db.NOTICEs.ToList();
            var memName = db.MEMBERs.Where(m => m.MAIL == memmail).Select(n => n.MEMBER_NAME +" "+ n.MEMBER_SURNAME).FirstOrDefault();
            ViewBag.Name = memName;
            var memSchool = db.MEMBERs.Where(s => s.MAIL == memmail).Select(x => x.SCHOOL).FirstOrDefault();
            ViewBag.School = memSchool;
            var memUserName = db.MEMBERs.Where(u => u.MAIL == memmail).Select(n => n.USER_NAME).FirstOrDefault();
            ViewBag.UserName = memUserName;
            var memTel= db.MEMBERs.Where(u => u.MAIL == memmail).Select(n => n.TEL).FirstOrDefault();
            ViewBag.memTel = memTel;
            var memMail = db.MEMBERs.Where(u => u.MAIL == memmail).Select(n => n.MAIL).FirstOrDefault();
            ViewBag.Mail = memMail;
            var uyeid= db.MEMBERs.Where(u => u.MAIL == memmail).Select(n => n.MEMBER_ID).FirstOrDefault();           
            var bookCount = db.ACTIONs.Where(x => x.MEMBER == uyeid).Count();
            ViewBag.bCount = bookCount;
            var receMesaj = db.MEM_MESSAGE.Where(m => m.RECEIVER == memmail).Count();
            ViewBag.rmesaj = receMesaj;
            var totalNotice = db.NOTICEs.Count();
            ViewBag.Notice = totalNotice;
            return View(listNotice);
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
        public ActionResult MemBookList()
        {
            var memmail = (string)Session["mail"];
            var memid = db.MEMBERs.Where(i => i.MAIL == memmail.ToString()).Select(z => z.MEMBER_ID).FirstOrDefault();
            var listbook = db.ACTIONs.Where(b => b.MEMBER == memid).ToList();
            return View(listbook);
        }
        public ActionResult MEmNotice()
        {
            var NoticeList = db.NOTICEs.ToList();
            return View(NoticeList);
        }
        public ActionResult LogOut() 
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("login", "Account");

        }
        public PartialViewResult PNotice()
        {
            return PartialView();
        }
        public PartialViewResult MemSettings()
        {
            var memmail = (string)Session["mail"];
            var id = db.MEMBERs.Where(x => x.MAIL == memmail).Select(y => y.MEMBER_ID).FirstOrDefault();
            var findId = db.MEMBERs.Find(id);
            return PartialView("MemSettings", findId);
        }

    }
}