using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Routing;
using System.Web.Mvc;
using log4net.Config;
using SDSK.API.Constraints;
using SDSK.API.Filters;
using SDSK.API.Handlers;
using Swashbuckle.Application;

namespace SDSK.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // swagger configuration
            config
                .EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", "SDSK.API");
                })
                .EnableSwaggerUi(c =>
                {
                    c.DocExpansion(DocExpansion.Full);
                });

            // log4net configuration
            XmlConfigurator.Configure();
            config.Services.Add(typeof(IExceptionLogger), new ExceptionLogger());

            // handlers configuration
            config.MessageHandlers.Add(new MethodOverrideHandler());

            // filters configuration
            config.Filters.Add(new LogPerformanceActionFilter());

            // routes configuration
            var constraintResolver = new DefaultInlineConstraintResolver();
            constraintResolver.ConstraintMap.Add("jiraid", typeof(JiraIdConstraint));
            config.MapHttpAttributeRoutes(constraintResolver);
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
