using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FFRKApi.Model.Api;
using FFRKApi.Model.EnlirTransform;
using Microsoft.AspNetCore.Hosting.Internal;
using D = FFRKApi.Dto.Api;

namespace FFRKApi.Api.FFRK
{
    public class EnlirTransformMappingProfile : Profile
    {
        public EnlirTransformMappingProfile()
        {
            CreateMap<Ability, D.Ability>();
            CreateMap<D.Ability, Ability>();

            CreateMap<OrbRequirementsByRankInfo, D.OrbRequirementsByRankInfo>();
            CreateMap<D.OrbRequirementsByRankInfo, OrbRequirementsByRankInfo>();


            CreateMap<Character, D.Character>();
            CreateMap<D.Character, Character>();

            CreateMap<StatsByLevelInfo, D.StatsByLevelInfo>();
            CreateMap<D.StatsByLevelInfo, StatsByLevelInfo>();

            CreateMap<SchoolAccessInfo, D.SchoolAccessInfo>();
            CreateMap<D.SchoolAccessInfo, SchoolAccessInfo>();

            CreateMap<EquipmentAccessInfo, D.EquipmentAccessInfo>();
            CreateMap<D.EquipmentAccessInfo, EquipmentAccessInfo>();


            CreateMap<Command, D.Command>();
            CreateMap<D.Command, Command>();


            CreateMap<Dungeon, D.Dungeon>();
            CreateMap<D.Dungeon, Dungeon>();


            CreateMap<Event, D.Event>();
            CreateMap<D.Event, Event>();


            CreateMap<Experience, D.Experience>();
            CreateMap<D.Experience, Experience>();

            CreateMap<ExperienceByLevelInfo, D.ExperienceByLevelInfo>();
            CreateMap<D.ExperienceByLevelInfo, ExperienceByLevelInfo>();


            CreateMap<ItemWithCountAndStarLevel, D.ItemWithCountAndStarLevel>();
            CreateMap<D.ItemWithCountAndStarLevel, ItemWithCountAndStarLevel>();

            CreateMap<ItemWithItemCount, D.ItemWithItemCount>();
            CreateMap<D.ItemWithItemCount, ItemWithItemCount>();

            CreateMap<ItemWithStarLevel, D.ItemWithStarLevel>();
            CreateMap<D.ItemWithStarLevel, ItemWithStarLevel>();

            CreateMap<LegendMateria, D.LegendMateria>();
            CreateMap<D.LegendMateria, LegendMateria>();

            CreateMap<LegendSphere, D.LegendSphere>();
            CreateMap<D.LegendSphere, LegendSphere>();

            CreateMap<LegendSphereInfo, D.LegendSphereInfo>();
            CreateMap<D.LegendSphereInfo, LegendSphereInfo>();

            CreateMap<Magicite, D.Magicite>();
            CreateMap<D.Magicite, Magicite>();

            CreateMap<UltraSkill, D.UltraSkill>();
            CreateMap<D.UltraSkill, UltraSkill>();

            CreateMap<PassiveEffectValueByLevelInfo, D.PassiveEffectValueByLevelInfo>();
            CreateMap<D.PassiveEffectValueByLevelInfo, PassiveEffectValueByLevelInfo>();

            CreateMap<MagiciteSkill, D.MagiciteSkill>();
            CreateMap<D.MagiciteSkill, MagiciteSkill>();

            CreateMap<Mission, D.Mission>();
            CreateMap<D.Mission, Mission>();

            CreateMap<Other, D.Other>();
            CreateMap<D.Other, Other>();

            CreateMap<RecordMateria, D.RecordMateria>();
            CreateMap<D.RecordMateria, RecordMateria>();

            CreateMap<RecordSphere, D.RecordSphere>();
            CreateMap<D.RecordSphere, RecordSphere>();

            CreateMap<RecordSphereLevel, D.RecordSphereLevel>();
            CreateMap<D.RecordSphereLevel, RecordSphereLevel>();

            CreateMap<Relic, D.Relic>();
            CreateMap<D.Relic, Relic>();

            CreateMap<SoulBreak, D.SoulBreak>();
            CreateMap<D.SoulBreak, SoulBreak>();

            CreateMap<Status, D.Status>();
            CreateMap<D.Status, Status>();

            CreateMap<TypeListBundle, D.TypeListBundle>();
            CreateMap<D.TypeListBundle, TypeListBundle>();

            CreateMap<IdListBundle, D.IdListBundle>();
            CreateMap<D.IdListBundle, IdListBundle>();
        }

    }
}
