using CleanArch.Domain.Commands.ProductImages;
using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.CommandHandler.ProductImages
{
    public class DeleteProductImageCommandHandler : IRequestHandler<DeleteProductImageCommand, bool>
    {
        private IProductImageRepository _productImageRepository;

        public DeleteProductImageCommandHandler(IProductImageRepository productImageRepository)
        {
            _productImageRepository = productImageRepository;
        }

        public async Task<bool> Handle(DeleteProductImageCommand request, CancellationToken cancellationToken)
        {
            var ProductImage = new ProductImage()
            {
                Id = request.Id
            };
            await _productImageRepository.Remove(ProductImage);
            return true;
        }
    }
}
