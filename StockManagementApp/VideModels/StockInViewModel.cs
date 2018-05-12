using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagement.Models.EntityModels;

namespace StockManagementApp.VideModels
{
    public class StockInViewModel
    {
        public StockIn StockIn { get; set; }
        public StockInDetail StockInDetail { get; set; }
    }
}