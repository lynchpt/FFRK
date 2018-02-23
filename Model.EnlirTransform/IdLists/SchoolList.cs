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
                                                                 new KeyValuePair<int, string>(1, "?"),
                                                                 new KeyValuePair<int, string>(2, "Bard"),
                                                                 new KeyValuePair<int, string>(3, "Black Magic"),
                                                                 new KeyValuePair<int, string>(4, "Celerity"),
                                                                 new KeyValuePair<int, string>(5, "Combat"),
                                                                 new KeyValuePair<int, string>(6, "Dancer"),
                                                                 new KeyValuePair<int, string>(7, "Darkness"),
                                                                 new KeyValuePair<int, string>(8, "Dragoon"),
                                                                 new KeyValuePair<int, string>(9, "Heavy"),                                                                
                                                                 new KeyValuePair<int, string>(10, "Knight"),
                                                                 new KeyValuePair<int, string>(11, "Machinist"),
                                                                 new KeyValuePair<int, string>(12, "Monk"),
                                                                 new KeyValuePair<int, string>(13, "Ninja"),
                                                                 new KeyValuePair<int, string>(14, "Samurai"),
                                                                 new KeyValuePair<int, string>(15, "Sharpshooter"),
                                                                 new KeyValuePair<int, string>(16, "Shooter"),
                                                                 new KeyValuePair<int, string>(17, "Special"),
                                                                 new KeyValuePair<int, string>(18, "Spellblade"),
                                                                 new KeyValuePair<int, string>(19, "Summoning"),
                                                                 new KeyValuePair<int, string>(20, "Support"),
                                                                 new KeyValuePair<int, string>(21, "Thief"),
                                                                 new KeyValuePair<int, string>(22, "White Magic"),
                                                                 new KeyValuePair<int, string>(23, "Witch"),
  
                                                             };

        public IList<KeyValuePair<int, string>> TypeList => _typeList;
    }
}
