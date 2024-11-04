using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagement.Controllers
{
    public class ReturnBookController : Controller
    {
        // GET: ReturnBook
        public ActionResult Index()
        {
            return View();
        }
    }
}