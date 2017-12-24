using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FFRK.Api.Infra.Options.EnlirETL;
using FFRKApi.Logic.EnlirImport;
using FFRKApi.Logic.EnlirTransform;
using FFRKApi.Model.EnlirImport;
using FunctionApp.ETL.DISupport;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FunctionApp.ETL
{
    public static class ExecuteImport
    {
        [FunctionName("ExecuteImport")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]HttpRequestMessage req, 
            [Inject]IImportManager importManager, [Inject]ILogger<IImportManager> logger)
        {
            logger.LogInformation("Azure Function ExecuteImport processed a request.");

            try
            {
                ImportResultsContainer irc = importManager.ImportAll();

                var response = req.CreateResponse(HttpStatusCode.OK, irc);

                return response;
            }
            catch (System.Exception ex)
            {

                logger.LogError(ex, $"Error in Azure Function ExecuteImport : {ex.Message}");

                var response = req.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);

                return response;
            }
        }
    }
}
