using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Commands.Companies
{
    public class EditCompanyCommand : CompanyCommand
    {
        public EditCompanyCommand(Company  companyy)
        {
            company = companyy;
        }
    }
}
