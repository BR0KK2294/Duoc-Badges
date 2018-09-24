using System;
using System.Collections.Generic;

namespace DuocBadges.Models
{
    public partial class Profile
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Telephone { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Email { get; set; }
        public string CriptoId { get; set; }
        public string VerificationId { get; set; }
        public string RevocationListId { get; set; }

        public CriptoKey Cripto { get; set; }
        public Revocations RevocationList { get; set; }
        public Verification Verification { get; set; }
    }
}
