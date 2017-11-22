using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using fibresInTexilesMvc.Models;
using fibresInTexilesMvc.ViewModels;
using System.Net;

namespace fibresInTexilesMvc.Controllers
{
    public class FibAndProdController : Controller
    {
        private fibresInTextilesEntities db = new fibresInTextilesEntities();
        
        public ActionResult Index()
        {
            return View();
        }

        // GET: FibAndProd
        public ActionResult DetailsVM(int? FiberId)
        {
            if (FiberId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FibAndProdViewModel fibprodVm = new FibAndProdViewModel();
            fibprodVm.fibre = (from f in db.fibres
                               where f.FiberId == FiberId
                               select f).FirstOrDefault();
            fibprodVm.Products = (from p in db.products
                                  where p.FiberId == FiberId
                                  select p).ToList();

            if (fibprodVm == null)
            {
                return HttpNotFound();
            }
            return View(fibprodVm);
        }
       
    }
}
