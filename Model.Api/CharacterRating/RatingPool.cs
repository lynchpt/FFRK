using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFRKApi.Model.Api.CharacterRating
{
    public class RatingPool
    {
        public string RatingPoolName { get; set; } //e.g. LegendDiveMoteType
        public int RatingPoolMemberCount => CharactersInRatingPool?.Count ?? 0;
        public IList<CharacterRatingContextInfo> CharactersInRatingPool { get; set; }
    }
}
