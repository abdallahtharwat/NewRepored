using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Interfaces
{
    public interface IProductImageService
    {
        IEnumerable<ProductImage> GetAll(Expression<Func<ProductImage, bool>>? filter = null, string? includeproperties = null);
        ProductImage Get(Expression<Func<ProductImage, bool>> filter, string? includeproperties = null, bool tracked = false);             /* select from database*/
        Task<bool> add(ProductImage entity);
        Task<bool> Remove(int id);
        Task<bool> RemoveRange(IEnumerable<ProductImage> entity);
        Task<bool> Update(ProductImage entity);
    }
}
