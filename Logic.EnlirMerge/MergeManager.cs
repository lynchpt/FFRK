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
        /// <summary>
        /// Merges based on the latest tranform results file
        /// </summary>
        /// <returns></returns>
        MergeResultsContainer MergeAll();

        /// <summary>
        /// Merges based on a specified tranform results file
        /// </summary>
        /// <param name="transformFilePath"></param>
        /// <returns></returns>
        MergeResultsContainer MergeAll(string transformFilePath);

        /// <summary>
        /// Tranforms based on a directly passed in  ImportResultsContainer
        /// </summary>
        /// <param name="transformResultsContainer"></param>
        /// <returns></returns>
        MergeResultsContainer MergeAll(TransformResultsContainer transformResultsContainer);
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
        public MergeResultsContainer MergeAll()
        {
            try
            {
                TransformResultsContainer transformResults = _transformStorageProvider.RetrieveTransformResults();


                MergeResultsContainer mergeResultsContainer = ExecuteMerge(transformResults);


                return mergeResultsContainer;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                _logger.LogInformation("Error in MergeManager MergeAll method - Merge was NOT completed.");
                throw;
            }
        }

        public MergeResultsContainer MergeAll(string transformFilePath)
        {
            try
            {
                TransformResultsContainer transformResults = _transformStorageProvider.RetrieveTransformResults(transformFilePath);


                MergeResultsContainer mergeResultsContainer = ExecuteMerge(transformResults);


                return mergeResultsContainer;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                _logger.LogInformation("Error in MergeManager MergeAll method - Merge was NOT completed.");
                throw;
            }
        }

        public MergeResultsContainer MergeAll(TransformResultsContainer transformResultsContainer)
        {
            try
            {
                MergeResultsContainer mergeResultsContainer = ExecuteMerge(transformResultsContainer);


                return mergeResultsContainer;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                _logger.LogInformation("Error in MergeManager MergeAll method - Merge was NOT completed.");
                throw;
            }
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

                    _logger.LogInformation("wired up CharacterId {CharacterId} to RecordSphere {RecordSphere}", rs.CharacterId, rs.Description);
                }
            }

            foreach (LegendSphere ls in transformResults.LegendSpheres)
            {
                if (!String.IsNullOrWhiteSpace(ls.CharacterName))
                {
                    ls.CharacterId = transformResults.Characters.Where(c => c.CharacterName == ls.CharacterName).Select(c => c.Id).SingleOrDefault();

                    _logger.LogInformation("wired up CharacterId {CharacterId} to LegendSphere {LegendSphere}", ls.CharacterId, ls.Description);
                }
            }

            foreach (RecordMateria rm in transformResults.RecordMaterias)
            {
                if (!String.IsNullOrWhiteSpace(rm.CharacterName))
                {
                    rm.CharacterId = transformResults.Characters.Where(c => c.CharacterName == rm.CharacterName).Select(c => c.Id).SingleOrDefault();

                    _logger.LogInformation("wired up CharacterId {CharacterId} to RecordMateria {RecordMateria}", rm.CharacterId, rm.Description);
                }
            }

            foreach (LegendMateria lm in transformResults.LegendMaterias)
            {
                if (!String.IsNullOrWhiteSpace(lm.CharacterName))
                {
                    lm.CharacterId = transformResults.Characters.Where(c => c.CharacterName == lm.CharacterName).Select(c => c.Id).SingleOrDefault();

                    _logger.LogInformation("wired up CharacterId {CharacterId} to LegendMateria {LegendMateria}", lm.CharacterId, lm.Description);
                }
            }

            foreach (Relic relic in transformResults.Relics)
            {
                if (!String.IsNullOrWhiteSpace(relic.CharacterName))
                {
                    relic.CharacterId = transformResults.Characters.Where(c => c.CharacterName == relic.CharacterName).Select(c => c.Id).SingleOrDefault();

                    _logger.LogInformation("wired up CharacterId {CharacterId} to Relic {Relic}", relic.CharacterId, relic.Description);
                }
            }

            foreach (Command command in transformResults.Commands)
            {
                if (!String.IsNullOrWhiteSpace(command.CharacterName))
                {
                    command.CharacterId = transformResults.Characters.Where(c => c.CharacterName == command.CharacterName).Select(c => c.Id).SingleOrDefault();

                    _logger.LogInformation("wired up CharacterId {CharacterId} to Command {Command}", command.CharacterId, command.Description);
                }
            }

            foreach (SoulBreak soulbreak in transformResults.SoulBreaks)
            {
                if (!String.IsNullOrWhiteSpace(soulbreak.CharacterName))
                {
                    soulbreak.CharacterId = transformResults.Characters.Where(c => c.CharacterName == soulbreak.CharacterName).Select(c => c.Id).SingleOrDefault();

                    _logger.LogInformation("wired up CharacterId {CharacterId} to SoulBreak {SoulBreak}", soulbreak.CharacterId, soulbreak.Description);
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

                    _logger.LogInformation("wired up LegendMateriaId {LegendMateriaId} to Relic {Relic}", relic.CharacterId, relic.Description);
                }
            }

        }

        private void WireUpEventIds(TransformResultsContainer transformResults)
        {
            foreach (Dungeon dungeon in transformResults.Dungeons)
            {
                dungeon.IntroducingEventId = transformResults.Events.Where(e => e.EventName == dungeon.IntroducingEvent).Select(e => e.Id).SingleOrDefault();

                _logger.LogInformation("wired up EventId {EventId} to Dungeon {Dungeon}", dungeon.IntroducingEventId, dungeon.Description);
            }

            foreach (Magicite magicite in transformResults.Magicites)
            {
                magicite.IntroducingEventId = transformResults.Events.Where(e => e.EventName == magicite.IntroducingEventName).Select(e => e.Id).Single();

                _logger.LogInformation("wired up EventId {EventId} to Magicite {Magicite}", magicite.IntroducingEventId, magicite.Description);
            }

            foreach (Character character in transformResults.Characters)
            {
                foreach (StatsByLevelInfo info in character.StatsByLevelInfos)
                {
                    info.IntroducingEventId = transformResults.Events.Where(e => e.EventName == info.IntroducingEvent).Select(e => e.Id).SingleOrDefault();

                    _logger.LogInformation("wired up EventId {EventId} to StatsByLevelInfo for Character {Character}", info.IntroducingEventId, character.Description);
                }

                character.StatIncrementsForRecordSpheres.IntroducingEventId = transformResults.Events.Where(e => e.EventName == character.StatIncrementsForRecordSpheres.IntroducingEvent).Select(e => e.Id).SingleOrDefault();
                _logger.LogInformation("wired up EventId {EventId} to StatIncrementsForRecordSpheres for Character {Character}", character.StatIncrementsForRecordSpheres.IntroducingEventId, character.Description);

                character.StatIncrementsForLegendSpheres.IntroducingEventId = transformResults.Events.Where(e => e.EventName == character.StatIncrementsForLegendSpheres.IntroducingEvent).Select(e => e.Id).SingleOrDefault();
                _logger.LogInformation("wired up EventId {EventId} to StatIncrementsForLegendSpheres for Character {Character}", character.StatIncrementsForLegendSpheres.IntroducingEventId, character.Description);
            }

            foreach (Ability ability in transformResults.Abilities)
            {
                ability.IntroducingEventId = transformResults.Events.Where(e => e.EventName == ability.IntroducingEventName).Select(e => e.Id).SingleOrDefault();

                _logger.LogInformation("wired up EventId {EventId} to Ability {Ability}", ability.IntroducingEventId, ability.Description);
            }

        }

        private void WireUpSoulBreakIds(TransformResultsContainer transformResults)
        {
            foreach (Command command in transformResults.Commands)
            {
                command.SourceSoulBreakId = transformResults.SoulBreaks.Where(sb => sb.SoulBreakName == command.SourceSoulBreakName 
                && sb.CharacterName.Trim() == command.CharacterName.Trim()).Select(e => e.Id).SingleOrDefault();

                _logger.LogInformation("wired up SoulBreakId {SoulBreakId} to Command {Command}", command.SourceSoulBreakId, command.Description);
            }

            foreach (Relic relic in transformResults.Relics)
            {
                string realmName = GetNameOfTypeListItem<RealmList>(relic.Realm);

                relic.SoulBreakId = transformResults.SoulBreaks.Where(sb => sb.SoulBreakName.Trim() == relic.SoulBreakName.Trim()
                && (sb.CharacterName.Trim() == relic.CharacterName.Trim()) && (sb.RelicName == $"{relic.RelicName} ({realmName})")
                && relic.Realm == sb.Realm).Select(e => e.Id).SingleOrDefault();

                _logger.LogInformation("wired up SoulBreakId {SoulBreakId} to Relic {Relic}", relic.SoulBreakId, relic.Description);
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

                    _logger.LogInformation("wired up RelicId {RelicId} to LegendMateria {LegendMateria}", lm.RelicId, lm.Description);
                }
            }

            foreach (SoulBreak sb in transformResults.SoulBreaks)
            {
                if (!String.IsNullOrWhiteSpace(sb.RelicName))
                {
                    string realmName = GetNameOfTypeListItem<RealmList>(sb.Realm);

                    sb.RelicId = transformResults.Relics.Where(r => (sb.RelicName == $"{r.RelicName} ({realmName})") && r.Realm == sb.Realm).Select(r => r.Id).SingleOrDefault();

                    _logger.LogInformation("wired up RelicId {RelicId} to SoulBreak {SoulBreak}", sb.RelicId, sb.Description);
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

                    _logger.LogInformation("wired up SourceId {SourceId} and SourceType {SourceType} to Other {Other}", other.SourceId, other.SourceType, other.Description);
                    continue;
                }

                //next check soul breaks for match
                SoulBreak relatedSoulBreak = transformResults.SoulBreaks.SingleOrDefault(s => s.SoulBreakName.Trim() == other.SourceName.Trim() 
                && (s.CharacterName.Trim() == other.CharacterName.Trim()));
                if (relatedSoulBreak != null) //this is the match
                {
                    other.SourceId = relatedSoulBreak.Id;
                    other.SourceType = nameof(SoulBreak);

                    _logger.LogInformation("wired up SourceId {SourceId} and SourceType {SourceType} to Other {Other}", other.SourceId, other.SourceType, other.Description);
                    continue;
                }

                RecordMateria relatedRecordMateria = transformResults.RecordMaterias.SingleOrDefault(r => r.RecordMateriaName.Trim() == other.SourceName.Trim());
                if (relatedRecordMateria != null) //this is the match
                {
                    other.SourceId = relatedRecordMateria.Id;
                    other.SourceType = nameof(RecordMateria);

                    _logger.LogInformation("wired up SourceId {SourceId} and SourceType {SourceType} to Other {Other}", other.SourceId, other.SourceType, other.Description);
                    continue;
                }

                Relic relatedRelic = transformResults.Relics.SingleOrDefault(r => r.RelicName.Trim() == other.SourceName.Trim());
                if (relatedRelic != null) //this is the match
                {
                    other.SourceId = relatedRelic.Id;
                    other.SourceType = nameof(Relic);

                    _logger.LogInformation("wired up SourceId {SourceId} and SourceType {SourceType} to Other {Other}", other.SourceId, other.SourceType, other.Description);
                    continue;
                }

                Command relatedCommand = transformResults.Commands.SingleOrDefault(c => c.CommandName.Trim() == other.SourceName.Trim());
                if (relatedCommand != null) //this is the match
                {
                    other.SourceId = relatedCommand.Id;
                    other.SourceType = nameof(Command);

                    _logger.LogInformation("wired up SourceId {SourceId} and SourceType {SourceType} to Other {Other}", other.SourceId, other.SourceType, other.Description);
                    continue;
                }

                LegendMateria relatedLegendMateria = transformResults.LegendMaterias.SingleOrDefault(l => l.LegendMateriaName == other.SourceName);
                if (relatedLegendMateria != null) //this is the match
                {
                    other.SourceId = relatedLegendMateria.Id;
                    other.SourceType = nameof(LegendMateria);

                    _logger.LogInformation("wired up SourceId {SourceId} and SourceType {SourceType} to Other {Other}", other.SourceId, other.SourceType, other.Description);
                    continue;
                }

                _logger.LogWarning("FAILED to wire up SourceId and SourceType to Other {Other}", other.Description);
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

                _logger.LogInformation("wired up {MagiciteSkillsCount} MagiciteSkills to Magicite {Magicite}", magicite.MagiciteSkills.Count(), magicite.Description);
            }
        }

        private void WireUpRecordSpheres(TransformResultsContainer transformResults)
        {
            foreach (Character character in transformResults.Characters)
            {
                character.RecordSpheres = transformResults.RecordSpheres.Where(rs => rs.CharacterName == character.CharacterName).ToList();

                _logger.LogInformation("wired up {RecordSpheresCount} RecordSpheres to Character {Character}", character.RecordSpheres.Count(), character.Description);
            }
        }

        private void WireUpLegendSpheres(TransformResultsContainer transformResults)
        {
            foreach (Character character in transformResults.Characters)
            {
                character.LegendSpheres = transformResults.LegendSpheres.Where(ls => ls.CharacterName == character.CharacterName).ToList();

                _logger.LogInformation("wired up {LegendSpheresCount} LegendSpheres to Character {Character}", character.LegendSpheres.Count(), character.Description);
            }
        }

        private void WireUpRecordMaterias(TransformResultsContainer transformResults)
        {
            foreach (Character character in transformResults.Characters)
            {
                character.RecordMaterias = transformResults.RecordMaterias.Where(rm => rm.CharacterName == character.CharacterName).ToList();

                _logger.LogInformation("wired up {RecordMateriasCount} RecordMaterias to Character {Character}", character.RecordMaterias.Count(), character.Description);
            }
        }

        private void WireUpLegendMaterias(TransformResultsContainer transformResults)
        {
            foreach (Character character in transformResults.Characters)
            {
                character.LegendMaterias = transformResults.LegendMaterias.Where(lm => lm.CharacterName == character.CharacterName).ToList();

                _logger.LogInformation("wired up {LegendMateriasCount} LegendMaterias to Character {Character}", character.LegendMaterias.Count(), character.Description);
            }
        }

        private void WireUpCommands(TransformResultsContainer transformResults)
        {
            foreach (SoulBreak soulBreak in transformResults.SoulBreaks)
            {
                soulBreak.Commands = transformResults.Commands.Where(c => c.SourceSoulBreakName == soulBreak.SoulBreakName).ToList();

                _logger.LogInformation("wired up {CommandsCount} Commands to SoulBreak {SoulBreak}", soulBreak.Commands.Count(), soulBreak.Description);
            }
        }

        private void WireUpStatuses(TransformResultsContainer transformResults)
        {
            foreach (SoulBreak soulBreak in transformResults.SoulBreaks)
            {
                soulBreak.Statuses = transformResults.Statuses.Where(s => !String.IsNullOrWhiteSpace(s.CommonName) && soulBreak.Effects.Contains(s.CommonName)).ToList();

                _logger.LogInformation("wired up {StatusesCount} Statuses to SoulBreak {SoulBreak}", soulBreak.Statuses.Count(), soulBreak.Description);
            }
        }

        private void WireUpOthers(TransformResultsContainer transformResults)
        {
            foreach (SoulBreak soulBreak in transformResults.SoulBreaks)
            {
                soulBreak.OtherEffects = transformResults.Others.Where(o => soulBreak.Effects.Contains(o.SourceName)).ToList();

                _logger.LogInformation("wired up {OtherEffectsCount} OtherEffects to SoulBreak {SoulBreak}", soulBreak.OtherEffects.Count(), soulBreak.Description);
            }
        }

        private void WireUpSoulBreaks(TransformResultsContainer transformResults)
        {
            foreach (Relic relic in transformResults.Relics)
            {
                string realmName = GetNameOfTypeListItem<RealmList>(relic.Realm);

                relic.SoulBreak = transformResults.SoulBreaks.SingleOrDefault(sb => sb.SoulBreakName.Trim() == relic.SoulBreakName.Trim()  
                && (sb.CharacterName.Trim() == relic.CharacterName.Trim()) && (sb.RelicName == $"{relic.RelicName} ({realmName})") && relic.Realm == sb.Realm);

                _logger.LogInformation("wired up {SoulBreak} SoulBreak to Relic {Relic}", relic.SoulBreak?.Description, relic?.Description);
            }
        }

        private void WireUpRelics(TransformResultsContainer transformResults)
        {
            foreach (Character character in transformResults.Characters)
            {
                character.Relics = transformResults.Relics.Where(r => r.CharacterName == character.CharacterName).ToList();

                _logger.LogInformation("wired up {RelicsCount} Relics to Character {Character}", character.Relics.Count(), character.Description);
            }
        }

        #endregion

        #region Private Methods

        private MergeResultsContainer ExecuteMerge(TransformResultsContainer transformResults)
        {
            MergeResultsContainer mergeResultsContainer = new MergeResultsContainer();

            //Id Wireup
            WireUpLegendMateriaIds(transformResults);
            _logger.LogInformation("Finished wiring up LegendMateriaIds");

            WireUpCharacterIds(transformResults);
            _logger.LogInformation("Finished wiring up CharacterIds");

            WireUpSoulBreakIds(transformResults);
            _logger.LogInformation("Finished wiring up SoulBreakIds");

            WireUpRelicIds(transformResults);
            _logger.LogInformation("Finished wiring up RelicIds");

            WireUpEventIds(transformResults);
            _logger.LogInformation("Finished wiring up EventIds");

            WireUpOtherSourceInfo(transformResults);
            _logger.LogInformation("Finished wiring up OtherSourceInfo");


            //Object Wireup
            WireUpMagiciteSkills(transformResults);
            _logger.LogInformation("Finished wiring up MagiciteSkills");

            WireUpRecordSpheres(transformResults);
            _logger.LogInformation("Finished wiring up RecordSpheres");

            WireUpLegendSpheres(transformResults);
            _logger.LogInformation("Finished wiring up LegendSpheres");

            WireUpRecordMaterias(transformResults);
            _logger.LogInformation("Finished wiring up RecordMaterias");

            WireUpLegendMaterias(transformResults);
            _logger.LogInformation("Finished wiring up LegendMaterias");

            WireUpCommands(transformResults);
            _logger.LogInformation("Finished wiring up Commands");

            WireUpStatuses(transformResults);
            _logger.LogInformation("Finished wiring up Statuses");

            WireUpOthers(transformResults);
            _logger.LogInformation("Finished wiring up Others");

            WireUpSoulBreaks(transformResults);
            _logger.LogInformation("Finished wiring up SoulBreaks");

            WireUpRelics(transformResults);
            _logger.LogInformation("Finished wiring up Relics");


            _logger.LogInformation("Finished MergeAll Operation");

            //copy data from transformResults container to merge results container

            mergeResultsContainer.Abilities = transformResults.Abilities;
            mergeResultsContainer.Characters = transformResults.Characters;
            mergeResultsContainer.Commands = transformResults.Commands;
            mergeResultsContainer.Dungeons = transformResults.Dungeons;
            mergeResultsContainer.Events = transformResults.Events;
            mergeResultsContainer.Experiences = transformResults.Experiences;
            mergeResultsContainer.LegendMaterias = transformResults.LegendMaterias;
            mergeResultsContainer.LegendSpheres = transformResults.LegendSpheres;
            mergeResultsContainer.MagiciteSkills = transformResults.MagiciteSkills;
            mergeResultsContainer.Magicites = transformResults.Magicites;
            mergeResultsContainer.Missions = transformResults.Missions;
            mergeResultsContainer.Others = transformResults.Others;
            mergeResultsContainer.RecordMaterias = transformResults.RecordMaterias;
            mergeResultsContainer.RecordSpheres = transformResults.RecordSpheres;
            mergeResultsContainer.Relics = transformResults.Relics;
            mergeResultsContainer.SoulBreaks = transformResults.SoulBreaks;
            mergeResultsContainer.Statuses = transformResults.Statuses;

            //now add in list members
            mergeResultsContainer.AbilityTypeList = new AbilityTypeList().TypeList;
            mergeResultsContainer.AutoTargetTypeList = new AutoTargetTypeList().TypeList;
            mergeResultsContainer.DamageFormulaTypeList = new DamageFormulaTypeList().TypeList;
            mergeResultsContainer.ElementList = new ElementList().TypeList;
            mergeResultsContainer.EquipmentTypeList = new EquipmentTypeList().TypeList;
            mergeResultsContainer.EventTypeList = new EventTypeList().TypeList;
            mergeResultsContainer.MissionTypeList = new MissionTypeList().TypeList;
            mergeResultsContainer.OrbTypeList = new OrbTypeList().TypeList;
            mergeResultsContainer.RealmList = new RealmList().TypeList;
            mergeResultsContainer.RelicTypeList = new RelicTypeList().TypeList;
            mergeResultsContainer.SchoolList = new SchoolList().TypeList;
            mergeResultsContainer.SoulBreakTierList = new SoulBreakTierList().TypeList;
            mergeResultsContainer.TargetTypeList = new TargetTypeList().TypeList;

            //now add in model lookup lists
            mergeResultsContainer.EventIdList = mergeResultsContainer.Events.Select(i => new KeyValuePair<int, string>(i.Id, i.EventName)).ToList();
            mergeResultsContainer.MissionList = mergeResultsContainer.Missions.Select(i => new KeyValuePair<int, string>(i.Id, i.Description)).ToList();
            mergeResultsContainer.ExperienceIdList = mergeResultsContainer.Experiences.Select(i => new KeyValuePair<int, string>(i.Id, i.Description)).ToList();
            mergeResultsContainer.DungeonIdList = mergeResultsContainer.Dungeons.Select(i => new KeyValuePair<int, string>(i.Id, i.DungeonName)).ToList();
            mergeResultsContainer.MagiciteSkillIdList = mergeResultsContainer.MagiciteSkills.Select(i => new KeyValuePair<int, string>(i.Id, i.Description)).ToList();
            mergeResultsContainer.MagiciteIdList = mergeResultsContainer.Magicites.Select(i => new KeyValuePair<int, string>(i.Id, i.MagiciteName)).ToList();
            mergeResultsContainer.StatusIdList = mergeResultsContainer.Statuses.Select(i => new KeyValuePair<int, string>(i.Id, i.CommonName)).ToList();
            mergeResultsContainer.OtherIdList = mergeResultsContainer.Others.Select(i => new KeyValuePair<int, string>(i.Id, i.Name)).ToList();
            mergeResultsContainer.CommandIdList = mergeResultsContainer.Commands.Select(i => new KeyValuePair<int, string>(i.Id, i.Description)).ToList();
            mergeResultsContainer.SoulBreakIdList = mergeResultsContainer.SoulBreaks.Select(i => new KeyValuePair<int, string>(i.Id, i.SoulBreakName)).ToList();
            mergeResultsContainer.RelicIdList = mergeResultsContainer.Relics.Select(i => new KeyValuePair<int, string>(i.Id, i.Description)).ToList();
            mergeResultsContainer.AbilityIdList = mergeResultsContainer.Abilities.Select(i => new KeyValuePair<int, string>(i.Id, i.AbilityName)).ToList();
            mergeResultsContainer.LegendMateriaIdList = mergeResultsContainer.LegendMaterias.Select(i => new KeyValuePair<int, string>(i.Id, i.Description)).ToList();
            mergeResultsContainer.RecordMateriaIdList = mergeResultsContainer.RecordMaterias.Select(i => new KeyValuePair<int, string>(i.Id, i.Description)).ToList();
            mergeResultsContainer.RecordSphereIdList = mergeResultsContainer.RecordSpheres.Select(i => new KeyValuePair<int, string>(i.Id, i.Description)).ToList();
            mergeResultsContainer.LegendSphereIdList = mergeResultsContainer.LegendSpheres.Select(i => new KeyValuePair<int, string>(i.Id, i.Description)).ToList();
            mergeResultsContainer.CharacterIdList = mergeResultsContainer.Characters.Select(i => new KeyValuePair<int, string>(i.Id, i.CharacterName)).ToList();

            return mergeResultsContainer;
        }

        private string GetNameOfTypeListItem<T>(int itemId) where T : class, ITypeList, new()
        {
            ITypeList list = new T();

            string name = list.TypeList[itemId].Value;

            return name;
        }



        #endregion
    }
}
