namespace OSBB_DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MonthPaymentsDetail
    {
        public int MonthPaymentsDetailId { get; set; }

        public int MonthPaymentsId { get; set; }

        public int UtilityId { get; set; }

        public int? MeterIndexStart { get; set; }

        public int? MeterIndexEnd { get; set; }

        public decimal PaymentSum { get; set; }

        public virtual MonthPayment MonthPayment { get; set; }

        public virtual Utility Utility { get; set; }
    }
}
