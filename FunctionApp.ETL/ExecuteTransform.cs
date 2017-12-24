using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FFRKApi.Logic.EnlirTransform;
using FFRKApi.Model.EnlirImport;
using FFRKApi.Model.EnlirTransform;
using FunctionApp.ETL.DISupport;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace FunctionApp.ETL
{
    public static class ExecuteTransform
    {
        [FunctionName("ExecuteTransform")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]HttpRequestMessage req, TraceWriter log,
            [Inject]ITransformManager transformManager, [Inject]ILogger<ITransformManager> logger)
        {
            logger.LogInformation("Azure Function ExecuteTransform processed a request.");

            try
            {
                dynamic data = await req.Content.ReadAsAsync<object>();

                string datastring = data.ToString();

                //this data had better be serializable to ImportResultsContainer
                ImportResultsContainer irc = JsonConvert.DeserializeObject<ImportResultsContainer>(datastring);

                TransformResultsContainer trc = transformManager.TransformAll(irc);

                var response = req.CreateResponse(HttpStatusCode.OK, trc);

                return response;
            }
            catch (System.Exception ex)
            {
                logger.LogError(ex, $"Error in Azure Function ExecuteTransform : {ex.Message}");

                var response = req.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);

                return response;
            }

        }
    }
}
