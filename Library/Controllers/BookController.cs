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
        public ActionResult Index(string p)
        {
           ;
            var books = from b in db.BOOKs select b;
            if (!string.IsNullOrEmpty(p))
            {
                books = books.Where(m => m.BOOK_NAME.Contains(p));
            }
            return View(books.ToList());
            //var bk = db.BOOKs.ToList()
            //return View(bk);
        }
        [HttpGet]
        public ActionResult bookAdd()
        {
            List<SelectListItem> catdrop = (from i in db.CATEGORies.ToList()
                                          select new SelectListItem
                                          {
                                              Text = i.CATEGORY_NAME,
                                              Value = i.CATEGORY_ID.ToString()
                                          }).ToList();
            ViewBag.ctdrp = catdrop;
            List<SelectListItem> authordrop = (from i in db.AUTHORs.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = i.AUTHOR_NAME +' '+i.AUTHOR_SURNAME,
                                                  Value = i.AUTHOR_ID.ToString()
                                              }).ToList();
            ViewBag.athdrp = authordrop;
            return View();
        }
        [HttpPost]
        public ActionResult bookAdd(BOOK b)
        {
            var ktg = db.CATEGORies.Where(c => c.CATEGORY_ID == b.CATEGORY.CATEGORY_ID).FirstOrDefault();
            var yzr = db.AUTHORs.Where(y => y.AUTHOR_ID == b.AUTHOR1.AUTHOR_ID).FirstOrDefault();
            b.AUTHOR1 = yzr;
            b.CATEGORY = ktg;
            db.BOOKs.Add(b);
            db.SaveChanges();
            return RedirectToAction("Index");          
        }
        public ActionResult bookDel(int id)
        {
            var book = db.BOOKs.Find(id);
            db.BOOKs.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult bookFind(int id)
        {
            var bookf = db.BOOKs.Find(id);
            List<SelectListItem> catdrop = (from i in db.CATEGORies.ToList()
                                            select new SelectListItem
                                            {
                                                Text = i.CATEGORY_NAME,
                                                Value = i.CATEGORY_ID.ToString()
                                            }).ToList();
            ViewBag.ctdrp = catdrop;
            List<SelectListItem> authordrop = (from i in db.AUTHORs.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = i.AUTHOR_NAME + ' ' + i.AUTHOR_SURNAME,
                                                   Value = i.AUTHOR_ID.ToString()
                                               }).ToList();
            ViewBag.athdrp = authordrop;
            return View("bookfind",bookf);
        }
        public ActionResult bookUpd(BOOK b)
        {
            var bookU = db.BOOKs.Find(b.BOOK_ID);
            bookU.BOOK_NAME = b.BOOK_NAME;
            bookU.EDITION = b.EDITION;
            bookU.PAGE = b.PAGE;
            bookU.PUBLISER = b.PUBLISER;
            bookU.IS_STATUS = true;
            var cat = db.CATEGORies.Where(k => k.CATEGORY_ID == b.CATEGORY.CATEGORY_ID).FirstOrDefault();
            var auth = db.AUTHORs.Where(k => k.AUTHOR_ID == b.AUTHOR1.AUTHOR_ID).FirstOrDefault();
            bookU.BOOK_CAT = cat.CATEGORY_ID;
            bookU.AUTHOR = auth.AUTHOR_ID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}