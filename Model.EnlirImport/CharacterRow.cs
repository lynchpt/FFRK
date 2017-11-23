using System;
using System.Collections.Generic;
using System.Text;

namespace Model.EnlirImport
{
    public enum CharacterColumn
    {
        //General
        Realm = 0,
        Name = 1,

        //Level 50
        IntroducingEventLevel50 = 2,
        HPLevel50 = 3,
        ATKLevel50 = 4,
        DEFLevel50 = 5,
        MAGLevel50 = 6,
        RESLevel50 = 7,
        MNDLevel50 = 8,
        ACCLevel50 = 9,
        EVALevel50 = 10,
        SPDLevel50 = 11,

        //Level 65
        IntroducingEventLevel65 = 12,
        HPLevel65 = 13,
        ATKLevel65 = 14,
        DEFLevel65 = 15,
        MAGLevel65 = 16,
        RESLevel65 = 17,
        MNDLevel65 = 18,
        ACCLevel65 = 19,
        EVALevel65 = 20,
        SPDLevel65 = 21,

        //Level 80
        IntroducingEventLevel80 = 22,
        HPLevel80 = 23,
        ATKLevel80 = 24,
        DEFLevel80 = 25,
        MAGLevel80 = 26,
        RESLevel80 = 27,
        MNDLevel80 = 28,
        ACCLevel80 = 29,
        EVALevel80 = 30,
        SPDLevel80 = 31,

        //Level 99
        IntroducingEventLevel99 = 32,
        HPLevel99 = 33,
        ATKLevel99 = 34,
        DEFLevel99 = 35,
        MAGLevel99 = 36,
        RESLevel99 = 37,
        MNDLevel99 = 38,
        ACCLevel99 = 39,
        EVALevel99 = 40,
        SPDLevel99 = 41,

        //Weapon Access
        DaggerAccess = 42,
        SwordAccess = 43,
        KatanaAccess = 44,
        AxeAccess = 45,
        HammerAccess = 46,
        SpearAccess = 47,
        FistAccess = 48,
        RodAccess = 49,
        StaffAccess = 50,
        BowAccess = 51,
        InstrumentAccess = 52,
        WhipAccess = 53,
        ThrownAccess = 54,
        GunAccess = 55,
        BookAccess = 56,
        BlitzballAccess = 57,
        HairpinAccess = 58,
        GunarmAccess = 59,
        GamblingGearAccess = 60,
        DollAccess = 61,
        ShieldAccess = 62,
        HatAccess = 63,
        HelmAccess = 64,
        LightArmorAccess = 65,
        HeavyArmorAccess = 66,
        RobeAccess = 67,
        BracerAccess = 68,
        AccessoryAccess = 69,

        //Armor Access
        BlackMagicAccess = 70,
        WhiteMagicAccess = 71,
        CombatAccess = 72,
        SupportAccess = 73,
        CelerityAccess = 74,
        SummoningAccess = 75,
        SpellbladeAccess = 76,
        DragoonAccess = 77,
        MonkAccess = 78,
        ThiefAccess = 79,
        KnightAccess = 80,
        SamuraiAccess = 81,
        NinjaAccess = 82,
        BardAccess = 83,
        DancerAccess = 84,
        MachinistAccess = 85,
        DarknessAccess = 86,
        SharpshooterAccess = 87,
        WitchAccess = 88,
        HeavyAccess = 89,

        //Record Sphere
        IntroducingEventRecordSphere = 90,
        HPRecordSphere = 91,
        ATKRecordSphere = 92,
        DEFRecordSphere = 93,
        MAGRecordSphere = 94,
        RESRecordSphere = 95,
        MNDRecordSphere = 96,

        //Legend Sphere
        IntroducingEventLegendSphere = 97,
        HPLegendSphere = 98,
        ATKLegendSphere = 99,
        DEFLegendSphere = 100,
        MAGLegendSphere = 101,
        RESLegendSphere = 102,
        MNDLegendSphere = 103,
        SPDLegendSphere = 104
    }

    public class CharacterRow
    {     
        //GENERAL
        public string Realm { get; set; }
        public string Name { get; set; }

        //LEVEL 50
        public string IntroducingEventLevel50 { get; set; }
        public string HPLevel50 { get; set; }
        public string ATKLevel50 { get; set; }
        public string DEFLevel50 { get; set; }
        public string MAGLevel50 { get; set; }
        public string RESLevel50 { get; set; }
        public string MNDLevel50 { get; set; }
        public string ACCLevel50 { get; set; }
        public string EVALevel50 { get; set; }
        public string SPDLevel50 { get; set; }

