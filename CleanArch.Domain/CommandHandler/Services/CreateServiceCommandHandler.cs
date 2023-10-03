using CleanArch.Domain.Commands.Products;
using CleanArch.Domain.Commands.Service;
using CleanArch.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.CommandHandler.Services
{
    public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand, bool>
    {
        private IServiceRepository _serviceRepository;

        public CreateServiceCommandHandler(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<bool> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
        {
            var subject = request.Service;
            var result = await _serviceRepository.add(subject);
            return result;

        }
    }
}
