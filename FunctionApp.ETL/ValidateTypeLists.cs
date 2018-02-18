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
            //IEnumerable<TypeListDifferences> typeListDifferencesForError = null;

            logger.LogInformation("Azure Function ValidateTypeLists processed a request.");

            try
            {
                HttpResponseMessage response = null;

                dynamic data = await req.Content.ReadAsAsync<object>();

                string datastring = data.ToString();

                //this data had better be serializable to ImportResultsContainer
                ImportResultsContainer irc = JsonConvert.DeserializeObject<ImportResultsContainer>(datastring);


                IList<TypeListDifferences> typeListDifferences = typeListValidator.TryValidateTypeLists(irc).ToList();
                if (typeListDifferences.Any(t => t.IsIdListDifferentFromSource))
                {
                    logger.LogWarning("Enlir TypeList Data differs from coded TypeLists.");

                    //typeListDifferencesForError = typeListDifferences;

                    //throw new Exception("Enlir Type List Data differs from coded TypeLists");
                    response = req.CreateResponse(HttpStatusCode.OK, typeListDifferences);
                }
                else
                {
                    response = req.CreateResponse(HttpStatusCode.OK, true);
                }
                            
                return response;
            }
            catch (System.Exception ex)
            {
               

                logger.LogError(ex, $"Error in Azure Function ValidateTypeLists : {ex.Message}");

                var response = req.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);

                return response;
            }
        }
    }
}
