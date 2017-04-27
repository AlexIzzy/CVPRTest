using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyChanged;
using PSC.Xamarin.MvvmHelpers;
using Realms;

namespace CVPRTest.Models
{
    [DoNotNotify]
    public class Visitor : RealmObject
    {
        [PrimaryKey]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string Email { get; set; }
        public IList<Visitor> AddedVisitors { get; }
        [Required]
        public string Password { get; set; }

    }
}
