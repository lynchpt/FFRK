using System;
using System.Collections.Generic;
using System.Text;

namespace FFRKApi.Model.EnlirTransform
{
    public class Dungeon : IModelDescriptor
    {
        #region IModelDescriptor Implementation
        public int Id { get; set; }
        public string Description { get; set; }
        #endregion

        public int Realm { get; set; }
        public string DungeonName { get; set; }

        public string IntroducingEvent { get; set; }
        public int IntroducingEventId { get; set; }

        //Classic
        public int StaminaClassic { get; set; }
        public int DifficultyClassic { get; set; }
        public int CompletionGilClassic { get; set; }
        public IEnumerable<ItemWithCountAndStarLevel> FirstTimeRewardsClassic { get; set; }
        public IEnumerable<ItemWithCountAndStarLevel> MasteryRewardsClassic { get; set; }

        //Elite
        public int StaminaElite { get; set; }
        public int DifficultyElite { get; set; }
        public int CompletionGilElite { get; set; }
        public IEnumerable<ItemWithCountAndStarLevel> FirstTimeRewardsElite { get; set; }
        public IEnumerable<ItemWithCountAndStarLevel> MasteryRewardsElite { get; set; }


    }
}
