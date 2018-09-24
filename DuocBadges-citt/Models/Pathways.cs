using System;
using System.Collections.Generic;

namespace DuocBadges.Models
{
    public partial class Pathways
    {
        public string IdAilgnment { get; set; }
        public string IdBadge { get; set; }
        public int IdPathway { get; set; }

        public Alignment IdAilgnmentNavigation { get; set; }
        public Badge IdBadgeNavigation { get; set; }
    }
}
