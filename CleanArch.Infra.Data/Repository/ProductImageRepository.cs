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
    public class ProductImageRepository : IProductImageRepository
    {
        private UniversityDBContext _db;
        public ProductImageRepository(UniversityDBContext db)
        {

            _db = db;
        }

        public async Task<bool> add(ProductImage entity)
        {
           await   _db.productImages.AddAsync(entity);
          await   _db.SaveChangesAsync();
            return true;

        }

        public ProductImage Get(Expression<Func<ProductImage, bool>> filter, string? includeproperties = null, bool tracked = false)
        {
            IQueryable<ProductImage> query;
            if (tracked)
            {
                query = _db.productImages;
            }
            else
            {
                query = _db.productImages.AsNoTracking();
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

        public IEnumerable<ProductImage> GetAll(Expression<Func<ProductImage, bool>>? filter = null, string? includeproperties = null)
        {
            IQueryable<ProductImage> query = _db.productImages;
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

        public async Task<bool> Remove(ProductImage entity)
        {
            _db.productImages.Remove(entity);
            await   _db.SaveChangesAsync();
            return true;
        }

        public Task<bool> RemoveRange(IEnumerable<ProductImage> entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(ProductImage entity)
        {
             _db.productImages.Update(entity);
            await _db.SaveChangesAsync();
            return true;
        }


    }
}