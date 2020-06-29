using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SIMSApi.Model
{
    public partial class SIMSContext : DbContext
    {
        public SIMSContext()
        {
        }

        public SIMSContext(DbContextOptions<SIMSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<UserInformation> UserInformation { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //        optionsBuilder.UseSqlServer("Server=.\\;Database=SIMS;Trusted_Connection=True;");
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserInformation>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserFullName).HasDefaultValueSql("(N'FirstName')");

                entity.Property(e => e.UserName).HasDefaultValueSql("(N'userName')");

                entity.Property(e => e.UserPassword).HasDefaultValueSql("((1234))");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.InverseCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserInformation_UserInformation");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.InverseUpdatedByNavigation)
                    .HasForeignKey(d => d.UpdatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserInformation_UserInformation1");

                entity.HasOne(d => d.UserGenderNavigation)
                    .WithMany(p => p.UserInformation)
                    .HasForeignKey(d => d.UserGender)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserInformation_Gender");
            });
        }
    }
}
