using Shop.Models;
using Shop.Models.Custom;
using Shop.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Controllers
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
        public ActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                var db = new ShopEntities1();
                if (login.Options=="Customer")
                {
                    var customer = (from cus in db.Customers
                                    where cus.Username == login.Username && cus.Password == login.Password
                                    select cus).SingleOrDefault();
                    if (customer != null)
                    {
                        Session["id"] = customer.Id;
                        Session["User"] = login.Options;

                        return RedirectToAction("AddProduct", "Customer");
                    }
                    else
                    {
                        ViewData["Error"] = "Username or Password not found";
                        return View();
                    }
                }
                else
                {
                    var admin = (from adm in db.Admins
                                 where adm.Username == login.Username && adm.Password == login.Password
                                 select adm).SingleOrDefault();
                    if (admin != null)
                    {
                        Session["id"] = admin.Id;
                        Session["User"] = login.Options;
                        return RedirectToAction("Index", "Admin");
                    }
                    else
                    {
                        ViewData["Error"] = "Username or Password not found";
                        return View();
                    }
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signup(Customer cus)
        {
            if (ModelState.IsValid)
            {
                var db = new ShopEntities1();
                db.Customers.Add(cus);
                db.SaveChanges();
                return RedirectToAction("Login");
            }
            return View(cus);
        }

    }
}