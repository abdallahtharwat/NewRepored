using CleanArch.Domain.Core.Commands;
using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Commands.Companies
{
    public class CompanyCommand : Command
    {
        public int Id { get; set; }

        public Company company { get; set; }
    }
}
