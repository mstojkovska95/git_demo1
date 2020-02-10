using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using log4net;
using TicketSelling.Core.Repository;
using TicketSelling.Core.Services;
using WebApiExample.Filters;

namespace TicketSelling.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<DatabaseRepo>().As<IDatabaseRepo>();
            builder.RegisterType<CustomerService>().As<ICustomerService>();
            builder.RegisterType<TicketService>().As<ITicketService>();
            builder.RegisterType<ConcertService>().As<IConcertService>();
            builder.RegisterType<ReservationService>().As<IReservationService>();
            builder.Register(c => LogManager.GetLogger(typeof(object))).As<ILog>();
            builder.RegisterType<UserService>().As<IUserService>();

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            config.Filters.Add(new BasicAuthenticationAttribute(container.Resolve<IUserService>()));

            // Web API routes
            config.MapHttpAttributeRoutes();


            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
