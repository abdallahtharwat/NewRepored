using CleanArch.Domain.Commands.ProductImages;
using CleanArch.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.CommandHandler.ProductImages
{
    public class CreateProductImageCommandHandler : IRequestHandler<CreateProductImageCommand, bool>
    {
        private IProductImageRepository  _productImageRepository;

        public CreateProductImageCommandHandler(IProductImageRepository productImageRepository)
        {
            _productImageRepository = productImageRepository;
        }

        public async Task<bool> Handle(CreateProductImageCommand request, CancellationToken cancellationToken)
        {

            var productImage = request.ProductImage;
             await _productImageRepository.add(productImage);
            return true;
        }
    }
}
