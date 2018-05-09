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
    public class StockInDetailsController : Controller
    {
        private StockDBContext db = new StockDBContext();

        // GET: StockInDetails
        public ActionResult Index()
        {
            var stockInDetails = db.StockInDetails.Include(s => s.Product).Include(s => s.StockIn);
            return View(stockInDetails.ToList());
        }

        // GET: StockInDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockInDetail stockInDetail = db.StockInDetails.Find(id);
            if (stockInDetail == null)
            {
                return HttpNotFound();
            }
            return View(stockInDetail);
        }

        // GET: StockInDetails/Create
        public ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name");
            ViewBag.StockInId = new SelectList(db.StockIns, "Id", "Description");
            return View();
        }

        // POST: StockInDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StockInId,ProductId,Qty")] StockInDetail stockInDetail)
        {
            if (ModelState.IsValid)
            {
                db.StockInDetails.Add(stockInDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", stockInDetail.ProductId);
            ViewBag.StockInId = new SelectList(db.StockIns, "Id", "Description", stockInDetail.StockInId);
            return View(stockInDetail);
        }

        // GET: StockInDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockInDetail stockInDetail = db.StockInDetails.Find(id);
            if (stockInDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", stockInDetail.ProductId);
            ViewBag.StockInId = new SelectList(db.StockIns, "Id", "Description", stockInDetail.StockInId);
            return View(stockInDetail);
        }

        // POST: StockInDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StockInId,ProductId,Qty")] StockInDetail stockInDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stockInDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", stockInDetail.ProductId);
            ViewBag.StockInId = new SelectList(db.StockIns, "Id", "Description", stockInDetail.StockInId);
            return View(stockInDetail);
        }

        // GET: StockInDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockInDetail stockInDetail = db.StockInDetails.Find(id);
            if (stockInDetail == null)
            {
                return HttpNotFound();
            }
            return View(stockInDetail);
        }

        // POST: StockInDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StockInDetail stockInDetail = db.StockInDetails.Find(id);
            db.StockInDetails.Remove(stockInDetail);
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
