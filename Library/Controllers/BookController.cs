using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library.Models.Entity;

namespace Library.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        LIBRARYEntities db = new LIBRARYEntities();
        public ActionResult Index()
        {
            var bk = db.BOOKs.ToList();
            return View(bk);
        }
    }
}