using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library.Models.Entity;
namespace Library.Controllers
{
    public class ActionController : Controller
    {
        // GET: Action
        LIBRARYEntities db = new LIBRARYEntities();
        public ActionResult Index() 
        {
            var values = db.ACTIONs.Where(a=>a.IS_STATUS==false).ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult lend()
        {
            List<SelectListItem> memberdop = (from i in db.MEMBERs.ToList()
                                            select new SelectListItem
                                            {
                                                Text = i.MEMBER_NAME+' '+i.MEMBER_SURNAME,
                                                Value = i.MEMBER_ID.ToString()
                                            }).ToList();
            ViewBag.memdrp = memberdop;
            List<SelectListItem> bookdrop = (from i in db.BOOKs.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.BOOK_NAME,
                                                 Value = i.BOOK_ID.ToString()
                                             }).ToList();
            ViewBag.bkdrp = bookdrop;
            List<SelectListItem> staffdrop = (from i in db.PERSONELs.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = i.PERSONEL_NAME,
                                                  Value = i.PERSONEL_ID.ToString()
                                              }).ToList();
            ViewBag.stffdrop = staffdrop;
            return View();
        }
        [HttpPost]
        public ActionResult lend(ACTION a)
        {
            var mem = db.MEMBERs.Where(m => m.MEMBER_ID == a.MEMBER1.MEMBER_ID).FirstOrDefault();
            var book = db.BOOKs.Where(b => b.BOOK_ID == a.BOOK1.BOOK_ID).FirstOrDefault();
            var staff = db.PERSONELs.Where(p => p.PERSONEL_ID == a.PERSONEL.PERSONEL_ID).FirstOrDefault();
            a.MEMBER1 = mem;
            a.BOOK1 = book;
            a.PERSONEL = staff;
            db.ACTIONs.Add(a);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult lendFind(int id)
        {
            var lendF = db.ACTIONs.Find(id);
            DateTime d1 = DateTime.Parse(lendF.RETURN_DATE.ToString());
            DateTime d2 = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            TimeSpan d3 = d2 - d1;
            ViewBag.dgr = d3.TotalDays;
            return View("lendFind", lendF);
        }
        public ActionResult LendUpd(ACTION gb)
        {
            var gback = db.ACTIONs.Find(gb.ACTION_ID);
            gback.MEMBER_RETURN_DATE = gb.MEMBER_RETURN_DATE;
            gback.IS_STATUS = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}