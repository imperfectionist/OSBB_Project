namespace OSBB_DAL.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class OSBB_Context : DbContext
    {
        public OSBB_Context()
            : base("name=OSBB_Context")
        {
        }

        public virtual DbSet<Apartment> Apartments { get; set; }
        public virtual DbSet<Benefit> Benefits { get; set; }
        public virtual DbSet<MonthPayment> MonthPayments { get; set; }
        public virtual DbSet<MonthPaymentsDetail> MonthPaymentsDetails { get; set; }
        public virtual DbSet<Unit> Units { get; set; }
        public virtual DbSet<Utility> Utilities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Apartment>()
                .Property(e => e.TotalSquare)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Apartment>()
                .Property(e => e.LivingSquare)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Apartment>()
                .HasMany(e => e.MonthPayments)
                .WithRequired(e => e.Apartment)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MonthPayment>()
                .HasMany(e => e.MonthPaymentsDetails)
                .WithRequired(e => e.MonthPayment)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MonthPaymentsDetail>()
                .Property(e => e.PaymentSum)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Utility>()
                .Property(e => e.UtilityPrice)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Utility>()
                .Property(e => e.UtilityNorm)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Utility>()
                .HasMany(e => e.MonthPaymentsDetails)
                .WithRequired(e => e.Utility)
                .WillCascadeOnDelete(false);
        }
    }
}
