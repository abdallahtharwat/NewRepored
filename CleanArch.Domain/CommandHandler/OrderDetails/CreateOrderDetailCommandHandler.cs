using CleanArch.Domain.Commands.OrderDetails;
using CleanArch.Domain.Commands.OrderHeaders;
using CleanArch.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.CommandHandler.OrderDetails
{
    public class CreateOrderDetailCommandHandler : IRequestHandler<CreateOrderDetailCommand, bool>
    {
        private IOrderDetailRepository  _orderDetailRepository;

        public CreateOrderDetailCommandHandler(IOrderDetailRepository orderHeaderRepository)
        {
            _orderDetailRepository = orderHeaderRepository;
        }

        public Task<bool> Handle(CreateOrderDetailCommand request, CancellationToken cancellationToken)
        {
            var orderDetail = request.orderDetail;
            _orderDetailRepository.add(orderDetail);
            return Task.FromResult(true);
        }
    }
}
