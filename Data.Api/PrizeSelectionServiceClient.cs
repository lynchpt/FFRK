using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using FFRK.Api.Infra.Options.EnlirETL;
using FFRKApi.Model.Api.Banners;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace FFRKApi.Data.Api
{
    public interface IPrizeSelectionServiceClient
    {
        IList<PrizeResultRow> SelectPrizesSingle(IList<SelectionDomain> selectionDomains);
    }

    public class PrizeSelectionServiceClient : IPrizeSelectionServiceClient
    {
        #region Class Variables
        private readonly HttpClient _client;
        private readonly ApiExternalWebsiteOptions _options;
        private readonly ILogger<PrizeSelectionServiceClient> _logger;
        private const string BasePath = "v1.0/PrizeSelection";
        #endregion

        #region Cosntructors
        public PrizeSelectionServiceClient(HttpClient client, IOptions<ApiExternalWebsiteOptions> apiExternalWebsiteOptionsAccessor, 
            ILogger<PrizeSelectionServiceClient> logger)
        {            
            _options = apiExternalWebsiteOptionsAccessor.Value;
            _client = client;
            _client.BaseAddress = new Uri(_options.PrizeSelectionUrl);
            _logger = logger;
        }
        #endregion

        #region IPrizeSelectionServiceClient Implementation
        public IList<PrizeResultRow> SelectPrizesSingle(IList<SelectionDomain> selectionDomains)
        {
            IList<PrizeResultRow> results = new List<PrizeResultRow>();

            string serializedSelectionDomains = JsonConvert.SerializeObject(selectionDomains);

            //set up post content
            HttpContent content = new StringContent(serializedSelectionDomains);
            content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");

            //call actual api
            var httpResponse = _client.PostAsync($"{BasePath}/PrizeResults", content).Result;

            //retrieve and deserialize api response data to object.
            string resultString = httpResponse.Content.ReadAsStringAsync().Result;
            results = JsonConvert.DeserializeObject<IList<PrizeResultRow>>(resultString);

            return results;
        } 
        #endregion
    }
}
