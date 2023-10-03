using CleanArch.Domain.Commands.Categorys;
using CleanArch.Domain.Commands.Companies;
using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.CommandHandler.Companies
{
    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, bool>
    {
        private ICompanyRepository  _companyRepository;

        public CreateCompanyCommandHandler(ICompanyRepository  companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public Task<bool> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            var Company = request.company;
             _companyRepository.add(Company);
            return Task.FromResult(true);
        }
    }
}
