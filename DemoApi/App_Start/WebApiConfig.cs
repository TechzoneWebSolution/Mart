using Swashbuckle.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Http.ExceptionHandling;
using ODET.APICommon;

namespace KVMartApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var cors = new EnableCorsByDomainAttribute();
            config.EnableCors(cors);

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            config.Routes.MapHttpRoute(
            name: "help_ui_shortcut",
            routeTemplate: "docs",
            defaults: null,
            constraints: null,
            handler: new RedirectHandler(SwaggerDocsConfig.DefaultRootUrlResolver, "docs"));

            // Web API routes
            config.MapHttpAttributeRoutes(new CustomDirectRouteProvider());

            config.Services.Replace(typeof(IExceptionHandler), new GlobalExceptionHandler());
            config.Services.Replace(typeof(IExceptionLogger), new GlobalExceptionLogger());
            config.MessageHandlers.Add(new GlobalMessageLogger());

            config.Services.Replace(typeof(IHttpControllerSelector), new ContentNegotiationVersioningSelector(config));

            var appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);
            ////config.Filters.Add(new Authenticate());
        }
    }
}
