using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Product :IEntity
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        //public List<ProductDetailDto> ProductCategories { get; set; }
    }
}
