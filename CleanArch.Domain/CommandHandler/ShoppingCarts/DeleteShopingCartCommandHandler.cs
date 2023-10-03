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
    public class DeleteShopingCartCommandHandler : IRequestHandler<DeleteShopingCartCommand, bool>
    {
        private IShoppingCartRepository _shoppingCartRepository;

        public DeleteShopingCartCommandHandler(IShoppingCartRepository shoppingCartRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
        }

        public Task<bool> Handle(DeleteShopingCartCommand request, CancellationToken cancellationToken)
        {
            var ShopingCart = new ShopingCart()
            {
                Id = request.Id

            };

            _shoppingCartRepository.Remove(ShopingCart);

            return Task.FromResult(true);
        }
    }
}
