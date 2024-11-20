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

        public ActionResult Register()
        {
            return View();
        }

        // POST: User/Register
        [HttpPost]
        public JsonResult Register(Registration model)
        {
            if (ModelState.IsValid)
            {
                // Check if username already exists
                if (db.Registrations.Any(u => u.UserName == model.UserName))
                {
                    return Json(new { success = false, message = "Username already exists!" });
                }

                // Save the new registration
                db.Registrations.Add(model);
                db.SaveChanges();
                return Json(new { success = true, message = "Registration successful!" });
            }

            // Collect model state errors
            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
            return Json(new { success = false, message = string.Join(", ", errors) });
        }

        // GET: User/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: User/Login
        [HttpPost]
        public JsonResult Login(string userName, string password)
        {
            var user = db.Registrations.FirstOrDefault(u => u.UserName == userName && u.password == password);

            if (user != null)
            {
                // Store user session
                Session["UserId"] = user.id;
                Session["UserName"] = user.UserName;
                return Json(new { success = true, message = "Login successful!" });
            }
            return Json(new { success = false, message = "Invalid username or password!" });
        }

        // Logout action to clear the session
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }

    }
}