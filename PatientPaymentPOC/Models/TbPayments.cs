using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientPaymentPOC.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    namespace tbpayments
    {
        public class tbpayments
        {


            #region Instance Properties
            [Display(Name = "PaymentId")]
            [Required]
            public Int32 PaymentId { get; set; }

            [Display(Name = "InvoiceId")]
            public Int32? InvoiceId { get; set; }

            [Display(Name = "InvoiceTotalAmt")]
            public Decimal? InvoiceTotalAmt { get; set; }

            [Display(Name = "AmtPaidSoFar")]
            public Decimal? AmtPaidSoFar { get; set; }

            [Display(Name = "AmtPaidNow")]
            public Decimal? AmtPaidNow { get; set; }

            [Display(Name = "Balance")]
            public Decimal? Balance { get; set; }

            [Display(Name = "PaymentDate")]
            public DateTime? PaymentDate { get; set; }

            [Display(Name = "ModeOfPayment")]
            [StringLength(50)]
            public String ModeOfPayment { get; set; }

            [Display(Name = "DateCreated")]
            public DateTime? DateCreated { get; set; }



            #endregion Instance Properties}

    }

 

}
