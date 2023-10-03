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

    public class ProductRepository : IProductRepository
    {

        private UniversityDBContext _db;
        public ProductRepository(UniversityDBContext db)
        {
                
            _db = db;
        }

        public async Task<bool> add(Product entity)
        {

            try
            {
                await _db.products.AddAsync(entity);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }


        }

        public Product Get(Expression<Func<Product, bool>> filter, string? includeproperties = null, bool tracked = false)
        {
            IQueryable<Product> query;
            if (tracked)
            {
                query = _db.products;
            }
            else
            {
                query = _db.products.AsNoTracking();
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

        public IEnumerable<Product> GetAll(Expression<Func<Product, bool>>? filter = null, string? includeproperties = null)
        {
            IQueryable<Product> query = _db.products;
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

        public async Task<bool> Remove(int id)
        {
            var produt = await _db.products.FindAsync(id);
            if(produt != null)
            {
                _db.products.Remove(produt);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
              
        }

        public Task<bool> RemoveRange(IEnumerable<Product> entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(Product entity)
        {
             _db.products.Update(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        //public void add(Product entity)
        //{
        //    _db.products.Add(entity);
        //    _db.SaveChanges();
        //}

        //public Product Get(Expression<Func<Product, bool>> filter, string? includeproperties = null, bool tracked = false)
        //{
        //    IQueryable<Product> query;
        //    if (tracked)
        //    {
        //        query = _db.products; 
        //    }
        //    else
        //    {
        //        query = _db.products.AsNoTracking();
        //    }
        //    query = query.Where(filter);
        //    if (!string.IsNullOrEmpty(includeproperties))
        //    {
        //        foreach (var includeProp in includeproperties
        //            .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        //        {
        //            query = query.Include(includeProp);
        //        }
        //    }
        //    return query.FirstOrDefault();
        //}

        //public IEnumerable<Product> GetAll(Expression<Func<Product, bool>>? filter = null, string? includeproperties = null)
        //{
        //    IQueryable<Product> query = _db.products;
        //    if (filter != null)
        //    {
        //        query = query.Where(filter);
        //    }
        //    if (!string.IsNullOrEmpty(includeproperties))
        //    {
        //        foreach (var includeprop in includeproperties
        //            .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        //        {
        //            query = query.Include(includeprop);
        //        }
        //    }

        //    return query.ToList();
        //}

        //public void Remove(Product entity)
        //{
        //    _db.products.Remove(entity);
        //    _db.SaveChanges();
        //}

        //public void RemoveRange(IEnumerable<Product> entity)
        //{
        //    _db.products.RemoveRange(entity);
        //    _db.SaveChanges();
        //}

        //public void Update(Product entity)
        //{
        //    _db.products.Update(entity);
        //    _db.SaveChanges();
        //}


    }
}
