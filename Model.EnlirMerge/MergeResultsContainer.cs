using System;
using System.Collections.Generic;
using System.Text;
using FFRKApi.Model.EnlirTransform;

namespace FFRKApi.Model.EnlirMerge
{
    public class MergeResultsContainer
    {
        public IEnumerable<Event> Events { get; set; }

        public IEnumerable<Mission> Missions { get; set; }

        public IEnumerable<Experience> Experiences { get; set; }

        public IEnumerable<Dungeon> Dungeons { get; set; }

        public IEnumerable<MagiciteSkill> MagiciteSkills { get; set; }

        public IEnumerable<Magicite> Magicites { get; set; }

        public IEnumerable<Status> Statuses { get; set; }

        public IEnumerable<Other> Others { get; set; }

        public IEnumerable<Command> Commands { get; set; }

        public IEnumerable<SoulBreak> SoulBreaks { get; set; }

        public IEnumerable<Relic> Relics { get; set; }

        public IEnumerable<Ability> Abilities { get; set; }

        public IEnumerable<LegendMateria> LegendMaterias { get; set; }

        public IEnumerable<RecordMateria> RecordMaterias { get; set; }

        public IEnumerable<RecordSphere> RecordSpheres { get; set; }

        public IEnumerable<LegendSphere> LegendSpheres { get; set; }

        public IEnumerable<Character> Characters { get; set; }

        //Type Lists
        public IList<KeyValuePair<int, string>> AbilityTypeList { get; set; }
        public IList<KeyValuePair<int, string>> AutoTargetTypeList { get; set; }
        public IList<KeyValuePair<int, string>> DamageFormulaTypeList { get; set; }
        public IList<KeyValuePair<int, string>> ElementList { get; set; }
        public IList<KeyValuePair<int, string>> EquipmentTypeList { get; set; }
        public IList<KeyValuePair<int, string>> EventTypeList { get; set; }
        public IList<KeyValuePair<int, string>> MissionTypeList { get; set; }
        public IList<KeyValuePair<int, string>> OrbTypeList { get; set; }
        public IList<KeyValuePair<int, string>> RealmList { get; set; }
        public IList<KeyValuePair<int, string>> RelicTypeList { get; set; }
        public IList<KeyValuePair<int, string>> SchoolList { get; set; }
        public IList<KeyValuePair<int, string>> SoulBreakTierList { get; set; }
        public IList<KeyValuePair<int, string>> TargetTypeList { get; set; }

        //Model lookup lists
        public IList<KeyValuePair<int, string>> EventIdList { get; set; }
        public IList<KeyValuePair<int, string>> MissionList { get; set; }
        public IList<KeyValuePair<int, string>> ExperienceIdList { get; set; }
        public IList<KeyValuePair<int, string>> DungeonIdList { get; set; }
        public IList<KeyValuePair<int, string>> MagiciteSkillIdList { get; set; }
        public IList<KeyValuePair<int, string>> MagiciteIdList { get; set; }
        public IList<KeyValuePair<int, string>> StatusIdList { get; set; }
        public IList<KeyValuePair<int, string>> OtherIdList { get; set; }
        public IList<KeyValuePair<int, string>> CommandIdList { get; set; }
        public IList<KeyValuePair<int, string>> SoulBreakIdList { get; set; }
        public IList<KeyValuePair<int, string>> RelicIdList { get; set; }
        public IList<KeyValuePair<int, string>> AbilityIdList { get; set; }
        public IList<KeyValuePair<int, string>> LegendMateriaIdList { get; set; }
        public IList<KeyValuePair<int, string>> RecordMateriaIdList { get; set; }
        public IList<KeyValuePair<int, string>> RecordSphereIdList { get; set; }
        public IList<KeyValuePair<int, string>> LegendSphereIdList { get; set; }
        public IList<KeyValuePair<int, string>> CharacterIdList { get; set; }
    }
}
