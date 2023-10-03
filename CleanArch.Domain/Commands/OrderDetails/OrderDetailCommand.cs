using CleanArch.Domain.Core.Commands;
using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Commands.OrderDetails
{
    public class OrderDetailCommand : Command
    {
        public int Id { get; set; }
        public OrderDetail orderDetail { get; set; }
    }
}
