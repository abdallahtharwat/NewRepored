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
    public class CompanyRepository : ICompanyRepository
    {
        private UniversityDBContext _db;
        public CompanyRepository(UniversityDBContext db)
        {

            _db = db;
        }

        public void add(Company entity)
        {
            _db.companies.Add(entity);
            _db.SaveChanges();
        }

        public Company Get(Expression<Func<Company, bool>> filter, string? includeproperties = null, bool tracked = false)
        {
            IQueryable<Company> query;
            if (tracked)
            {
                query = _db.companies;
            }
            else
            {
                query = _db.companies.AsNoTracking();
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

        public IEnumerable<Company> GetAll(Expression<Func<Company, bool>>? filter = null, string? includeproperties = null)
        {
            IQueryable<Company> query = _db.companies;
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

        public void Remove(Company entity)
        {
            _db.companies.Remove(entity);
            _db.SaveChanges();
        }

        public void RemoveRange(IEnumerable<Company> entity)
        {
            _db.companies.RemoveRange(entity);
            _db.SaveChanges();
        }

        public void Update(Company entity)
        {
            _db.companies.Update(entity);
            _db.SaveChanges();
        }



    }
}
