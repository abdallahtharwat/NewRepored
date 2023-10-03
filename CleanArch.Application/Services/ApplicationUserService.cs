using AutoMapper;
using CleanArch.Application.Interfaces;
using CleanArch.Domain.Commands.ApplicationUers;
using CleanArch.Domain.Commands.ShoppingCarts;
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
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly IApplicationUserRepository  _applicationUserRepository;
        private readonly IMediatorHandler _Bus;
        private readonly IMapper _mapper;

        public ApplicationUserService(IApplicationUserRepository  applicationUserRepository, IMediatorHandler Bus, IMapper mapper)
        {

            _applicationUserRepository = applicationUserRepository;
            _Bus = Bus;
            _mapper = mapper;
        }

        public void add(ApplicationUser entity)
        {
            var CreateApplicationUserCommandd = new CreateApplicationUserCommand(entity);
            _Bus.SendCommand(CreateApplicationUserCommandd);
        }

        public ApplicationUser Get(Expression<Func<ApplicationUser, bool>> filter, string? includeproperties = null, bool tracked = false)
        {
            return _applicationUserRepository.Get(filter, includeproperties, tracked);
        }

        public IEnumerable<ApplicationUser> GetAll(Expression<Func<ApplicationUser, bool>>? filter = null, string? includeproperties = null)
        {
            return _applicationUserRepository.GetAll(filter, includeproperties);
        }

        public void Remove(ApplicationUser entity)
        {
            var DeleteApplicationUserCommandd = new DeleteApplicationUserCommand
          (
               entity.Id
          );

            _Bus.SendCommand(DeleteApplicationUserCommandd);
        }

        public void RemoveRange(IEnumerable<ApplicationUser> entity)
        {
            throw new NotImplementedException();
        }

        public void Update(ApplicationUser entity)
        {
            var EditApplicationUserCommandd = new EditApplicationUserCommand(entity);
            _Bus.SendCommand(EditApplicationUserCommandd);
        }
    }
}
