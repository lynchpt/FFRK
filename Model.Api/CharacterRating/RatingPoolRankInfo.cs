using System;
using System.Collections.Generic;
using System.Text;

namespace FFRKApi.Model.Api.CharacterRating
{
    public class RatingPoolRankInfo
    {
        public string RatingPoolName { get; set; } //e.g. LegendDiveMoteType
        public int RatingPoolMemberCount { get; set; } //e.g. 55

        public int CharacterRankInRatingPool { get; set; } //e.g. 4

    }
}
