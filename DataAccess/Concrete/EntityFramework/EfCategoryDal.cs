using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal : EfEntityRepositoryBase<Category, ShopContext>, ICategoryDal
    {
        public void DeleteFromCategory(int categoryId, int productId)
        {
            using (ShopContext context = new ShopContext())
            {
                var cmd = @"delete from ProductCategory where ProductId=@p0 And categoryId=@p1";
                context.Database.ExecuteSqlRaw(cmd, productId, categoryId);
                //context.Database.ExecuteSqlCommand(cmd, productId, categoryId);
            }
        }

        public Category GetByIdWithProducts(int id)
        {
            using (ShopContext context = new ShopContext())
            {
                return context.Categories
                    .Where(x => x.Id == id)
                    .Include(x => x.ProductCategories)
                    .ThenInclude(x => x.Product)
                    .FirstOrDefault();
            }
        }
    }
}
