using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using fibresInTexilesMvc.Models;
using fibresInTexilesMvc.ViewModels;

namespace fibresInTexilesMvc.Controllers
{
    public class HomeController : Controller
    {
      
        private fibresInTextilesEntities db = new fibresInTextilesEntities();
                    
        // GET: Home
        public ActionResult Index(int?FiberId)

        {
            var fibres = db.fibres.Include(f => f.products);
            return View(db.fibres);
        }
   
    // GET: Home/Details/5
    public ActionResult Details(int?id)

        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fibre fibre = db.fibres.Find(id);

            if (fibre == null)
            {
                return HttpNotFound();
            }             
            return View(fibre);        
    }
    // GET: Home/Create
    public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FiberId,Name,Category,Picture1,Description,Advantages,Disadvantages,Picture2")] fibre fibre)
        {
            if (ModelState.IsValid)
            {
                db.fibres.Add(fibre);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fibre);
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fibre fibre = db.fibres.Find(id);
            if (fibre == null)
            {
                return HttpNotFound();
            }
            return View(fibre);
        }

        // POST: Home/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FiberId,Name,Category,Picture1,Description,Advantages,Disadvantages,Picture2")] fibre fibre)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fibre).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fibre);
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fibre fibre = db.fibres.Find(id);
            if (fibre == null)
            {
                return HttpNotFound();
            }
            return View(fibre);
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            fibre fibre = db.fibres.Find(id);
            db.fibres.Remove(fibre);
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
