using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "Ürün ismi max 30 karakter olmalıdır.")]
        public string Name { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        [StringLength(1000, MinimumLength = 20, ErrorMessage = "Ürün açıklaması min 20, max 1000 karakter olmalıdır.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Fiyat girin.")]
        [Range(1, 1000)]
        public decimal? UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public List<Category> SelectedCategories { get; set; }
    }
}
