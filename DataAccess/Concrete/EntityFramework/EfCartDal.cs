using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCartDal : EfEntityRepositoryBase<Cart, ShopContext>, ICartDal
    {
        public override void Update(Cart entity)
        {
            using (ShopContext context = new ShopContext())
            {
                context.Carts.Update(entity);
                context.SaveChanges();
            }
        }
        public Cart GetByUserId(string userId)
        {
            using (ShopContext context = new ShopContext())
            {
                return context
                               .Carts
                               .Include(x => x.CartItem)
                               .ThenInclude(x => x.Product)
                               .FirstOrDefault(x => x.UserId == userId);
            }
        }

        public void DeleteFromCart(int cartId, int productId)
        {
            using (ShopContext context = new ShopContext())
            {
                var cmd = @"delete from CartItem where CartId=@p0 And ProductId=@p1";
                context.Database.ExecuteSqlRaw(cmd, cartId, productId);
            }
        }

        public void ClearCart(string cartId)
        {
            using (ShopContext context = new ShopContext())
            {
                var cmd = @"delete from CartItem where CartId=@p0";
                context.Database.ExecuteSqlRaw(cmd, cartId);
            }
        }
    }
}
