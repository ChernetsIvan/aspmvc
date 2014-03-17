using SportsStore.WebUI.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SportsStore.WebUI
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                null,
                "",                          //Соответствует только пустой URL, т.е. /
                new { controller = "Product", action = "List", 
                    category = (string)null, page = 1 }
                );
            routes.MapRoute(
                null,
                "Page{page}", //Соответствует /Page2, /Page123, но не /PageXYZ
                new { controller = "Product", action = "List", 
                    category = (string)null }, 
                new {page = @"\d+"} //Ограничения: страница должна быть числовой
                );
            routes.MapRoute(
                null,
                "{category}", // Соответствует /категория или /AnythingWithNoSlash
                new { controller = "Product", action = "List", page = 1 }
                );
            routes.MapRoute(
                null,                          //нам не нужно указывать имя
                "{category}/Page{page}", //Соответствует /категория/страница 
                new { Controller = "Product", Action = "List" }, //По умолчанию
                new { page = @"\d+" } //Ограничения: страница должна быть числовой
                );
            routes.MapRoute(
                null,
                "{controller}/{action}" // URL with parameters
                );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            // Use LocalDB for Entity Framework by default
            //Database.DefaultConnectionFactory = new SqlConnectionFactory(@"Data Source=(localdb)\v11.0; Integrated Security=True; MultipleActiveResultSets=True");

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory()); 
        }
    }
}