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
    public class DeleteCompanyCommandHandler : IRequestHandler<DeleteCompanyCommand, bool>
    {
        private ICompanyRepository _companyRepository;

        public DeleteCompanyCommandHandler(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public Task<bool> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = new Company()
            {
                Id = request.Id
                
            };

            _companyRepository.Remove(company);

            return Task.FromResult(true);
        }
    }
}
