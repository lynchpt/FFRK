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
                                                                 new KeyValuePair<int, string>(9, "Staff"),
                                                                 new KeyValuePair<int, string>(10, "Bow"),
                                                                 new KeyValuePair<int, string>(11, "Instrument"),
                                                                 new KeyValuePair<int, string>(12, "Whip"),
                                                                 new KeyValuePair<int, string>(13, "Thrown"),
                                                                 new KeyValuePair<int, string>(14, "Gun"),
                                                                 new KeyValuePair<int, string>(15, "Book"),
                                                                 new KeyValuePair<int, string>(16, "Blitzball"),
                                                                 new KeyValuePair<int, string>(17, "Hairpin"),
                                                                 new KeyValuePair<int, string>(18, "Gun-Arm"),
                                                                 new KeyValuePair<int, string>(19, "Gambling Gear"),
                                                                 new KeyValuePair<int, string>(20, "Doll"),
                                                                 new KeyValuePair<int, string>(21, "Keyblade"),
                                                                 new KeyValuePair<int, string>(22, "Shield"),
                                                                 new KeyValuePair<int, string>(23, "Hat"),
                                                                 new KeyValuePair<int, string>(24, "Helm"),
                                                                 new KeyValuePair<int, string>(25, "Light Armor"),
                                                                 new KeyValuePair<int, string>(26, "Heavy Armor"),
                                                                 new KeyValuePair<int, string>(27, "Robe"),
                                                                 new KeyValuePair<int, string>(28, "Bracer"),
                                                                 new KeyValuePair<int, string>(29, "Accessory")

                                                             };

        public IList<KeyValuePair<int, string>> TypeList => _typeList;
    }
}
