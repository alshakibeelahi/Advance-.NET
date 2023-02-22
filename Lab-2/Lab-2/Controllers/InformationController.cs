using Lab_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab_2.Controllers
{
    public class InformationController : Controller
    {
        // GET: Information
        [HttpGet]
        public ActionResult Home()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Home(Information info)
        {
            return View(info);
        }
    }
}