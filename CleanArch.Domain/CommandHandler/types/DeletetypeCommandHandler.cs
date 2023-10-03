using CleanArch.Domain.Commands.types;
using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CleanArch.Domain.CommandHandler.types
{
    public class DeletetypeCommandHandler : IRequestHandler<DeletetypeCommand, bool>
    {
        private ItypeRepository _typeRepository;

        public DeletetypeCommandHandler(ItypeRepository itypeRepository)
        {
            _typeRepository = itypeRepository;
        }

        public Task<bool> Handle(DeletetypeCommand request, CancellationToken cancellationToken)
        {
            var type = new type()
            {
                Id = request.Id,
                Name = request.Name,
                DisplayOrder = request.DisplayOrder
            };

            _typeRepository.Remove(type);

            return Task.FromResult(true);
        }
    }
}


