using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Z_Hunger.EF.Model;
using Z_Hunger.Models;

namespace Z_Hunger.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Models.Login login)
        {
            object ms = 0;
            if (ModelState.IsValid)
            {
                ZHContext db = new ZHContext();
                var user = ms;
                if (login.Options.Equals("Donor"))
                {
                    user = (from usr in db.Donors
                            where usr.Username.Equals(login.Username) && usr.Password.Equals(login.Password)
                            select usr).SingleOrDefault();
                }
                else if (login.Options.Equals("Employee"))
                {
                    user = (from usr in db.Employees
                            where usr.Username.Equals(login.Username) && usr.Password.Equals(login.Password)
                            select usr).SingleOrDefault();
                }
                if (user != null)
                {
                    Session["user"] = user;
                    var returnUrl = Request["ReturnUrl"];
                    if (returnUrl != null)
                    {
                        return Redirect(returnUrl);
                    }
                    return RedirectToAction("Index", login.Options);
                }
                TempData["Msg"] = "Username Password Invalid";
            }
            return View(login);
        }
        [HttpGet]
        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signup(Signup signup)
        {
            if (ModelState.IsValid)
            {
                ZHContext db = new ZHContext();
                Donor dnr = new Donor()
                {
                    Name= signup.Name,
                    Phone= signup.Phone,
                    Email= signup.Email,
                    Username= signup.Username,
                    Password=signup.Password,
                    OrgAddress=signup.OrgAddress,
                    Organization=signup.Organization,
                    Role = "Donor"
                };
                db.Donors.Add(dnr);
                db.SaveChanges();
                return RedirectToAction("Login");
            }
            return View(signup);
        }
        public ActionResult Logout()
        {
            Session["user"] = null;
            return RedirectToAction("Index");
        }
    }
}