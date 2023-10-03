using CleanArch.Domain.Commands.OrderHeaders;
using CleanArch.Domain.Commands.ShoppingCarts;
using CleanArch.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.CommandHandler.OrderHeaders
{
    public class CreateOrderHeaderCommandHandler : IRequestHandler<CreateOrderHeaderCommand, bool>
    {
        private IOrderHeaderRepository _orderHeaderRepository;

        public CreateOrderHeaderCommandHandler(IOrderHeaderRepository orderHeaderRepository)
        {
            _orderHeaderRepository = orderHeaderRepository;
        }

        public Task<bool> Handle(CreateOrderHeaderCommand request, CancellationToken cancellationToken)
        {
            var orderheader = request.orderHeader;
            _orderHeaderRepository.add(orderheader);
            return Task.FromResult(true);
        }
    }
}
