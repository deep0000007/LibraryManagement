using LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LibraryManagement.Controllers
{
    public class RegisterController : Controller
    {
        LibraryManagementDBEntities1 db = new LibraryManagementDBEntities1();
        // GET: Register

        public ActionResult home()
        {
            return View();
        }

        public ActionResult Index()
        {
            var data = db.Registrations.ToList();
            return View(data);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Registration r)
        {
            db.Registrations.Add(r);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}