using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Commands.Companies
{
    public class DeleteCompanyCommand : CompanyCommand
    {
        public DeleteCompanyCommand(int id)
        {
            Id = id;
        }
    }
}
