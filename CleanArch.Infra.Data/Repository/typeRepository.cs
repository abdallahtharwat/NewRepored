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
    public class typeRepository : ItypeRepository
    {

        private UniversityDBContext _db;
        public typeRepository(UniversityDBContext db)
        {

            _db = db;
        }
        public void add(type entity)
        {
            _db.types.Add(entity);
            _db.SaveChanges();
        }

        public type Get(Expression<Func<type, bool>> filter, string? includeproperties = null, bool tracked = false)
        {
            IQueryable<type> query;
            if (tracked)
            {
                query = _db.types;
            }
            else
            {
                query = _db.types.AsNoTracking();
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

        public IEnumerable<type> GetAll(Expression<Func<type, bool>>? filter = null, string? includeproperties = null)
        {
            IQueryable<type> query = _db.types;
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

        public void Remove(type entity)
        {
            _db.types.Remove(entity);
            _db.SaveChanges();
        }

        public void RemoveRange(IEnumerable<type> entity)
        {
            throw new NotImplementedException();
        }

        public void Update(type entity)
        {
            _db.types.Update(entity);
            _db.SaveChanges();
        }
    }
}
