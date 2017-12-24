using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FFRKApi.Data.Storage;
using FFRKApi.Model.EnlirMerge;
using FFRKApi.Model.EnlirTransform;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace FunctionApp.ETL
{
    public static class StoreMerge
    {
        [FunctionName("StoreMerge")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]HttpRequestMessage req,
            [Inject]IMergeStorageProvider mergeStorageProvider, [Inject]ILogger<IMergeStorageProvider> logger)
        {
            logger.LogInformation("Azure Function StoreMerge processed a request.");

            try
            {
                // parse query parameter -can be null
                string formattedDateString = req.GetQueryNameValuePairs()
                    .FirstOrDefault(q => string.Compare(q.Key, "formattedDateString", true) == 0)
                    .Value;

                // Get request body
                dynamic data = await req.Content.ReadAsAsync<object>();

                string datastring = data.ToString();

                //this data had better be serializable to MergeResultsContainer
                MergeResultsContainer mrc = JsonConvert.DeserializeObject<MergeResultsContainer>(datastring);


                string filePath = mergeStorageProvider.StoreMergeResults(mrc, formattedDateString);

                var response = req.CreateResponse(HttpStatusCode.OK, filePath);

                return response;
            }
            catch (System.Exception ex)
            {

                logger.LogError(ex, $"Error in Azure Function StoreMerge : {ex.Message}");

                var response = req.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);

                return response;
            }
        }
    }
}
