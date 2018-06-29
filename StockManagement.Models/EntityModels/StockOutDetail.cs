using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StockManagement.Models.EntityModels
{
    public class StockOutDetail
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("StockOut Name")]
        public int StockOutId { get; set; }

        [DisplayName("Product Name")]
        public int ProductId { get; set; }

        [DisplayName("StockOut Qty")]
        public int Qty { get; set; }

        public StockOut StockOut { get; set; }
        public Product Product { get; set; }


    }
}