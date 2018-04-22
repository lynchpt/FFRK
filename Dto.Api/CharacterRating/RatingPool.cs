using System.Collections.Generic;

namespace FFRKApi.Dto.Api.CharacterRating
{
    public class RatingPool
    {
        public string RatingPoolName { get; set; } //e.g. LegendDiveMoteType
        public int RatingPoolMemberCount => CharactersInRatingPool?.Count ?? 0;
        public IList<CharacterRatingContextInfo> CharactersInRatingPool { get; set; }
    }
}
