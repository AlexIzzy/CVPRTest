using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Realms;

namespace CVPRTest
{
    public static class RealmHelper
    {
        public static Realm GetRealm()
        {
            var config = new RealmConfiguration
            {
                SchemaVersion = 4
            };
            return Realm.GetInstance(config);
        }
    }
}
