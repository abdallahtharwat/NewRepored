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
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private UniversityDBContext _db;
        public ApplicationUserRepository(UniversityDBContext db)
        {
            _db = db;
        }

        public void add(ApplicationUser entity)
        {
            _db.applicationUsers.Add(entity);
            _db.SaveChanges();
        }

        public ApplicationUser Get(Expression<Func<ApplicationUser, bool>> filter, string? includeproperties = null, bool tracked = false)
        {
            IQueryable<ApplicationUser> query;
            if (tracked)
            {
                query = _db.applicationUsers;
            }
            else
            {
                query = _db.applicationUsers.AsNoTracking();
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

        public IEnumerable<ApplicationUser> GetAll(Expression<Func<ApplicationUser, bool>>? filter = null, string? includeproperties = null)
        {
            IQueryable<ApplicationUser> query = _db.applicationUsers;
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

        public void Remove(ApplicationUser entity)
        {
            _db.applicationUsers.Remove(entity);
            _db.SaveChanges();
        }

        public void RemoveRange(IEnumerable<ApplicationUser> entity)
        {
            throw new NotImplementedException();
        }

        public void Update(ApplicationUser entity)
        {
            _db.applicationUsers.Update(entity);
            _db.SaveChanges();
        }
    }
}
