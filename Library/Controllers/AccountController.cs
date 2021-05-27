using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library.Models.Entity;
using System.Web.Security;

namespace Library.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {      
        // GET: Login
        LIBRARYEntities db = new LIBRARYEntities();
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(MEMBER m)
        {
            var mem = db.MEMBERs.FirstOrDefault(x => x.MAIL == m.MAIL && x.PASSWORD == m.PASSWORD);
            if(mem != null)
            {
                FormsAuthentication.SetAuthCookie(mem.MAIL, false);
                Session["mail"] = mem.MAIL.ToString();                
                return RedirectToAction("Index", "Panel");
            }
            else
            {
                return View();
            }
            
        }
        [HttpGet]
        public ActionResult register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult register(MEMBER m)
        {
            if(!ModelState.IsValid)
            {
                return View("register");
            }
            db.MEMBERs.Add(m);
            db.SaveChanges();
            return View();
        }
    }
}