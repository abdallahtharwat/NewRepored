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

    public class CategoryRepository : ICategoryRepository
    {

        private UniversityDBContext _db;
        public CategoryRepository(UniversityDBContext db)
        {
                
            _db = db;
        }

        public void add(Category entity)
        {
          _db.categories.Add(entity);
           _db.SaveChanges();
        }

        public Category Get(Expression<Func<Category, bool>> filter, string? includeproperties = null, bool tracked = false)
        {
            IQueryable<Category> query;
            if (tracked)
            {
                query = _db.categories;
            }
            else
            {
                query = _db.categories.AsNoTracking();
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

        public IEnumerable<Category> GetAll(Expression<Func<Category, bool>>? filter = null, string? includeproperties = null)
        {
            IQueryable<Category> query = _db.categories;
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

        public void Remove(Category entity)
        {
          _db.categories.Remove(entity);
            _db.SaveChanges();
        }

        public void RemoveRange(IEnumerable<Category> entity)
        {
            _db.categories.RemoveRange(entity);
            _db.SaveChanges();
        }

        public void Update(Category entity)
        {
            _db.categories.Update(entity);
            _db.SaveChanges();
        }

        //public void Save( Category category )
        //{
        //    _db.SaveChanges();
     
        //}



   
     













    }
}
