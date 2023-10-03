using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Interfaces
{
    public interface IProductRepository
    {

        IEnumerable<Product> GetAll(Expression<Func<Product, bool>>? filter = null, string? includeproperties = null);
        Product Get(Expression<Func<Product, bool>> filter, string? includeproperties = null, bool tracked = false);             /* select from database*/
           Task<bool> add(Product entity);
        Task<bool> Remove(int id );
        Task<bool> RemoveRange(IEnumerable<Product> entity);
        Task<bool> Update(Product entity);

        //void Save(Category entity);

    }
}
