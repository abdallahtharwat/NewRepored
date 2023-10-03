using CleanArch.Domain.Commands.OrderHeaders;
using CleanArch.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.CommandHandler.OrderHeaders
{
    public class EditOrderHeaderCommandHandler : IRequestHandler<EditOrderHeaderCommand, bool>
    {
        private IOrderHeaderRepository _orderHeaderRepository;

        public EditOrderHeaderCommandHandler(IOrderHeaderRepository orderHeaderRepository)
        {
            _orderHeaderRepository = orderHeaderRepository;
        }

        public Task<bool> Handle(EditOrderHeaderCommand request, CancellationToken cancellationToken)
        {
            var orderheader = request.orderHeader;
            _orderHeaderRepository.Update(orderheader);
            return Task.FromResult(true);   
        }
    }
}
