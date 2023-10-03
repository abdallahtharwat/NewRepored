using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Commands.types
{
    public class DeletetypeCommand : typeCommand
    {
        public DeletetypeCommand( int id)
        {
            Id = id;
        }

    }
}
