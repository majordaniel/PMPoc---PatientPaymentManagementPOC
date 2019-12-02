using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PatientPaymentPOC.Data.Models.tbpatientinfo
{
  
        public class TbPatientInfo
        {


      
            [Display(Name = "PatientId")]
            [Required]
            public int PatientId { get; set; }

            [Display(Name = "FirstName")]
            [StringLength(500)]
            public string FirstName { get; set; }

            [Display(Name = "LastName")]
            [StringLength(500)]
            public string LastName { get; set; }

            [Display(Name = "DOB")]
            public DateTime DOB { get; set; }

            [Display(Name = "Email")]
            [StringLength(500)]
            public string Email { get; set; }

            [Display(Name = "PhoneNo")]
            [StringLength(50)]
            public string PhoneNo { get; set; }

            [Display(Name = "State")]
            [StringLength(500)]
            public string State { get; set; }

            [Display(Name = "LGA")]
            [StringLength(500)]
            public string LGA { get; set; }

            [Display(Name = "Gender")]
            [StringLength(500)]
            public string Gender { get; set; }

            [Display(Name = "BGroup")]
            [StringLength(500)]
            public string BGroup { get; set; }

            [Display(Name = "GType")]
            [StringLength(500)]
            public string GType { get; set; }

            [Display(Name = "DateCreated")]
            public DateTime DateCreated { get; set; }

    


    }
    

}
