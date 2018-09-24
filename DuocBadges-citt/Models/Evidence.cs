using System;
using System.Collections.Generic;

namespace DuocBadges.Models
{
    public partial class Evidence
    {
        public Evidence()
        {
            Assertions = new HashSet<Assertions>();
        }

        public string Type { get; set; }
        public string Id { get; set; }
        public string Narrative { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public string Audience { get; set; }

        public ICollection<Assertions> Assertions { get; set; }
    }
}
