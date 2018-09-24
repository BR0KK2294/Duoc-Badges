using System;
using System.Collections.Generic;

namespace DuocBadges.Models
{
    public partial class Assertions
    {
        public Assertions()
        {
            Revocations = new HashSet<Revocations>();
        }

        public string Id { get; set; }
        public string Type { get; set; }
        public string RecipientId { get; set; }
        public string BadgeId { get; set; }
        public string VerificationId { get; set; }
        public DateTime? IssuedOn { get; set; }
        public string Image { get; set; }
        public string EvidenceId { get; set; }
        public string Narrative { get; set; }
        public DateTime? Expires { get; set; }
        public bool? Revoked { get; set; }
        public string RevocationReason { get; set; }

        public Badge Badge { get; set; }
        public Evidence Evidence { get; set; }
        public IdentityObject Recipient { get; set; }
        public Verification Verification { get; set; }
        public ICollection<Revocations> Revocations { get; set; }
    }
}
