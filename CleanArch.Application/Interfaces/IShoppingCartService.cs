using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Interfaces
{
    public interface IShoppingCartService
    {
        IEnumerable<ShopingCart> GetAll(Expression<Func<ShopingCart, bool>>? filter = null, string? includeproperties = null);
        ShopingCart Get(Expression<Func<ShopingCart, bool>> filter, string? includeproperties = null, bool tracked = false);             /* select from database*/
        void add(ShopingCart entity);
        void Remove(ShopingCart entity);
        void RemoveRange(IEnumerable<ShopingCart> entity);
        void Update(ShopingCart entity);
    }
}
