using System.ComponentModel;

namespace StockManagement.Models.EntityModels
{
    public class StockInDetail
    {
        public int Id { get; set; }

        [DisplayName("Name")]
        public int StockInId { get; set; }

        [DisplayName("Product")]
        public int ProductId { get; set; }
        [DisplayName("Qty")]
        public int Qty { get; set; }

        public StockIn StockIn { get; set; }
        public Product Product { get; set; }
    }
}