using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Esam
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ServerDirectory.PhysicalPath = HttpContext.Current.Server.MapPath(".");
        }
        void Session_Start(object sender, EventArgs e)
        {
            Uri uri = HttpContext.Current.Request.Url;
            String host;
            //if (Request.IsLocal)
                host = uri.Scheme + Uri.SchemeDelimiter + uri.Host + ":" + uri.Port;
            //else
            //    host = uri.Scheme + Uri.SchemeDelimiter + uri.Host + ":" + uri.Port;
          
            ServerDirectory.Host = host;
            SysProperty.Client = new SysClient();
            SysProperty.ChangeSiteLanguage(Languages.English);
        }
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new ValidateInputAttribute(false));
        }
    }
}
