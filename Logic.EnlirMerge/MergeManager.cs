using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FFRKApi.Data.Storage;
using FFRKApi.Model.EnlirMerge;
using FFRKApi.Model.EnlirTransform;
using FFRKApi.Model.EnlirTransform.IdLists;
using Microsoft.Extensions.Logging;
using Model.EnlirImport;

namespace FFRKApi.Logic.EnlirMerge
{
    public interface IMergeManager
    {
        MergeResultsContainer MergeAll();
    }

    public class MergeManager : IMergeManager
    {
        #region Class Variables

        private ITransformStorageProvider _transformStorageProvider;
        private readonly ILogger<MergeManager> _logger;
        #endregion

        #region Constructors
        public MergeManager(ITransformStorageProvider transformStorageProvider, ILogger<MergeManager> logger)
        {
            _transformStorageProvider = transformStorageProvider;
            _logger = logger;
        }
        #endregion

        #region IMergeManager Implementation
        public MergeResultsContainer MergeAll()
        {
            MergeResultsContainer mergeResultsContainer = new MergeResultsContainer();

            TransformResultsContainer transformResults = _transformStorageProvider.RetrieveTransformResults();

            /*Containment
             * 
             * Characters contain
             *  Record Spheres (object) *
             *  Legend Spheres (object) *
             *  Record Materia (object) *
             *  Legend Materia (object) *
             *  Relics (object) *
             * 
             * Legend Sphere
             *  Legend Materia (generic name / only inferred link possible)
             *  
             * Soul Breaks
             *  Commands (object) *
             *  Other (object) *
             *  Status (object) *
             *  
             * 
             * Relic
             *  Legend Materia (name / id link) *
             *  Soul Break (object) *
             * 
             * Magicite
             *  Event (name / id link) *
             *  Magicite Skill (object) *
             *  
             * Dungeons
             *  Event (name / id link) *
             *  
             *  
             *Upward Pointers
             * 
             * Record Spheres -> CharacterId *
             * Legend Spheres -> CharacterId *
             * Record Materia -> CharacterId *
             * Legend Materia -> CharacterId *
             * Relics -> CharacterId *
             * Command -> CharacterId *
             * Soul Break -> CharacterId *
             * 
             * Relic -> LegenedMateriaId *
             * 
             * Command -> SoulBreakid *
             * Relic -> SoulBreakId *
             * 
             * LegendMateria -> RelicId *
             * SoulBreak -> RelicId *
             * 
             * 
             * Dungeon -> EventId *
             * Magicite -> EventId *
             * Character.StatInfos -> EventId *
             * Character.RecordSpheres -> EventId *
             * Character.LegendSpheres -> EventId *
             * Ability -> EventId *
             * 
             * 
             */


            WireUpLegendMateriaIds(transformResults);
            WireUpCharacterIds(transformResults);
            WireUpSoulBreakIds(transformResults);
            WireUpRelicIds(transformResults);
            WireUpEventIds(transformResults);
            WireUpOtherSourceInfo(transformResults);

            WireUpMagiciteSkills(transformResults);
            WireUpRecordSpheres(transformResults);
            WireUpLegendSpheres(transformResults);
            WireUpRecordMaterias(transformResults);
            WireUpLegendMaterias(transformResults);
            WireUpCommands(transformResults);
            WireUpStatuses(transformResults);
            WireUpOthers(transformResults);
            WireUpSoulBreaks(transformResults);
            WireUpRelics(transformResults);

            return mergeResultsContainer;
        }
        #endregion

