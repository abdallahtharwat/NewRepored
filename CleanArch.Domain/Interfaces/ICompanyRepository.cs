using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Interfaces
{
    public interface ICompanyRepository
    {
        IEnumerable<Company> GetAll(Expression<Func<Company, bool>>? filter = null, string? includeproperties = null);
        Company Get(Expression<Func<Company, bool>> filter, string? includeproperties = null, bool tracked = false);             /* select from database*/
        void add(Company entity);
        void Remove(Company entity);
        void RemoveRange(IEnumerable<Company> entity);
        void Update(Company entity);
    }
}
