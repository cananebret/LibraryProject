using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library.Models.Entity;
using System.Web.Security;

namespace Library.Controllers
{
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
                //TempData["id"] = mem.MEMBER_ID.ToString();
                //TempData["name"] = mem.MEMBER_NAME.ToString();
                //TempData["surname"] = mem.MEMBER_SURNAME.ToString();
                //TempData["usern"] = mem.USER_NAME.ToString();
                //TempData["pass"] = mem.PASSWORD.ToString();
                //TempData["phone"] = mem.TEL.ToString();
                //TempData["school"] = mem.SCHOOL.ToString();
                return RedirectToAction("Index", "Panel");
            }
            else
            {
                return View();
            }
            
        }
    }
}