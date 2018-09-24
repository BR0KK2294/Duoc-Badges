using System;
using System.Collections.Generic;

namespace DuocBadges.Models
{
    public partial class Endorsement
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string Calim { get; set; }
        public string IssuerId { get; set; }
        public DateTime? IssuedOn { get; set; }
        public string VerifiactionId { get; set; }

        public Verification Verifiaction { get; set; }
    }
}
