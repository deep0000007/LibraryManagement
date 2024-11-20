using LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web.Mvc;

namespace LibraryManagement.Controllers
{
    public class ReturnBookController : Controller
    {
        private LibraryManagementDBEntities1 db = new LibraryManagementDBEntities1();

        // GET: ReturnBook
        public ActionResult Index()
        {
            var issuedBooks = db.IssueBooks.Select(s => new
            {
                MemberId = s.member_id,
                BookName = s.book_id, // Ensure `Book` has a `name` property in `IssueBooks`
                IssueDate = s.issuedate,
                ReturnDate = s.returndate
            }).ToList();

            ViewBag.IssuedBooks = issuedBooks;
            return View();
        }

        // Fetch details by member ID for AJAX
        public ActionResult GetMid(int id)
        {
            var memberDetails = (from s in db.IssueBooks
                                 where s.member_id == id
                                 select new
                                 {
                                     IssueDate = s.issuedate,
                                     ReturnDate = s.returndate,
                                     MemberId = s.member_id,
                                     BookName = s.book_id, // Ensure Book has a 'name' property
                                     ElapsedDays = SqlFunctions.DateDiff("day", s.returndate, DateTime.Now)
                                 }).ToList();

            return Json(memberDetails, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Save(ReturnBook returnBook)
        {
            if (ModelState.IsValid)
            {
                db.ReturnBooks.Add(returnBook);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Index", returnBook);
        }
    }
}
