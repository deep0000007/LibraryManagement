using LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagement.Controllers
{
    public class IssueBookController : Controller
    {
        // GET: IssueBook
        LibraryManagementDBEntities1 db = new LibraryManagementDBEntities1 ();
        public ActionResult Index()
        {

            return View();
        }
        
        [HttpGet]
        public ActionResult GetMid(int id)
        {
            var member = db.Members.Where(m => m.id == id).Select(m => new { m.name }).FirstOrDefault(); // Only select the Name field

            if (member != null)
            {
                return Json(member, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet); // Return null if not found
        }


        [HttpGet ]
        
        public ActionResult GetBook()
        {
            var books = db.Books.Select(p => new
            {
                ID = p.id,
                Bname = p.bname
            }).ToList();
            return Json(books, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Save(IssueBook i)
        {
            if (ModelState.IsValid)
            {
               
                db.IssueBooks.Add(i);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(i);
        }

    }

}
