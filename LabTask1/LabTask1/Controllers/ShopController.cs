using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabTask1.Controllers
{
    public class ShopController : Controller
    {
        // GET: Shop
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult Products() 
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult LoginCheck()
        {
            return RedirectToAction("MyProfile","Dashboard");
        }
    }
}