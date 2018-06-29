
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AutoMapper;
using StockManagement.Models.EntityModels;
using StockManagement.Models.ViewModels;

namespace StockManagementApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<StockInViewModel, StockIn>();
                cfg.CreateMap<StockIn,StockInViewModel>();
            });
        }
    }
}
