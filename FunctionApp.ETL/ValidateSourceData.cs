using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FFRKApi.Logic.EnlirImport;
using FunctionApp.ETL.DISupport;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using FFRKApi.Logic.Validation.Enlir;

namespace FFRKApi.FunctionApp.ETL
{
    public static class ValidateSourceData
    {
        [FunctionName("ValidateSourceData")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]HttpRequestMessage req,
            [Inject]IImportValidator importValidator, [Inject]ILogger<IImportValidator> logger)
        {
            logger.LogInformation("Azure Function ValidateSourceData processed a request.");

            try
            {
                string failureInfo;

                bool isDataSourceValid = importValidator.TryValidateDataSource(out failureInfo);
                if (!isDataSourceValid)
                {
                    logger.LogWarning("Enlir Import Data not in Expected Format: \n" + failureInfo);
                    throw new Exception("Enlir Import Data not in Expected Format: \n" + failureInfo);
                }

                var response = req.CreateResponse(HttpStatusCode.OK, true);

                return response;
            }
            catch (System.Exception ex)
            {

                logger.LogError(ex, $"Error in Azure Function ValidateSourceData : {ex.Message}");

                var response = req.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);

                return response;
            }
       
        }
    }
}
