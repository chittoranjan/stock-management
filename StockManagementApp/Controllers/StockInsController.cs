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
using StockManagementApp.VideModels;

namespace StockManagementApp.Controllers
{
    public class StockInsController : Controller
    {
        private StockDBContext db = new StockDBContext();

        // GET: StockIns
        public ActionResult Index()
        {
            return View(db.StockIns.ToList());
        }

        // GET: StockIns/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockIn stockIn = db.StockIns.Find(id);
            if (stockIn == null)
            {
                return HttpNotFound();
            }
            return View(stockIn);
        }

        // GET: StockIns/Create
        public ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(db.Categories, "Id", "Name");
            return View();
        }

        // POST: StockIns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description,StockInDetail,Qty")] StockInViewModel stockIn)
        {
            if (ModelState.IsValid)
            {
               //db.StockIns.Add(stockIn);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stockIn);
        }

        // GET: StockIns/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockIn stockIn = db.StockIns.Find(id);
            if (stockIn == null)
            {
                return HttpNotFound();
            }
            return View(stockIn);
        }

        // POST: StockIns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description,StockDate")] StockIn stockIn)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stockIn).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stockIn);
        }

        // GET: StockIns/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockIn stockIn = db.StockIns.Find(id);
            if (stockIn == null)
            {
                return HttpNotFound();
            }
            return View(stockIn);
        }

        // POST: StockIns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StockIn stockIn = db.StockIns.Find(id);
            db.StockIns.Remove(stockIn);
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
