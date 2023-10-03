using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Commands.Companies
{
    public class CreateCompanyCommand : CompanyCommand
    {

        public CreateCompanyCommand( Company companyy)
        {
            company = companyy;
        }
    }
}
