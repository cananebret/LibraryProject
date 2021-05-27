using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library.Models.Entity;
using PagedList;
using PagedList.Mvc;
namespace Library.Controllers
{
    public class MemberController : Controller
    {
        // GET: Member
        LIBRARYEntities db = new LIBRARYEntities();
        public ActionResult Index(int page=1)
        {
            var members = db.MEMBERs.ToList().ToPagedList(page,2);
            return View(members);
        }
        [HttpGet]
        public ActionResult memberAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult memberAdd(MEMBER m)
        {
            if (!ModelState.IsValid)
            {
                return View("memberAdd");
            }
            db.MEMBERs.Add(m);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult memberDel(int id)
        {
            var memdel = db.MEMBERs.Find(id);
            db.MEMBERs.Remove(memdel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult memberFind(int id)
        {
            var memF = db.MEMBERs.Find(id);
            return View("memberFind", memF);
        }
        public ActionResult memberUpd(MEMBER m)
        {
            var memU = db.MEMBERs.Find(m.MEMBER_ID);
            memU.MEMBER_NAME = m.MEMBER_NAME;
            memU.MEMBER_SURNAME = m.MEMBER_SURNAME;
            memU.MAIL = m.MAIL;
            memU.PASSWORD = m.PASSWORD;
            memU.USER_NAME = m.USER_NAME;
            memU.TEL = m.TEL;
            memU.SCHOOL = m.SCHOOL;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult memberBook(int id)
        {
            var membook = db.ACTIONs.Where(m => m.MEMBER == id).ToList();
            var memName = db.MEMBERs.Where(n => n.MEMBER_ID == id).Select(x => x.MEMBER_NAME + " " + x.MEMBER_SURNAME).FirstOrDefault();
            ViewBag.mName = memName;
            return View(membook);


        }
    }
}