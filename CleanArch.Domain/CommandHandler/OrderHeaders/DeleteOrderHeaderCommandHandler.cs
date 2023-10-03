using CleanArch.Domain.Commands.OrderHeaders;
using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.CommandHandler.OrderHeaders
{
    public class DeleteOrderHeaderCommandHandler : IRequestHandler<DeleteOrderHeaderCommand, bool>
    {
        private IOrderHeaderRepository _orderHeaderRepository;

        public DeleteOrderHeaderCommandHandler(IOrderHeaderRepository orderHeaderRepository)
        {
            _orderHeaderRepository = orderHeaderRepository;
        }

        public Task<bool> Handle(DeleteOrderHeaderCommand request, CancellationToken cancellationToken)
        {
            var orderheader = new OrderHeader
            {
                Id = request.Id
            };
            _orderHeaderRepository.Remove(orderheader);
            return Task.FromResult(true);
        }
    }
}
