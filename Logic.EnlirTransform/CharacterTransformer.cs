using System;
using System.Collections.Generic;
using System.Text;
using FFRKApi.Model.EnlirTransform;
using FFRKApi.Model.EnlirTransform.Converters;
using FFRKApi.Model.EnlirTransform.IdLists;
using Microsoft.Extensions.Logging;
using Model.EnlirImport;

namespace FFRKApi.Logic.EnlirTransform
{
    public class CharacterTransformer : RowTransformerBase<CharacterRow, Character>
    {
        #region Class Variables
        private readonly IntConverter _intConverter;
        private readonly TypeListConverter _realmConverter;
        private readonly StringToBooleanConverter _stringToBooleanConverter;

        #endregion

        #region Constructors
        public CharacterTransformer(ILogger<RowTransformerBase<CharacterRow, Character>> logger) : base(logger)
        {
            //prepare converters so we only need one instance no matter how many rows are processed
            _intConverter = new IntConverter();
            _stringToBooleanConverter = new StringToBooleanConverter();
            _realmConverter = new TypeListConverter(new RealmList());
        }
        #endregion

        #region RowTransformerBase Overrides
        protected override Character ConvertRowToModel(int generatedId, CharacterRow row)
        {
            Character model = new Character();

            model.Id = generatedId;
            model.Description = row.Name;

            model.CharacterName = row.Name;
            model.Realm = _realmConverter.ConvertFromNameToId(row.Realm);


            model.Relics = null; //filled in during merge phase
            model.RecordSpheres = null; //filled in during merge phase
            model.LegendSpheres = null;//filled in during merge phase
            model.RecordMaterias = null;  //filled in during merge phase
            model.LegendMaterias = null;  //filled in during merge phase

            model.StatsByLevelInfos = GetStatsByLevelInfos(row);

            model.StatIncrementsForRecordSpheres = GetStatIncrementsForRecordSpheres(row);

            model.StatIncrementsForLegendSpheres = GetStatIncrementsForLegendSpheres(row);

            model.SchoolAccessInfos = GetSchoolAccessInfos(row);

            model.EquipmentAccessInfos = GetEquipmentAccessInfos(row);

            _logger.LogDebug("Converted CharacterRow to Character: {Id} - {Description}", model.Id, model.Description);

            return model;
        }

        #endregion

