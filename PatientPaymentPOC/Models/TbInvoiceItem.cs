﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientPaymentPOC.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    namespace InvoiceItem
    {
        public class TbInvoiceItem
        {


            #region Instance Properties
            [Display(Name = "InvoiceItemId")]
            [Required]
            public int InvoiceItemId { get; set; }

            [Display(Name = "InvoiceId")]
            public int InvoiceId { get; set; }

            [Display(Name = "ItemDescription")]
            [StringLength(500)]
            public string ItemDescription { get; set; }

            [Display(Name = "ItemAmt")]
            public int ItemAmt { get; set; }

            [Display(Name = "DateCreated")]
            public DateTime DateCreated { get; set; }



            #endregion Instance Properties}

    }

   
}
