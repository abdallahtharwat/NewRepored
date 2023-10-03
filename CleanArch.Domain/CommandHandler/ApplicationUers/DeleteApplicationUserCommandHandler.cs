using CleanArch.Domain.Commands.ApplicationUers;
using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.CommandHandler.ApplicationUers
{
    public class DeleteApplicationUserCommandHandler : IRequestHandler<DeleteApplicationUserCommand, bool>
    {

        private IApplicationUserRepository _applicationUserRepository;

        public DeleteApplicationUserCommandHandler(IApplicationUserRepository applicationUserRepository)
        {
            _applicationUserRepository = applicationUserRepository;
        }

        public Task<bool> Handle(DeleteApplicationUserCommand request, CancellationToken cancellationToken)
        {
            var ApplicationUserr = new ApplicationUser()
            {
                Id = request.Id,
              
               

            };

            _applicationUserRepository.Remove(ApplicationUserr);

            return Task.FromResult(true);
        }
    }
}
