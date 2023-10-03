using AutoMapper;
using CleanArch.Application.ViewModel;
using CleanArch.Domain.Commands;
using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.AutoMapper
{
    public class ViewModelToDomainProfile : Profile
    {
        public ViewModelToDomainProfile()
        {
            //CreateMap<CourseViewModel, CreateCourseCommand>().ConstructUsing(c => new CreateCourseCommand(c.Name, c.Description, c.ImageUrl));

           // CreateMap<CourseViewModel, CreateCourseCommand>();
            

        }



    }
}


 //CreateMap<CourseViewModel, CreateCourseCommand>()
 //               .ForMember(e => e.Description1 , s=> s.MapFrom(s => s.Description));