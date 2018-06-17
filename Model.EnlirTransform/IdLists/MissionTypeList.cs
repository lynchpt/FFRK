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
                                                                 new KeyValuePair<int, string>(1, "Book of Challenges"),
                                                                 new KeyValuePair<int, string>(2, "Book of Dates"),
                                                                 new KeyValuePair<int, string>(3, "Book of Time"),
                                                                 new KeyValuePair<int, string>(4, "Book of Trials, Vol. I"),
                                                                 new KeyValuePair<int, string>(5, "Book of Trials, Vol. II"),
                                                                 new KeyValuePair<int, string>(6, "Book of Trials, Vol. III"),
                                                                 new KeyValuePair<int, string>(7, "Book of Trials, Vol. IV"),
                                                                 new KeyValuePair<int, string>(8, "Book of Trials, Vol. V"),
                                                                 new KeyValuePair<int, string>(9, "Book of Trials, Vol. VI"),
                                                                 new KeyValuePair<int, string>(10, "Book of Trials, Vol. VII"),
                                                                 new KeyValuePair<int, string>(11, "Book of Trials, Vol. VIII"),
                                                                 new KeyValuePair<int, string>(12, "Book of Trials, Vol. IX"),
                                                                 new KeyValuePair<int, string>(13, "Book of Transcendence")

                                                             };

        public IList<KeyValuePair<int, string>> TypeList => _typeList;
    }
}
