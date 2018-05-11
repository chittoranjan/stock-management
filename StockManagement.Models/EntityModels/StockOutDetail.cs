using System.ComponentModel;

namespace StockManagement.Models.EntityModels
{
    public class StockOutDetail
    {
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