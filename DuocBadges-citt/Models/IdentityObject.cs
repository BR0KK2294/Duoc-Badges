using System;
using System.Collections.Generic;

namespace DuocBadges.Models
{
    public partial class IdentityObject
    {
        public IdentityObject()
        {
            Assertions = new HashSet<Assertions>();
        }

        public string Id { get; set; }
        public string Type { get; set; }
        public bool? Hashed { get; set; }
        public string Salt { get; set; }

        public ICollection<Assertions> Assertions { get; set; }
    }
}
