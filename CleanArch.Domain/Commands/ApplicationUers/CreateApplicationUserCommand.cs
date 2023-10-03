using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Commands.ApplicationUers
{
    public class CreateApplicationUserCommand : ApplicationUserCommand
    {
        public CreateApplicationUserCommand(ApplicationUser ApplicationUser)
        {
                 applicationUser = ApplicationUser;
        }
    }
}
