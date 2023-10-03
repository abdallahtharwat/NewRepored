using CleanArch.Domain.Commands.types;
using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.CommandHandler.types
{
    public class EdittypeCommandHandler : IRequestHandler<EdittypeCommand, bool>
    {
        private ItypeRepository _typeRepository;

        public EdittypeCommandHandler(ItypeRepository itypeRepository)
        {
            _typeRepository = itypeRepository;
        }

        public Task<bool> Handle(EdittypeCommand request, CancellationToken cancellationToken)
        {
            var type = new type()
            {
                Id = request.Id,
                Name = request.Name,
                DisplayOrder = request.DisplayOrder
            };

            _typeRepository.Update(type);

            return Task.FromResult(true);
        }

    }
}
