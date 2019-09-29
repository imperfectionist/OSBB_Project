namespace OSBB_DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Utility
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Utility()
        {
            MonthPaymentsDetails = new HashSet<MonthPaymentsDetail>();
        }

        public int UtilityId { get; set; }

        [Required]
        [StringLength(300)]
        public string UtilityName { get; set; }

        public int? UnitId { get; set; }

        public decimal UtilityPrice { get; set; }

        public decimal UtilityNorm { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MonthPaymentsDetail> MonthPaymentsDetails { get; set; }

        public virtual Unit Unit { get; set; }
    }
}
