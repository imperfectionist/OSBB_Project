using Autofac;
using Autofac.Integration.Mvc;
using OSBB.App_Start;
using OSBB_BLL.Modules;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OSBB
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly).PropertiesAutowired();
            builder.RegisterModule(new ServiceModule());

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            //string strCulture = (Request.Cookies["lang"] != null) ?
            //    Request.Cookies["lang"].Value : "uk-UA";

            //if (strCulture != String.Empty)
            //{
            //    Thread.CurrentThread.CurrentCulture = new CultureInfo(strCulture);
            //    Thread.CurrentThread.CurrentUICulture = new CultureInfo(strCulture);
            //}

            HttpCookie cookie = HttpContext.Current.Request.Cookies["lang"];
            if(cookie != null && cookie.Value != null)
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo(cookie.Value);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(cookie.Value);
            }
            else
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("uk-UA");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("uk-UA");
                HttpCookie cookieLang = new HttpCookie("lang");
                cookieLang.Value = "uk-UA";
                Response.Cookies.Add(cookieLang);
            }
        }
    }
}
