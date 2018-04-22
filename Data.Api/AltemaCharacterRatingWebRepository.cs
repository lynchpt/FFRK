using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FFRK.Api.Infra.Options.EnlirETL;
using Microsoft.Extensions.Options;

namespace FFRKApi.Data.Api
{
    public class AltemaCharacterRatingWebRepository : IAltemaCharacterRatingRepository
    {
        #region Class Variables

        private readonly ApiExternalWebsiteOptions _apiExternalWebsiteOptions;
        #endregion

        #region Constructors

        public AltemaCharacterRatingWebRepository(IOptions<ApiExternalWebsiteOptions> apiExternalWebsiteOptionsAccessor)
        {
            _apiExternalWebsiteOptions = apiExternalWebsiteOptionsAccessor.Value;
        }
        #endregion

        public Stream GetAltemaCharacterRatingStream()
        {
            HttpClient client = new HttpClient();

            Stream webStream = null;

            try
            {
                webStream = client.GetStreamAsync(_apiExternalWebsiteOptions.AltemaCharacterRatingsUrl).Result;
            }
            catch (Exception)
            {
                //swallow, leave webStream null
            }

            return webStream;
        }

        public string GetAltemaCharacterRatingString()
        {
            HttpClient client = new HttpClient();

            string html = null;

            try
            {
                html = client.GetStringAsync(_apiExternalWebsiteOptions.AltemaCharacterRatingsUrl).Result;
            }
            catch (Exception)
            {
                //swallow, leave html null
            }

            return html;
        }
    }
}
