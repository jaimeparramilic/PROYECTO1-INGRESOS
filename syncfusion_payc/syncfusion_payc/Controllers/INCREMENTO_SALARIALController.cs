using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Syncfusion.JavaScript;
using Syncfusion.JavaScript.DataSources;
using System.Data.Entity;
using System.Net;
using System.Web;
using System.Web.Mvc;
using syncfusion_payc.Models;

namespace syncfusion_payc.Controllers
{
    public class INCREMENTO_SALARIALController : Controller
    {
        private test_payc_contabilidadEntities db = new test_payc_contabilidadEntities();

        // GET: INCREMENTO_SALARIAL
        public ActionResult Index()
        {
            var iNCREMENTO_SALARIAL = db.INCREMENTO_SALARIAL.Include(i => i.FORMAS_PAGO_FECHAS);
            return View(iNCREMENTO_SALARIAL.ToList());
        }

        // GET: INCREMENTO_SALARIAL/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INCREMENTO_SALARIAL iNCREMENTO_SALARIAL = db.INCREMENTO_SALARIAL.Find(id);
            if (iNCREMENTO_SALARIAL == null)
            {
                return HttpNotFound();
            }
            return View(iNCREMENTO_SALARIAL);
        }

        // GET: INCREMENTO_SALARIAL/Create
        public ActionResult Create()
        {
            ViewBag.COD_FORMAS_PAGO_FECHAS = new SelectList(db.FORMAS_PAGO_FECHAS, "COD_FORMAS_PAGO_FECHAS", "PERIODO_TEXTO");
            return View();
        }

        // POST: INCREMENTO_SALARIAL/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COD_INCREMENTO,COD_FORMAS_PAGO_FECHAS,FACTOR_INCREMENTO")] INCREMENTO_SALARIAL iNCREMENTO_SALARIAL)
        {
            if (ModelState.IsValid)
            {
                db.INCREMENTO_SALARIAL.Add(iNCREMENTO_SALARIAL);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.COD_FORMAS_PAGO_FECHAS = new SelectList(db.FORMAS_PAGO_FECHAS, "COD_FORMAS_PAGO_FECHAS", "PERIODO_TEXTO", iNCREMENTO_SALARIAL.COD_FORMAS_PAGO_FECHAS);
            return View(iNCREMENTO_SALARIAL);
        }

        // GET: INCREMENTO_SALARIAL/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INCREMENTO_SALARIAL iNCREMENTO_SALARIAL = db.INCREMENTO_SALARIAL.Find(id);
            if (iNCREMENTO_SALARIAL == null)
            {
                return HttpNotFound();
            }
            ViewBag.COD_FORMAS_PAGO_FECHAS = new SelectList(db.FORMAS_PAGO_FECHAS, "COD_FORMAS_PAGO_FECHAS", "PERIODO_TEXTO", iNCREMENTO_SALARIAL.COD_FORMAS_PAGO_FECHAS);
            return View(iNCREMENTO_SALARIAL);
        }

        // POST: INCREMENTO_SALARIAL/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COD_INCREMENTO,COD_FORMAS_PAGO_FECHAS,FACTOR_INCREMENTO")] INCREMENTO_SALARIAL iNCREMENTO_SALARIAL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iNCREMENTO_SALARIAL).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.COD_FORMAS_PAGO_FECHAS = new SelectList(db.FORMAS_PAGO_FECHAS, "COD_FORMAS_PAGO_FECHAS", "PERIODO_TEXTO", iNCREMENTO_SALARIAL.COD_FORMAS_PAGO_FECHAS);
            return View(iNCREMENTO_SALARIAL);
        }

        // GET: INCREMENTO_SALARIAL/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INCREMENTO_SALARIAL iNCREMENTO_SALARIAL = db.INCREMENTO_SALARIAL.Find(id);
            if (iNCREMENTO_SALARIAL == null)
            {
                return HttpNotFound();
            }
            return View(iNCREMENTO_SALARIAL);
        }

        // POST: INCREMENTO_SALARIAL/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            INCREMENTO_SALARIAL iNCREMENTO_SALARIAL = db.INCREMENTO_SALARIAL.Find(id);
            db.INCREMENTO_SALARIAL.Remove(iNCREMENTO_SALARIAL);
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

		//Aca inicia syncfusion

        //Traer data

        
		public ActionResult UrlAdaptor()
        {
            var DataSource2 = db.INCREMENTO_SALARIAL.ToList();
            ViewBag.dataSource2 = DataSource2;
            return View();
        }	
		public ActionResult GetOrderData(DataManager dm)
        {
            IEnumerable DataSource = db.INCREMENTO_SALARIAL.ToList();
            DataOperations ds = new DataOperations();
            List<string> str = new List<string>();
            db.Configuration.ProxyCreationEnabled = false;
            db.Configuration.LazyLoadingEnabled = false;
			if (dm.Search != null && dm.Search.Count > 0)
            {
                DataSource = ds.PerformSearching(DataSource, dm.Search);
            }
            if (dm.Sorted != null && dm.Sorted.Count > 0) //Sorting
            {
                DataSource = ds.PerformSorting(DataSource, dm.Sorted);
            }
            if (dm.Where != null && dm.Where.Count > 0) //Filtering
            {
                DataSource = ds.PerformWhereFilter(DataSource, dm.Where, dm.Where[0].Operator);
            }
            if (dm.Aggregates != null)
            {
                for (var i = 0; i < dm.Aggregates.Count; i++)
                    str.Add(dm.Aggregates[i].Field);
               
            }
            IEnumerable aggregate = ds.PerformSelect(DataSource, str);
            var count = DataSource.Cast<INCREMENTO_SALARIAL>().Count();
            if (dm.Skip != 0)
            {
                DataSource = ds.PerformSkip(DataSource, dm.Skip);
            }
            if (dm.Take != 0)
            {
                DataSource = ds.PerformTake(DataSource, dm.Take);
            }
            return Json(new { result = DataSource, count = count}, JsonRequestBehavior.AllowGet);     
        }

        //Perform file insertion 
        public ActionResult PerformInsert(EditParams_INCREMENTO_SALARIAL param)
        {
            db.INCREMENTO_SALARIAL.Add(param.value);
            db.SaveChanges();
			var data = db.INCREMENTO_SALARIAL.ToList();
			var value = data.Last();
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        //Actualizar grid
        public ActionResult PerformUpdate(EditParams_INCREMENTO_SALARIAL param)
        {
            
			INCREMENTO_SALARIAL table = db.INCREMENTO_SALARIAL.Single(o => o.COD_INCREMENTO == param.value.COD_INCREMENTO);

            db.Entry(table).CurrentValues.SetValues(param.value);
            db.SaveChanges();
			return RedirectToAction("GetOrderData");
			
        }

        //Borrar grid
        public ActionResult PerformDelete(int key, string keyColumn)
        {
            db.INCREMENTO_SALARIAL.Remove(db.INCREMENTO_SALARIAL.Single(o => o.COD_INCREMENTO== key));
            db.SaveChanges();
            return RedirectToAction("GetOrderData");
            
        }
    }
}
