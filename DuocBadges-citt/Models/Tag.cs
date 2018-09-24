using System;
using System.Collections.Generic;

namespace DuocBadges.Models
{
    public partial class Tag
    {
        public Tag()
        {
            TagBadge = new HashSet<TagBadge>();
        }

        public string Nombre { get; set; }
        public int Id { get; set; }

        public ICollection<TagBadge> TagBadge { get; set; }
    }
}
