using System;
using System.Collections.Generic;

namespace DuocBadges.Models
{
    public partial class Badge
    {
        public Badge()
        {
            Assertions = new HashSet<Assertions>();
            Pathways = new HashSet<Pathways>();
            TagBadge = new HashSet<TagBadge>();
        }

        public string Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageId { get; set; }
        public string CriteriaId { get; set; }
        public string IssuerId { get; set; }

        public Criteria Criteria { get; set; }
        public Image Image { get; set; }
        public ICollection<Assertions> Assertions { get; set; }
        public ICollection<Pathways> Pathways { get; set; }
        public ICollection<TagBadge> TagBadge { get; set; }
    }
}
