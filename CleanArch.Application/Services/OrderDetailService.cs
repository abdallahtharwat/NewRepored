using AutoMapper;
using CleanArch.Application.Interfaces;
using CleanArch.Domain.Commands.OrderDetails;
using CleanArch.Domain.Core.Bus;
using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Services
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepository  _orderDetailRepository;
        private readonly IMediatorHandler _Bus;
        private readonly IMapper _mapper;

        public OrderDetailService(IOrderDetailRepository  orderDetailRepository, IMediatorHandler Bus, IMapper mapper)
        {

            _orderDetailRepository = orderDetailRepository;
            _Bus = Bus;
            _mapper = mapper;
        }

        public void add(OrderDetail entity)
        {
            var createOrderDetailCommand = new CreateOrderDetailCommand(entity);
            _Bus.SendCommand(createOrderDetailCommand);
                
        }

        public OrderDetail Get(Expression<Func<OrderDetail, bool>> filter, string? includeproperties = null, bool tracked = false)
        {
            return _orderDetailRepository.Get(filter, includeproperties, tracked);
        }

        public IEnumerable<OrderDetail> GetAll(Expression<Func<OrderDetail, bool>>? filter = null, string? includeproperties = null)
        {
            return _orderDetailRepository.GetAll(filter, includeproperties);
        }

        public void Remove(OrderDetail entity)
        {
            var deleteOrderDetailCommand = new DeleteOrderDetailCommand(entity.Id);
            _Bus.SendCommand(deleteOrderDetailCommand);
        }

        public void RemoveRange(IEnumerable<OrderDetail> entity)
        {
            throw new NotImplementedException();
        }

        public void Update(OrderDetail entity)
        {
          var editOrderDetailCommand = new EditOrderDetailCommand(entity);
            _Bus.SendCommand(editOrderDetailCommand);
        }
    }
}
