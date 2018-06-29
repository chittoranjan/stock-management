using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Models.EntityModels
{
    public class Inventory
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Product Name")]
        public int ProductId { get; set; }

        [DisplayName("Total Qty")]
        public int Qty { get; set; }

        public Product Product { get; set; }

    }
}
