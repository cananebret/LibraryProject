using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library.Models.Entity;
using Library.Models.Classes;
namespace Library.Controllers
{
    public class ShowcaseController : Controller
    {
        // GET: Showcas
        LIBRARYEntities db = new LIBRARYEntities();
        [HttpGet]
        public ActionResult Index()
        {
            Class1 clss = new Class1();
            clss.about = db.ABOUT_US.Where(a => a.IS_STATUS == true).ToList();            
            clss.book = db.BOOKs.ToList();
            //var values = db.BOOKs.ToList();
            return View(clss);
        }
        [HttpPost]
        public ActionResult Index(CONTACT c)
        {
            db.CONTACTs.Add(c);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}