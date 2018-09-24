using System;
using System.Collections.Generic;

namespace DuocBadges.Models
{
    public partial class Verification
    {
        public Verification()
        {
            Assertions = new HashSet<Assertions>();
            Endorsement = new HashSet<Endorsement>();
            Profile = new HashSet<Profile>();
        }

        public string Type { get; set; }
        public string Id { get; set; }
        public string StartWith { get; set; }
        public string AllowedOrigins { get; set; }

        public ICollection<Assertions> Assertions { get; set; }
        public ICollection<Endorsement> Endorsement { get; set; }
        public ICollection<Profile> Profile { get; set; }
    }
}
