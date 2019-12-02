using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientPaymentPOC.Models
{
    public class ApplicationUser :IdentityUser
    {



        public bool IsAccepted { get; set; }

        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }

        public ApplicationUser()
        {
            IsActive = true;
            IsDeleted = false;
            Created = DateTime.Now;
        }
    }
}
