using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StockManagement.Models.DatabaseContext;
using StockManagement.Models.EntityModels;

namespace StockManagementApp.Controllers
{
    public class StockOutDetailsController : Controller
    {
        private StockDBContext db = new StockDBContext();

        // GET: StockOutDetails
        public ActionResult Index()
        {
            var stockOutDetails = db.StockOutDetails.Include(s => s.Product).Include(s => s.StockOut);
            return View(stockOutDetails.ToList());
        }

        // GET: StockOutDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockOutDetail stockOutDetail = db.StockOutDetails.Find(id);
            if (stockOutDetail == null)
            {
                return HttpNotFound();
            }
            return View(stockOutDetail);
        }

        // GET: StockOutDetails/Create
        public ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name");
            ViewBag.StockOutId = new SelectList(db.StockOuts, "Id", "Description");
            return View();
        }

        // POST: StockOutDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StockOutId,ProductId,Qty")] StockOutDetail stockOutDetail)
        {
            if (ModelState.IsValid)
            {
                db.StockOutDetails.Add(stockOutDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", stockOutDetail.ProductId);
            ViewBag.StockOutId = new SelectList(db.StockOuts, "Id", "Description", stockOutDetail.StockOutId);
            return View(stockOutDetail);
        }

        // GET: StockOutDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockOutDetail stockOutDetail = db.StockOutDetails.Find(id);
            if (stockOutDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", stockOutDetail.ProductId);
            ViewBag.StockOutId = new SelectList(db.StockOuts, "Id", "Description", stockOutDetail.StockOutId);
            return View(stockOutDetail);
        }

        // POST: StockOutDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StockOutId,ProductId,Qty")] StockOutDetail stockOutDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stockOutDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", stockOutDetail.ProductId);
            ViewBag.StockOutId = new SelectList(db.StockOuts, "Id", "Description", stockOutDetail.StockOutId);
            return View(stockOutDetail);
        }

        // GET: StockOutDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockOutDetail stockOutDetail = db.StockOutDetails.Find(id);
            if (stockOutDetail == null)
            {
                return HttpNotFound();
            }
            return View(stockOutDetail);
        }

        // POST: StockOutDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StockOutDetail stockOutDetail = db.StockOutDetails.Find(id);
            db.StockOutDetails.Remove(stockOutDetail);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
