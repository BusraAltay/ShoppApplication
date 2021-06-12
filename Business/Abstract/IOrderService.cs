using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IOrderService
    {
        void Add(Order entity);
        List<Order> GetOrders(string userId);
    }
}
