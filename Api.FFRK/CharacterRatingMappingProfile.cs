using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FFRKApi.Model.Api.CharacterRating;
using D = FFRKApi.Dto.Api.CharacterRating;

namespace FFRKApi.Api.FFRK
{
    public class CharacterRatingMappingProfile : Profile
    {
        public CharacterRatingMappingProfile()
        {
            CreateMap<AltemaCharacterInfo, D.AltemaCharacterInfo>();
            CreateMap<D.AltemaCharacterInfo, AltemaCharacterInfo>();

            CreateMap<CharacterRatingContextInfo, D.CharacterRatingContextInfo>();
            CreateMap<D.CharacterRatingContextInfo, CharacterRatingContextInfo>();

            CreateMap<LegendMateriaSummaryInfo, D.LegendMateriaSummaryInfo>();
            CreateMap<D.LegendMateriaSummaryInfo, LegendMateriaSummaryInfo>();

            CreateMap<RatingPool, D.RatingPool>();
            CreateMap<D.RatingPool, RatingPool>();

            CreateMap<RatingPoolRankInfo, D.RatingPoolRankInfo>();
            CreateMap<D.RatingPoolRankInfo, RatingPoolRankInfo>();
        }
    }
}
