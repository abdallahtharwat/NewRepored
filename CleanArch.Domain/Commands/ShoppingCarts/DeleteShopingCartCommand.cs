using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Commands.ShoppingCarts
{
    public class DeleteShopingCartCommand : ShoppingCartCommand
    {
        public DeleteShopingCartCommand(int id)
        {
                Id = id;
        }
    }
}
