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
                                                                 new KeyValuePair<int, string>(1, "Dungeons Update"),
                                                                 new KeyValuePair<int, string>(2, "Challenge Event"),
                                                                 new KeyValuePair<int, string>(3, "Collection Event"),
                                                                 new KeyValuePair<int, string>(4, "Survival Event"),
                                                                 new KeyValuePair<int, string>(5, "Festival"),
                                                                 new KeyValuePair<int, string>(6, "Nightmare Dungeon"),
                                                                 new KeyValuePair<int, string>(7, "Mote Dungeon"),
                                                                 new KeyValuePair<int, string>(8, "Torment Dungeon"),
                                                                 new KeyValuePair<int, string>(9, "Record Missions"),
                                                                 new KeyValuePair<int, string>(10, "Magicite Dungeon"),
                                                                 new KeyValuePair<int, string>(11, "Crystal Tower"),
                                                                 new KeyValuePair<int, string>(12, "Endless Battle")
                                                             };


        public IList<KeyValuePair<int, string>> TypeList => _typeList;

    }
}
