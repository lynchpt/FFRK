using System;
using System.Collections.Generic;
using System.Text;

namespace FFRKApi.Model.EnlirTransform.IdLists
{
    public class ElementList : ITypeList
    {
        private IList<KeyValuePair<int, string>> _typeList = new List<KeyValuePair<int, string>>()
                                                                {
                                                                    new KeyValuePair<int, string>(0, "Unknown"),
                                                                    new KeyValuePair<int, string>(1, String.Empty),
                                                                    new KeyValuePair<int, string>(2, "-"),
                                                                    new KeyValuePair<int, string>(3, "NE"),
                                                                    new KeyValuePair<int, string>(4, "Fire"),
                                                                    new KeyValuePair<int, string>(5, "Ice"),
                                                                    new KeyValuePair<int, string>(6, "Lightning"),
                                                                    new KeyValuePair<int, string>(7, "Earth"),
                                                                    new KeyValuePair<int, string>(8, "Wind"),
                                                                    new KeyValuePair<int, string>(9, "Water"),
                                                                    new KeyValuePair<int, string>(10, "Holy"),
                                                                    new KeyValuePair<int, string>(11, "Dark"),
                                                                    new KeyValuePair<int, string>(12, "Poison")
                                                                };

        public IList<KeyValuePair<int, string>> TypeList => _typeList;
    }
}
