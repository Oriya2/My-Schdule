using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace mySchdule
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            GlobalConfiguration.Configuration.Formatters.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);

            //GlobalConfiguration.Configure(WebApiConfig.Register);

        }
        protected void Application_BeginRequest()
        {
            Response.AddHeader("Access-Control-Allow-Origin", "*");
            Response.AddHeader("Access-Control-Allow-Methods", "GET, DELETE, PUT,POST");
            Response.AddHeader("Access-Control-Allow-Headers", "Content-Type, Accept, Pragma, Cache-Control, Authorization ");

            if (Request.Headers.AllKeys.Contains("Origin", StringComparer.CurrentCultureIgnoreCase)
                && Request.HttpMethod == "OPTIONS")
            {
                Response.End();
            }

        }
    }
}
