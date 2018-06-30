using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using StockManagement.Models.EntityModels;

namespace StockManagement.Models.ViewModels
{
    public class StockInViewModel
    {
        
        public int Id { get; set; }


        [Required(ErrorMessage = "Please write a description!"),MaxLength(500,ErrorMessage = "Max Length 500 character")]
        [DisplayName("Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please select date!")]
        [DisplayName("Date")]
        public DateTime StockDate { get; set; }

        [DisplayName("Party")]
        public int? PartyId { get; set; }

        public List<Party> Parties { get; set; }

        [NotMapped]
        public List<Category> Categories { get; set; }
        
        public  List<StockInDetail> StockInDetails { get; set; } 


    }
}
