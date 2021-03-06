﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace PeopleSearch
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			// Web API configuration and services

			// Web API routes
			config.MapHttpAttributeRoutes();

			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);


			// set JSON handler serializer setting - otherwise following we'd get error of the form: 
			// "The 'ObjectContent`1' type failed to serialize the response body for content type 'application/xml; charset=utf-8'"
			var json = config.Formatters.JsonFormatter;
			json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
			config.Formatters.Remove(config.Formatters.XmlFormatter);
		}
	}
}
