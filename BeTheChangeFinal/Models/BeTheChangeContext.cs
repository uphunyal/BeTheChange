using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BeTheChangeFinal.Models
{
    public partial class BeTheChangeContext : DbContext
    {
        public BeTheChangeContext()
        {
        }

        public BeTheChangeContext(DbContextOptions<BeTheChangeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Charity> Charity { get; set; }
        public virtual DbSet<CharityType> CharityType { get; set; }
        public virtual DbSet<CustomCauses> CustomCauses { get; set; }
        public virtual DbSet<Disaster> Disaster { get; set; }
        public virtual DbSet<DisasterType> DisasterType { get; set; }
        public virtual DbSet<Posts> Posts { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Charity>(entity =>
            {
                entity.Property(e => e.CharityId).HasColumnName("charity_id");

                entity.Property(e => e.CharityDetails)
                    .IsRequired()
                    .HasColumnName("charity_details")
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.CharityLink)
                    .HasColumnName("charity_link")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.CharityLocation)
                    .HasColumnName("charity_location")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.CharityName)
                    .IsRequired()
                    .HasColumnName("charity_name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CharityOrganization)
                    .HasColumnName("charity_organization")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CtypeName)
                    .IsRequired()
                    .HasColumnName("ctype_name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.CtypeNameNavigation)
                    .WithMany(p => p.Charity)
                    .HasForeignKey(d => d.CtypeName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Charity__ctype_n__2C3393D0");
            });

            modelBuilder.Entity<CharityType>(entity =>
            {
                entity.HasKey(e => e.CtypeName)
                    .HasName("PK__Charity___AEFECC1A1C13ADD2");

                entity.ToTable("Charity_Type");

                entity.Property(e => e.CtypeName)
                    .HasColumnName("ctype_name")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CustomCauses>(entity =>
            {
                entity.HasKey(e => e.CustomId)
                    .HasName("PK__Custom_C__8664B23A2218D9AE");

                entity.ToTable("Custom_Causes");

                entity.Property(e => e.CustomId).HasColumnName("custom_id");

                entity.Property(e => e.CauseType)
                    .HasColumnName("cause_type")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomDetails)
                    .IsRequired()
                    .HasColumnName("custom_details")
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.CustomLocation)
                    .HasColumnName("custom_location")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.CustomName)
                    .IsRequired()
                    .HasColumnName("custom_name")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.DonateLink)
                    .HasColumnName("donate_link")
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Disaster>(entity =>
            {
                entity.Property(e => e.DisasterId).HasColumnName("disaster_id");

                entity.Property(e => e.DisasterDetails)
                    .IsRequired()
                    .HasColumnName("disaster_details")
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.DisasterLink)
                    .HasColumnName("disaster_link")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.DisasterLocation)
                    .IsRequired()
                    .HasColumnName("disaster_location")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.DisasterName)
                    .IsRequired()
                    .HasColumnName("disaster_name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DtypeName)
                    .IsRequired()
                    .HasColumnName("dtype_name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Urgency)
                    .IsRequired()
                    .HasColumnName("urgency")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.DtypeNameNavigation)
                    .WithMany(p => p.Disaster)
                    .HasForeignKey(d => d.DtypeName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Disaster__dtype___2F10007B");
            });

            modelBuilder.Entity<DisasterType>(entity =>
            {
                entity.HasKey(e => e.DtypeName)
                    .HasName("PK__Disaster__56E16900129580B2");

                entity.ToTable("Disaster_type");

                entity.Property(e => e.DtypeName)
                    .HasColumnName("dtype_name")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Posts>(entity =>
            {
                entity.HasKey(e => e.PostId)
                    .HasName("PK__Posts__3ED7876680D93C76");

                entity.Property(e => e.PostId).HasColumnName("post_id");

                entity.Property(e => e.PostDate)
                    .HasColumnName("post_date")
                    .HasColumnType("date");

                entity.Property(e => e.PostDetails)
                    .IsRequired()
                    .HasColumnName("post_details")
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.PostTitle)
                    .IsRequired()
                    .HasColumnName("post_title")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserEmail)
                    .IsRequired()
                    .HasColumnName("user_email")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