        #region Id Wireup Private Methods
        private void WireUpCharacterIds(TransformResultsContainer transformResults)
        {
            foreach (RecordSphere rs in transformResults.RecordSpheres)
            {
                if (!String.IsNullOrWhiteSpace(rs.CharacterName))
                {
                    rs.CharacterId = transformResults.Characters.Where(c => c.CharacterName == rs.CharacterName).Select(c => c.Id).SingleOrDefault();
                }
            }

            foreach (LegendSphere ls in transformResults.LegendSpheres)
            {
                if (!String.IsNullOrWhiteSpace(ls.CharacterName))
                {
                    ls.CharacterId = transformResults.Characters.Where(c => c.CharacterName == ls.CharacterName).Select(c => c.Id).SingleOrDefault();
                }
            }

            foreach (RecordMateria rm in transformResults.RecordMaterias)
            {
                if (!String.IsNullOrWhiteSpace(rm.CharacterName))
                {
                    rm.CharacterId = transformResults.Characters.Where(c => c.CharacterName == rm.CharacterName).Select(c => c.Id).SingleOrDefault();
                }
            }

            foreach (LegendMateria lm in transformResults.LegendMaterias)
            {
                if (!String.IsNullOrWhiteSpace(lm.CharacterName))
                {
                    lm.CharacterId = transformResults.Characters.Where(c => c.CharacterName == lm.CharacterName).Select(c => c.Id).SingleOrDefault();
                }
            }

            foreach (Relic relic in transformResults.Relics)
            {
                if (!String.IsNullOrWhiteSpace(relic.CharacterName))
                {
                    relic.CharacterId = transformResults.Characters.Where(c => c.CharacterName == relic.CharacterName).Select(c => c.Id).SingleOrDefault();
                }
            }

            foreach (Command command in transformResults.Commands)
            {
                if (!String.IsNullOrWhiteSpace(command.CharacterName))
                {
                    command.CharacterId = transformResults.Characters.Where(c => c.CharacterName == command.CharacterName).Select(c => c.Id).SingleOrDefault();
                }
            }

            foreach (SoulBreak soulbreak in transformResults.SoulBreaks)
            {
                if (!String.IsNullOrWhiteSpace(soulbreak.CharacterName))
                {
                    soulbreak.CharacterId = transformResults.Characters.Where(c => c.CharacterName == soulbreak.CharacterName).Select(c => c.Id).SingleOrDefault();
                }
            }
        }

        private void WireUpLegendMateriaIds(TransformResultsContainer transformResults)
        {
            foreach (Relic relic in transformResults.Relics)
            {
                if (!String.IsNullOrWhiteSpace(relic.LegendMateriaName))
                {
                    relic.LegendMateriaId = transformResults.LegendMaterias.Where(lm => (lm.LegendMateriaName == relic.LegendMateriaName) && (lm.Realm == relic.Realm)).Select(lm => lm.Id).SingleOrDefault();
                }
            }

        }

        private void WireUpEventIds(TransformResultsContainer transformResults)
        {
            foreach (Dungeon dungeon in transformResults.Dungeons)
            {
                dungeon.IntroducingEventId = transformResults.Events.Where(e => e.EventName == dungeon.IntroducingEvent).Select(e => e.Id).SingleOrDefault();
            }

            foreach (Magicite magicite in transformResults.Magicites)
            {
                magicite.IntroducingEventId = transformResults.Events.Where(e => e.EventName == magicite.IntroducingEventName).Select(e => e.Id).Single();
            }

            foreach (Character character in transformResults.Characters)
            {
                foreach (StatsByLevelInfo info in character.StatsByLevelInfos)
                {
                    info.IntroducingEventId = transformResults.Events.Where(e => e.EventName == info.IntroducingEvent).Select(e => e.Id).SingleOrDefault();
                }

                character.StatIncrementsForRecordSpheres.IntroducingEventId = transformResults.Events.Where(e => e.EventName == character.StatIncrementsForRecordSpheres.IntroducingEvent).Select(e => e.Id).SingleOrDefault();

                character.StatIncrementsForLegendSpheres.IntroducingEventId = transformResults.Events.Where(e => e.EventName == character.StatIncrementsForLegendSpheres.IntroducingEvent).Select(e => e.Id).SingleOrDefault();
            }

            foreach (Ability ability in transformResults.Abilities)
            {
                ability.IntroducingEventId = transformResults.Events.Where(e => e.EventName == ability.IntroducingEventName).Select(e => e.Id).SingleOrDefault();
            }

        }

