using CleanArch.Domain.Commands.Companies;
using CleanArch.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.CommandHandler.Companies
{
    public class EditCompanyCommandHandler : IRequestHandler<EditCompanyCommand, bool>
    {
        private ICompanyRepository _companyRepository;

        public EditCompanyCommandHandler(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public Task<bool> Handle(EditCompanyCommand request, CancellationToken cancellationToken)
        {
            var Company = request.company;
            _companyRepository.Update(Company);
            return Task.FromResult(true);
        }
    }
}
