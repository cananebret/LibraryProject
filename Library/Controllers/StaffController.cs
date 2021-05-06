using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library.Models.Entity;

namespace Library.Controllers
{
    public class StaffController : Controller
    {
        // GET: Staff
        LIBRARYEntities db = new LIBRARYEntities();
        public ActionResult Index()
        {
            var staff = db.PERSONELs.ToList();
            return View(staff);
        }
        [HttpGet]
        public ActionResult staffAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult staffAdd(PERSONEL p)
        { 
            if(!ModelState.IsValid)
            {
                return View("staffAdd");
            }
            var staffa = db.PERSONELs.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult staffDel(int id)
        {
            var staffd = db.PERSONELs.Find(id);
            db.PERSONELs.Remove(staffd);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult staffFind(int id)
        {
            var stafff = db.PERSONELs.Find(id);
            return View("staffFind", stafff);
        }
        public ActionResult staffUpd(PERSONEL p)
        {
            var staffU = db.PERSONELs.Find(p.PERSONEL_ID);
            staffU.PERSONEL_NAME = p.PERSONEL_NAME;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}