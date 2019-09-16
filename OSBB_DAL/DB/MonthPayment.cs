namespace OSBB_DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MonthPayment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MonthPayment()
        {
            MonthPaymentsDetails = new HashSet<MonthPaymentsDetail>();
        }

        [Key]
        public int MonthPaymentsId { get; set; }

        [Required]
        public int MonthPaymentsNum { get; set; }

        public int ApartmentId { get; set; }

        public virtual Apartment Apartment { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MonthPaymentsDetail> MonthPaymentsDetails { get; set; }
    }
}
