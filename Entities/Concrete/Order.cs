using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Order : IEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public int Quantity { get; set; }
        public List<Product> Products { get; set; }
    }
}
