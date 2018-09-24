using System;
using System.Collections.Generic;

namespace DuocBadges.Models
{
    public partial class Criteria
    {
        public Criteria()
        {
            Badge = new HashSet<Badge>();
        }

        public string Type { get; set; }
        public string Id { get; set; }
        public string Narrative { get; set; }
        public int? Puntos { get; set; }

        public ICollection<Badge> Badge { get; set; }
    }
}
