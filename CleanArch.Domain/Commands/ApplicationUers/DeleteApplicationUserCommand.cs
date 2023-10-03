using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Commands.ApplicationUers
{
    public class DeleteApplicationUserCommand : ApplicationUserCommand
    {
        public DeleteApplicationUserCommand(string id  )
        {
            Id = id;
          
        }
    }
}
