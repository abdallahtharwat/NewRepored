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
    public class EditShopingCartCommandHandler : IRequestHandler<EditShoppingCartCommand, bool>
    {
        private IShoppingCartRepository _shoppingCartRepository;

        public EditShopingCartCommandHandler(IShoppingCartRepository shoppingCartRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
        }

        public Task<bool> Handle(EditShoppingCartCommand request, CancellationToken cancellationToken)
        {
            var ShopingCartt = request.ShopingCart;
            _shoppingCartRepository.Update(ShopingCartt);
            return Task.FromResult(true);
        }
    }
}
