using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Interfaces
{
    public interface IOrderHeaderRepository
    {
        IEnumerable<OrderHeader> GetAll(Expression<Func<OrderHeader, bool>>? filter = null, string? includeproperties = null);
        OrderHeader Get(Expression<Func<OrderHeader, bool>> filter, string? includeproperties = null, bool tracked = false);             /* select from database*/
        void add(OrderHeader entity);
        void Remove(OrderHeader entity);
        void RemoveRange(IEnumerable<OrderHeader> entity);
        void Update(OrderHeader entity);

        void UpdateStatus(int id, string orderStatus, string? paymentStatus = null);
        void UpdateStripePaymentID(int id, string sessionId, string paymentIntentId);
    }
}
