using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Commands.types
{
    public class EdittypeCommand : typeCommand
    {
        public EdittypeCommand(string name , int displayorder, int id)
        {
            Id = id;
            Name = name;
            DisplayOrder = displayorder;
        }
    }
}
