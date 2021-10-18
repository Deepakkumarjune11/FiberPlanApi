using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace FiberPlanAPI.FiberConnection
{
    public partial class fiber_connectionContext : DbContext
    {
        public fiber_connectionContext()
        {
        }

        public fiber_connectionContext(DbContextOptions<fiber_connectionContext> options)
            : base(options)
        {
        }

        public virtual DbSet<FiberPlan> FiberPlans { get; set; }
        public virtual DbSet<Offer> Offers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tcp:fiberplan.database.windows.net,1433;Initial Catalog=fiberconnection;Persist Security Info=False;User ID=team3;Password=Bdgs@007;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<FiberPlan>(entity =>
            {
                entity.HasKey(e => e.PlanId)
                    .HasName("PK__FiberPla__755C22D7B7FB4E8C");

                entity.ToTable("FiberPlan");

                entity.Property(e => e.PlanId)
                    .ValueGeneratedNever()
                    .HasColumnName("PlanID");

                entity.Property(e => e.Image).IsUnicode(false);

                entity.Property(e => e.OfferId).HasColumnName("OfferID");

                entity.Property(e => e.PlanName).IsUnicode(false);

                entity.Property(e => e.PlanPrice)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PlanSpeed)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Validity)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Offer)
                    .WithMany(p => p.FiberPlans)
                    .HasForeignKey(d => d.OfferId)
                    .HasConstraintName("FK__FiberPlan__Offer__7E37BEF6");
            });

            modelBuilder.Entity<Offer>(entity =>
            {
                entity.Property(e => e.OfferId).HasColumnName("OfferID");

                entity.Property(e => e.Hotstar)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Hungamaplay)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Lionplay)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Netflix)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Others).IsUnicode(false);

                entity.Property(e => e.Ultra)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Voot)
                    .HasMaxLength(3)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
