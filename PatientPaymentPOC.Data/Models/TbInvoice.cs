using PatientPaymentPOC.Data.Models.InvoiceItem;
using PatientPaymentPOC.Data.Models.tbpatientinfo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PatientPaymentPOC.Data.Models.TbInvoice
{
        public class TbInvoice
        {


            #region Instance Properties
            [Display(Name = "InvoiceId")]
            [Required]
            public int InvoiceId { get; set; }

            [Display(Name = "PatientId")]
            public int PatientId { get; set; }

            [Display(Name = "TotalAmt")]
            public int TotalAmt { get; set; }

            [Display(Name = "InvoiceDate")]
            public DateTime InvoiceDate { get; set; }

            [Display(Name = "Status")]
            [StringLength(50)]
            public string Status { get; set; }

            [Display(Name = "DateCreated")]
            public DateTime DateCreated { get; set; }

            public List<TbInvoiceItem> TbInvoiceItem { get; set; }
        //public TbPatientInfo TbPatientInfo { get; set; }





        #endregion Instance Properties}

    

}