        #region Private Methods
        private IEnumerable<StatsByLevelInfo> GetStatsByLevelInfos(CharacterRow row)
        {
            IList<StatsByLevelInfo> statsByLevelInfos = new List<StatsByLevelInfo>();

            //level 50
            StatsByLevelInfo sli50 = new StatsByLevelInfo()
                                     {
                                         Level = 50,
                                         IntroducingEvent = row.IntroducingEventLevel50,
                                         IntroducingEventId = 0, //filled in during merge phase
                                         HitPoints = _intConverter.ConvertFromStringToInt(row.HPLevel50),
                                         Attack = _intConverter.ConvertFromStringToInt(row.ATKLevel50),
                                         Defense = _intConverter.ConvertFromStringToInt(row.DEFLevel50),
                                         Magic = _intConverter.ConvertFromStringToInt(row.MAGLevel50),
                                         Resistance = _intConverter.ConvertFromStringToInt(row.RESLevel50),
                                         Mind = _intConverter.ConvertFromStringToInt(row.MNDLevel50),
                                         Accuracy = _intConverter.ConvertFromStringToInt(row.ACCLevel50),
                                         Evasion = _intConverter.ConvertFromStringToInt(row.EVALevel50),
                                         Speed = _intConverter.ConvertFromStringToInt(row.SPDLevel50)
                                    };
            statsByLevelInfos.Add(sli50);

            //level 65
            StatsByLevelInfo sli65 = new StatsByLevelInfo()
                                     {
                                         Level = 65,
                                         IntroducingEvent = row.IntroducingEventLevel65,
                                         IntroducingEventId = 0, //filled in during merge phase
                                         HitPoints = _intConverter.ConvertFromStringToInt(row.HPLevel65),
                                         Attack = _intConverter.ConvertFromStringToInt(row.ATKLevel65),
                                         Defense = _intConverter.ConvertFromStringToInt(row.DEFLevel65),
                                         Magic = _intConverter.ConvertFromStringToInt(row.MAGLevel65),
                                         Resistance = _intConverter.ConvertFromStringToInt(row.RESLevel65),
                                         Mind = _intConverter.ConvertFromStringToInt(row.MNDLevel65),
                                         Accuracy = _intConverter.ConvertFromStringToInt(row.ACCLevel65),
                                         Evasion = _intConverter.ConvertFromStringToInt(row.EVALevel65),
                                         Speed = _intConverter.ConvertFromStringToInt(row.SPDLevel65)
                                     };
            statsByLevelInfos.Add(sli65);

            //level 80
            StatsByLevelInfo sli80 = new StatsByLevelInfo()
                                     {
                                         Level = 80,
                                         IntroducingEvent = row.IntroducingEventLevel80,
                                         IntroducingEventId = 0, //filled in during merge phase
                                         HitPoints = _intConverter.ConvertFromStringToInt(row.HPLevel80),
                                         Attack = _intConverter.ConvertFromStringToInt(row.ATKLevel80),
                                         Defense = _intConverter.ConvertFromStringToInt(row.DEFLevel80),
                                         Magic = _intConverter.ConvertFromStringToInt(row.MAGLevel80),
                                         Resistance = _intConverter.ConvertFromStringToInt(row.RESLevel80),
                                         Mind = _intConverter.ConvertFromStringToInt(row.MNDLevel80),
                                         Accuracy = _intConverter.ConvertFromStringToInt(row.ACCLevel80),
                                         Evasion = _intConverter.ConvertFromStringToInt(row.EVALevel80),
                                         Speed = _intConverter.ConvertFromStringToInt(row.SPDLevel80)
                                     };
            statsByLevelInfos.Add(sli80);

            //level 99
            StatsByLevelInfo sli99 = new StatsByLevelInfo()
                                     {
                                         Level = 99,
                                         IntroducingEvent = row.IntroducingEventLevel99,
                                         IntroducingEventId = 0, //filled in during merge phase
                                         HitPoints = _intConverter.ConvertFromStringToInt(row.HPLevel99),
                                         Attack = _intConverter.ConvertFromStringToInt(row.ATKLevel99),
                                         Defense = _intConverter.ConvertFromStringToInt(row.DEFLevel99),
                                         Magic = _intConverter.ConvertFromStringToInt(row.MAGLevel99),
                                         Resistance = _intConverter.ConvertFromStringToInt(row.RESLevel99),
                                         Mind = _intConverter.ConvertFromStringToInt(row.MNDLevel99),
                                         Accuracy = _intConverter.ConvertFromStringToInt(row.ACCLevel99),
                                         Evasion = _intConverter.ConvertFromStringToInt(row.EVALevel99),
                                         Speed = _intConverter.ConvertFromStringToInt(row.SPDLevel99)
                                     };
            statsByLevelInfos.Add(sli99);


            return statsByLevelInfos;
        }

        private StatsByLevelInfo GetStatIncrementsForRecordSpheres(CharacterRow row)
        {
            StatsByLevelInfo sli = new StatsByLevelInfo()
                                   {
                                       Level = 0, //not relevant for record spheres
                                       IntroducingEvent = row.IntroducingEventRecordSphere,
                                       IntroducingEventId = 0, //filled in during merge phase
                                       HitPoints = _intConverter.ConvertFromStringToInt(row.HPRecordSphere),
                                       Attack = _intConverter.ConvertFromStringToInt(row.ATKRecordSphere),
                                       Defense = _intConverter.ConvertFromStringToInt(row.DEFRecordSphere),
                                       Magic = _intConverter.ConvertFromStringToInt(row.MAGRecordSphere),
                                       Resistance = _intConverter.ConvertFromStringToInt(row.RESRecordSphere),
                                       Mind = _intConverter.ConvertFromStringToInt(row.MNDRecordSphere),
                                       Accuracy = 0, //not relevant for record spheres
                                       Evasion = 0, //not relevant for record spheres
                                       Speed = 0 //not relevant for record spheres
            };


            return sli;
        }

