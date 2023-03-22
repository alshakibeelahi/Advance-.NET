using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Z_Hunger.EF.Model;

namespace Z_Hunger.Cust_Auth
{
    public class AdminAccess : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var user = (Person)httpContext.Session["user"];
            var nuser = (Employee)httpContext.Session["user"];
            if (user != null && user.Role.Equals("Employee") && nuser.Designation.Equals("Admin")) return true;

            httpContext.Response.StatusCode = 401;
            httpContext.Response.Redirect("/Home/Login");
            return false;
        }
    }
}