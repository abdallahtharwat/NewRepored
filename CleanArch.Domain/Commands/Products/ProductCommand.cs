using CleanArch.Domain.Core.Commands;
using CleanArch.Domain.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CleanArch.Domain.Core.Commands.Command;

namespace CleanArch.Domain.Commands.Products
{
    public class ProductCommand : Command
    {
        public int Id { get; set; }

        public Product Product { get; set; }

        //public string Title { get; set; }
   
        //public string Description { get; set; }
   
        //public string Brand { get; set; }
     
        //public string Color { get; set; }

      
        //public int Code { get; set; }
  
        //public double Price { get; set; }
        //public int CategoryId { get; set; }

        //[ValidateNever]
        //public List<ProductImage> productImages { get; set; }

    }
}
