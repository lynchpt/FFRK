using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace FFRKApi.Api.FFRK.Constants
{
    public class RouteConstants
    {
        public const string ContentType_ApplicationJson = "application/json";

        public const string BaseRoute = "api/v1.0/[controller]"; //to handle versioning

        //IdList Routes
        public const string IdListsRoute_All = "";
        public const string IdListsRoute_Ability = "Ability";
        public const string IdListsRoute_Character = "Character";
        public const string IdListsRoute_Command = "Command";
        public const string IdListsRoute_Dungeon = "Dungeon";
        public const string IdListsRoute_Event = "Event";
        public const string IdListsRoute_Experience = "Experience";
        public const string IdListsRoute_LegendMateria = "LegendMateria";
        public const string IdListsRoute_LegendSphere = "LegendSphere";
        public const string IdListsRoute_Magicite = "Magicite";
        public const string IdListsRoute_MagiciteSkill = "MagiciteSkill";
        public const string IdListsRoute_Mission = "Mission";
        public const string IdListsRoute_Other = "Other";
        public const string IdListsRoute_RecordMateria = "RecordMateria";
        public const string IdListsRoute_RecordSphere = "RecordSphere";
        public const string IdListsRoute_Relic = "Relic";
        public const string IdListsRoute_SoulBreak = "SoulBreak";
        public const string IdListsRoute_Status = "Status";


        //TypeList Routes
        public const string TypeListsRoute_All = "";
        public const string TypeListsRoute_AbilityType = "AbilityType";
        public const string TypeListsRoute_AutoTargetType = "AutoTargetType";
        public const string TypeListsRoute_DamageFormulaType = "DamageFormulaType";
        public const string TypeListsRoute_ElementType = "ElementType";
        public const string TypeListsRoute_EquipmentType = "EquipmentType";
        public const string TypeListsRoute_EventType = "EventType";
        public const string TypeListsRoute_MissionType = "MissionType";
        public const string TypeListsRoute_OrbType = "OrbType";
        public const string TypeListsRoute_RealmType = "RealmType";
        public const string TypeListsRoute_RelicType = "RelicType";
        public const string TypeListsRoute_SchoolType = "SchoolType";
        public const string TypeListsRoute_SoulBreakTierType = "SoulBreakTierType";
        public const string TypeListsRoute_TargetType = "TargetType";

        //Abilities Routes
        public const string AbilitiesRoute_All = "";
        public const string AbilitiesRoute_Id = "{abilityId}";
        public const string AbilitiesRoute_AbilityType = "AbilityType/{abilityType}";
        public const string AbilitiesRoute_Rarity = "Rarity/{rarity}";
        public const string AbilitiesRoute_School = "School/{schoolType}";
        public const string AbilitiesRoute_Element = "Element/{elementType}";
        public const string AbilitiesRoute_Search = "Search"; //POST

        //Characters Routes
        public const string CharactersRoute_All = "";
        public const string CharactersRoute_Id = "{characterId}";
        public const string CharactersRoute_RealmType = "RealmType/{realmType}";
        public const string CharactersRoute_Name = "Name/{characterName}";
        public const string CharactersRoute_Equipment = "Equipment/{equipmentType}";
        public const string CharactersRoute_School = "School/{schoolType}/{schoolMinLevel}";
        public const string CharactersRoute_Search = "Search"; //POST


        //Commands Routes
        public const string CommandsRoute_All = "";
        public const string CommandsRoute_Id = "{commandId}";
        public const string CommandsRoute_AbilityType = "AbilityType/{abilityType}";
        public const string CommandsRoute_Character = "Character/{characterId}";
        public const string CommandsRoute_School = "School/{schoolType}";
        public const string CommandsRoute_Element = "Element/{elementType}";
        public const string CommandsRoute_Search = "Search"; //POST

        //Dungeons Routes
        public const string DungeonsRoute_All = "";
        public const string DungeonsRoute_Id = "{dungeonId}";
        public const string DungeonsRoute_RealmType = "RealmType/{realmType}";
        public const string DungeonsRoute_Name = "Name/{dungeonName}";
        public const string DungeonsRoute_Rewards = "Rewards/{itemName}/{starLevel}";
        public const string DungeonsRoute_Search = "Search"; //POST


        //Events Routes
        public const string EventsRoute_All = "";
        public const string EventsRoute_Id = "{eventId}";
        public const string EventsRoute_Name = "Name/{eventName}";
        public const string EventsRoute_RealmType = "RealmType/{realmType}";
        public const string EventsRoute_EventType = "EventType/{eventType}";
        public const string EventsRoute_HeroRecords = "HeroRecords/{characterName}";
        public const string EventsRoute_MemoryCrystal1 = "MemoryCrystal1/{characterName}";
        public const string EventsRoute_MemoryCrystal2 = "MemoryCrystal2/{characterName}";
        public const string EventsRoute_MemoryCrystal3 = "MemoryCrystal3/{characterName}";
        public const string EventsRoute_SoulOfHero = "SoulOfHero";
        public const string EventsRoute_MemoryLode1 = "MemoryLode1";
        public const string EventsRoute_MemoryLode2 = "MemoryLode2";
        public const string EventsRoute_MemoryLode3 = "MemoryLode3";
        public const string EventsRoute_WardrobeRecord = "WardrobeRecord/{characterName}";
        public const string EventsRoute_Abilities = "Abilities/{abilityName}";


        //Experiences Routes
        public const string ExperiencesRoute_All = "";


        //LegendMaterias Routes
        public const string LegendMateriasRoute_All = "";
        public const string LegendMateriasRoute_Id = "{legendMateriaId}";
        public const string LegendMateriasRoute_RealmType = "RealmType/{realmType}";
        public const string LegendMateriasRoute_Name = "Name/{legendMateriaName}";
        public const string LegendMateriasRoute_Character = "Character/{characterId}";
        public const string LegendMateriasRoute_Effect = "Effect/{effectText}";
        public const string LegendMateriasRoute_MasteryBonus = "MasteryBonus/{masteryBonusText}";
        public const string LegendMateriasRoute_Relic = "Relic/{relicId}"; //POST
        public const string LegendMateriasRoute_Search = "Search"; //POST


        //LegendSpheres Routes
        public const string LegendSpheresRoute_All = "";


        //Magicites Routes
        public const string MagicitesRoute_All = "";


        //MagiciteSkills Routes
        public const string MagiciteSkillsRoute_All = "";


        //Missions Routes
        public const string MissionsRoute_All = "";


        //Others Routes
        public const string OthersRoute_All = "";


        //RecordMaterias Routes
        public const string RecordMateriasRoute_All = "";


        //RecordSpheres Routes
        public const string RecordSpheresRoute_All = "";


        //Relics Routes
        public const string RelicsRoute_All = "";


        //SoulBreaks Routes
        public const string SoulBreaksRoute_All = "";


        //Statuses Routes
        public const string StatusesRoute_All = "";







        //Maintenance Routes
        public const string MaintenanceRoute_DataStatus = "DataStatus";
    }
}
