using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Commands.Products
{
    public class DeleteProductCommand : ProductCommand
    {
        //public DeleteProductCommand(int id, string title, string description, string brand, string color, int code, double price, int categoryid , List<ProductImage> productImage)
        //{
        //    CategoryId = categoryid;
        //    Id = id;
        //    Title = title;
        //    Description = description;
        //    Brand = brand;
        //    Color = color;
        //    Code = code;
        //    Price = price;
        //    productImages = productImage;


        //}

        public DeleteProductCommand(int id)
        {
            Id = id;
        }

    }
}
