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
            return View();
        }
        [HttpPost]
        public ActionResult lend(ACTION a)
        {
            db.ACTIONs.Add(a);
            db.SaveChanges();
            return View();
        }
        public ActionResult lendFind(int id)
        {
            var lendF = db.ACTIONs.Find(id);
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