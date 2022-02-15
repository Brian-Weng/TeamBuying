using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace TeamBuying
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {
            if(HttpContext.Current.Items["DbContext"] != null)
            {
                var context = HttpContext.Current.Items["DbContext"] as DbContext;
                context.Dispose();
            }
        }
    }
}