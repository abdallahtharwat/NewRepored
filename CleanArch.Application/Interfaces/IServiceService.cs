using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Interfaces
{
    public interface IServiceService
    {

        IEnumerable<service> GetAll(Expression<Func<service, bool>>? filter = null, string? includeproperties = null);
        service Get(Expression<Func<service, bool>> filter, string? includeproperties = null, bool tracked = false);             /* select from database*/
        Task<bool> add(service entity);
        Task<bool> Remove(int id);
        Task<bool> RemoveRange(IEnumerable<service> entity);
        Task<bool> Update(service entity);
    }
}
