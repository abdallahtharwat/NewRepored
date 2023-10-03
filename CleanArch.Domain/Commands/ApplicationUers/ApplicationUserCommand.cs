using CleanArch.Domain.Core.Commands;
using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Commands.ApplicationUers
{
    public class ApplicationUserCommand : Command
    {
        public string Id { get; set; }
        public ApplicationUser applicationUser { get; set; }
    }
}
