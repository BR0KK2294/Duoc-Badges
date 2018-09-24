using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DuocBadges.Models
{
    public partial class DuocBadgesContext : DbContext
    {
        public DuocBadgesContext()
        {
        }

        public DuocBadgesContext(DbContextOptions<DuocBadgesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Alignment> Alignment { get; set; }
        public virtual DbSet<Assertions> Assertions { get; set; }
        public virtual DbSet<Badge> Badge { get; set; }
        public virtual DbSet<CriptoKey> CriptoKey { get; set; }
        public virtual DbSet<Criteria> Criteria { get; set; }
        public virtual DbSet<Endorsement> Endorsement { get; set; }
        public virtual DbSet<Evidence> Evidence { get; set; }
        public virtual DbSet<IdentityObject> IdentityObject { get; set; }
        public virtual DbSet<Image> Image { get; set; }
        public virtual DbSet<Pathways> Pathways { get; set; }
        public virtual DbSet<Profile> Profile { get; set; }
        public virtual DbSet<Revocations> Revocations { get; set; }
        public virtual DbSet<Tag> Tag { get; set; }
        public virtual DbSet<TagBadge> TagBadge { get; set; }
        public virtual DbSet<Verification> Verification { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=duocbadges.database.windows.net;Initial Catalog=Duoc Badges;User ID=duoc;Password=Admin0918");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alignment>(entity =>
            {
                entity.HasKey(e => e.TargetCode);

                entity.Property(e => e.TargetCode)
                    .HasColumnName("targetCode")
                    .HasMaxLength(10)
                    .ValueGeneratedNever();

                entity.Property(e => e.TargetDescription)
                    .HasColumnName("targetDescription")
                    .HasMaxLength(10);

                entity.Property(e => e.TargetFramework)
                    .HasColumnName("targetFramework")
                    .HasMaxLength(10);

                entity.Property(e => e.TargetName)
                    .HasColumnName("targetName")
                    .HasMaxLength(10);

                entity.Property(e => e.TargetUrl)
                    .HasColumnName("targetUrl")
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<Assertions>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(100)
                    .ValueGeneratedNever();

                entity.Property(e => e.BadgeId)
                    .HasColumnName("badge_id")
                    .HasMaxLength(100);

                entity.Property(e => e.EvidenceId)
                    .HasColumnName("evidence_id")
                    .HasMaxLength(100);

                entity.Property(e => e.Expires)
                    .HasColumnName("expires")
                    .HasColumnType("datetime");

                entity.Property(e => e.Image)
                    .HasColumnName("image")
                    .HasMaxLength(50);

                entity.Property(e => e.IssuedOn)
                    .HasColumnName("issuedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.Narrative)
                    .HasColumnName("narrative")
                    .HasMaxLength(50);

                entity.Property(e => e.RecipientId)
                    .HasColumnName("recipient_id")
                    .HasMaxLength(100);

                entity.Property(e => e.RevocationReason)
                    .HasColumnName("revocationReason")
                    .HasMaxLength(50);

                entity.Property(e => e.Revoked).HasColumnName("revoked");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasMaxLength(50);

                entity.Property(e => e.VerificationId)
                    .HasColumnName("verification_id")
                    .HasMaxLength(100);

                entity.HasOne(d => d.Badge)
                    .WithMany(p => p.Assertions)
                    .HasForeignKey(d => d.BadgeId)
                    .HasConstraintName("FK_Badge_Assertion");

                entity.HasOne(d => d.Evidence)
                    .WithMany(p => p.Assertions)
                    .HasForeignKey(d => d.EvidenceId)
                    .HasConstraintName("FK_Assertions_Evidence");

                entity.HasOne(d => d.Recipient)
                    .WithMany(p => p.Assertions)
                    .HasForeignKey(d => d.RecipientId)
                    .HasConstraintName("FK_Assertions_IdentityObject");

                entity.HasOne(d => d.Verification)
                    .WithMany(p => p.Assertions)
                    .HasForeignKey(d => d.VerificationId)
                    .HasConstraintName("FK_Assertions_Verification");
            });

            modelBuilder.Entity<Badge>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(100)
                    .ValueGeneratedNever();

                entity.Property(e => e.CriteriaId)
                    .HasColumnName("criteria_id")
                    .HasMaxLength(50);

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(50);

                entity.Property(e => e.ImageId)
                    .HasColumnName("image_id")
                    .HasMaxLength(100);

                entity.Property(e => e.IssuerId)
                    .HasColumnName("issuer_id")
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Criteria)
                    .WithMany(p => p.Badge)
                    .HasForeignKey(d => d.CriteriaId)
                    .HasConstraintName("FK_Badge_Criteria");

                entity.HasOne(d => d.Image)
                    .WithMany(p => p.Badge)
                    .HasForeignKey(d => d.ImageId)
                    .HasConstraintName("FK_Badge_Image");
            });

            modelBuilder.Entity<CriptoKey>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(100)
                    .ValueGeneratedNever();

                entity.Property(e => e.Owner)
                    .HasColumnName("owner")
                    .HasMaxLength(50);

                entity.Property(e => e.PublicKey)
                    .HasColumnName("publicKey")
                    .HasMaxLength(50);

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Criteria>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.Narrative)
                    .HasColumnName("narrative")
                    .HasMaxLength(50);

                entity.Property(e => e.Puntos).HasColumnName("puntos");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Endorsement>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(100)
                    .ValueGeneratedNever();

                entity.Property(e => e.Calim)
                    .HasColumnName("calim")
                    .HasMaxLength(10);

                entity.Property(e => e.IssuedOn)
                    .HasColumnName("issuedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.IssuerId)
                    .HasColumnName("issuer_id")
                    .HasMaxLength(100);

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasMaxLength(50);

                entity.Property(e => e.VerifiactionId)
                    .HasColumnName("verifiaction_id")
                    .HasMaxLength(100);

                entity.HasOne(d => d.Verifiaction)
                    .WithMany(p => p.Endorsement)
                    .HasForeignKey(d => d.VerifiactionId)
                    .HasConstraintName("FK_Endorsement_Profile");
            });

            modelBuilder.Entity<Evidence>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(100)
                    .ValueGeneratedNever();

                entity.Property(e => e.Audience)
                    .HasColumnName("audience")
                    .HasMaxLength(50);

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(50);

                entity.Property(e => e.Genre)
                    .HasColumnName("genre")
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Narrative)
                    .HasColumnName("narrative")
                    .HasMaxLength(50);

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<IdentityObject>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(100)
                    .ValueGeneratedNever();

                entity.Property(e => e.Hashed).HasColumnName("hashed");

                entity.Property(e => e.Salt)
                    .HasColumnName("salt")
                    .HasMaxLength(100);

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(100)
                    .ValueGeneratedNever();

                entity.Property(e => e.Author)
                    .HasColumnName("author")
                    .HasMaxLength(50);

                entity.Property(e => e.Caption)
                    .HasColumnName("caption")
                    .HasMaxLength(50);

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Pathways>(entity =>
            {
                entity.HasKey(e => e.IdPathway);

                entity.Property(e => e.IdPathway).HasColumnName("id_pathway");

                entity.Property(e => e.IdAilgnment)
                    .HasColumnName("id_ailgnment")
                    .HasMaxLength(10);

                entity.Property(e => e.IdBadge)
                    .HasColumnName("id_badge")
                    .HasMaxLength(100);

                entity.HasOne(d => d.IdAilgnmentNavigation)
                    .WithMany(p => p.Pathways)
                    .HasForeignKey(d => d.IdAilgnment)
                    .HasConstraintName("FK_Pathways_Alignment");

                entity.HasOne(d => d.IdBadgeNavigation)
                    .WithMany(p => p.Pathways)
                    .HasForeignKey(d => d.IdBadge)
                    .HasConstraintName("FK_Pathways_Badge");
            });

            modelBuilder.Entity<Profile>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(100)
                    .ValueGeneratedNever();

                entity.Property(e => e.CriptoId)
                    .HasColumnName("cripto_id")
                    .HasMaxLength(100);

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(50);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50);

                entity.Property(e => e.Image)
                    .HasColumnName("image")
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.RevocationListId)
                    .HasColumnName("revocationList_id")
                    .HasMaxLength(100);

                entity.Property(e => e.Telephone)
                    .HasColumnName("telephone")
                    .HasMaxLength(50);

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasMaxLength(50);

                entity.Property(e => e.Url)
                    .HasColumnName("url")
                    .HasMaxLength(50);

                entity.Property(e => e.VerificationId)
                    .HasColumnName("verification_id")
                    .HasMaxLength(100);

                entity.HasOne(d => d.Cripto)
                    .WithMany(p => p.Profile)
                    .HasForeignKey(d => d.CriptoId)
                    .HasConstraintName("FK_Profile_CriptoKey");

                entity.HasOne(d => d.RevocationList)
                    .WithMany(p => p.Profile)
                    .HasForeignKey(d => d.RevocationListId)
                    .HasConstraintName("FK_Profile_Revocations");

                entity.HasOne(d => d.Verification)
                    .WithMany(p => p.Profile)
                    .HasForeignKey(d => d.VerificationId)
                    .HasConstraintName("FK_Profile_Verification");
            });

            modelBuilder.Entity<Revocations>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(100)
                    .ValueGeneratedNever();

                entity.Property(e => e.AssertionId)
                    .HasColumnName("assertion_id")
                    .HasMaxLength(100);

                entity.Property(e => e.Issuer)
                    .HasColumnName("issuer")
                    .HasMaxLength(50);

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Assertion)
                    .WithMany(p => p.Revocations)
                    .HasForeignKey(d => d.AssertionId)
                    .HasConstraintName("FK_Revocations_Assertions");
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TagBadge>(entity =>
            {
                entity.HasKey(e => e.IdTagBadge);

                entity.ToTable("Tag_Badge");

                entity.Property(e => e.IdTagBadge).HasColumnName("id_tag_badge");

                entity.Property(e => e.IdBadge)
                    .HasColumnName("id_badge")
                    .HasMaxLength(100);

                entity.Property(e => e.IdTag).HasColumnName("id_tag");

                entity.HasOne(d => d.IdBadgeNavigation)
                    .WithMany(p => p.TagBadge)
                    .HasForeignKey(d => d.IdBadge)
                    .HasConstraintName("FK_Tag_Badge_Badge");

                entity.HasOne(d => d.IdTagNavigation)
                    .WithMany(p => p.TagBadge)
                    .HasForeignKey(d => d.IdTag)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tag_Badge_Tag");
            });

            modelBuilder.Entity<Verification>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(100)
                    .ValueGeneratedNever();

                entity.Property(e => e.AllowedOrigins)
                    .HasColumnName("allowedOrigins")
                    .HasMaxLength(50);

                entity.Property(e => e.StartWith)
                    .HasColumnName("startWith")
                    .HasMaxLength(50);

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasMaxLength(50);
            });
        }
    }
}
