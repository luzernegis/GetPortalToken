using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using RestSharp;
using MacRestSharpTest.Models;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace MacRestSharpTest.Controllers
{

    public class GetPortalTokenController : ApiController
    {

        public string Get()
        {
            var client = new RestClient("https://gis.luzernecounty.org/portal/sharing/rest/generateToken");
            var request = new RestRequest(Method.POST);
            request.AddHeader("postman-token", "9c3b3863-cebd-30cc-acf3-ae12c17f0a69");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddParameter("application/x-www-form-urlencoded", "username=gissubscriber&password=U%24e4p%40idAcct&client=requestip&f=json", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            PortalToken portaltoken = JsonConvert.DeserializeObject<PortalToken>(response.Content.ToString());

            return portaltoken.Token;

        }
    }
}