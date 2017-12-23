using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FFRK.Api.Infra.Options.EnlirETL;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Options;

namespace FunctionApp.ETL
{
    public static class ExecuteImport
    {
        [FunctionName("ExecuteImport")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]HttpRequestMessage req, TraceWriter log, 
            [Inject(typeof(IOptions<SheetsServiceOptions>))]IOptions<SheetsServiceOptions> options)
        {
            log.Info("C# HTTP trigger function processed a request.");

            SheetsServiceOptions opt = options.Value;

            // parse query parameter
            string name = req.GetQueryNameValuePairs()
                .FirstOrDefault(q => string.Compare(q.Key, "name", true) == 0)
                .Value;

            // Get request body
            dynamic data = await req.Content.ReadAsAsync<object>();

            // Set name to query string or body data
            name = name ?? data?.name;

            //List<string> results = new List<string>(){"one", "two"};

            //var res = req.CreateResponse(HttpStatusCode.OK, results);

            return name == null
                ? req.CreateResponse(HttpStatusCode.BadRequest, "Please pass a name on the query string or in the request body")
                : req.CreateResponse(HttpStatusCode.OK, "Hello " + name);
        }
    }
}
