using Shop.Models;
using Shop.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            if (Session["User"].Equals("Admin"))
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }
        [HttpPost]
        public ActionResult Add()
        {
            if (Session["User"].Equals("Admin"))
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }
        [HttpPost]
        public ActionResult Add(Product pro)
        {
            if (Session["User"].Equals("Admin"))
            {
                var db = new ShopEntities1();
                db.Products.Add(pro);
                db.SaveChanges();
                return RedirectToAction("List");
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
            
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (Session["User"].Equals("Admin"))
            {
                var db = new ShopEntities1();
                var product = (from pro in db.Products
                               where pro.Id == id
                               select pro).SingleOrDefault();

                return View(product);
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }
        [HttpPost]
        public ActionResult Edit(Product prod)
        {
            if (Session["User"].Equals("Admin"))
            {
                var db = new ShopEntities1();
                var product = (from pro in db.Products
                               where pro.Id == prod.Id
                               select pro).SingleOrDefault();

                //product.Name = prod.Name;
                //product.Price = prod.Price;
                //product.Quantity = prod.Quantity;
                db.Entry(product).CurrentValues.SetValues(prod);
                db.SaveChanges();
                return RedirectToAction("List");
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }
        public ActionResult List()
        {
            if (Session["User"].Equals("Admin"))
            {
                var db = new ShopEntities1();
                var products = db.Products.ToList();
                return View(products);
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (Session["User"].Equals("Admin"))
            {
                var db = new ShopEntities1();
                var product = (from pro in db.Products
                               where pro.Id == id
                               select pro).SingleOrDefault();

                return View(product);
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }
        [HttpPost]
        public ActionResult Delete(Product prepro)
        {
            if (Session["User"].Equals("Admin"))
            {
                var db = new ShopEntities1();
                var product = (from pro in db.Products
                               where pro.Id == prepro.Id
                               select pro).SingleOrDefault();
                db.Products.Remove(product);
                db.SaveChanges();
                return RedirectToAction("list");
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }
        public ActionResult Logout()
        {
            Session["User"] = null;
            Session["id"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}