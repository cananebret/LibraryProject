using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Library.Models.Entity;

namespace Library.Controllers
{
    public class StatisticsController : Controller
    {
        // GET: Statistics
        LIBRARYEntities db = new LIBRARYEntities();
        public ActionResult Index()
        {
            var mem = db.MEMBERs.Count();
            var book = db.BOOKs.Count();
            var lendBook = db.BOOKs.Where(b => b.IS_STATUS == false).Count();
            var money = db.PUNISHMENTs.Sum(m => m.MONEY);
            ViewBag.moneySum = money;
            ViewBag.bookCount = book;
            ViewBag.memCount = mem;
            ViewBag.lentCount = lendBook;
            return View();
        }
        public ActionResult Weather()
        {
            return View();
        }
        public ActionResult WeatherCart()
        {
            return View();
        }
        public ActionResult Gallery()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Uploadfile(HttpPostedFileBase file)
        {
            if(file.ContentLength>0)
            {
                string filepath = Path.Combine(Server.MapPath("~/web2/resimler/"),Path.GetFileName(file.FileName));
                file.SaveAs(filepath);               
            }
            return RedirectToAction("Gallery");
        }
        public ActionResult Cart()
        {
            var book = db.BOOKs.Count();
            var mem = db.MEMBERs.Count();
            var pay = db.PUNISHMENTs.Sum(m => m.MONEY);
            var lend = db.BOOKs.Where(b => b.IS_STATUS == false).Count();
            var cat = db.CATEGORies.Count();
            var mail = db.CONTACTs.Count();
            var maxbook = db.MAXAUTHORSBOOK().FirstOrDefault();
            var publiser = db.BOOKs.GroupBy(p => p.PUBLISER).OrderByDescending(x => x.Count()).Select(y=> new { y.Key}).FirstOrDefault();
            ViewBag.publiserCount = publiser;
            ViewBag.maxBookCount = maxbook;
            ViewBag.mailcount = mail;
            ViewBag.catcount = cat;
            ViewBag.lendCount = lend;
            ViewBag.paysum = pay;
            ViewBag.memcount = mem;
            ViewBag.bookcount = book;
            return View();
        }
    }
}