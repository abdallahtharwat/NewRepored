using CleanArch.Domain.Commands.ApplicationUers;
using CleanArch.Domain.Commands.ShoppingCarts;
using CleanArch.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.CommandHandler.ApplicationUers
{
    public class CreateApplicationUserCommandHandler : IRequestHandler<CreateApplicationUserCommand, bool>
    {
        private IApplicationUserRepository  _applicationUserRepository;

        public CreateApplicationUserCommandHandler(IApplicationUserRepository  applicationUserRepository)
        {
            _applicationUserRepository = applicationUserRepository;
        }

        public Task<bool> Handle(CreateApplicationUserCommand request, CancellationToken cancellationToken)
        {
            var applicationuser = request.applicationUser;
            _applicationUserRepository.add(applicationuser);
            return Task.FromResult(true);
        }

    }
}
