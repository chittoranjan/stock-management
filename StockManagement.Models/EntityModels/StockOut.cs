using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Models.EntityModels
{
    public class StockOut
    {
        public int Id { get; set; }

        [DisplayName("StockOut Description")]
        public string Description { get; set; }

        [DisplayName("StockOut Date")]
        public DateTime StockOutDate { get; set; }

        public List<StockOutDetail> StockOutDetails { get; set; }

    }
}
