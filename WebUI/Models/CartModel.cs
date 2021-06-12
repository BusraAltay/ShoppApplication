using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Models
{
    public class CartModel
    {
        public int CartId { get; set; }
        public List<CartItemModel> CartItem { get; set; }

        public decimal TotalPrice()
        {
            return CartItem.Sum(x => x.Price * x.Quantity);
        }
    }
}
