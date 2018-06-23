using System.Collections.Generic;

namespace FFRKApi.Dto.Api.Banners
{
    public class SelectionDomain
    {
        public string SelectionDomainName { get; set; }
        public int PrizesToSelectFromDomainCount { get; set; }
        public IList<PrizeSelectionRow> PrizeSelectionTable { get; set; }
    }
}
