using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TidyHome2.UI.Models;

namespace TidyHome2.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
           
            return View();
        }

        public ActionResult Contact()
        {

          return View();
        }

        [HttpPost]
        public void Admin(bool flag)
        {
            if (!ModelState.IsValid) return;
            CheckViewAdminCash.Flag = flag;
        }
    }
}