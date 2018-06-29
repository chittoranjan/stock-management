using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using StockManagement.BLL;
using StockManagement.Models.DatabaseContext;
using StockManagement.Models.EntityModels;
using StockManagement.Models.ViewModels;

namespace StockManagementApp.Controllers
{
    public class StockInController : Controller
    {
        StockDBContext db=new StockDBContext();
        PartyManager _partyManager=new PartyManager();
        // GET: StockIn
        [HttpGet]
        public ActionResult StockIn()
        {
            var model=new StockInViewModel();
            model.Categories = db.Categories.ToList();
            model.Parties = _partyManager.PartyList();
            ViewBag.ProductDropDown = new SelectList(new[] {new SelectListItem(){Value="",Text ="Select Product"} },"Value","Text");

            return View(model); 
        }
        [HttpPost]
        public ActionResult StockIn(StockInViewModel stockInViewModel)
        {
            if (ModelState.IsValid)
            {
                StockIn stockIn = Mapper.Map<StockIn>(stockInViewModel);   
                db.StockIns.Add(stockIn);
                
                if (db.SaveChanges() > 0)
                {
                    ModelState.Clear();
                    TempData["msg"] = "StockIn information has been successfully saved.";
                    return RedirectToAction("Index", "StockInDetails", new { area = "" });
                }
            }
            
            var model = new StockInViewModel();
            model.Categories = db.Categories.ToList();
            model.Parties = _partyManager.PartyList();
            ViewBag.ProductDropDown = new SelectList(new[] { new SelectListItem() { Value = "", Text = "Select Product" } }, "Value", "Text");
            TempData["msg"] = "StockIn information has been failed to save!";
            return View(model);
        }
    }
}