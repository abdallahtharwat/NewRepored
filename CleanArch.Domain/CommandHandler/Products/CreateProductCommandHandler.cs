using CleanArch.Domain.Commands.Categorys;
using CleanArch.Domain.Commands.Products;
using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.CommandHandler.Products
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, bool>
    {
        private IProductRepository _productRepository;

        public CreateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<bool> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var subject = request.Product;
            var result = await _productRepository.add(subject);
            return result;
        }

        //public Task<bool> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        //{
        //    var product = new Product()
        //    {
        //        CategoryId = request.CategoryId,
        //        Title = request.Title,
        //        Description = request.Description,
        //        Brand = request.Brand,
        //        Color = request.Color,
        //        Code = request.Code,
        //        Price = request.Price,
        //        productImages = request.productImages,
        //        Id =request.Id


        //    };

        //    _productRepository.add(product);

        //    return Task.FromResult(true);
        //}





    }
}
