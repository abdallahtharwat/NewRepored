using CleanArch.Domain.Core.Commands;
using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Commands.ShoppingCarts
{
    public class ShoppingCartCommand : Command
    {
        public int Id { get; set; }
        public ShopingCart ShopingCart { get; set; }
        public List<ShopingCart> listShopingCarts { get; set; }

    }
}
