using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Commands.Products
{
    public class CreateProductCommand : ProductCommand
    {
        //public CreateProductCommand(string title, string description, string brand , string color, int code , double price , int categoryid
        //    , List<ProductImage> productImage , int id)
        //{
        //    CategoryId = categoryid;
        //     Title = title;
        //    Description = description;
        //    Brand = brand;
        //    Color = color;
        //    Code = code;
        //    Price = price;
        //    productImages = productImage;
        //    Id = id;

        //}

        public CreateProductCommand(Product product)
        {
                Product = product;
        }

    }
}
