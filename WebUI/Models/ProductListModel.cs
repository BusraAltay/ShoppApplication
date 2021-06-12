using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Models
{
    public class ProductListModel
    {
        public PageInfoModel PageInfoModel { get; set; }
        public List<Product> Products { get; set; }
    }
}
