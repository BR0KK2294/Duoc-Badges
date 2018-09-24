using System;
using System.Collections.Generic;

namespace DuocBadges.Models
{
    public partial class Alignment
    {
        public Alignment()
        {
            Pathways = new HashSet<Pathways>();
        }

        public string TargetName { get; set; }
        public string TargetUrl { get; set; }
        public string TargetDescription { get; set; }
        public string TargetFramework { get; set; }
        public string TargetCode { get; set; }

        public ICollection<Pathways> Pathways { get; set; }
    }
}
