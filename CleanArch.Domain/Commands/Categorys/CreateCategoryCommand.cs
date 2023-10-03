using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Commands.Categorys
{
    public class CreateCategoryCommand : CategoryCommand
    {
        public CreateCategoryCommand( string name , int displayorder)
        {
              Name = name;
            DisplayOrder = displayorder;
        }

    }
}
