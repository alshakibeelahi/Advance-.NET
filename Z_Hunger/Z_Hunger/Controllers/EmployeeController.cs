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
    [GenEmpAccess]
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [AdminAccess]
        public ActionResult AllRequests()
        {
            ZHContext db = new ZHContext();
            var req = (from rq in db.CollectRequests
                       where rq.Status.Equals("Requested")
                       select rq).ToList();

            return View(req);
        }
        [HttpGet]
        [AdminAccess]
        public ActionResult AcceptDonation(int id)
        {
            ViewBag.id = id;
            ZHContext db = new ZHContext();
            var emp = (from em in db.Employees
                       where em.Status.Equals("Free")
                       select em).ToList();
            return View(emp);
        }
        [AdminAccess]
        [HttpPost]
        public ActionResult AcceptDonation(Accept acpt)
        {
            ZHContext db = new ZHContext();
            CollectRequest crlreq = db.CollectRequests.Find(acpt.CRId);
            Employee empd = db.Employees.Find(acpt.EId);
            crlreq.Status = "Accepted";
            empd.Status = "Assigned";
            Collection clc = new Collection()
            {
                CRId = acpt.CRId, 
                EId = acpt.EId
            };
            db.Collections.Add(clc);
            db.SaveChanges();
            return RedirectToAction("AllDonations");
        }
        [AdminAccess]
        [HttpGet]
        public ActionResult DeclineDonation(int id)
        {
            ZHContext db = new ZHContext();
            var crlreq = db.CollectRequests.Find(id);
            crlreq.Status = "Declined";
            db.SaveChanges();
            return RedirectToAction("AllRequests");
        }
        public ActionResult AllDonations()
        {
            ZHContext db = new ZHContext();
            var dtls = db.Collections.ToList();
            return View(dtls);
        }
        public ActionResult AssignedWork()
        {
            ZHContext db = new ZHContext();
            var user = (Employee)Session["user"];
            var dtls = (from clc in db.Collections
                        where clc.EId.Equals(user.Id)
                        select clc).SingleOrDefault();
            return View(dtls);
        }
    }
}