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
    public class EditServiceCommandHandler : IRequestHandler<EditServiceCommand, bool>
    {
        private readonly IServiceRepository _serviceRepository;
        public EditServiceCommandHandler(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<bool> Handle(EditServiceCommand request, CancellationToken cancellationToken)
        {
            var subject = request.Service;
            var result = await _serviceRepository.Update(subject); 
            return result;

        }
    }
}
