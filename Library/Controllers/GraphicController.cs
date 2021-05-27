using Library.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.Controllers
{
    public class GraphicController : Controller
    {
        // GET: Graphic
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult VisualizeBookResult()
        {
            return Json(liste());
        }
        public List<Graphic> liste()
        {
            List<Graphic> cs = new List<Graphic>();
            cs.Add(new Graphic()
            {
                PUBLISER = "ddd",
                SAYI= 2
            });
            cs.Add(new Graphic()
            {
                PUBLISER = "ff",
                SAYI = 2
            });
            return cs;
        }
    }
}