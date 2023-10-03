using AutoMapper;
using CleanArch.Application.Interfaces;
using CleanArch.Domain.Commands.Categorys;
using CleanArch.Domain.Commands.Companies;
using CleanArch.Domain.Commands.Products;
using CleanArch.Domain.Core.Bus;
using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMediatorHandler _Bus;
        private readonly IMapper _mapper;

        public CompanyService(ICompanyRepository  companyRepository, IMediatorHandler Bus, IMapper mapper)
        {

            _companyRepository = companyRepository;
            _Bus = Bus;
            _mapper = mapper;
        }

        public Company Get(Expression<Func<Company, bool>> filter, string? includeproperties = null, bool tracked = false)
        {
            return _companyRepository.Get(filter, includeproperties, tracked);
        }

        public IEnumerable<Company> GetAll(Expression<Func<Company, bool>>? filter = null, string? includeproperties = null)
        {
            return _companyRepository.GetAll(filter, includeproperties);
        }


        public void Remove(Company entity)
        {
            var deleteCompanyCommand = new DeleteCompanyCommand
              (
                   entity.Id
              );

            _Bus.SendCommand(deleteCompanyCommand);
        }

        public void RemoveRange(IEnumerable<Company> entity)
        {
            throw new NotImplementedException();
        }
        public void add(Company entity)
        {

            var createCompanyCommand = new CreateCompanyCommand(entity);
             _Bus.SendCommand(createCompanyCommand);
            
        }

        public void Update(Company entity)
        {
            var editCompanyCommand = new EditCompanyCommand(entity);
            _Bus.SendCommand(editCompanyCommand);
        }








    }
}
