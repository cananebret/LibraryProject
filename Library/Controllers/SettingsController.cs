using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library.Models.Entity;
namespace Library.Controllers
{
    public class SettingsController : Controller
    {
        // GET: Settings
        LIBRARYEntities db = new LIBRARYEntities();
        public ActionResult Index()
        {
            var AdminUsers = db.ADMIN_SET.ToList();
            return View(AdminUsers);
        }
        [HttpGet]
        public ActionResult NewAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewAdmin(ADMIN_SET a)
        {
            db.ADMIN_SET.Add(a);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult AdminDel(int id)
        {
            var delA = db.ADMIN_SET.Find(id);
            db.ADMIN_SET.Remove(delA);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AdminUpd(int id)
        {
            var FindAdmin = db.ADMIN_SET.Find(id);
            return View("AdminUpd", FindAdmin);

        }
        [HttpPost]
        public ActionResult AdminUpd(ADMIN_SET a)
        {
            var FindAdmin = db.ADMIN_SET.Find(a.ID);
            FindAdmin.ADMIN_NAME = a.ADMIN_NAME;
            FindAdmin.ADMIN_AUT = a.ADMIN_AUT;
            FindAdmin.ADMIN_PASSWORD = a.ADMIN_PASSWORD;
            FindAdmin.ADMIN_DESCRIPTION = a.ADMIN_DESCRIPTION;
            db.SaveChanges();
            return RedirectToAction("Index");

        }


    }
}