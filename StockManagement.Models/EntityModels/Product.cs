using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StockManagement.Models.EntityModels
{
    public class Product
    {
        public int Id { get; set; }

        [DisplayName("Product Name")]
        public string Name { get; set; }

        [DisplayName("Product Code")]
        public string Code { get; set; }

        [DisplayName("Category Name")]
        public int CategoryId { get; set; }
        
        public Category Category { get; set; }
    }
}