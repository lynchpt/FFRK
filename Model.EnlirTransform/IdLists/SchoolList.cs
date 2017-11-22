using System;
using System.Collections.Generic;
using System.Text;

namespace FFRKApi.Model.EnlirTransform.IdLists
{
    public class SchoolList : ITypeList
    {
        private IList<KeyValuePair<int, string>> _typeList = new List<KeyValuePair<int, string>>()
                                                             {
                                                                 new KeyValuePair<int, string>(0, "Unknown"),
                                                                 new KeyValuePair<int, string>(1, String.Empty),
                                                                 new KeyValuePair<int, string>(2, "?"),
                                                                 new KeyValuePair<int, string>(3, "Black Magic"),
                                                                 new KeyValuePair<int, string>(4, "Celerity"),
                                                                 new KeyValuePair<int, string>(5, "Combat"),
                                                                 new KeyValuePair<int, string>(6, "Dancer"),
                                                                 new KeyValuePair<int, string>(7, "Darkness"),
                                                                 new KeyValuePair<int, string>(8, "Dragoon"),
                                                                 new KeyValuePair<int, string>(9, "Knight"),
                                                                 new KeyValuePair<int, string>(10, "Machinist"),
                                                                 new KeyValuePair<int, string>(11, "Monk"),
                                                                 new KeyValuePair<int, string>(12, "Ninja"),
                                                                 new KeyValuePair<int, string>(13, "Samurai"),
                                                                 new KeyValuePair<int, string>(14, "Sharpshooter"),
                                                                 new KeyValuePair<int, string>(15, "Shooter"),
                                                                 new KeyValuePair<int, string>(16, "Special"),
                                                                 new KeyValuePair<int, string>(17, "Spellblade"),
                                                                 new KeyValuePair<int, string>(18, "Summoning"),
                                                                 new KeyValuePair<int, string>(19, "Support"),
                                                                 new KeyValuePair<int, string>(20, "Thief"),
                                                                 new KeyValuePair<int, string>(21, "White Magic"),
                                                                 new KeyValuePair<int, string>(22, "Witch")
                                                             };

        public IList<KeyValuePair<int, string>> TypeList => _typeList;
    }
}
