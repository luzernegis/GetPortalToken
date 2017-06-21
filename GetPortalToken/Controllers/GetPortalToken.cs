using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using RestSharp;
using MacRestSharpTest.Models;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.Xml;
using System.Configuration;

namespace MacRestSharpTest.Controllers
{

    public class GetPortalTokenController : ApiController
    {

        public string Get()
        {

            var impersonateUser = System.Configuration.ConfigurationManager.AppSettings["ImpersonateUser"];
            var impersonatePassword = HttpUtility.UrlEncode(System.Configuration.ConfigurationManager.AppSettings["ImpersonatePassword"]);
            var gisPortalTokenEndpoint = System.Configuration.ConfigurationManager.AppSettings["GISPortalTokenEndpoint"];
            var referrerType = System.Configuration.ConfigurationManager.AppSettings["ReferrerType"];
            var responseFormat = System.Configuration.ConfigurationManager.AppSettings["ResponseFormat"];

            var formParameters = "username=" + impersonateUser + "&password=" + impersonatePassword + "&client=" + referrerType + "&f=" + responseFormat; 


            var client = new RestClient(gisPortalTokenEndpoint);
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddParameter("application/x-www-form-urlencoded", formParameters, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            PortalToken portaltoken = JsonConvert.DeserializeObject<PortalToken>(response.Content.ToString());

            return portaltoken.Token;

        }
    }
}