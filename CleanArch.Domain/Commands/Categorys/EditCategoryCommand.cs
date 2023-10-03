using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Commands.Categorys
{
    public class EditCategoryCommand : CategoryCommand
    {
        public EditCategoryCommand(string name , int displayorder, int id)
        {
            Id = id;
            Name = name;
            DisplayOrder = displayorder;
        }
    }
}
