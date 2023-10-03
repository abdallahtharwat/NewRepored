using CleanArch.Domain.Commands.Categorys;
using CleanArch.Domain.Commands.Products;
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
    public class CreatetypeCommandHandler : IRequestHandler<CreatetypeCommand, bool>
    {
        private ItypeRepository _typeRepository;

        public CreatetypeCommandHandler(ItypeRepository  itypeRepository)
        {
            _typeRepository = itypeRepository;
        }

        public Task<bool> Handle(CreatetypeCommand request, CancellationToken cancellationToken)
        {
            var type = new type()
            {
               Name = request.Name,
                DisplayOrder = request.DisplayOrder
            };

            _typeRepository.add(type);

            return Task.FromResult(true);
        }
    }
}
