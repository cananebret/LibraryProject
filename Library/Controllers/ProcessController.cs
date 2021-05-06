using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library.Models.Entity;

namespace Library.Controllers
{
    public class ProcessController : Controller
    {
        // GET: Process
        LIBRARYEntities db = new LIBRARYEntities();
        public ActionResult Index()
        {
            var values = db.ACTIONs.Where(a => a.IS_STATUS == true).ToList();
            return View(values);
        }
    }
}