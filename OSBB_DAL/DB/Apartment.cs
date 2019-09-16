namespace OSBB_DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Apartment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Apartment()
        {
            MonthPayments = new HashSet<MonthPayment>();
        }

        public int ApartmentId { get; set; }

        public int ApartmentNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string AccountNumber { get; set; }

        [Required]
        [StringLength(100)]
        public string OwnerName { get; set; }

        [StringLength(100)]
        public string Username { get; set; }

        public decimal TotalSquare { get; set; }

        public decimal LivingSquare { get; set; }

        public int Tenants { get; set; }

        public int? BenefitId { get; set; }

        public virtual Benefit Benefit { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MonthPayment> MonthPayments { get; set; }
    }
}
