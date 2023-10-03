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
    public class EditProductCommandHandler : IRequestHandler<EditProductCommand, bool>
    {
        private IProductRepository _productRepository;

        public EditProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<bool> Handle(EditProductCommand request, CancellationToken cancellationToken)
        {
            var subject = request.Product;
            var result = await _productRepository.Update(subject);
            return result;
        }



        //public Task<bool> Handle(EditProductCommand request, CancellationToken cancellationToken)
        //{
        //    var product = new Product()
        //    {
        //        CategoryId = request.CategoryId,
        //        Id = request.Id,
        //        Title = request.Title,
        //        Description = request.Description,
        //        Brand = request.Brand,
        //        Color = request.Color,
        //        Code = request.Code,
        //        Price = request.Price,
        //        productImages = request.productImages

        //    };

        //    _productRepository.Update(product);

        //    return Task.FromResult(true);
        //}
    }
}
