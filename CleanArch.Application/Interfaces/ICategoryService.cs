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
    public interface ICategoryService
    {

        IEnumerable<Category> GetAll(Expression<Func<Category, bool>>? filter = null, string? includeproperties = null);
        Category Get(Expression<Func<Category, bool>> filter, string? includeproperties = null, bool tracked = false);             /* select from database*/
        void add(Category entity);
        void Remove(Category entity);
        void RemoveRange(IEnumerable<Category> entity);
        void Update(Category entity);
         //void Save( Category category);
    }
}