        private void WireUpSoulBreakIds(TransformResultsContainer transformResults)
        {
            foreach (Command command in transformResults.Commands)
            {
                command.SourceSoulBreakId = transformResults.SoulBreaks.Where(sb => sb.SoulBreakName == command.SourceSoulBreakName 
                && sb.CharacterName.Trim() == command.CharacterName.Trim()).Select(e => e.Id).SingleOrDefault();
            }

            foreach (Relic relic in transformResults.Relics)
            {
                string realmName = GetNameOfTypeListItem<RealmList>(relic.Realm);

                relic.SoulBreakId = transformResults.SoulBreaks.Where(sb => sb.SoulBreakName.Trim() == relic.SoulBreakName.Trim()
                && (sb.CharacterName.Trim() == relic.CharacterName.Trim()) && (sb.RelicName == $"{relic.RelicName} ({realmName})")
                && relic.Realm == sb.Realm).Select(e => e.Id).SingleOrDefault();

            }
        }

        private void WireUpRelicIds(TransformResultsContainer transformResults)
        {
            foreach (LegendMateria lm in transformResults.LegendMaterias)
            {
                if (!String.IsNullOrWhiteSpace(lm.RelicName))
                {
                    string realmName = GetNameOfTypeListItem<RealmList>(lm.Realm);

                    lm.RelicId = transformResults.Relics.Where(r => (lm.RelicName == $"{r.RelicName} ({realmName})") && r.Realm == lm.Realm).Select(r => r.Id).SingleOrDefault();
                }
            }

            foreach (SoulBreak sb in transformResults.SoulBreaks)
            {
                if (!String.IsNullOrWhiteSpace(sb.RelicName))
                {
                    string realmName = GetNameOfTypeListItem<RealmList>(sb.Realm);

                    sb.RelicId = transformResults.Relics.Where(r => (sb.RelicName == $"{r.RelicName} ({realmName})") && r.Realm == sb.Realm).Select(r => r.Id).SingleOrDefault();
                }
            }

        }

        private void WireUpOtherSourceInfo(TransformResultsContainer transformResults)
        {
            foreach (Other other in transformResults.Others)
            {
                //first check statuses for match
                Status relatedStatus = transformResults.Statuses.SingleOrDefault(s => s.CommonName.Trim() == other.SourceName.Trim());
                if (relatedStatus != null) //this is the match
                {
                    other.SourceId = relatedStatus.Id;
                    other.SourceType = nameof(Status);
                    continue;
                }

                //next check soul breaks for match
                SoulBreak relatedSoulBreak = transformResults.SoulBreaks.SingleOrDefault(s => s.SoulBreakName.Trim() == other.SourceName.Trim() 
                && (s.CharacterName.Trim() == other.CharacterName.Trim()));
                if (relatedSoulBreak != null) //this is the match
                {
                    other.SourceId = relatedSoulBreak.Id;
                    other.SourceType = nameof(SoulBreak);
                    continue;
                }

                RecordMateria relatedRecordMateria = transformResults.RecordMaterias.SingleOrDefault(r => r.RecordMateriaName.Trim() == other.SourceName.Trim());
                if (relatedRecordMateria != null) //this is the match
                {
                    other.SourceId = relatedRecordMateria.Id;
                    other.SourceType = nameof(RecordMateria);
                    continue;
                }

                Relic relatedRelic = transformResults.Relics.SingleOrDefault(r => r.RelicName.Trim() == other.SourceName.Trim());
                if (relatedRelic != null) //this is the match
                {
                    other.SourceId = relatedRelic.Id;
                    other.SourceType = nameof(Relic);
                    continue;
                }

                Command relatedCommand = transformResults.Commands.SingleOrDefault(c => c.CommandName.Trim() == other.SourceName.Trim());
                if (relatedCommand != null) //this is the match
                {
                    other.SourceId = relatedCommand.Id;
                    other.SourceType = nameof(Command);
                    continue;
                }

                LegendMateria relatedLegendMateria = transformResults.LegendMaterias.SingleOrDefault(l => l.LegendMateriaName == other.SourceName);
                if (relatedLegendMateria != null) //this is the match
                {
                    other.SourceId = relatedLegendMateria.Id;
                    other.SourceType = nameof(LegendMateria);
                    continue;
                }
            }
        }
        #endregion

