using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;

namespace ColetaEntrega
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Serviços e configuração da API da Web
            // New code
            config.EnableCors();


            // Rotas da API da Web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.JsonFormatter.SupportedMediaTypes
                .Add(new MediaTypeHeaderValue("text/html"));

        }
    }
}
