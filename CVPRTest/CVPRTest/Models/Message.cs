using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyChanged;
using Realms;

namespace CVPRTest.Models
{
    [DoNotNotify]
    public class Message : RealmObject
    {
        [PrimaryKey]
        public string ID { get; set; } = Guid.NewGuid().ToString();

        public bool? IsSent { get; set; } = null;
        public DateTimeOffset MessageDateTime { get; set; }

        public string MessageText
        {
            get; set;
        }
        public Visitor Sender { get; set; }
        public Visitor Reciever { get; set; }
    }
}
