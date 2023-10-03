using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Commands.Categorys
{
    public class DeleteCategoryCommand : CategoryCommand
    {
        public DeleteCategoryCommand( int id)
        {
            Id = id;
        }

    }
}
