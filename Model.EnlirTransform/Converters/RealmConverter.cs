using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FFRKApi.Model.EnlirTransform.IdLists;

namespace FFRKApi.Model.EnlirTransform.Converters
{
    public class RealmConverter
    {
        public int ConvertFromNameToId(string name)
        {
            int id = 0;

            RealmList realmList = new RealmList();

            id = realmList.Realms.SingleOrDefault(r => r.Value == name.Trim()).Key;

            return id;
        }
    }
}
