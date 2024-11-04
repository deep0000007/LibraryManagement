using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LibraryManagement.Models;

namespace LibraryManagement.Controllers
{
    public class BookController : Controller
    {
        private LibraryManagementDBEntities1 db = new LibraryManagementDBEntities1();

        // GET: Book
        public ActionResult Index()
        {
            var books = db.Books.Include(b => b.Author).Include(b => b.Category).Include(b => b.Publisher);
            return View(books.ToList());
        }

        // GET: Book/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            ViewBag.auth_id = new SelectList(db.Authors, "id", "name");
            ViewBag.cat_id = new SelectList(db.Categories, "id", "catname");
            ViewBag.pub_id = new SelectList(db.Publishers, "id", "name");
            return View();
        }

        // POST: Book/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,bname,cat_id,auth_id,pub_id,contents,pages,edition")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.auth_id = new SelectList(db.Authors, "id", "name", book.auth_id);
            ViewBag.cat_id = new SelectList(db.Categories, "id", "catname", book.cat_id);
            ViewBag.pub_id = new SelectList(db.Publishers, "id", "name", book.pub_id);
            return View(book);
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            ViewBag.auth_id = new SelectList(db.Authors, "id", "name", book.auth_id);
            ViewBag.cat_id = new SelectList(db.Categories, "id", "catname", book.cat_id);
            ViewBag.pub_id = new SelectList(db.Publishers, "id", "name", book.pub_id);
            return View(book);
        }

        // POST: Book/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,bname,cat_id,auth_id,pub_id,contents,pages,edition")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.auth_id = new SelectList(db.Authors, "id", "name", book.auth_id);
            ViewBag.cat_id = new SelectList(db.Categories, "id", "catname", book.cat_id);
            ViewBag.pub_id = new SelectList(db.Publishers, "id", "name", book.pub_id);
            return View(book);
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
