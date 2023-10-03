using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArch.Application.Interfaces;
using CleanArch.Application.ViewModel;
using CleanArch.Domain.Commands;
using CleanArch.Domain.Commands.Categorys;
using CleanArch.Domain.Core.Bus;
using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _CategoryRepository;
        private readonly IMediatorHandler _Bus;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository CategoryRepository, IMediatorHandler Bus, IMapper mapper)
        {

            _CategoryRepository = CategoryRepository;
            _Bus = Bus;
            _mapper = mapper;
        }

       

        public Category Get(Expression<Func<Category, bool>> filter, string? includeproperties = null, bool tracked = false)
        {
            return   _CategoryRepository.Get(filter, includeproperties , tracked );
        }

        public IEnumerable<Category> GetAll(Expression<Func<Category, bool>>? filter = null, string? includeproperties = null)
        {
            return _CategoryRepository.GetAll(filter , includeproperties);
        }


        public void Remove(Category entity)
        {
            var DeleteCategoryCommand = new DeleteCategoryCommand
              (
                   entity.Id
              );

            _Bus.SendCommand((DeleteCategoryCommand)DeleteCategoryCommand);
        }

        public void RemoveRange(IEnumerable<Category> entity)
        {
            throw new NotImplementedException();
        }
        public void add(Category entity)
        {


            var CreateCategoryCommand = new CreateCategoryCommand
                (
                    entity.Name,
                    entity.DisplayOrder
                ) ;

            _Bus.SendCommand((CreateCategoryCommand)CreateCategoryCommand);
        }

        public void Update(Category entity)
        {
            var editCategoryCommand = new EditCategoryCommand
                 (
                      
                     entity.Name,
                     entity.DisplayOrder,
                      entity.Id
                 );

            _Bus.SendCommand(editCategoryCommand);
        }



        //public void Save( Category category )
        //{
        //     _CategoryRepository.Save(category);
        //}






        //public IEnumerable<CourseViewModel> GetCourses()
        //{
        //    return _courseRepository.GetCourses().ProjectTo<CourseViewModel>(_mapper.ConfigurationProvider);
        //}



        //public void Create(CourseViewModel courseViewModel)
        //{
        //    //var CreateCourseCommand = new CreateCourseCommand
        //    //    (
        //    //    courseViewModel.Name,
        //    //    courseViewModel.Description,
        //    //    courseViewModel.ImageUrl
        //    //    );


        //    _Bus.SendCommand(_mapper.Map<CreateCourseCommand>(courseViewModel));
        //}

    }
}
