using LibraryManagement.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace LibraryManagement.Controllers
{
    public class IssueBookController : Controller
    {
        private LibraryManagementDBEntities1 db = new LibraryManagementDBEntities1();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetMid(int id)
        {
            var member = db.Members
                           .Where(m => m.id == id)
                           .Select(m => new { m.name })
                           .FirstOrDefault();

            return Json(member, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetBook()
        {
            var books = db.Books
                          .Select(b => new { ID = b.id, Bname = b.bname })
                          .ToList();
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
            return View("Index", i); // Return to the view with the model data if not valid
        }
    }
}
