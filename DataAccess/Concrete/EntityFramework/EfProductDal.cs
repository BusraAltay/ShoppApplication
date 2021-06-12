using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, ShopContext>, IProductDal
    {
        public Product GetByIdWithCategories(int id)
        {
            using (ShopContext context = new ShopContext())
            {
                return context.Products
                    .Where(x => x.Id == id)
                    .Include(x => x.ProductCategories)
                    .ThenInclude(x => x.Category)
                    .FirstOrDefault();
            }
        }

        public int GetCountByCategory(string category)
        {
            using (ShopContext context = new ShopContext())
            {
                var products = context.Products.AsQueryable();

                if (!string.IsNullOrEmpty(category))
                {
                    products = products.Include(x => x.ProductCategories)
                        .ThenInclude(x => x.Category)
                        .Where(x => x.ProductCategories
                        .Any(x => x.Category.Name.ToLower() == category.ToLower()));
                }
                return products.Count();
            }
        }

        public Product GetProductDetails(int id)
        {
            using (ShopContext context = new ShopContext())
            {
                return context.Products.Where(x => x.Id == id)
                    .Include(x => x.ProductCategories)
                    .ThenInclude(x => x.Category)
                    .FirstOrDefault();
            }
        }

        public List<Product> GetProductsByCategory(string category, int page, int pageSize)
        {
            using (ShopContext context = new ShopContext())
            {
                var products = context.Products.AsQueryable();

                if (!string.IsNullOrEmpty(category))
                {
                    products = products.Include(x => x.ProductCategories)
                        .ThenInclude(x => x.Category)
                        .Where(x => x.ProductCategories
                        .Any(a => a.Category.Name
                        .ToLower() == category.ToLower()));
                }
                return products.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public List<Product> GetSearch(string search)
        {
            using (ShopContext context = new ShopContext())
            {
                var products = context
                    .Products
                    .Where(x => x.Name.ToLower().Contains(search.ToLower()))
                    .AsQueryable();

                return products.ToList();
            }
        }

        public void Update(Product entity, int[] categoryIds)
        {
            using (ShopContext context = new ShopContext())
            {
                var product = context.Products
                    .Include(x => x.ProductCategories)
                    .FirstOrDefault(x => x.Id == entity.Id);
                if (product != null)
                {
                    product.Name = entity.Name;
                    product.Description = entity.Description;
                    product.ImageUrl = entity.ImageUrl;
                    product.UnitPrice = entity.UnitPrice;
                    product.ProductCategories = categoryIds.Select(catid => new ProductCategory()
                    {
                        CategoryId = catid,
                        ProductId = entity.Id
                    }).ToList();
                    context.SaveChanges();
                }
            }
        }
    }
}
