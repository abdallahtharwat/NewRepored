using AutoMapper;
using CleanArch.Application.Interfaces;
using CleanArch.Domain.Commands.ProductImages;
using CleanArch.Domain.Core.Bus;
using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Services
{
    public class ProductImageService : IProductImageService
    {
        private readonly IProductImageRepository _productImageRepository;
        private readonly IMediatorHandler _Bus;
        private readonly IMapper _mapper;

        public ProductImageService(IProductImageRepository productImageRepository, IMediatorHandler Bus, IMapper mapper)
        {

            _productImageRepository = productImageRepository;
            _Bus = Bus;
            _mapper = mapper;
        }

        public async Task<bool> add(ProductImage entity)
        {
            var add = new CreateProductImageCommand(entity);
           await _Bus.SendCommand(add);
            return true;
        }

        public ProductImage Get(Expression<Func<ProductImage, bool>> filter, string? includeproperties = null, bool tracked = false)
        {
            return _productImageRepository.Get(filter, includeproperties, tracked);
        }

        public IEnumerable<ProductImage> GetAll(Expression<Func<ProductImage, bool>>? filter = null, string? includeproperties = null)
        {
            return _productImageRepository.GetAll(filter, includeproperties);
        }

        public async Task<bool> Remove(int id)
        {
            var delete = new DeleteProductImageCommand(id);
            await _Bus.SendCommand(delete);
            return true;
        }

        public Task<bool> RemoveRange(IEnumerable<ProductImage> entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(ProductImage entity)
        {
            var edit = new EditProductImageCommand(entity);
             await _Bus.SendCommand(edit);
            return true;
        }


    }
}
