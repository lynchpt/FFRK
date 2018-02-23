using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FFRK.Api.Infra.Options.EnlirETL;
using FFRKApi.SheetsApiHelper;
using Google.Apis.Sheets.v4.Data;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Model.EnlirImport;

namespace FFRKApi.Logic.EnlirImport
{

    public class CharacterImporter : RowImporterBase<CharacterRow>
    {
        public CharacterImporter(ISheetsApiHelper sheetsApiHelper, IOptions<CharacterImporterOptions> importerOptionsAccessor, ILogger<RowImporterBase<CharacterRow>> logger)
            : base(sheetsApiHelper, importerOptionsAccessor, logger)
        {
        }

        protected override CharacterRow AssignColumnToProperty(int columnCount, IList<object> row)
        {
            CharacterRow importedRow = new CharacterRow();

            //General
            importedRow.Realm = ResolveColumnContents(columnCount, CharacterColumn.Realm, row);
            importedRow.Name = ResolveColumnContents(columnCount, CharacterColumn.Name, row);

            //Level 50
            importedRow.IntroducingEventLevel50 = ResolveColumnContents(columnCount, CharacterColumn.IntroducingEventLevel50, row);
            importedRow.HPLevel50 = ResolveColumnContents(columnCount, CharacterColumn.HPLevel50, row);
            importedRow.ATKLevel50 = ResolveColumnContents(columnCount, CharacterColumn.ATKLevel50, row);
            importedRow.DEFLevel50 = ResolveColumnContents(columnCount, CharacterColumn.DEFLevel50, row);
            importedRow.MAGLevel50 = ResolveColumnContents(columnCount, CharacterColumn.MAGLevel50, row);
            importedRow.RESLevel50 = ResolveColumnContents(columnCount, CharacterColumn.RESLevel50, row);
            importedRow.MNDLevel50 = ResolveColumnContents(columnCount, CharacterColumn.MNDLevel50, row);
            importedRow.ACCLevel50 = ResolveColumnContents(columnCount, CharacterColumn.ACCLevel50, row);
            importedRow.EVALevel50 = ResolveColumnContents(columnCount, CharacterColumn.EVALevel50, row);
            importedRow.SPDLevel50 = ResolveColumnContents(columnCount, CharacterColumn.SPDLevel50, row);

            //Level 65
            importedRow.IntroducingEventLevel65 = ResolveColumnContents(columnCount, CharacterColumn.IntroducingEventLevel65, row);
            importedRow.HPLevel65 = ResolveColumnContents(columnCount, CharacterColumn.HPLevel65, row);
            importedRow.ATKLevel65 = ResolveColumnContents(columnCount, CharacterColumn.ATKLevel65, row);
            importedRow.DEFLevel65 = ResolveColumnContents(columnCount, CharacterColumn.DEFLevel65, row);
            importedRow.MAGLevel65 = ResolveColumnContents(columnCount, CharacterColumn.MAGLevel65, row);
            importedRow.RESLevel65 = ResolveColumnContents(columnCount, CharacterColumn.RESLevel65, row);
            importedRow.MNDLevel65 = ResolveColumnContents(columnCount, CharacterColumn.MNDLevel65, row);
            importedRow.ACCLevel65 = ResolveColumnContents(columnCount, CharacterColumn.ACCLevel65, row);
            importedRow.EVALevel65 = ResolveColumnContents(columnCount, CharacterColumn.EVALevel65, row);
            importedRow.SPDLevel65 = ResolveColumnContents(columnCount, CharacterColumn.SPDLevel65, row);

            //Level 80
            importedRow.IntroducingEventLevel80 = ResolveColumnContents(columnCount, CharacterColumn.IntroducingEventLevel80, row);
            importedRow.HPLevel80 = ResolveColumnContents(columnCount, CharacterColumn.HPLevel80, row);
            importedRow.ATKLevel80 = ResolveColumnContents(columnCount, CharacterColumn.ATKLevel80, row);
            importedRow.DEFLevel80 = ResolveColumnContents(columnCount, CharacterColumn.DEFLevel80, row);
            importedRow.MAGLevel80 = ResolveColumnContents(columnCount, CharacterColumn.MAGLevel80, row);
            importedRow.RESLevel80 = ResolveColumnContents(columnCount, CharacterColumn.RESLevel80, row);
            importedRow.MNDLevel80 = ResolveColumnContents(columnCount, CharacterColumn.MNDLevel80, row);
            importedRow.ACCLevel80 = ResolveColumnContents(columnCount, CharacterColumn.ACCLevel80, row);
            importedRow.EVALevel80 = ResolveColumnContents(columnCount, CharacterColumn.EVALevel80, row);
            importedRow.SPDLevel80 = ResolveColumnContents(columnCount, CharacterColumn.SPDLevel80, row);

            //Level 99
            importedRow.IntroducingEventLevel99 = ResolveColumnContents(columnCount, CharacterColumn.IntroducingEventLevel99, row);
            importedRow.HPLevel99 = ResolveColumnContents(columnCount, CharacterColumn.HPLevel99, row);
            importedRow.ATKLevel99 = ResolveColumnContents(columnCount, CharacterColumn.ATKLevel99, row);
            importedRow.DEFLevel99 = ResolveColumnContents(columnCount, CharacterColumn.DEFLevel99, row);
            importedRow.MAGLevel99 = ResolveColumnContents(columnCount, CharacterColumn.MAGLevel99, row);
            importedRow.RESLevel99 = ResolveColumnContents(columnCount, CharacterColumn.RESLevel99, row);
            importedRow.MNDLevel99 = ResolveColumnContents(columnCount, CharacterColumn.MNDLevel99, row);
            importedRow.ACCLevel99 = ResolveColumnContents(columnCount, CharacterColumn.ACCLevel99, row);
            importedRow.EVALevel99 = ResolveColumnContents(columnCount, CharacterColumn.EVALevel99, row);
            importedRow.SPDLevel99 = ResolveColumnContents(columnCount, CharacterColumn.SPDLevel99, row);

            //Equipment Access
            importedRow.DaggerAccess = ResolveColumnContents(columnCount, CharacterColumn.DaggerAccess, row);
            importedRow.SwordAccess = ResolveColumnContents(columnCount, CharacterColumn.SwordAccess, row);
            importedRow.KatanaAccess = ResolveColumnContents(columnCount, CharacterColumn.KatanaAccess, row);
            importedRow.AxeAccess = ResolveColumnContents(columnCount, CharacterColumn.AxeAccess, row);
            importedRow.HammerAccess = ResolveColumnContents(columnCount, CharacterColumn.HammerAccess, row);
            importedRow.SpearAccess = ResolveColumnContents(columnCount, CharacterColumn.SpearAccess, row);
            importedRow.FistAccess = ResolveColumnContents(columnCount, CharacterColumn.FistAccess, row);
            importedRow.RodAccess = ResolveColumnContents(columnCount, CharacterColumn.RodAccess, row);
            importedRow.StaffAccess = ResolveColumnContents(columnCount, CharacterColumn.StaffAccess, row);
            importedRow.BowAccess = ResolveColumnContents(columnCount, CharacterColumn.BowAccess, row);
            importedRow.InstrumentAccess = ResolveColumnContents(columnCount, CharacterColumn.InstrumentAccess, row);
            importedRow.WhipAccess = ResolveColumnContents(columnCount, CharacterColumn.WhipAccess, row);
            importedRow.ThrownAccess = ResolveColumnContents(columnCount, CharacterColumn.ThrownAccess, row);
            importedRow.GunAccess = ResolveColumnContents(columnCount, CharacterColumn.GunAccess, row);
            importedRow.BookAccess = ResolveColumnContents(columnCount, CharacterColumn.BookAccess, row);
            importedRow.BlitzballAccess = ResolveColumnContents(columnCount, CharacterColumn.BlitzballAccess, row);
            importedRow.HairpinAccess = ResolveColumnContents(columnCount, CharacterColumn.HairpinAccess, row);
            importedRow.GunarmAccess = ResolveColumnContents(columnCount, CharacterColumn.GunarmAccess, row);
            importedRow.GamblingGearAccess = ResolveColumnContents(columnCount, CharacterColumn.GamblingGearAccess, row);
            importedRow.DollAccess = ResolveColumnContents(columnCount, CharacterColumn.DollAccess, row);
            importedRow.KeybladeAccess = ResolveColumnContents(columnCount, CharacterColumn.KeybladeAccess, row);
            importedRow.ShieldAccess = ResolveColumnContents(columnCount, CharacterColumn.ShieldAccess, row);
            importedRow.HatAccess = ResolveColumnContents(columnCount, CharacterColumn.HatAccess, row);
            importedRow.HelmAccess = ResolveColumnContents(columnCount, CharacterColumn.HelmAccess, row);
            importedRow.LightArmorAccess = ResolveColumnContents(columnCount, CharacterColumn.LightArmorAccess, row);
            importedRow.HeavyArmorAccess = ResolveColumnContents(columnCount, CharacterColumn.HeavyArmorAccess, row);
            importedRow.RobeAccess = ResolveColumnContents(columnCount, CharacterColumn.RobeAccess, row);
            importedRow.BracerAccess = ResolveColumnContents(columnCount, CharacterColumn.BracerAccess, row);
            importedRow.AccessoryAccess = ResolveColumnContents(columnCount, CharacterColumn.AccessoryAccess, row);

            //Ability Access
            importedRow.BlackMagicAccess = ResolveColumnContents(columnCount, CharacterColumn.BlackMagicAccess, row);
            importedRow.WhiteMagicAccess = ResolveColumnContents(columnCount, CharacterColumn.WhiteMagicAccess, row);
            importedRow.CombatAccess = ResolveColumnContents(columnCount, CharacterColumn.CombatAccess, row);
            importedRow.SupportAccess = ResolveColumnContents(columnCount, CharacterColumn.SupportAccess, row);
            importedRow.CelerityAccess = ResolveColumnContents(columnCount, CharacterColumn.CelerityAccess, row);
            importedRow.SummoningAccess = ResolveColumnContents(columnCount, CharacterColumn.SummoningAccess, row);
            importedRow.SpellbladeAccess = ResolveColumnContents(columnCount, CharacterColumn.SpellbladeAccess, row);
            importedRow.DragoonAccess = ResolveColumnContents(columnCount, CharacterColumn.DragoonAccess, row);
            importedRow.MonkAccess = ResolveColumnContents(columnCount, CharacterColumn.MonkAccess, row);
            importedRow.ThiefAccess = ResolveColumnContents(columnCount, CharacterColumn.ThiefAccess, row);
            importedRow.KnightAccess = ResolveColumnContents(columnCount, CharacterColumn.KnightAccess, row);
            importedRow.SamuraiAccess = ResolveColumnContents(columnCount, CharacterColumn.SamuraiAccess, row);
            importedRow.NinjaAccess = ResolveColumnContents(columnCount, CharacterColumn.NinjaAccess, row);
            importedRow.BardAccess = ResolveColumnContents(columnCount, CharacterColumn.BardAccess, row);
            importedRow.DancerAccess = ResolveColumnContents(columnCount, CharacterColumn.DancerAccess, row);
            importedRow.MachinistAccess = ResolveColumnContents(columnCount, CharacterColumn.MachinistAccess, row);
            importedRow.DarknessAccess = ResolveColumnContents(columnCount, CharacterColumn.DarknessAccess, row);
            importedRow.SharpshooterAccess = ResolveColumnContents(columnCount, CharacterColumn.SharpshooterAccess, row);
            importedRow.WitchAccess = ResolveColumnContents(columnCount, CharacterColumn.WitchAccess, row);
            importedRow.HeavyAccess = ResolveColumnContents(columnCount, CharacterColumn.HeavyAccess, row);

            //Record Sphere
            importedRow.IntroducingEventRecordSphere = ResolveColumnContents(columnCount, CharacterColumn.IntroducingEventRecordSphere, row);
            importedRow.HPRecordSphere = ResolveColumnContents(columnCount, CharacterColumn.HPRecordSphere, row);
            importedRow.ATKRecordSphere = ResolveColumnContents(columnCount, CharacterColumn.ATKRecordSphere, row);
            importedRow.DEFRecordSphere = ResolveColumnContents(columnCount, CharacterColumn.DEFRecordSphere, row);
            importedRow.MAGRecordSphere = ResolveColumnContents(columnCount, CharacterColumn.MAGRecordSphere, row);
            importedRow.RESRecordSphere = ResolveColumnContents(columnCount, CharacterColumn.RESRecordSphere, row);
            importedRow.MNDRecordSphere = ResolveColumnContents(columnCount, CharacterColumn.MNDRecordSphere, row);

            //Legend Sphere
            importedRow.IntroducingEventLegendSphere = ResolveColumnContents(columnCount, CharacterColumn.IntroducingEventLegendSphere, row);
            importedRow.HPLegendSphere = ResolveColumnContents(columnCount, CharacterColumn.HPLegendSphere, row);
            importedRow.ATKLegendSphere = ResolveColumnContents(columnCount, CharacterColumn.ATKLegendSphere, row);
            importedRow.DEFLegendSphere = ResolveColumnContents(columnCount, CharacterColumn.DEFLegendSphere, row);
            importedRow.MAGLegendSphere = ResolveColumnContents(columnCount, CharacterColumn.MAGLegendSphere, row);
            importedRow.RESLegendSphere = ResolveColumnContents(columnCount, CharacterColumn.RESLegendSphere, row);
            importedRow.MNDLegendSphere = ResolveColumnContents(columnCount, CharacterColumn.MNDLegendSphere, row);
            importedRow.SPDLegendSphere = ResolveColumnContents(columnCount, CharacterColumn.SPDLegendSphere, row);

            return importedRow;
        }
    }
}
