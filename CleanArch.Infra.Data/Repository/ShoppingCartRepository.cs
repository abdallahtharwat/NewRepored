using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using CleanArch.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Infra.Data.Repository
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private UniversityDBContext _db;
        public ShoppingCartRepository(UniversityDBContext db)
        {
            _db = db;
        }

        public void add(ShopingCart entity)
        {
            _db.shopingCarts.Add(entity);
            _db.SaveChanges();
        }

        public ShopingCart Get(Expression<Func<ShopingCart, bool>> filter, string? includeproperties = null, bool tracked = false)
        {
            IQueryable<ShopingCart> query;
            if (tracked)
            {
                query = _db.shopingCarts;
            }
            else
            {
                query = _db.shopingCarts.AsNoTracking();
            }
            query = query.Where(filter);
            if (!string.IsNullOrEmpty(includeproperties))
            {
                foreach (var includeProp in includeproperties
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.FirstOrDefault();
        }

        public IEnumerable<ShopingCart> GetAll(Expression<Func<ShopingCart, bool>>? filter = null, string? includeproperties = null)
        {
            IQueryable<ShopingCart> query = _db.shopingCarts;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (!string.IsNullOrEmpty(includeproperties))
            {
                foreach (var includeprop in includeproperties
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeprop);
                }
            }

            return query.ToList();
        }

        public void Remove(ShopingCart entity)
        {
            _db.shopingCarts.Remove(entity);
            _db.SaveChanges();
        }

        public void RemoveRange(IEnumerable<ShopingCart> entity)
        {
            _db.shopingCarts.RemoveRange(entity);
            _db.SaveChanges();
        }

        public void Update(ShopingCart entity)
        {
            _db.shopingCarts.Update(entity);
            _db.SaveChanges();
        }
    }
}
