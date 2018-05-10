using System.ComponentModel.DataAnnotations;

namespace StockManagement.Models.EntityModels
{
    public class Product
    {
        public int Id { get; set; }

        [Display(Name = "Product Name")]
        public string Name { get; set; }

        [Display(Name = "Product Code")]
        public string Code { get; set; }

        [Display(Name = "Category Name")]
        public int CategoryId { get; set; }
        
        public Category Category { get; set; }
    }
}