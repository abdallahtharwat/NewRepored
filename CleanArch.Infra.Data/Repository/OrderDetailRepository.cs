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
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private UniversityDBContext _db;
        public OrderDetailRepository(UniversityDBContext db)
        {
            _db = db;
        }
        public void add(OrderDetail entity)
        {
            _db.orderDetails.Add(entity);
            _db.SaveChanges();
        }

        public OrderDetail Get(Expression<Func<OrderDetail, bool>> filter, string? includeproperties = null, bool tracked = false)
        {
            IQueryable<OrderDetail> query;
            if (tracked)
            {
                query = _db.orderDetails;
            }
            else
            {
                query = _db.orderDetails.AsNoTracking();
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

        public IEnumerable<OrderDetail> GetAll(Expression<Func<OrderDetail, bool>>? filter = null, string? includeproperties = null)
        {
            IQueryable<OrderDetail> query = _db.orderDetails;
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

        public void Remove(OrderDetail entity)
        {
            _db.orderDetails.Remove(entity);
            _db.SaveChanges();
        }

        public void RemoveRange(IEnumerable<OrderDetail> entity)
        {
            _db.orderDetails.RemoveRange(entity);
            _db.SaveChanges();
        }

        public void Update(OrderDetail entity)
        {
            _db.orderDetails.Update(entity);
            _db.SaveChanges();
        }
    }
}