        private StatsByLevelInfo GetStatIncrementsForLegendSpheres(CharacterRow row)
        {
            StatsByLevelInfo sli = new StatsByLevelInfo()
                                   {
                                       Level = 0, //not relevant for legend spheres
                                       IntroducingEvent = row.IntroducingEventLegendSphere,
                                       IntroducingEventId = 0, //filled in during merge phase
                                       HitPoints = _intConverter.ConvertFromStringToInt(row.HPLegendSphere),
                                       Attack = _intConverter.ConvertFromStringToInt(row.ATKLegendSphere),
                                       Defense = _intConverter.ConvertFromStringToInt(row.DEFLegendSphere),
                                       Magic = _intConverter.ConvertFromStringToInt(row.MAGLegendSphere),
                                       Resistance = _intConverter.ConvertFromStringToInt(row.RESLegendSphere),
                                       Mind = _intConverter.ConvertFromStringToInt(row.MNDLegendSphere),
                                       Accuracy = 0, //not relevant for legend spheres
                                       Evasion = 0, //not relevant for legend spheres
                                       Speed = _intConverter.ConvertFromStringToInt(row.SPDLegendSphere)
            };


            return sli;
        }

        private IEnumerable<SchoolAccessInfo> GetSchoolAccessInfos(CharacterRow row)
        {
            IList<SchoolAccessInfo> schoolAccessInfos = new List<SchoolAccessInfo>()
                {
                    new SchoolAccessInfo(){School = 3, SchoolName = "Bard", AccessLevel = _intConverter.ConvertFromStringToInt(row.BardAccess)},
                    new SchoolAccessInfo(){School = 4, SchoolName = "Black Magic", AccessLevel = _intConverter.ConvertFromStringToInt(row.BlackMagicAccess)},
                    new SchoolAccessInfo(){School = 5, SchoolName = "Celerity", AccessLevel = _intConverter.ConvertFromStringToInt(row.CelerityAccess)},
                    new SchoolAccessInfo(){School = 6, SchoolName = "Combat", AccessLevel = _intConverter.ConvertFromStringToInt(row.CombatAccess)},
                    new SchoolAccessInfo(){School = 7, SchoolName = "Dancer", AccessLevel = _intConverter.ConvertFromStringToInt(row.DancerAccess)},
                    new SchoolAccessInfo(){School = 8, SchoolName = "Darkness", AccessLevel = _intConverter.ConvertFromStringToInt(row.DarknessAccess)},
                    new SchoolAccessInfo(){School = 9, SchoolName = "Dragoon", AccessLevel = _intConverter.ConvertFromStringToInt(row.DragoonAccess)},
                    new SchoolAccessInfo(){School = 10, SchoolName = "Knight", AccessLevel = _intConverter.ConvertFromStringToInt(row.KnightAccess)},
                    new SchoolAccessInfo(){School = 11, SchoolName = "Machinist", AccessLevel = _intConverter.ConvertFromStringToInt(row.MachinistAccess)},
                    new SchoolAccessInfo(){School = 12, SchoolName = "Monk", AccessLevel = _intConverter.ConvertFromStringToInt(row.MonkAccess)},
                    new SchoolAccessInfo(){School = 13, SchoolName = "Ninja", AccessLevel = _intConverter.ConvertFromStringToInt(row.NinjaAccess)},
                    new SchoolAccessInfo(){School = 14, SchoolName = "Samurai", AccessLevel = _intConverter.ConvertFromStringToInt(row.SamuraiAccess)},
                    new SchoolAccessInfo(){School = 15, SchoolName = "Sharpshooter", AccessLevel = _intConverter.ConvertFromStringToInt(row.SharpshooterAccess)},
                    new SchoolAccessInfo(){School = 18, SchoolName = "Spellblade", AccessLevel = _intConverter.ConvertFromStringToInt(row.SpellbladeAccess)},
                    new SchoolAccessInfo(){School = 19, SchoolName = "Summoning", AccessLevel = _intConverter.ConvertFromStringToInt(row.SummoningAccess)},
                    new SchoolAccessInfo(){School = 20, SchoolName = "Support", AccessLevel = _intConverter.ConvertFromStringToInt(row.SupportAccess)},
                    new SchoolAccessInfo(){School = 21, SchoolName = "Thief", AccessLevel = _intConverter.ConvertFromStringToInt(row.ThiefAccess)},
                    new SchoolAccessInfo(){School = 22, SchoolName = "White Magic", AccessLevel = _intConverter.ConvertFromStringToInt(row.WhiteMagicAccess)},
                    new SchoolAccessInfo(){School = 23, SchoolName = "Witch", AccessLevel = _intConverter.ConvertFromStringToInt(row.WitchAccess)},
                    new SchoolAccessInfo(){School = 24, SchoolName = "Heavy", AccessLevel = _intConverter.ConvertFromStringToInt(row.HeavyAccess)}

                };


            return schoolAccessInfos;
        }

