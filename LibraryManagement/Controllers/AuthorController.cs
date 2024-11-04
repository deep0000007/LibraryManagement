using LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagement.Controllers
{
    public class AuthorController : Controller
    {
        LibraryManagementDBEntities1 db= new LibraryManagementDBEntities1 ();
        // GET: Author
        public ActionResult Index()
        {
            var data = db.Authors.ToList();
            return View(data);
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Author c)
        {
            db.Authors.Add(c);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = db.Authors.Find(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Author c)
        {
            db.Authors.AddOrUpdate(c);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var data = db.Authors.Find(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult Delete(int id, Author c)
        {
            var data = db.Authors.Find(id);

            db.Authors.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}