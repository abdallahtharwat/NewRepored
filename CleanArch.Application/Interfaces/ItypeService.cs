using CleanArch.Application.ViewModel;
using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Interfaces
{
    public interface ItypeService
    {

        IEnumerable<type> GetAll(Expression<Func<type, bool>>? filter = null, string? includeproperties = null);
        type Get(Expression<Func<type, bool>> filter, string? includeproperties = null, bool tracked = false);             /* select from database*/
        void add(type entity);
        void Remove(type entity);
        void RemoveRange(IEnumerable<type> entity);
        void Update(type entity);
         //void Save( Category category);
    }
}
