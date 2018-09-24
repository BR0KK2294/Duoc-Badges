using System;
using System.Collections.Generic;

namespace DuocBadges.Models
{
    public partial class Revocations
    {
        public Revocations()
        {
            Profile = new HashSet<Profile>();
        }

        public string Id { get; set; }
        public string Type { get; set; }
        public string Issuer { get; set; }
        public string AssertionId { get; set; }

        public Assertions Assertion { get; set; }
        public ICollection<Profile> Profile { get; set; }
    }
}
