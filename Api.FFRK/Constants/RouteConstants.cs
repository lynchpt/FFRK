﻿using System;
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


        //Maintenance Routes
        public const string MaintenanceRoute_DataStatus = "DataStatus";
    }
}
