using LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagement.Controllers
{
    public class MemberController : Controller
    {
        LibraryManagementDBEntities1 db = new LibraryManagementDBEntities1();
        // GET: Member
        public ActionResult Index()
        {
            var data = db.Members.ToList();
            return View(data);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Member c)
        {
            db.Members.Add(c);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = db.Members.Find(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Member c)
        {
            db.Members.AddOrUpdate(c);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var data = db.Members.Find(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult Delete(int id, Member c)
        {
            var data = db.Members.Find(id);

            db.Members.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}