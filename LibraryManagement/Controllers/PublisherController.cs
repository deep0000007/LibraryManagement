using LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagement.Controllers
{
   
    public class PublisherController : Controller
    {
        LibraryManagementDBEntities1 db = new LibraryManagementDBEntities1 ();
        // GET: Publisher
        public ActionResult Index()
        {
            var data = db.Publishers.ToList();
            return View(data);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Publisher c)
        {
            db.Publishers.Add(c);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = db.Publishers.Find(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Publisher c)
        {
            db.Publishers.AddOrUpdate(c);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var data = db.Publishers.Find(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult Delete(int id, Publisher c)
        {
            var data = db.Publishers.Find(id);

            db.Publishers.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}