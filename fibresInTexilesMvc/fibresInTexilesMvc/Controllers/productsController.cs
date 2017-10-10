using System;
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
    public class productsController : Controller
    {
        private fibresInTextilesEntities db = new fibresInTextilesEntities();

        // GET: products
        public ActionResult Index(int?FiberId)
        {
            var products = db.products.Include(p => p.fibre);
            return View(products.ToList());
        }
        public ActionResult GetProducts(int? FiberId)
        {
            var prod = from p in db.products
                         where p.FiberId == FiberId
                         select p;
          
            return View(prod);
        }
        //public ActionResult FiberAndProducts(int? FiberId)
        //{

        //    //var products = db.products.Include(p => p.fibre);
        //    List<fibre> fibandprodlist = db.fibres.ToList();
        //    List<FibAndProdViewModel> fibandprodVmList = fibandprodlist
        //                .Where(x => x.FiberId == FiberId)
        //                .Select(x => new FibAndProdViewModel()
        //                {
        //                    FiberId = x.FiberId,
        //                    Picture1 = x.Picture1,
        //                    Description = x.Description,
        //                    Advantages = x.Advantages,
        //                    Disadvantages = x.Disadvantages,
        //                    Picture2 = x.Picture2,

        //                    //Picture = x.products.Select(a => a.Picture).FirstOrDefault(),
        //                    //Name = x.products.Select(a => a.Name).FirstOrDefault()
        //                }).ToList();
        //    return View(fibandprodVmList);
        //}

        //public ActionResult FiberAndProducts()
        //{
        //    //List<product> fibandprodlist = db.products.ToList();
        //    //List<fibre> fibandprodlist = db.fibres.ToList();

        //    FibAndProdViewModel fibandprodVM = new FibAndProdViewModel();

        //    List<FibAndProdViewModel> fibandprodVmList = fibandprodVmlist.Select(x => new FibAndProdViewModel
        //    {
        //        FiberId = x.FiberId,
        //        Picture1 = x.Picture1,
        //        Description = x.Description,
        //        Advantages = x.Advantages,
        //        Disadvantages = x.Disadvantages,
        //        Picture2 = x.Picture2,
        //        Name = x.products.Name,
        //        Picture = x.products.Picture
        //    }).ToList();
        //    return View(fibandprodVmList);
        //}




        // GET: products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product product = db.products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: products/Create
        public ActionResult Create()
        {
            ViewBag.FiberId = new SelectList(db.fibres, "FiberId", "Name");
            return View();
        }

        // POST: products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,Name,Picture,Overview,FiberId")] product product)
        {
            if (ModelState.IsValid)
            {
                db.products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FiberId = new SelectList(db.fibres, "FiberId", "Name", product.FiberId);
            return View(product);
        }

        // GET: products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product product = db.products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.FiberId = new SelectList(db.fibres, "FiberId", "Name", product.FiberId);
            return View(product);
        }

        // POST: products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,Name,Picture,Overview,FiberId")] product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FiberId = new SelectList(db.fibres, "FiberId", "Name", product.FiberId);
            return View(product);
        }

        // GET: products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product product = db.products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            product product = db.products.Find(id);
            db.products.Remove(product);
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
