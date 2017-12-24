using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FFRKApi.Data.Storage;
using FFRKApi.Model.EnlirTransform;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace FunctionApp.ETL
{
    public static class StoreTransform
    {
        [FunctionName("StoreTransform")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]HttpRequestMessage req,
            [Inject(typeof(ITransformStorageProvider))]ITransformStorageProvider transformStorageProvider, [Inject(typeof(ILogger<ITransformStorageProvider>))]ILogger<ITransformStorageProvider> logger)
        {
            logger.LogInformation("Azure Function StoreTransform processed a request.");

            try
            {
                // parse query parameter - can be null
                string formattedDateString = req.GetQueryNameValuePairs()
                    .FirstOrDefault(q => string.Compare(q.Key, "formattedDateString", true) == 0)
                    .Value;

                // Get request body
                dynamic data = await req.Content.ReadAsAsync<object>();

                string datastring = data.ToString();

                //this data had better be serializable to TransformResultsContainer
                TransformResultsContainer trc = JsonConvert.DeserializeObject<TransformResultsContainer>(datastring);

                string filePath = transformStorageProvider.StoreTransformResults(trc, formattedDateString);

                var response = req.CreateResponse(HttpStatusCode.OK, filePath);

                return response;
            }
            catch (System.Exception ex)
            {
                logger.LogError(ex, $"Error in Azure Function StoreTransform : {ex.Message}");

                var response = req.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);

                return response;
            }
        }
    }
}
