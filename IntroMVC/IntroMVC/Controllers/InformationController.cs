using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntroMVC.Controllers
{
    public class InformationController : Controller
    {
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult Education()
        {
            return View();
        }
        public ActionResult Projects()
        {
            return View();
        }
        public ActionResult References()
        {
            return View();
        }
    }
}