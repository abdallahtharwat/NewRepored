using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Commands.ProductImages
{
    public class DeleteProductImageCommand : ProductImageCommand
    {
        public DeleteProductImageCommand(int id)
        {
            Id = id;
        }
    }
}
