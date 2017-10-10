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
        // GET: FibAndProd
        public ActionResult Index()
        {

            return View();

        }

        // GET: FibAndProd
        public ActionResult FibAndProdVm/*Index*/(int? FiberId)
        {
            fibresInTextilesEntities db = new fibresInTextilesEntities();
            //var fib = db.fibres.Find(FiberId);

            List<FibAndProdViewModel> FibAndProdViewModellist = new List<FibAndProdViewModel>(); //to hold list of fiber and products
            var fibandprodlist = (from p in db.products
                                  join f in db.fibres on p.FiberId equals f.FiberId
                                  //where p.FiberId == f.FiberId
                                  select new
                                  {
                                      //f.Picture1,
                                      //f.Description,
                                      // f.Advantages,
                                      //f.Disadvantages,
                                      f.FiberId,
                                      //f.Picture2,
                                      p.Picture,
                                      p.Name
                                  }).ToList();
            // querry getting data from database from joining two tables and storing data in fibandprodlist
            foreach (var item in fibandprodlist)
            {
                FibAndProdViewModel objcvm = new FibAndProdViewModel();//ViewModel

                //objcvm.Picture1 = item.Picture1;
                //objcvm.Description = item.Description;
                //objcvm.Advantages = item.Advantages;
                //objcvm.Disadvantages = item.Disadvantages;
                objcvm.FiberId = item.FiberId;
                //objcvm.Picture2 = item.Picture2;
                objcvm.Picture = item.Picture;
                objcvm.Name = item.Name;
                FibAndProdViewModellist.Add(objcvm);
            }
            //Using foreach loop fill data from fibandprodlist to List<FibAndProdViewModel>
            return PartialView(FibAndProdViewModellist); // List of FibAndProdViewModel (ViewModel)
            //return View();
        }
        public ActionResult AAA(int? FiberId)

        {

            if (FiberId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fibre fibre = db.fibres.Find(FiberId);

            if (fibre == null)
            {
                return HttpNotFound();
            }

            List<FibAndProdViewModel> FibAndProdViewModellist = new List<FibAndProdViewModel>();
            var prodList = from p in db.products
                           where p.FiberId == FiberId
                           select new {p.FiberId, p.Picture,
                           p.Name};
            return View();

        }
        public ActionResult DetailsVM(int? FiberId)
        {
            if (FiberId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FibAndProdViewModel fibprodVm = new FibAndProdViewModel();
            fibprodVm.fibre = (from f in db.fibres
                               where f.FiberId == FiberId
                               select f/*.FiberId,f.Picture1, f.Description, f.Advantages, f.Disadvantages, f.Picture2)*/).FirstOrDefault();
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