        private IEnumerable<EquipmentAccessInfo> GetEquipmentAccessInfos(CharacterRow row)
        {
            IList<EquipmentAccessInfo> schoolAccessInfos = new List<EquipmentAccessInfo>()
                {
                    new EquipmentAccessInfo(){EquipmentType = 1, EquipmentName = "Dagger", IsWeapon = true, CanAccess = _stringToBooleanConverter.ConvertFromStringToBool(row.DaggerAccess)},
                    new EquipmentAccessInfo(){EquipmentType = 2, EquipmentName = "Sword", IsWeapon = true, CanAccess = _stringToBooleanConverter.ConvertFromStringToBool(row.SwordAccess)},
                    new EquipmentAccessInfo(){EquipmentType = 3, EquipmentName = "Katana", IsWeapon = true, CanAccess = _stringToBooleanConverter.ConvertFromStringToBool(row.KatanaAccess)},
                    new EquipmentAccessInfo(){EquipmentType = 4, EquipmentName = "Axe", IsWeapon = true, CanAccess = _stringToBooleanConverter.ConvertFromStringToBool(row.AxeAccess)},
                    new EquipmentAccessInfo(){EquipmentType = 5, EquipmentName = "Hammer", IsWeapon = true, CanAccess = _stringToBooleanConverter.ConvertFromStringToBool(row.HammerAccess)},
                    new EquipmentAccessInfo(){EquipmentType = 6, EquipmentName = "Spear", IsWeapon = true, CanAccess = _stringToBooleanConverter.ConvertFromStringToBool(row.SpearAccess)},
                    new EquipmentAccessInfo(){EquipmentType = 7, EquipmentName = "Fist", IsWeapon = true, CanAccess = _stringToBooleanConverter.ConvertFromStringToBool(row.FistAccess)},
                    new EquipmentAccessInfo(){EquipmentType = 8, EquipmentName = "Rod", IsWeapon = true, CanAccess = _stringToBooleanConverter.ConvertFromStringToBool(row.RodAccess)},
                    new EquipmentAccessInfo(){EquipmentType = 9, EquipmentName = "Staff", IsWeapon = true, CanAccess = _stringToBooleanConverter.ConvertFromStringToBool(row.StaffAccess)},
                    new EquipmentAccessInfo(){EquipmentType = 10, EquipmentName = "Bow", IsWeapon = true, CanAccess = _stringToBooleanConverter.ConvertFromStringToBool(row.BowAccess)},
                    new EquipmentAccessInfo(){EquipmentType = 11, EquipmentName = "Instrument", IsWeapon = true, CanAccess = _stringToBooleanConverter.ConvertFromStringToBool(row.InstrumentAccess)},
                    new EquipmentAccessInfo(){EquipmentType = 12, EquipmentName = "Whip", IsWeapon = true, CanAccess = _stringToBooleanConverter.ConvertFromStringToBool(row.WhipAccess)},
                    new EquipmentAccessInfo(){EquipmentType = 13, EquipmentName = "Thrown", IsWeapon = true, CanAccess = _stringToBooleanConverter.ConvertFromStringToBool(row.ThrownAccess)},
                    new EquipmentAccessInfo(){EquipmentType = 14, EquipmentName = "Gun", IsWeapon = true, CanAccess = _stringToBooleanConverter.ConvertFromStringToBool(row.GunAccess)},
                    new EquipmentAccessInfo(){EquipmentType = 15, EquipmentName = "Book", IsWeapon = true, CanAccess = _stringToBooleanConverter.ConvertFromStringToBool(row.BookAccess)},
                    new EquipmentAccessInfo(){EquipmentType = 16, EquipmentName = "Blitzball", IsWeapon = true, CanAccess = _stringToBooleanConverter.ConvertFromStringToBool(row.BlitzballAccess)},
                    new EquipmentAccessInfo(){EquipmentType = 17, EquipmentName = "Hairpin", IsWeapon = true, CanAccess = _stringToBooleanConverter.ConvertFromStringToBool(row.HairpinAccess)},
                    new EquipmentAccessInfo(){EquipmentType = 18, EquipmentName = "Gun-arm", IsWeapon = true, CanAccess = _stringToBooleanConverter.ConvertFromStringToBool(row.GunarmAccess)},
                    new EquipmentAccessInfo(){EquipmentType = 19, EquipmentName = "Gambling Gear", IsWeapon = true, CanAccess = _stringToBooleanConverter.ConvertFromStringToBool(row.GamblingGearAccess)},
                    new EquipmentAccessInfo(){EquipmentType = 20, EquipmentName = "Doll", IsWeapon = true, CanAccess = _stringToBooleanConverter.ConvertFromStringToBool(row.DollAccess)},
                    new EquipmentAccessInfo(){EquipmentType = 21, EquipmentName = "Shield", IsWeapon = false, CanAccess = _stringToBooleanConverter.ConvertFromStringToBool(row.ShieldAccess)},
                    new EquipmentAccessInfo(){EquipmentType = 22, EquipmentName = "Hat", IsWeapon = false, CanAccess = _stringToBooleanConverter.ConvertFromStringToBool(row.HatAccess)},
                    new EquipmentAccessInfo(){EquipmentType = 23, EquipmentName = "Helm", IsWeapon = false, CanAccess = _stringToBooleanConverter.ConvertFromStringToBool(row.HelmAccess)},
                    new EquipmentAccessInfo(){EquipmentType = 24, EquipmentName = "Light Armor",IsWeapon = false,  CanAccess = _stringToBooleanConverter.ConvertFromStringToBool(row.LightArmorAccess)},
                    new EquipmentAccessInfo(){EquipmentType = 25, EquipmentName = "Heavy Armor", IsWeapon = false, CanAccess = _stringToBooleanConverter.ConvertFromStringToBool(row.HeavyArmorAccess)},
                    new EquipmentAccessInfo(){EquipmentType = 26, EquipmentName = "Robe", IsWeapon = false, CanAccess = _stringToBooleanConverter.ConvertFromStringToBool(row.RobeAccess)},
                    new EquipmentAccessInfo(){EquipmentType = 27, EquipmentName = "Bracer", IsWeapon = false, CanAccess = _stringToBooleanConverter.ConvertFromStringToBool(row.BracerAccess)},
                    new EquipmentAccessInfo(){EquipmentType = 28, EquipmentName = "Accessory", IsWeapon = false, CanAccess = _stringToBooleanConverter.ConvertFromStringToBool(row.AccessoryAccess)}


                };


            return schoolAccessInfos;
        }
        #endregion
    }
}
