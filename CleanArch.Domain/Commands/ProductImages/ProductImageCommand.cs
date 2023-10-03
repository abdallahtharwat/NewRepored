using CleanArch.Domain.Core.Commands;
using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Commands.ProductImages
{
    public class ProductImageCommand : Command
    {
        public int Id { get; set; }

        public ProductImage ProductImage { get; set; }

    }
}
