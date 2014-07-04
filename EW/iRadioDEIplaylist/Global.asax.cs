using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebMatrix.WebData;

namespace iRadioDEIplaylist
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //instruction added because of this error:
                //You must call the "WebSecurity.InitializeDatabaseConnection" method before you call any other method of the "WebSecurity" class. This call should be placed in an _AppStart.cshtml file in the root of your site.
            //We don’t use an _AppStart.cshtml file in ASP.NET MVC, so look to add code to Application_Start in global.asax.cs instead.
            WebSecurity.InitializeDatabaseConnection(
                "DefaultConnection",
                "UserProfile",
                "UserId",
                "UserName", autoCreateTables: true);
            //---------------------------------------

            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
        }

        public void HelpdeskRequest()
        {
            Application_Start();
        }
    }
}