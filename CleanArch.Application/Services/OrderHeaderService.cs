using AutoMapper;
using CleanArch.Application.Interfaces;
using CleanArch.Domain.Commands.OrderHeaders;
using CleanArch.Domain.Core.Bus;
using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using CleanArch.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Services
{
    public class OrderHeaderService : IOrderHeaderService
    {
        private readonly IOrderHeaderRepository  _orderHeaderRepository;
        private readonly IMediatorHandler _Bus;
        private readonly IMapper _mapper;
        

        public OrderHeaderService(IOrderHeaderRepository  orderHeaderRepository, IMediatorHandler Bus, IMapper mapper)
        {

            _orderHeaderRepository = orderHeaderRepository;
            _Bus = Bus;
            _mapper = mapper;
           
        }

        public void add(OrderHeader entity)
        {
            var createOrderHeaderCommand = new CreateOrderHeaderCommand(entity);
            _Bus.SendCommand(createOrderHeaderCommand);
                
        }

        public OrderHeader Get(Expression<Func<OrderHeader, bool>> filter, string? includeproperties = null, bool tracked = false)
        {
            return _orderHeaderRepository.Get(filter, includeproperties, tracked);
        }

        public IEnumerable<OrderHeader> GetAll(Expression<Func<OrderHeader, bool>>? filter = null, string? includeproperties = null)
        {
            return _orderHeaderRepository.GetAll(filter, includeproperties);
        }

        public void Remove(OrderHeader entity)
        {
            var deleteOrderHeaderCommand = new DeleteOrderHeaderCommand(entity.Id);
            _Bus.SendCommand(deleteOrderHeaderCommand);
        }

        public void RemoveRange(IEnumerable<OrderHeader> entity)
        {
            throw new NotImplementedException();
        }

        public void Update(OrderHeader entity)
        {
          var editOrderHeaderCommand = new EditOrderHeaderCommand(entity);
            _Bus.SendCommand(editOrderHeaderCommand);
        }

        public void UpdateStatus(int id, string orderStatus, string? paymentStatus = null)
        {
         _orderHeaderRepository.UpdateStatus(id, orderStatus, paymentStatus);
        }

        public void UpdateStripePaymentID(int id, string sessionId, string paymentIntentId)
        {
           _orderHeaderRepository.UpdateStripePaymentID(id, sessionId, paymentIntentId);
        }
    }
}
