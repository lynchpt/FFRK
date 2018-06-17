using System;
using System.Collections.Generic;
using System.Text;
using Model.EnlirImport;

namespace FFRKApi.Model.EnlirImport
{
    public class ImportResultsContainer
    {
        public IEnumerable<CharacterRow> CharacterRows { get; set; }

        public IEnumerable<RecordSphereRow> RecordSphereRows { get; set; }

        public IEnumerable<LegendSphereRow> LegendSphereRows { get; set; }

        public IEnumerable<RecordMateriaRow> RecordMateriaRows { get; set; }

        public IEnumerable<LegendMateriaRow> LegendMateriaRows { get; set; }

        public IEnumerable<AbilityRow> AbilityRows { get; set; }

        public IEnumerable<SoulBreakRow> SoulBreakRows { get; set; }

        public IEnumerable<CommandRow> CommandRows { get; set; }

        public IEnumerable<BraveActionRow> BraveActionRows { get; set; }

        public IEnumerable<OtherRow> OtherRows { get; set; }

        public IEnumerable<StatusRow> StatusRows { get; set; }

        public IEnumerable<RelicRow> RelicRows { get; set; }

        public IEnumerable<MagiciteRow> MagiciteRows { get; set; }

        public IEnumerable<MagiciteSkillRow> MagiciteSkillRows { get; set; }

        public IEnumerable<DungeonRow> DungeonRows { get; set; }

        public IEnumerable<EventRow> EventRows { get; set; }

        public IEnumerable<MissionRow> MissionRows { get; set; }

        public IEnumerable<ExperienceRow> ExperienceRows { get; set; }
    }
}
