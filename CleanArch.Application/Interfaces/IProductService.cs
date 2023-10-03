using CleanArch.Application.ViewModel;
using CleanArch.Domain.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Interfaces
{
    public interface IProductService
    {

        IEnumerable<Product> GetAll(Expression<Func<Product, bool>>? filter = null, string? includeproperties = null);
        Product Get(Expression<Func<Product, bool>> filter, string? includeproperties = null, bool tracked = false);             /* select from database*/
        Task<bool> add(Product entity, List<IFormFile>? files = null, string? wwwRootPath = null);
        Task<bool> Remove(int id );
        Task<bool> RemoveRange(IEnumerable<Product> entity);
        Task<bool> Update(Product entity, List<IFormFile>? files = null, string? wwwRootPath = null);

      
    }
}
