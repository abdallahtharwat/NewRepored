using CleanArch.Domain.Commands.ShoppingCarts;
using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.CommandHandler.ShoppingCarts
{
    public class DeleteRangeShopingCartCommandHandler : IRequestHandler<DeleteRangShopingCartCommand, bool>
    {
        private IShoppingCartRepository _shoppingCartRepository;

        public DeleteRangeShopingCartCommandHandler(IShoppingCartRepository shoppingCartRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
        }

        public  Task<bool> Handle(DeleteRangShopingCartCommand request, CancellationToken cancellationToken)
        {
            //var ShoppingCart = new List<ShopingCart> 
            //{
            //    new ShopingCart
            //    {
            //        Id = request.Id,
            //    }

            //};

            //_shoppingCartRepository.RemoveRange(ShoppingCart);

            //return Task.FromResult(true);



            var subject = request.listShopingCarts;
             _shoppingCartRepository.RemoveRange(subject);
            return Task.FromResult(true);



        }
    }
}
