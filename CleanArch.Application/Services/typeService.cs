using AutoMapper;
using CleanArch.Application.Interfaces;
using CleanArch.Domain.Commands.Categorys;
using CleanArch.Domain.Commands.types;
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
    public class typeService : ItypeService
    {
        private readonly ItypeRepository  _itypeRepository;
        private readonly IMediatorHandler _Bus;
        private readonly IMapper _mapper;

        public typeService(ItypeRepository  itypeRepository, IMediatorHandler Bus, IMapper mapper)
        {

            _itypeRepository = itypeRepository;
            _Bus = Bus;
            _mapper = mapper;
        }

        public void add(type entity)
        {
            var CreateCategoryCommand = new CreatetypeCommand
              (
                  entity.Name,
                  entity.DisplayOrder
              );

            _Bus.SendCommand((CreatetypeCommand)CreateCategoryCommand);
        }

        public type Get(Expression<Func<type, bool>> filter, string? includeproperties = null, bool tracked = false)
        {
            return _itypeRepository.Get(filter, includeproperties, tracked);
        }

        public IEnumerable<type> GetAll(Expression<Func<type, bool>>? filter = null, string? includeproperties = null)
        {
            return _itypeRepository.GetAll(filter, includeproperties);
        }

        public void Remove(type entity)
        {
            var DeletetypeCommand = new DeletetypeCommand
             (
                  entity.Id
             );

            _Bus.SendCommand((DeletetypeCommand)DeletetypeCommand);
        }

        public void RemoveRange(IEnumerable<type> entity)
        {
            throw new NotImplementedException();
        }

        public void Update(type entity)
        {
            var edittypeCommand = new EdittypeCommand
              (

                  entity.Name,
                  entity.DisplayOrder,
                   entity.Id
              );

            _Bus.SendCommand(edittypeCommand);
        }
    }
}
