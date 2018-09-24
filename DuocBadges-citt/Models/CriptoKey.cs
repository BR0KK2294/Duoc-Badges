using System;
using System.Collections.Generic;

namespace DuocBadges.Models
{
    public partial class CriptoKey
    {
        public CriptoKey()
        {
            Profile = new HashSet<Profile>();
        }

        public string Type { get; set; }
        public string Id { get; set; }
        public string Owner { get; set; }
        public string PublicKey { get; set; }

        public ICollection<Profile> Profile { get; set; }
    }
}
