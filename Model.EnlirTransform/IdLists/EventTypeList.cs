using System;
using System.Collections.Generic;
using System.Text;

namespace FFRKApi.Model.EnlirTransform.IdLists
{
    public class EventTypeList : ITypeList
    {
        private IList<KeyValuePair<int, string>> _typeList = new List<KeyValuePair<int, string>>()
                                                             {
                                                                 new KeyValuePair<int, string>(0, "Unknown"),
                                                                 new KeyValuePair<int, string>(1, "Challenge Event"),
                                                                 new KeyValuePair<int, string>(2, "Collection Event"),
                                                                 new KeyValuePair<int, string>(3, "Crystal Tower"),
                                                                 new KeyValuePair<int, string>(4, "Dungeons Update"),
                                                                 new KeyValuePair<int, string>(5, "Endless Battle"),
                                                                 new KeyValuePair<int, string>(6, "Festival"),
                                                                 new KeyValuePair<int, string>(7, "Magicite Dungeon"),
                                                                 new KeyValuePair<int, string>(8, "Mote Dungeon"),
                                                                 new KeyValuePair<int, string>(9, "Nightmare Dungeon"),
                                                                 new KeyValuePair<int, string>(10, "Record Dungeon"),
                                                                 new KeyValuePair<int, string>(11, "Record Missions"),
                                                                 new KeyValuePair<int, string>(12, "Survival Event"),
                                                                 new KeyValuePair<int, string>(12, "Torment Dungeon")
                                                             };


        public IList<KeyValuePair<int, string>> TypeList => _typeList;

    }
}
