using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Commands.ProductImages
{
    public class CreateProductImageCommand : ProductImageCommand
    {
        public CreateProductImageCommand( ProductImage productImages)
        {
            ProductImage = productImages;
        }

    }
}
