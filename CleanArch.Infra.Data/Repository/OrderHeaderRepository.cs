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
    public class OrderHeaderRepository : IOrderHeaderRepository
    {
        private UniversityDBContext _db;
        public OrderHeaderRepository(UniversityDBContext db)
        {
            _db = db;
        }
        public void add(OrderHeader entity)
        {
            _db.orderHeaders.Add(entity);
            _db.SaveChanges();
        }

        public OrderHeader Get(Expression<Func<OrderHeader, bool>> filter, string? includeproperties = null, bool tracked = false)
        {
            IQueryable<OrderHeader> query;
            if (tracked)
            {
                query = _db.orderHeaders;
            }
            else
            {
                query = _db.orderHeaders.AsNoTracking();
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

        public IEnumerable<OrderHeader> GetAll(Expression<Func<OrderHeader, bool>>? filter = null, string? includeproperties = null)
        {
            IQueryable<OrderHeader> query = _db.orderHeaders;
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

        public void Remove(OrderHeader entity)
        {
            _db.orderHeaders.Remove(entity);
            _db.SaveChanges();
        }

        public void RemoveRange(IEnumerable<OrderHeader> entity)
        {
            _db.orderHeaders.RemoveRange(entity);
            _db.SaveChanges();
        }

        public void Update(OrderHeader entity)
        {
            _db.orderHeaders.Update(entity);
            _db.SaveChanges();
        }


        public void UpdateStatus(int id, string orderStatus, string? paymentStatus = null)
        {
            var orderFromDb = _db.orderHeaders.FirstOrDefault(u => u.Id == id); // retrieve orderheader from database based on Id
            if (orderFromDb != null)      // work on order status
            {
                orderFromDb.OrderStatus = orderStatus;   // if order from db is not null we can update orderstatus drom db  

                if (!string.IsNullOrEmpty(paymentStatus)) // if that is not null or empty then we will update the payment status  
                {
                    orderFromDb.PaymentStatus = paymentStatus;
                }
            }
                _db.SaveChanges();
        }

        public void UpdateStripePaymentID(int id, string sessionId, string paymentIntentId)
        {
            var orderFromDb = _db.orderHeaders.FirstOrDefault(u => u.Id == id);

            if (!string.IsNullOrEmpty(sessionId))  // if sessionid is not null we will update order from db 
            {
                orderFromDb.SessionId = sessionId;  //we will update  from db ( when a user try to make a payment)
            }

            if (!string.IsNullOrEmpty(paymentIntentId))  // if paymentIntentId is not null that mean the payment was sussfull 
            {
                orderFromDb.PaymentIntentId = paymentIntentId;  //we will update paymentIntentId from db 
                orderFromDb.PaymentDate = DateTime.Now;  // update payment date
            }

            _db.SaveChanges();

        }
    }
}
