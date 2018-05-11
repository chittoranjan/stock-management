using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Models.EntityModels
{
    public class Category
    {
        public int Id { get; set; }

        //[Required(ErrorMessage = "Please write Category Name")]
        [DisplayName("Category Name")]
        public string Name { get; set; }

        //[Required(ErrorMessage = "Please write a code 3-6 digits")]
        [DisplayName("Category Code")]
        //[MinLength(3 , ErrorMessage = "Please write minimum 3 digits"),MaxLength(6, ErrorMessage = "Please write maximum 6 digits")]
        public string Code { get; set; }

        public List<Product> Products { get; set; }
       
    }
}
