using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.ViewModel
{
    public class ShoppingCartVM
    {
        public IEnumerable<ShopingCart> ShoppingCartList { get; set; }

        public OrderHeader OrderHeader { get; set; }
      
    }
}
