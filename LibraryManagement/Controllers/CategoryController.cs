using LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagement.Controllers
{
    public class CategoryController : Controller
    {
        LibraryManagementDBEntities1 db = new LibraryManagementDBEntities1();
        // GET: Category
        public ActionResult Index()
        {
            var data = db.Categories.ToList();
            return View(data);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category c)
        {
            db.Categories.Add(c);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = db.Categories.Find(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Category c)
        {
            db.Categories.AddOrUpdate(c);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var data = db.Categories.Find(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult Delete(int id, Category c)
        {
            var data = db.Categories.Find(id);

            db.Categories.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
       
}