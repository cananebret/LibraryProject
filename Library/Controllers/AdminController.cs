using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Library.Models.Entity;

namespace Library.Controllers
{
    [AllowAnonymous]
    public class AdminController : Controller
    {
        // GET: Admin
        LIBRARYEntities db = new LIBRARYEntities();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(ADMIN_SET a)
        {
            var values = db.ADMIN_SET.FirstOrDefault(x => x.ADMIN_NAME == a.ADMIN_NAME && x.ADMIN_PASSWORD == a.ADMIN_PASSWORD);
            if(values != null)
            {
                FormsAuthentication.SetAuthCookie(values.ADMIN_NAME, false);
                Session["ADMIN_NAME"] = values.ADMIN_NAME.ToString();
                return RedirectToAction("Index","Category");
            }
            else
            {
                return View();
            }           
        }
       

    }
}