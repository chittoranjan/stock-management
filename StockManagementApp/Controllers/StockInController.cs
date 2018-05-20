using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StockManagement.Models.DatabaseContext;
using StockManagement.Models.EntityModels;
using StockManagement.Models.ViewModels;

namespace StockManagementApp.Controllers
{
    public class StockInController : Controller
    {
        StockDBContext db=new StockDBContext();
        // GET: StockIn
        [HttpGet]
        public ActionResult StockIn()
        {
            var model=new StockInViewModel();
            model.Categories = db.Categories.ToList();
            ViewBag.ProductDropDown = new SelectList(new[] {new SelectListItem(){Value="",Text ="Select Product"} },"Value","Text");

            return View(model); 
        }
        [HttpPost]
        public ActionResult StockIn(StockInViewModel stockInViewModel)
        {
            if (ModelState.IsValid)
            {
                var stockIn = new StockIn();
                stockIn.StockDate = stockInViewModel.StockDate;
                stockIn.Description = stockInViewModel.Description;
                db.StockIns.Add(stockIn);
                db.SaveChanges();
                var id = stockIn.Id;
                List<StockInDetail> stockList = new List<StockInDetail>();
                foreach (var ss in stockInViewModel.StockInDetails)
                {
                    var stockDetails = new StockInDetail();
                    stockDetails.StockInId = id;
                    stockDetails.ProductId = ss.ProductId;
                    stockDetails.Qty = ss.Qty;
                    stockList.Add(stockDetails);

                }
                db.StockInDetails.AddRange(stockList);
                var count = db.SaveChanges();
                if (count > 0)
                {
                    ModelState.Clear();
                    TempData["msg"] = "StockIn information has been successfully saved.";
                    return RedirectToAction("Index", "StockInDetails", new { area = "" });
                }
            }
            
            var model = new StockInViewModel();
            model.Categories = db.Categories.ToList();
            ViewBag.ProductDropDown = new SelectList(new[] { new SelectListItem() { Value = "", Text = "Select Product" } }, "Value", "Text");
            TempData["msg"] = "StockIn information has been failed to save!";
            return View(model);
        }
    }
}