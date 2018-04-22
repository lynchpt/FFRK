using System;
using System.Collections.Generic;
using System.Text;

namespace FFRKApi.Model.Api.CharacterRating
{
    public class CharacterRatingContextInfo
    {
        public int CharacterId { get; set; }
        public string CharacterName { get; set; }

        public int AltemaCharacterRating { get; set; }

        public IList<string> Roles { get; set; }

        public IList<string> ProficientSchools { get; set; }


        public string LegendDiveMote1Type { get; set; }
        public string LegendDiveMote2Type { get; set; }

        public LegendMateriaSummaryInfo LegendMateria1 { get; set; }
        public LegendMateriaSummaryInfo LegendMateria2 { get; set; }

        public IList<LegendMateriaSummaryInfo> LegendMateriaFromRelics { get; set; }

        public IList<RatingPoolRankInfo> RatingPoolRankInfos { get; set; }
    }
}
