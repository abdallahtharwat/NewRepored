using AutoMapper;
using CleanArch.Application.Interfaces;
using CleanArch.Domain.Commands.Products;
using CleanArch.Domain.Commands.Service;
using CleanArch.Domain.Core.Bus;
using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using CleanArch.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Services
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IMediatorHandler _Bus;
        private readonly IMapper _mapper;


        public ServiceService(IServiceRepository serviceRepository, IMediatorHandler Bus, IMapper mapper)
        {

            _serviceRepository = serviceRepository;
            _Bus = Bus;
            _mapper = mapper;
        }

        public async Task<bool> add(service entity)
        {
            var subject = new CreateServiceCommand(entity);
            await _Bus.SendCommand(subject);
            return true;
        }

        public service Get(Expression<Func<service, bool>> filter, string? includeproperties = null, bool tracked = false)
        {
            return _serviceRepository.Get(filter, includeproperties, tracked);
        }

        public IEnumerable<service> GetAll(Expression<Func<service, bool>>? filter = null, string? includeproperties = null)
        {
            return _serviceRepository.GetAll(filter, includeproperties);
        }

        public async Task<bool> Remove(int id)
        {
           var subject = new DeleteServiceCommand(id);
            await _Bus.SendCommand(subject);
            return true;
        }

        public Task<bool> RemoveRange(IEnumerable<service> entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(service entity)
        {
            var subject =  new EditServiceCommand(entity);
            await _Bus.SendCommand(subject);
            return true;
        }



    }
}
