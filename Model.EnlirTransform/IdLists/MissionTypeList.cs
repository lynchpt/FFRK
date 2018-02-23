using System;
using System.Collections.Generic;
using System.Text;

namespace FFRKApi.Model.EnlirTransform.IdLists
{
    public class MissionTypeList : ITypeList
    {
        private IList<KeyValuePair<int, string>> _typeList = new List<KeyValuePair<int, string>>()
                                                             {
                                                                 new KeyValuePair<int, string>(0, "Unknown"),
                                                                 new KeyValuePair<int, string>(1, "Normal"),
                                                                 new KeyValuePair<int, string>(2, "Special"),
                                                                 new KeyValuePair<int, string>(3, "Tome of Challenges"),
                                                                 new KeyValuePair<int, string>(4, "Tome of Dailies"),
                                                                 new KeyValuePair<int, string>(5, "Tome of Time"),
                                                                 new KeyValuePair<int, string>(6, "Tome of Trials, Volume I"),
                                                                 new KeyValuePair<int, string>(7, "Tome of Trials, Volume II"),
                                                                 new KeyValuePair<int, string>(8, "Tome of Trials, Volume III"),
                                                                 new KeyValuePair<int, string>(9, "Tome of Trials, Volume IV"),
                                                                 new KeyValuePair<int, string>(10, "Tome of Trials, Volume V"),
                                                                 new KeyValuePair<int, string>(11, "Tome of Trials, Volume VI"),
                                                                 new KeyValuePair<int, string>(12, "Tome of Trials, Volume VII"),
                                                                 new KeyValuePair<int, string>(13, "Tome of Trials, Volume VIII"),
                                                                 new KeyValuePair<int, string>(14, "Tome of Trials, Volume IX"),
                                                                 new KeyValuePair<int, string>(15, "Wayfarer")

                                                             };

        public IList<KeyValuePair<int, string>> TypeList => _typeList;
    }
}
