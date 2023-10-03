using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CleanArch.Domain.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required] 
        public string Color { get; set; }
 
        [Required]
        public int Code { get; set; }
        [Required]
        public double Price { get; set; }



        public int CategoryId { get; set; }     //( step 1 for forienKEY) -- STEP 2 in dbcontext class   -- step 3 in product controller -- step 4 in upsert view -- create viewmodel
        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category Category { get; set; }

        public int typeId { get; set; }     //( step 1 for forienKEY) -- STEP 2 in dbcontext class   -- step 3 in product controller -- step 4 in upsert view -- create viewmodel
        [ForeignKey("typeId")]
        [ValidateNever]
        public  type  type { get; set; }

        [ValidateNever]
        public List<ProductImage> productImages { get; set; }

    }
}
