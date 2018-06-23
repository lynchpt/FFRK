using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FFRKApi.Model.Api.Banners;
using D = FFRKApi.Dto.Api.Banners;

namespace FFRKApi.Api.FFRK
{
    public class BannersMappingProfile : Profile
    {
        public BannersMappingProfile()
        {
            CreateMap<BannerRelicMetadata, D.BannerRelicMetadata>();
            CreateMap<D.BannerRelicMetadata, BannerRelicMetadata>();

            CreateMap<PrizeResultRow, D.PrizeResultRow>();
            CreateMap<D.PrizeResultRow, PrizeResultRow>();

            CreateMap<PrizeSelectionRow, D.PrizeSelectionRow>();
            CreateMap<D.PrizeSelectionRow, PrizeSelectionRow>();

            CreateMap<PrizeSelectionsForSuccessInfo, D.PrizeSelectionsForSuccessInfo>();
            CreateMap<D.PrizeSelectionsForSuccessInfo, PrizeSelectionsForSuccessInfo>();

            CreateMap<PullResultRow, D.PullResultRow>();
            CreateMap<D.PullResultRow, PullResultRow>();

            CreateMap<SelectionDomain, D.SelectionDomain>();
            CreateMap<D.SelectionDomain, SelectionDomain>();
        }
    }
}
