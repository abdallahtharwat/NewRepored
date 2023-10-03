using CleanArch.Domain.Commands.OrderDetails;
using CleanArch.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.CommandHandler.OrderDetails
{
    public class EditOrderDetailCommandHandler : IRequestHandler<EditOrderDetailCommand, bool>
    {
        private IOrderDetailRepository _orderDetailRepository;

        public EditOrderDetailCommandHandler(IOrderDetailRepository orderHeaderRepository)
        {
            _orderDetailRepository = orderHeaderRepository;
        }

        public Task<bool> Handle(EditOrderDetailCommand request, CancellationToken cancellationToken)
        {
            var orderDetail = request.orderDetail;
            _orderDetailRepository.Update(orderDetail);
            return Task.FromResult(true);
        }
    }
}
