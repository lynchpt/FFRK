using System;
using System.Collections.Generic;
using System.Text;

namespace FFRKApi.Model.EnlirTransform.IdLists
{
    public class StatTypeList : ITypeList
    {
        private readonly IList<KeyValuePair<int, string>> _typeList = new List<KeyValuePair<int, string>>()
                                                                      {
                                                                          new KeyValuePair<int, string>(0, "Unknown"),
                                                                          new KeyValuePair<int, string>(1, "ACC"),
                                                                          new KeyValuePair<int, string>(2, "ATK"),
                                                                          new KeyValuePair<int, string>(3, "DEF"),
                                                                          new KeyValuePair<int, string>(4, "EVA"),
                                                                          new KeyValuePair<int, string>(5, "MAG"),
                                                                          new KeyValuePair<int, string>(6, "MND"),
                                                                          new KeyValuePair<int, string>(7, "RES")
                                                                      };


        public IList<KeyValuePair<int, string>> TypeList => _typeList;
    }
}
