using CleanArch.Domain.Commands.ApplicationUers;
using CleanArch.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.CommandHandler.ApplicationUers
{
    public class EditApplicationUserCommandHandler : IRequestHandler<EditApplicationUserCommand, bool>
    {
        private IApplicationUserRepository _applicationUserRepository;

        public EditApplicationUserCommandHandler(IApplicationUserRepository applicationUserRepository)
        {
            _applicationUserRepository = applicationUserRepository;
        }

        public Task<bool> Handle(EditApplicationUserCommand request, CancellationToken cancellationToken)
        {
            var applicationUserr = request.applicationUser;
            _applicationUserRepository.Update(applicationUserr);
            return Task.FromResult(true);
        }
    }
}
