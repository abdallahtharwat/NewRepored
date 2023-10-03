using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string Name { get; set; }
        public string? StreetAddress { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }
        public string? Build { get; set; }
        public string? apartment { get; set; }


        //  (this dropdown for role (Admin or customer ))   (step 0) add forenkey in ApplicationUser Model    ( step 1 ) to add forienKey  (step 2) we need populate that inside get method  ( step 3 in view )   ( step 4 in line 177  assign role for a user in create user Succeeded  )   add unitofwork
        public int? CompanyId { get; set; } // (step 1) to add forenkey in register   
        [ForeignKey("CompanyId")]
        [ValidateNever]
        public Company? Company { get; set; }

        [NotMapped]
        public string Role { get; set; }

    }
}
