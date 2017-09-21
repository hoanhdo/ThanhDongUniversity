using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace FacebookChatBot
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        protected void Application_BeginRequest(Object Sender, EventArgs e)
        {
            string logfile = HttpContext.Current.Server.MapPath("~/log.txt");
            Request.SaveAs(logfile, true);
        }
    }
}
