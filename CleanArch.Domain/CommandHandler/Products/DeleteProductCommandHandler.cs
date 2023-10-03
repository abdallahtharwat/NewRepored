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
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private IProductRepository _productRepository;

        public DeleteProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async  Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {

            //var product = new Product()
            //  {
           
            //    Id = request.Id,
            //    };
            //_productRepository.Remove();
            //return Task.FromResult(true);


           var subject = request.Id;
           var result = await _productRepository.Remove(subject);
            return result;




        }



        //public Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
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

        //    _productRepository.Remove(product);

        //    return Task.FromResult(true);
        //}
    }
}
