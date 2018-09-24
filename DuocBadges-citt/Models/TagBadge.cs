using System;
using System.Collections.Generic;

namespace DuocBadges.Models
{
    public partial class TagBadge
    {
        public int IdTag { get; set; }
        public string IdBadge { get; set; }
        public int IdTagBadge { get; set; }

        public Badge IdBadgeNavigation { get; set; }
        public Tag IdTagNavigation { get; set; }
    }
}
