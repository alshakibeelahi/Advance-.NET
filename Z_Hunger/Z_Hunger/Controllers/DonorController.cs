using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Z_Hunger.Cust_Auth;
using Z_Hunger.EF.Model;
using Z_Hunger.Models;

namespace Z_Hunger.Controllers
{
    [Logged]
    [DonorAccess]
    public class DonorController : Controller
    {
        // GET: Donor
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Donate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Donate(Request req)
        {
            if (ModelState.IsValid)
            {
                var user = (Donor)Session["user"];
                ZHContext db = new ZHContext();
                CollectRequest crq = new CollectRequest()
                {
                    FoodDes = req.FoodDes,
                    PreTime = req.PreTime,
                    Status = "Requested",
                    DId = user.Id
                };
                db.CollectRequests.Add(crq);
                db.SaveChanges();
                return RedirectToAction("Contributions");
            }
            return View(req);
        }
        [HttpGet]
        public ActionResult Contributions() 
        { 
            ZHContext db = new ZHContext();
            var user = (Donor)Session["user"];
            var contr = (from lst in db.CollectRequests
                         where lst.DId.Equals(user.Id)
                         select lst).ToList();
            return View(contr);
        }
    }
}