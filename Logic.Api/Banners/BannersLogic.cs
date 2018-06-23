using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Api;
using FFRKApi.Data.Api;
using FFRKApi.Data.Storage;
using FFRKApi.Model.Api.Banners;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace FFRKApi.Logic.Api.Banners
{
    public interface IBannersLogic
    {
        IList<PullResultRow> GetPullResults(string bannerId);
    }

    public class BannersLogic : IBannersLogic
    {
        #region Class Variables
        private readonly IBannerSpecProvider _bannerSpecProvider;
        private readonly IPrizeSelectionServiceClient _prizeSelectionServiceClient;
        private readonly ILogger<BannersLogic> _logger;
        private readonly ICacheProvider _cacheProvider;

        private const string MetadataPrefix = "md_";
        private const string StorageExtension = ".json";
        #endregion

        #region Constructors

        public BannersLogic(IBannerSpecProvider bannerSpecProvider, IPrizeSelectionServiceClient prizeSelectionServiceClient,
            ICacheProvider cacheProvider, ILogger<BannersLogic> logger)
        {
            _bannerSpecProvider = bannerSpecProvider;
            _prizeSelectionServiceClient = prizeSelectionServiceClient;
            _logger = logger;
            _cacheProvider = cacheProvider;
        }
        #endregion


        #region IBannersLogic Implementation
        public IList<PullResultRow> GetPullResults(string bannerId)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetPullResults)}");

            IList<PullResultRow> pullResultRows = new List<PullResultRow>();
            if (String.IsNullOrWhiteSpace(bannerId)) return pullResultRows;

            //resolve banner spec
            string cacheKeyBannerSpec = $"{nameof(BannersLogic)}:BannerSpec:{bannerId}";
            IList<SelectionDomain> bannerSpec = _cacheProvider.ObjectGet<IList<SelectionDomain>>(cacheKeyBannerSpec);

            if (bannerSpec == null)
            {
                string bannerSpecStorageName = $"{bannerId}{StorageExtension}";
                string bannerSpecString = _bannerSpecProvider.GetBannerSpec(bannerSpecStorageName);
                bannerSpec = JsonConvert.DeserializeObject<IList<SelectionDomain>>(bannerSpecString);

                _cacheProvider.ObjectSet(cacheKeyBannerSpec, bannerSpec);
            }

            //resolve metadata
            string cacheKeyBannerMetadata = $"{nameof(BannersLogic)}:BannerMetadata:{bannerId}";
            IList<BannerRelicMetadata> bannerMetadata = _cacheProvider.ObjectGet<IList<BannerRelicMetadata>>(cacheKeyBannerMetadata);

            if (bannerMetadata == null)
            {
                string bannerMetadataStorageName = $"{MetadataPrefix}{bannerId}{StorageExtension}";
                string bannerMetadataString = _bannerSpecProvider.GetBannerMetadata(bannerMetadataStorageName);
                bannerMetadata = JsonConvert.DeserializeObject<IList<BannerRelicMetadata>>(bannerMetadataString);

                _cacheProvider.ObjectSet(cacheKeyBannerMetadata, bannerMetadata);
            }

            //get prize results
            IList<PrizeResultRow> prizeResultRows = _prizeSelectionServiceClient.SelectPrizesSingle(bannerSpec);

            //use metadata to convert prize results to pull results
            pullResultRows = ConvertPrizeResultsToPullResults(prizeResultRows, bannerMetadata);


            return pullResultRows;
        }
        #endregion

        #region Private Methods

        private IList<PullResultRow> ConvertPrizeResultsToPullResults(IList<PrizeResultRow> prizeResultRows, IList<BannerRelicMetadata> bannerMetadata)
        {
            IList<PullResultRow> pullResultRows = new List<PullResultRow>();

            if (prizeResultRows != null && prizeResultRows.Any())
            {
                pullResultRows = (from prize in prizeResultRows join md in bannerMetadata on prize.PrizeName equals md.RelicId.ToString()
                select new PullResultRow()
                       {
                           BannerSlot = md.BannerSlot,
                           SoulBreakName = md.SoulBreakName,
                           RelicName = md.RelicName,
                           CharacterName = md.CharacterName,
                           CharacterId = md.CharacterId,
                           SoulBreakId = md.SoulBreakId,
                           LegendMateriaId = md.LegendMateriaId,
                           LegendMateriaName = md.LegendMateriaName,
                           RelicId = md.RelicId,
                           SoulBreakTierType = md.SoulBreakTierType,
                           SoulBreakTierName = md.SoulBreakTierName,
                           CategoryName = prize.PrizeCategoryName,
                           SelectedCount = prize.PrizeSelectedCount
                       }).OrderBy(r => r.BannerSlot).ToList();
            }


            return pullResultRows;
        }

        #endregion


    }
}
