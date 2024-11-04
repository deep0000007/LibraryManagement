using LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagement.Controllers
{
    public class LoginController : Controller
    {

        LibraryManagementDBEntities1 db = new LibraryManagementDBEntities1();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Registration r)
        {
            return View();
        }
    }
}