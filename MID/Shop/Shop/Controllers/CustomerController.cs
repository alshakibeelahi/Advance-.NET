using Shop.Models;
using Shop.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Order = Shop.Models.EF.Order;
using OrderProduct = Shop.Models.EF.OrderProduct;

namespace Shop.Controllers
{
    public class CustomerController : Controller
    {
        public ActionResult Index() { return View(); }
        [HttpGet]
        public ActionResult AddProduct(int id=1)
        {
            if (Session["User"].Equals("Customer"))
            {
                var db = new ShopEntities1();
                int pro = db.Products.ToList().Count();
                int prosize = 2;
                var pagesize = Math.Ceiling(pro / (decimal)prosize);
                ViewBag.Page = pagesize;
                return View(db.Products.OrderBy(e=>e.Id).Skip((id-1)*prosize).Take(prosize));
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }
        [HttpGet]
        public ActionResult AddtoCart(int id=1)
        {
            if (Session["User"].Equals("Customer"))
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
        public ActionResult AddtoCart(Product oPro)
        {
            if (Session["User"].Equals("Customer"))
            {
                var db = new ShopEntities1();
                var prod = (from pro in db.Products
                               where pro.Id == oPro.Id
                               select pro).SingleOrDefault();
                List<Product> products;
                if (Session["Cart"] == null)
                {
                    products = new List<Product>();
                }
                else
                {
                    var oldpro = Session["Cart"].ToString();
                    products = new JavaScriptSerializer().Deserialize<List<Product>>(oldpro);
                }
                oPro.Price = prod.Price;
                oPro.Name= prod.Name;
                oPro.Quantity = oPro.Quantity;

                products.Add(oPro);
                var oldpro2 = new JavaScriptSerializer().Serialize(products);
                Session["Cart"] = oldpro2;
                return RedirectToAction("AddProduct", "Customer");
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }
        [HttpGet]
        public ActionResult MyCart()
        {
            if (Session["User"].Equals("Customer"))
            {
                if (Session["Cart"] != null)
                {
                    var cart = Session["Cart"].ToString();
                    var cartD = new JavaScriptSerializer().Deserialize<List<Product>>(cart);
                    return View(cartD);
                }
                else
                {
                    return RedirectToAction("Index", "Customer");
                }
                
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
        [HttpGet]
        public ActionResult Checkout(int id)
        {
            var db = new ShopEntities1();

            var ord = new Order();
            ord.Amount = id;
            ord.Status = "Ordered";
            ord.CusId = Convert.ToInt32(Session["id"]);
            db.Orders.Add(ord);
            db.SaveChanges();
            var cart = Session["Cart"].ToString();
            var cartD = new JavaScriptSerializer().Deserialize<List<Models.EF.Product>>(cart);
            foreach(var item in cartD)
            {
                OrderProduct ordPro = new OrderProduct();
                ordPro.ProId = item.Id;
                var product = (from pro in db.Products
                               where pro.Id == ordPro.ProId
                               select pro).SingleOrDefault();
                product.Quantity= product.Quantity-item.Quantity;
                ordPro.OrdId = ord.Id;
                ordPro.OrdQuantity = item.Quantity;
                db.OrderProducts.Add(ordPro);
            }
            db.SaveChanges();
            Session["Cart"] = null;
            return RedirectToAction("Index");
        }
    }
}