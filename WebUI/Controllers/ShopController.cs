using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class ShopController : Controller
    {
        private IProductService _productService;

        public ShopController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Product product = _productService.GetProductDetails((int)id);
            if (product == null)
            {
                return NotFound();
            }
            return View(new ProductDetailsModel()
            {
                Product = product,
                Categories = product.ProductCategories.Select(x => x.Category).ToList()
            });
        }
        public IActionResult List(string category, int page = 1)
        {
            const int pageSize = 3;
            return View(new ProductListModel()
            {
                PageInfoModel = new PageInfoModel()
                {
                    TotalItems = _productService.GetCountByCategory(category),
                    CurentPage = page,
                    ItemsPerPage = pageSize,
                    CurentCategory = category

                },
                Products = _productService.GetProductsByCategory(category, page, pageSize)
            });
        }
        public IActionResult Search(string search)
        {
            var productListModel = new ProductListModel()
            {
                Products = _productService.GetSearch(search)
            };

            return View(productListModel);
        }
    }
}
