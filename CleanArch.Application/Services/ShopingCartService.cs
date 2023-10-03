using AutoMapper;
using CleanArch.Application.Interfaces;
using CleanArch.Domain.Commands.Companies;
using CleanArch.Domain.Commands.ShoppingCarts;
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
    public class ShopingCartService : IShoppingCartService
    {
        private readonly IShoppingCartRepository  _shoppingCartRepository;
        private readonly IMediatorHandler _Bus;
        private readonly IMapper _mapper;

        public ShopingCartService(IShoppingCartRepository shoppingCartRepository, IMediatorHandler Bus, IMapper mapper)
        {

            _shoppingCartRepository = shoppingCartRepository;
            _Bus = Bus;
            _mapper = mapper;
        }

        public void add(ShopingCart entity)
        {
            var CreateShopingCartCommandd = new CreateShopingCartCommand(entity);
            _Bus.SendCommand(CreateShopingCartCommandd);
        }

        public ShopingCart Get(Expression<Func<ShopingCart, bool>> filter, string? includeproperties = null, bool tracked = false)
        {
            return _shoppingCartRepository.Get(filter, includeproperties, tracked);
        }

        public IEnumerable<ShopingCart> GetAll(Expression<Func<ShopingCart, bool>>? filter = null, string? includeproperties = null)
        {
            return _shoppingCartRepository.GetAll(filter, includeproperties);
        }

        public void Remove(ShopingCart entity)
        {
            var DeleteShopingCartCommand = new DeleteShopingCartCommand
           (
                entity.Id
           );

            _Bus.SendCommand(DeleteShopingCartCommand);
        }

        public void RemoveRange(IEnumerable<ShopingCart> entity)
        {
            var EditShoppingCartCommandd = new DeleteRangShopingCartCommand(entity.ToList());
            _Bus.SendCommand(EditShoppingCartCommandd);
        }

        public void Update(ShopingCart entity)
        {
            var EditShoppingCartCommandd = new EditShoppingCartCommand(entity);
            _Bus.SendCommand(EditShoppingCartCommandd);
        }
    }
}