        //LEVEL 65
        public string IntroducingEventLevel65 { get; set; }
        public string HPLevel65 { get; set; }
        public string ATKLevel65 { get; set; }
        public string DEFLevel65 { get; set; }
        public string MAGLevel65 { get; set; }
        public string RESLevel65 { get; set; }
        public string MNDLevel65 { get; set; }
        public string ACCLevel65 { get; set; }
        public string EVALevel65 { get; set; }
        public string SPDLevel65 { get; set; }

        //LEVEL 80
        public string IntroducingEventLevel80 { get; set; }
        public string HPLevel80 { get; set; }
        public string ATKLevel80 { get; set; }
        public string DEFLevel80 { get; set; }
        public string MAGLevel80 { get; set; }
        public string RESLevel80 { get; set; }
        public string MNDLevel80 { get; set; }
        public string ACCLevel80 { get; set; }
        public string EVALevel80 { get; set; }
        public string SPDLevel80 { get; set; }

        //LEVEL 99
        public string IntroducingEventLevel99 { get; set; }
        public string HPLevel99 { get; set; }
        public string ATKLevel99 { get; set; }
        public string DEFLevel99 { get; set; }
        public string MAGLevel99 { get; set; }
        public string RESLevel99 { get; set; }
        public string MNDLevel99 { get; set; }
        public string ACCLevel99 { get; set; }
        public string EVALevel99 { get; set; }
        public string SPDLevel99 { get; set; }

        //Equipment Access
        public string DaggerAccess { get; set; }
        public string SwordAccess { get; set; }
        public string KatanaAccess { get; set; }
        public string AxeAccess { get; set; }
        public string HammerAccess { get; set; }
        public string SpearAccess { get; set; }
        public string FistAccess { get; set; }
        public string RodAccess { get; set; }
        public string StaffAccess { get; set; }
        public string BowAccess { get; set; }
        public string InstrumentAccess { get; set; }
        public string WhipAccess { get; set; }
        public string ThrownAccess { get; set; }
        public string GunAccess { get; set; }
        public string BookAccess { get; set; }
        public string BlitzballAccess { get; set; }
        public string HairpinAccess { get; set; }
        public string GunarmAccess { get; set; }
        public string GamblingGearAccess { get; set; }
        public string DollAccess { get; set; }
        public string ShieldAccess { get; set; }
        public string HatAccess { get; set; }
        public string HelmAccess { get; set; }
        public string LightArmorAccess { get; set; }
        public string HeavyArmorAccess { get; set; }
        public string RobeAccess { get; set; }
        public string BracerAccess { get; set; }
        public string AccessoryAccess { get; set; }

        //Ability Access

        public string BlackMagicAccess { get; set; }
        public string WhiteMagicAccess { get; set; }
        public string CombatAccess { get; set; }
        public string SupportAccess { get; set; }
        public string CelerityAccess { get; set; }
        public string SummoningAccess { get; set; }
        public string SpellbladeAccess { get; set; }
        public string DragoonAccess { get; set; }
        public string MonkAccess { get; set; }
        public string ThiefAccess { get; set; }
        public string KnightAccess { get; set; }
        public string SamuraiAccess { get; set; }
        public string NinjaAccess { get; set; }
        public string BardAccess { get; set; }
        public string DancerAccess { get; set; }
        public string MachinistAccess { get; set; }
        public string DarknessAccess { get; set; }
        public string SharpshooterAccess { get; set; }
        public string WitchAccess { get; set; }
        public string HeavyAccess { get; set; }

        //Record Sphere
        public string IntroducingEventRecordSphere { get; set; }
        public string HPRecordSphere  { get; set; }
        public string ATKRecordSphere  { get; set; }
        public string DEFRecordSphere  { get; set; }
        public string MAGRecordSphere  { get; set; }
        public string RESRecordSphere  { get; set; }
        public string MNDRecordSphere  { get; set; }


        //Legend Sphere
        public string IntroducingEventLegendSphere{ get; set; }
        public string HPLegendSphere{ get; set; }
        public string ATKLegendSphere{ get; set; }
        public string DEFLegendSphere{ get; set; }
        public string MAGLegendSphere{ get; set; }
        public string RESLegendSphere{ get; set; }
        public string MNDLegendSphere{ get; set; }
        public string SPDLegendSphere { get; set; }

    }
}
