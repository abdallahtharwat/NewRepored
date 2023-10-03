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
    public class ServiceRepository : IServiceRepository
    {

        private UniversityDBContext _db;
        public ServiceRepository(UniversityDBContext db)
        {

            _db = db;
        }

        public async Task<bool> add(service entity)
        {

            try
            {
                await _db.services.AddAsync(entity);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }


        }

        public service Get(Expression<Func<service, bool>> filter, string? includeproperties = null, bool tracked = false)
        {
            IQueryable<service> query;
            if (tracked)
            {
                query = _db.services;
            }
            else
            {
                query = _db.services.AsNoTracking();
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

        public IEnumerable<service> GetAll(Expression<Func<service, bool>>? filter = null, string? includeproperties = null)
        {
            IQueryable<service> query = _db.services;
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
            var service = await _db.services.FindAsync(id);
            if (service != null)
            {
                _db.services.Remove(service);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;

        }

        public Task<bool> RemoveRange(IEnumerable<service> entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(service entity)
        {


            try
            {
                _db.services.Update(entity);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }


        }




    }
}



    

