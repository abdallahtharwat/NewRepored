using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Commands.OrderDetails
{
    public class CreateOrderDetailCommand : OrderDetailCommand
    {
        public CreateOrderDetailCommand(OrderDetail orderDetaill)
        {
            orderDetail = orderDetaill;
        }
    }
}
