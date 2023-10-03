using CleanArch.Domain.Commands.Companies;
using CleanArch.Domain.Commands.ShoppingCarts;
using CleanArch.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.CommandHandler.ShoppingCarts
{
    public class CreateShopingCartCommandHandler : IRequestHandler<CreateShopingCartCommand, bool>
    {
        private IShoppingCartRepository  _shoppingCartRepository;

        public CreateShopingCartCommandHandler(IShoppingCartRepository  shoppingCartRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
        }

        public Task<bool> Handle(CreateShopingCartCommand request, CancellationToken cancellationToken)
        {
            var ShoppingCart = request.ShopingCart;
            _shoppingCartRepository.add(ShoppingCart);
            return Task.FromResult(true);
        }
    }
}
