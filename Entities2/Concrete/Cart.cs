using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Cart : IEntity
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public List<CartItem> CartItem { get; set; }
    }
}
