using System;
using System.Collections.Generic;
using System.Text;

namespace FFRKApi.Model.EnlirTransform
{
    public class TransformResultsContainer
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
    }
}
