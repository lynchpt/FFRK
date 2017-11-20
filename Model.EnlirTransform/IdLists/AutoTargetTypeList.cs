using System;
using System.Collections.Generic;
using System.Text;

namespace FFRKApi.Model.EnlirTransform.IdLists
{
    public class AutoTargetTypeList :ITypeList
    {
        private readonly IList<KeyValuePair<int, string>> _typeList = new List<KeyValuePair<int, string>>()
                                                                      {
                                                                          new KeyValuePair<int, string>(0, "Unknown"),
                                                                          new KeyValuePair<int, string>(1, "?"),
                                                                          new KeyValuePair<int, string>(2, "All enemies"),
                                                                          new KeyValuePair<int, string>(3, "All allies"),
                                                                          new KeyValuePair<int, string>(4, "Lowest HP% enemy"),
                                                                          new KeyValuePair<int, string>(5, "Lowest HP% enemies"),
                                                                          new KeyValuePair<int, string>(6, "Highest HP% enemy"),
                                                                          new KeyValuePair<int, string>(7, "Lowest HP% ally"),
                                                                          new KeyValuePair<int, string>(8, "Ally with KO or lowest HP% ally"),
                                                                          new KeyValuePair<int, string>(9, "Random enemy"),
                                                                          new KeyValuePair<int, string>(10, "Random enemies"),
                                                                          new KeyValuePair<int, string>(11, "Random enemy with status"),
                                                                          new KeyValuePair<int, string>(12, "Random enemy without status"),
                                                                          new KeyValuePair<int, string>(13, "Random ally with status"),
                                                                          new KeyValuePair<int, string>(14, "Random ally without status"),
                                                                          new KeyValuePair<int, string>(15, "Self")
                                                                      };


        public IList<KeyValuePair<int, string>> TypeList => _typeList;
    }
}
