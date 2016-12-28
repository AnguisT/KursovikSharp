using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MemberShip
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Home", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "InformationApplicant",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "InformationApplicant", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "InformationEmployer",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "InformationEmployer", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "ListResume",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Applicant", action = "ListResume", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "CreateResume",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Applicant", action = "CreateResume", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "DetailsForApplicant",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Applicant", action = "Details", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "ListJobs",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Employer", action = "ListJobs", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "CreateJobs",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Employer", action = "CreateJobs", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "DetailsForEmployer",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Employer", action = "Details", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Details",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Account", action = "Details", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Login",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "CreateApplicant",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Admin", action = "CreateApplicant", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "CreateEmployer",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Admin", action = "CreateEmployer", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Index",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Admin", action = "ListPeople", id = UrlParameter.Optional }
            );
        }
    }
}