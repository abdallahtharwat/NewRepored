using AutoMapper;
using AutoMapper.Execution;
using CleanArch.Application.Interfaces;
using CleanArch.Domain.Commands.ProductImages;
using CleanArch.Domain.Commands.Products;
using CleanArch.Domain.Core.Bus;
using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using CleanArch.Domain.ViewModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Services
{
    public class ProductService : IProductService
    {

        private readonly IProductRepository _productRepository;
        private readonly IMediatorHandler _Bus;
        private readonly IMapper _mapper;


        public ProductService(IProductRepository productRepository, IMediatorHandler Bus, IMapper mapper)
        {

            _productRepository = productRepository;
            _Bus = Bus;
            _mapper = mapper;
        }

        public async Task<bool> add(Product entity, List<IFormFile>? files = null, string? wwwRootPath = null)
        {
          
            var addQrFillCommand = new CreateProductCommand(entity);
             await _Bus.SendCommand(addQrFillCommand);
            await uploadfile(entity, files, wwwRootPath);
            return true;
            
        }
        
        public Product Get(Expression<Func<Product, bool>> filter, string? includeproperties = null, bool tracked = false)
        {
            return _productRepository.Get(filter, includeproperties, tracked);
        }

        public IEnumerable<Product> GetAll(Expression<Func<Product, bool>>? filter = null, string? includeproperties = null)
        {
            return _productRepository.GetAll(filter, includeproperties);
        }

        public async Task<bool> Remove(int id  )
        {
            var addQrFillCommand = new DeleteProductCommand(id);
              await _Bus.SendCommand(addQrFillCommand);
            return true;


        }

        public Task<bool> RemoveRange(IEnumerable<Product> entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(Product entity , List<IFormFile>? files = null, string? wwwRootPath = null)
        {
            var addQrFillCommand = new EditProductCommand(entity);
             await _Bus.SendCommand(addQrFillCommand);
            await uploadfile(entity, files, wwwRootPath);
            return true;
        }

        private async Task uploadfile(Product productVM, List<IFormFile>? files = null, string? wwwRootPath = null)
        {
            //string wwwRootPath = _WebHostEnvironment.WebRootPath;  // access to wwwroot folder
            if (files != null)
            {
                // we can iterate through each file that were uploaded 
                foreach (IFormFile file in files)
                {
                    // unique name for image
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = @"images\products\product-" + productVM.Id; // we need to add the productID
                    string finalPath = Path.Combine(wwwRootPath, productPath); // the location where to have save images

                    // we will have to create this particular product folder in linen(95) if that does not exist
                    if (!Directory.Exists(finalPath))  // if final path is not exists
                        Directory.CreateDirectory(finalPath); // will create that particular  ||  to upload all the files 

                    // change piets to file and  (( Save the photo))
                    using (var fileStream = new FileStream(Path.Combine(finalPath, fileName), FileMode.Create))  // where to have save the file
                    {
                        file.CopyTo(fileStream);      // that will copy the file in the new location|| that we added  in line 76
                    }

                    ProductImage productImage = new()   //save
                    {
                        ImageUrl = @"\" + productPath + @"\" + fileName,
                        ProductId = productVM.Id,
                        product = null
                    };

                    // that way we will not get an exception if product image is null
                    if (productVM.productImages == null)
                        productVM.productImages = new List<ProductImage>();

                    productVM.productImages.Add(productImage);
                }

                var addQrFillCommand = new EditProductCommand(productVM);
                await _Bus.SendCommand(addQrFillCommand);
                //_productService.Update(productVM);
            }
        }





    }
}
