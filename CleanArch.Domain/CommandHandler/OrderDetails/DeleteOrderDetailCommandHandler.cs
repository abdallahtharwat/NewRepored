using CleanArch.Domain.Commands.OrderDetails;
using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.CommandHandler.OrderDetails
{
    public class DeleteOrderDetailCommandHandler : IRequestHandler<DeleteOrderDetailCommand, bool>
    {
        private IOrderDetailRepository _orderDetailRepository;

        public DeleteOrderDetailCommandHandler(IOrderDetailRepository orderHeaderRepository)
        {
            _orderDetailRepository = orderHeaderRepository;
        }

        public Task<bool> Handle(DeleteOrderDetailCommand request, CancellationToken cancellationToken)
        {
            var OrderDetail = new OrderDetail
            {
                Id = request.Id
            };
            _orderDetailRepository.Remove(OrderDetail);
            return Task.FromResult(true);
        }
    }
}
