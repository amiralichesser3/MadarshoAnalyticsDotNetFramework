using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace MadarshoAnalyticsDotNetFramework.Handlers
{
    public class ApiKeyHandler : DelegatingHandler
    {
        //set a default API key 
        private readonly string MY_API_KEY = System.Configuration.ConfigurationManager.AppSettings["api_key"];

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            bool isValidApiKey = false;
            IEnumerable<string> lsHeaders;
            //Validate that the api key exists

            var checkApiKeyExists = request.Headers.TryGetValues("API_KEY", out lsHeaders);

            if (checkApiKeyExists)
            {
                if (MY_API_KEY.Equals(lsHeaders.FirstOrDefault()))
                {
                    isValidApiKey = true;
                }
            }

            //If the key is not valid, return an http status code.
            if (!isValidApiKey)
                return request.CreateResponse(HttpStatusCode.Forbidden, "Bad API Key");

            //Allow the request to process further down the pipeline
            var response = await base.SendAsync(request, cancellationToken);

            //Return the response back up the chain
            return response;
        }
    }
}