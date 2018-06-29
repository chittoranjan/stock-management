using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Models.EntityModels
{
    public class StockIn
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime StockDate { get; set; }
        public  List<StockInDetail> StockInDetails { get; set; }
        public int? PartyId { get; set; }
        public Party Party { get; set; }


    }
}
