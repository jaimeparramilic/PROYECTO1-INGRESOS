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
    public class INCREMENTO_ORDENController : Controller
    {
        private test_payc_contabilidadEntities db = new test_payc_contabilidadEntities();

        // GET: INCREMENTO_ORDEN
        public ActionResult Index()
        {
            var iNCREMENTO_ORDEN = db.INCREMENTO_ORDEN.Include(i => i.CONTRATO_PROYECTO);
            return View(iNCREMENTO_ORDEN.ToList());
        }

        // GET: INCREMENTO_ORDEN/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INCREMENTO_ORDEN iNCREMENTO_ORDEN = db.INCREMENTO_ORDEN.Find(id);
            if (iNCREMENTO_ORDEN == null)
            {
                return HttpNotFound();
            }
            return View(iNCREMENTO_ORDEN);
        }

        // GET: INCREMENTO_ORDEN/Create
        public ActionResult Create()
        {
            ViewBag.COD_CONTRATO_PROYECTO = new SelectList(db.CONTRATO_PROYECTO, "COD_CONTRATO_PROYECTO", "COMPLETA");
            ViewBag.COD_FORMAS_PAGO_FECHAS = new SelectList(db.FORMAS_PAGO_FECHAS, "COD_FORMAS_PAGO_FECHAS", "PERIODO_TEXTO");
            ViewBag.COD_INCREMENTO = new SelectList(db.INCREMENTO_SALARIAL, "COD_INCREMENTO", "COD_INCREMENTO");
            return View();
        }

        // POST: INCREMENTO_ORDEN/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COD_INCREMENTO_ORDEN,COD_INCREMENTO,COD_CONTRATO_PROYECTO,VALOR_INCREMENTO,COD_FORMAS_PAGO_FECHAS")] INCREMENTO_ORDEN iNCREMENTO_ORDEN)
        {
            if (ModelState.IsValid)
            {
                db.INCREMENTO_ORDEN.Add(iNCREMENTO_ORDEN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.COD_CONTRATO_PROYECTO = new SelectList(db.CONTRATO_PROYECTO, "COD_CONTRATO_PROYECTO", "COMPLETA", iNCREMENTO_ORDEN.COD_CONTRATO_PROYECTO);
            
            
            return View(iNCREMENTO_ORDEN);
        }

        // GET: INCREMENTO_ORDEN/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INCREMENTO_ORDEN iNCREMENTO_ORDEN = db.INCREMENTO_ORDEN.Find(id);
            if (iNCREMENTO_ORDEN == null)
            {
                return HttpNotFound();
            }
            ViewBag.COD_CONTRATO_PROYECTO = new SelectList(db.CONTRATO_PROYECTO, "COD_CONTRATO_PROYECTO", "COMPLETA", iNCREMENTO_ORDEN.COD_CONTRATO_PROYECTO);
            
            
            return View(iNCREMENTO_ORDEN);
        }

        // POST: INCREMENTO_ORDEN/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COD_INCREMENTO_ORDEN,COD_CONTRATO_PROYECTO,VALOR_INCREMENTO,COD_FORMAS_PAGO_FECHAS")] INCREMENTO_ORDEN iNCREMENTO_ORDEN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iNCREMENTO_ORDEN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.COD_CONTRATO_PROYECTO = new SelectList(db.CONTRATO_PROYECTO, "COD_CONTRATO_PROYECTO", "COMPLETA", iNCREMENTO_ORDEN.COD_CONTRATO_PROYECTO);
           
            
            return View(iNCREMENTO_ORDEN);
        }

        // GET: INCREMENTO_ORDEN/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INCREMENTO_ORDEN iNCREMENTO_ORDEN = db.INCREMENTO_ORDEN.Find(id);
            if (iNCREMENTO_ORDEN == null)
            {
                return HttpNotFound();
            }
            return View(iNCREMENTO_ORDEN);
        }

        // POST: INCREMENTO_ORDEN/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            INCREMENTO_ORDEN iNCREMENTO_ORDEN = db.INCREMENTO_ORDEN.Find(id);
            db.INCREMENTO_ORDEN.Remove(iNCREMENTO_ORDEN);
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
            var DataSource2 = db.INCREMENTO_ORDEN.ToList();
            ViewBag.dataSource2 = DataSource2;
            return View();
        }	
		public ActionResult GetOrderData(DataManager dm)
        {
            IEnumerable DataSource = db.INCREMENTO_ORDEN.ToList();
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
            var count = DataSource.Cast<INCREMENTO_ORDEN>().Count();
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
        public ActionResult PerformInsert(EditParams_INCREMENTO_ORDEN param)
        {
            db.INCREMENTO_ORDEN.Add(param.value);
            db.SaveChanges();
			var data = db.INCREMENTO_ORDEN.ToList();
			var value = data.Last();
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        //Actualizar grid
        public ActionResult PerformUpdate(EditParams_INCREMENTO_ORDEN param)
        {
            
			INCREMENTO_ORDEN table = db.INCREMENTO_ORDEN.Single(o => o.COD_INCREMENTO_ORDEN == param.value.COD_INCREMENTO_ORDEN);

            db.Entry(table).CurrentValues.SetValues(param.value);
            db.SaveChanges();
			return RedirectToAction("GetOrderData");
			
        }

        //Borrar grid
        public ActionResult PerformDelete(int key, string keyColumn)
        {
            db.INCREMENTO_ORDEN.Remove(db.INCREMENTO_ORDEN.Single(o => o.COD_INCREMENTO_ORDEN== key));
            db.SaveChanges();
            return RedirectToAction("GetOrderData");
            
        }
    }
}
