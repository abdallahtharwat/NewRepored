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
    public class EditProductImageCommandHandler : IRequestHandler<EditProductImageCommand, bool>
    {
        private IProductImageRepository  _productImageRepository;

        public EditProductImageCommandHandler(IProductImageRepository   productImageRepository)
        {
            _productImageRepository = productImageRepository;
        }

        public async Task<bool> Handle(EditProductImageCommand request, CancellationToken cancellationToken)
        {
            var productimages = request.ProductImage;
            await _productImageRepository.Update(productimages);
            return true;
        }
    }
}
