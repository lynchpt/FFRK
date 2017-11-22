using System;
using System.Collections.Generic;
using System.Text;

namespace FFRKApi.Model.EnlirTransform.IdLists
{
    public class RelicTypeList : ITypeList
    {
        private IList<KeyValuePair<int, string>> _typeList = new List<KeyValuePair<int, string>>()
                                                             {
                                                                 new KeyValuePair<int, string>(0, "Unknown"),
                                                                 new KeyValuePair<int, string>(1, "Dagger"),
                                                                 new KeyValuePair<int, string>(2, "Sword"),
                                                                 new KeyValuePair<int, string>(3, "Katana"),
                                                                 new KeyValuePair<int, string>(4, "Axe"),
                                                                 new KeyValuePair<int, string>(5, "Hammer"),
                                                                 new KeyValuePair<int, string>(6, "Spear"),
                                                                 new KeyValuePair<int, string>(7, "Fist"),
                                                                 new KeyValuePair<int, string>(8, "Rod"),
                                                                 new KeyValuePair<int, string>(8, "Staff"),
                                                                 new KeyValuePair<int, string>(8, "Bow"),
                                                                 new KeyValuePair<int, string>(8, "Instrument"),
                                                                 new KeyValuePair<int, string>(8, "Whip"),
                                                                 new KeyValuePair<int, string>(8, "Thrown"),
                                                                 new KeyValuePair<int, string>(8, "Gun"),
                                                                 new KeyValuePair<int, string>(8, "Book"),
                                                                 new KeyValuePair<int, string>(8, "Blitzball"),
                                                                 new KeyValuePair<int, string>(8, "Hairpin"),
                                                                 new KeyValuePair<int, string>(8, "Gun-Arm"),
                                                                 new KeyValuePair<int, string>(8, "Gambling Gear"),
                                                                 new KeyValuePair<int, string>(8, "Doll"),
                                                                 new KeyValuePair<int, string>(8, "Shield"),
                                                                 new KeyValuePair<int, string>(8, "Hat"),
                                                                 new KeyValuePair<int, string>(8, "Helm"),
                                                                 new KeyValuePair<int, string>(8, "Light Armor"),
                                                                 new KeyValuePair<int, string>(8, "Heavy Armor"),
                                                                 new KeyValuePair<int, string>(8, "Robe"),
                                                                 new KeyValuePair<int, string>(8, "Bracer"),
                                                                 new KeyValuePair<int, string>(8, "Accessory")

                                                             };

        public IList<KeyValuePair<int, string>> TypeList => _typeList;
    }
}
