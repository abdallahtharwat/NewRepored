using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Interfaces
{
    public interface IOrderDetailService
    {
        IEnumerable<OrderDetail> GetAll(Expression<Func<OrderDetail, bool>>? filter = null, string? includeproperties = null);
        OrderDetail Get(Expression<Func<OrderDetail, bool>> filter, string? includeproperties = null, bool tracked = false);             /* select from database*/
        void add(OrderDetail entity);
        void Remove(OrderDetail entity);
        void RemoveRange(IEnumerable<OrderDetail> entity);
        void Update(OrderDetail entity);
    }
}
