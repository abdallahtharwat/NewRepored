using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Interfaces
{
    public interface IApplicationUserRepository
    {
        IEnumerable<ApplicationUser> GetAll(Expression<Func<ApplicationUser, bool>>? filter = null, string? includeproperties = null);
        ApplicationUser Get(Expression<Func<ApplicationUser, bool>> filter, string? includeproperties = null, bool tracked = false);             /* select from database*/
        void add(ApplicationUser entity);
        void Remove(ApplicationUser entity);
        void RemoveRange(IEnumerable<ApplicationUser> entity);
        void Update(ApplicationUser entity);
    }
}
