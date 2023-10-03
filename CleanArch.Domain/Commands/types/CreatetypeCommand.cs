using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Commands.types
{
    public class CreatetypeCommand : typeCommand
    {
        public CreatetypeCommand( string name , int displayorder)
        {
              Name = name;
            DisplayOrder = displayorder;
        }

    }
}
