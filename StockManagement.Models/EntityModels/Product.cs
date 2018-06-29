using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StockManagement.Models.EntityModels
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please input product name!")]
        [DisplayName("Product Name"), StringLength(250, ErrorMessage = "Name maximum 250 character")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please write a code 3-6 digits")]
        [DisplayName("Product Code")]
        [MinLength(3, ErrorMessage = "Please write minimum 3 digits!"), MaxLength(6, ErrorMessage = "Please write maximum 6 digits!")]
        public string Code { get; set; }


        [Required(ErrorMessage = "Please select category!")]
        [DisplayName("Category Name")]
        public int CategoryId { get; set; }
        
        public Category Category { get; set; }
    }
}