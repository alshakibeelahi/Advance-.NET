using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Z_Hunger.Cust_Auth
{
    public class Logged : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Session["user"] != null) return true;
            httpContext.Response.StatusCode = 401;
            httpContext.Response.Redirect("/Home/Login");
            return false;
        }
    }
}