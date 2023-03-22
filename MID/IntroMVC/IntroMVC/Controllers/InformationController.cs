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
        public ActionResult links(int? link)
        {
            if (link == 1) return Redirect("https://drive.google.com/drive/u/0/folders/11XQcouAIAFTiTCW2BqyLL0-5eGrhiG71");
            else if (link == 2) return Redirect("https://github.com/sajid43677/SmartHostel");
            else return Redirect("https://github.com/AlShakibEElahi/Smart_Hostel");
        }
    }
}