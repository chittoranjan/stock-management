using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using StockManagement.Models.EntityModels;

namespace StockManagement.Models.ViewModels
{
    public class StockInViewModel
    {
        public int Id { get; set; }

        [DisplayName("Description")]
        public string Description { get; set; }

        [DisplayName("Date")]
        public DateTime StockDate { get; set; }
        [NotMapped]
        public List<Category> Categories { get; set; }
        public  List<StockInDetail> StockInDetails { get; set; } 


    }
}
