using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FFRKApi.Logic.EnlirImport;
using FFRKApi.Logic.EnlirTransform;
using FunctionApp.ETL.DISupport;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace FunctionApp.ETL
{
    public static class GetFormattedDate
    {
        [FunctionName("GetFormattedDate")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]HttpRequestMessage req,
            [Inject]ILogger<IImportManager> logger)
        {

            logger.LogInformation("Azure Function GetFormattedDate processed a request.");

            const string DateFormatSpecifier = "yyyy-MM-dd_hh-mm-ss";

            try
            {
                //user might pass a specific date in that they want formatted. The query string param will be "date" if so
                string date = req.GetQueryNameValuePairs()
                    .FirstOrDefault(q => string.Compare(q.Key, "date", true) == 0)
                    .Value;

                DateTime resolvedDate = DateTime.UtcNow;

                if (!String.IsNullOrWhiteSpace(date))
                {
                    DateTime submittedDate;

                    if (DateTime.TryParse(date, out submittedDate))
                    {
                        resolvedDate = submittedDate;
                    }
                }

                string formattedDateString = resolvedDate.ToString(DateFormatSpecifier);

                var response = req.CreateResponse(HttpStatusCode.OK, formattedDateString);
                //var response = req.CreateResponse(HttpStatusCode.InternalServerError, "Fake Failure");

                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error in Azure Function GetFormattedDate : {ex.Message}");

                var response = req.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);

                return response;
            }
        }
    }
}
