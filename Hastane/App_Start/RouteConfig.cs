using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Hastane
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();


            routes.MapRoute(
           name: "BolumUnvanDoktorListe",
           url: "BolumDoktorListe/{BolumNo}/{UnvanNo}",
           defaults: new { controller = "Unvan", action = "BolumDoktorGetir" }
       );


            routes.MapRoute(
                    name: "UnvanDoktorListe",
                    url: "UnvanDoktorlari/{UnvanNo}",
                    defaults: new { controller = "Unvan", action = "UnvanDoktorGetir" }
                );

            routes.MapRoute(
                    name: "UnvanEklemeSayfasiGetir",
                    url: "UnvanEkle",
                    defaults: new { controller = "Unvan", action = "UnvanEkle" }
                );

            routes.MapRoute(
                    name: "DuyuruListesiGetir",
                    url: "listeGetir",
                    defaults: new { controller = "Hasta", action = "DuyuruListe"}
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Hasta", action = "Selam", id = UrlParameter.Optional }
            );
        }
    }
}
