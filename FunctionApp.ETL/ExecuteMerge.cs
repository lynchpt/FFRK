using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FFRKApi.Logic.EnlirMerge;
using FFRKApi.Logic.EnlirTransform;
using FFRKApi.Model.EnlirMerge;
using FFRKApi.Model.EnlirTransform;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace FunctionApp.ETL
{
    public static class ExecuteMerge
    {
        [FunctionName("ExecuteMerge")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]HttpRequestMessage req,
            [Inject(typeof(IMergeManager))]IMergeManager mergeManager, [Inject(typeof(ILogger<IMergeManager>))]ILogger<IMergeManager> logger)
        {
            logger.LogInformation("Azure Function ExecuteMerge processed a request.");

            try
            {
                dynamic data = await req.Content.ReadAsAsync<object>();

                string datastring = data.ToString();

                //this data had better be serializable to TranformResultsContainer
                TransformResultsContainer trc = JsonConvert.DeserializeObject<TransformResultsContainer>(datastring);

                MergeResultsContainer mrc = mergeManager.MergeAll(trc);

                var response = req.CreateResponse(HttpStatusCode.OK, mrc);

                return response;
            }
            catch (System.Exception ex)
            {
                logger.LogError(ex, $"Error in Azure Function ExecuteMerge : {ex.Message}");

                var response = req.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);

                return response;
            }
        }
    }
}
