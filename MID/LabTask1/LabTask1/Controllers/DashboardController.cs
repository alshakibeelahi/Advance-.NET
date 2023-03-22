using LabTask1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Management;
using System.Web.Mvc;

namespace LabTask1.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult MyProfile()
        {
            List<Product> products = new List<Product>();
            for(int i = 1; i <= 10; i++)
            {
                Product p = new Product();
                p.Id = i;
                p.Name = "Mobile"+i;
                p.Price = i * 100;
                products.Add(p);
            }
            ViewBag.Products = products;
            return View();
        }
        public ActionResult ProductCategory()
        {
            List<Category> cat = new List<Category>();
            int OId = 1;
            for (int i = 1; i <= 3; i++)
            {
                Category c = new Category();
                List<Product> pro = new List<Product>();
                c.CName = "cat-" + i;
                
                for (int j = 1; j <=3 ; j++)
                {
                    Product p = new Product();
                    p.Id = OId;
                    p.Name = "pro-" + OId;
                    p.Price = (OId) * 100;
                    pro.Add(p);
                    OId++;
                }
                c.Products = pro;
                cat.Add(c);
            }
            ViewBag.Category = cat;
            return View();
        }
        public ActionResult Logout()
        {
            return RedirectToAction("Home","Shop");
        }
    }
}