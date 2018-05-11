using System.ComponentModel;

namespace StockManagement.Models.EntityModels
{
    public class StockInDetail
    {
        public int Id { get; set; }

        [DisplayName("StockIn Name")]
        public int StockInId { get; set; }

        [DisplayName("Product Name")]
        public int ProductId { get; set; }
        [DisplayName("StockIn Qty")]
        public int Qty { get; set; }

        public StockIn StockIn { get; set; }
        public Product Product { get; set; }
    }
}