        #region Object Wireup Private Methods
        private void WireUpMagiciteSkills(TransformResultsContainer transformResults)
        {
            foreach (Magicite magicite in transformResults.Magicites)
            {
                string realmName = GetNameOfTypeListItem<RealmList>(magicite.Realm);
                magicite.MagiciteSkills = transformResults.MagiciteSkills.Where(s => s.MagiciteName == $"{magicite.MagiciteName} ({realmName})").ToList();
            }
        }

        private void WireUpRecordSpheres(TransformResultsContainer transformResults)
        {
            foreach (Character character in transformResults.Characters)
            {
                character.RecordSpheres = transformResults.RecordSpheres.Where(rs => rs.CharacterName == character.CharacterName).ToList();
            }
        }

        private void WireUpLegendSpheres(TransformResultsContainer transformResults)
        {
            foreach (Character character in transformResults.Characters)
            {
                character.LegendSpheres = transformResults.LegendSpheres.Where(ls => ls.CharacterName == character.CharacterName).ToList();
            }
        }

        private void WireUpRecordMaterias(TransformResultsContainer transformResults)
        {
            foreach (Character character in transformResults.Characters)
            {
                character.RecordMaterias = transformResults.RecordMaterias.Where(rm => rm.CharacterName == character.CharacterName).ToList();
            }
        }

        private void WireUpLegendMaterias(TransformResultsContainer transformResults)
        {
            foreach (Character character in transformResults.Characters)
            {
                character.LegendMaterias = transformResults.LegendMaterias.Where(lm => lm.CharacterName == character.CharacterName).ToList();
            }
        }

        private void WireUpCommands(TransformResultsContainer transformResults)
        {
            foreach (SoulBreak soulBreak in transformResults.SoulBreaks)
            {
                soulBreak.Commands = transformResults.Commands.Where(c => c.SourceSoulBreakName == soulBreak.SoulBreakName).ToList();
            }
        }

        private void WireUpStatuses(TransformResultsContainer transformResults)
        {
            foreach (SoulBreak soulBreak in transformResults.SoulBreaks)
            {
                soulBreak.Statuses = transformResults.Statuses.Where(s => !String.IsNullOrWhiteSpace(s.CommonName) && soulBreak.Effects.Contains(s.CommonName)).ToList();
            }
        }

        private void WireUpOthers(TransformResultsContainer transformResults)
        {
            foreach (SoulBreak soulBreak in transformResults.SoulBreaks)
            {
                soulBreak.OtherEffects = transformResults.Others.Where(o => soulBreak.Effects.Contains(o.SourceName)).ToList();
            }
        }

        private void WireUpSoulBreaks(TransformResultsContainer transformResults)
        {
            foreach (Relic relic in transformResults.Relics)
            {
                string realmName = GetNameOfTypeListItem<RealmList>(relic.Realm);

                relic.SoulBreak = transformResults.SoulBreaks.SingleOrDefault(sb => sb.SoulBreakName.Trim() == relic.SoulBreakName.Trim()  
                && (sb.CharacterName.Trim() == relic.CharacterName.Trim()) && (sb.RelicName == $"{relic.RelicName} ({realmName})") && relic.Realm == sb.Realm);
            }
        }

        private void WireUpRelics(TransformResultsContainer transformResults)
        {
            foreach (Character character in transformResults.Characters)
            {
                character.Relics = transformResults.Relics.Where(r => r.CharacterName == character.CharacterName).ToList(); ;
            }
        }

        #endregion



        #region Private Methods

        private string GetNameOfTypeListItem<T>(int itemId) where T : class, ITypeList, new()
        {
            ITypeList list = new T();

            string name = list.TypeList[itemId].Value;

            return name;
        }



        #endregion
    }
}
