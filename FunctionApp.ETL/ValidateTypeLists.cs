using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FunctionApp.ETL.DISupport;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using FFRKApi.Model.EnlirImport;
using FFRKApi.Logic.Validation.Enlir;

namespace FFRKApi.FunctionApp.ETL
{
    public static class ValidateTypeLists
    {
        [FunctionName("ValidateTypeLists")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)]HttpRequestMessage req,
            [Inject]ITypeListValidator typeListValidator, [Inject]ILogger<ITypeListValidator> logger)
        {
            IEnumerable<TypeListDifferences> typeListDifferencesForError = null;

            logger.LogInformation("Azure Function ValidateTypeLists processed a request.");

            try
            {
                dynamic data = await req.Content.ReadAsAsync<object>();

                string datastring = data.ToString();

                //this data had better be serializable to ImportResultsContainer
                ImportResultsContainer irc = JsonConvert.DeserializeObject<ImportResultsContainer>(datastring);


                IEnumerable<TypeListDifferences> typeListDifferences = typeListValidator.TryValidateTypeLists(irc);
                if (typeListDifferences.Any(t => t.IsIdListDifferentFromSource))
                {
                    logger.LogWarning("Enlir TypeList Data differs from coded TypeLists.");

                    typeListDifferencesForError = typeListDifferences;

                    throw new Exception("Enlir Type List Data differs from coded TypeLists");
                }

                var response = req.CreateResponse(HttpStatusCode.OK, true);

                return response;
            }
            catch (System.Exception ex)
            {
                object message;

                logger.LogError(ex, $"Error in Azure Function ValidateTypeLists : {ex.Message}");

                if (typeListDifferencesForError != null)
                {
                    message = typeListDifferencesForError;
                }
                else
                {
                    message = ex.Message;
                }

                var response = req.CreateResponse(HttpStatusCode.InternalServerError, message);

                return response;
            }
        }
    }
}
