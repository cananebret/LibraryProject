using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library.Models.Entity;

namespace Library.Controllers
{
    public class NoticeController : Controller
    {
        // GET: Notice
        LIBRARYEntities db = new LIBRARYEntities();
        public ActionResult Index()
        {
            var noticeList = db.NOTICEs.ToList();
            return View(noticeList);
        }
        [HttpGet]
        public ActionResult NoticeAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NoticeAdd(NOTICE n)
        {
            db.NOTICEs.Add(n);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult NoticeDel(int id)
        {
            var ndel = db.NOTICEs.Find(id);
            db.NOTICEs.Remove(ndel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult NoticeFind(NOTICE n)
        {
            var nFind = db.NOTICEs.Find(n.ID);
            return View("NoticeFind", nFind);
        }
        public ActionResult NoticeUpd(NOTICE u)
        {
            var nUpd = db.NOTICEs.Find(u.ID);
            nUpd.NOTICE_CATEGORY = u.NOTICE_CATEGORY;
            nUpd.NOTICE_CONTENT = u.NOTICE_CONTENT;
            nUpd.NOTICE_DATE = u.NOTICE_DATE;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}