using System;
using System.Collections.Generic;

namespace DuocBadges.Models
{
    public partial class Image
    {
        public Image()
        {
            Badge = new HashSet<Badge>();
        }

        public string Id { get; set; }
        public string Type { get; set; }
        public string Caption { get; set; }
        public string Author { get; set; }

        public ICollection<Badge> Badge { get; set; }
    }
}
