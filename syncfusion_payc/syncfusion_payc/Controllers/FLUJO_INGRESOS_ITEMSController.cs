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
    public class FLUJO_INGRESOS_ITEMSController : Controller
    {
        private test_payc_contabilidadEntities db = new test_payc_contabilidadEntities();

        // GET: FLUJO_INGRESOS_ITEMS
        public ActionResult Index()
        {
            var fLUJO_INGRESOS_ITEMS = db.FLUJO_INGRESOS_ITEMS.Include(f => f.CONTRATO_PROYECTO).Include(f => f.FORMAS_PAGO_FECHAS).Include(f => f.ITEMS_CONTRATO);
            return View(fLUJO_INGRESOS_ITEMS.ToList());
        }

        // GET: FLUJO_INGRESOS_ITEMS/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FLUJO_INGRESOS_ITEMS fLUJO_INGRESOS_ITEMS = db.FLUJO_INGRESOS_ITEMS.Find(id);
            if (fLUJO_INGRESOS_ITEMS == null)
            {
                return HttpNotFound();
            }
            return View(fLUJO_INGRESOS_ITEMS);
        }

        // GET: FLUJO_INGRESOS_ITEMS/Create
        public ActionResult Create()
        {
            ViewBag.COD_CONTRATO_PROYECTO = new SelectList(db.CONTRATO_PROYECTO, "COD_CONTRATO_PROYECTO", "COMPLETA");
            ViewBag.COD_FORMAS_PAGO_FECHAS = new SelectList(db.FORMAS_PAGO_FECHAS, "COD_FORMAS_PAGO_FECHAS", "PERIODO_TEXTO");
            ViewBag.COD_ITEM = new SelectList(db.ITEMS_CONTRATO, "COD_ITEM", "DESCRIPCION");
            return View();
        }

        // POST: FLUJO_INGRESOS_ITEMS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COD_FLUJO_INGRESOS_ITEMS,COD_FORMAS_PAGO_FECHAS,COD_ITEM,COD_CONTRATO_PROYECTO,ETAPA,VALOR_FIJO,VALOR_VARIABLE,VALOR_TOTAL")] FLUJO_INGRESOS_ITEMS fLUJO_INGRESOS_ITEMS)
        {
            if (ModelState.IsValid)
            {
                db.FLUJO_INGRESOS_ITEMS.Add(fLUJO_INGRESOS_ITEMS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.COD_CONTRATO_PROYECTO = new SelectList(db.CONTRATO_PROYECTO, "COD_CONTRATO_PROYECTO", "COMPLETA", fLUJO_INGRESOS_ITEMS.COD_CONTRATO_PROYECTO);
            ViewBag.COD_FORMAS_PAGO_FECHAS = new SelectList(db.FORMAS_PAGO_FECHAS, "COD_FORMAS_PAGO_FECHAS", "PERIODO_TEXTO", fLUJO_INGRESOS_ITEMS.COD_FORMAS_PAGO_FECHAS);
            ViewBag.COD_ITEM = new SelectList(db.ITEMS_CONTRATO, "COD_ITEM", "DESCRIPCION", fLUJO_INGRESOS_ITEMS.COD_ITEM);
            return View(fLUJO_INGRESOS_ITEMS);
        }

        // GET: FLUJO_INGRESOS_ITEMS/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FLUJO_INGRESOS_ITEMS fLUJO_INGRESOS_ITEMS = db.FLUJO_INGRESOS_ITEMS.Find(id);
            if (fLUJO_INGRESOS_ITEMS == null)
            {
                return HttpNotFound();
            }
            ViewBag.COD_CONTRATO_PROYECTO = new SelectList(db.CONTRATO_PROYECTO, "COD_CONTRATO_PROYECTO", "COMPLETA", fLUJO_INGRESOS_ITEMS.COD_CONTRATO_PROYECTO);
            ViewBag.COD_FORMAS_PAGO_FECHAS = new SelectList(db.FORMAS_PAGO_FECHAS, "COD_FORMAS_PAGO_FECHAS", "PERIODO_TEXTO", fLUJO_INGRESOS_ITEMS.COD_FORMAS_PAGO_FECHAS);
            ViewBag.COD_ITEM = new SelectList(db.ITEMS_CONTRATO, "COD_ITEM", "DESCRIPCION", fLUJO_INGRESOS_ITEMS.COD_ITEM);
            return View(fLUJO_INGRESOS_ITEMS);
        }

        // POST: FLUJO_INGRESOS_ITEMS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COD_FLUJO_INGRESOS_ITEMS,COD_FORMAS_PAGO_FECHAS,COD_ITEM,COD_CONTRATO_PROYECTO,ETAPA,VALOR_FIJO,VALOR_VARIABLE,VALOR_TOTAL")] FLUJO_INGRESOS_ITEMS fLUJO_INGRESOS_ITEMS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fLUJO_INGRESOS_ITEMS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.COD_CONTRATO_PROYECTO = new SelectList(db.CONTRATO_PROYECTO, "COD_CONTRATO_PROYECTO", "COMPLETA", fLUJO_INGRESOS_ITEMS.COD_CONTRATO_PROYECTO);
            ViewBag.COD_FORMAS_PAGO_FECHAS = new SelectList(db.FORMAS_PAGO_FECHAS, "COD_FORMAS_PAGO_FECHAS", "PERIODO_TEXTO", fLUJO_INGRESOS_ITEMS.COD_FORMAS_PAGO_FECHAS);
            ViewBag.COD_ITEM = new SelectList(db.ITEMS_CONTRATO, "COD_ITEM", "DESCRIPCION", fLUJO_INGRESOS_ITEMS.COD_ITEM);
            return View(fLUJO_INGRESOS_ITEMS);
        }

        // GET: FLUJO_INGRESOS_ITEMS/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FLUJO_INGRESOS_ITEMS fLUJO_INGRESOS_ITEMS = db.FLUJO_INGRESOS_ITEMS.Find(id);
            if (fLUJO_INGRESOS_ITEMS == null)
            {
                return HttpNotFound();
            }
            return View(fLUJO_INGRESOS_ITEMS);
        }

        // POST: FLUJO_INGRESOS_ITEMS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            FLUJO_INGRESOS_ITEMS fLUJO_INGRESOS_ITEMS = db.FLUJO_INGRESOS_ITEMS.Find(id);
            db.FLUJO_INGRESOS_ITEMS.Remove(fLUJO_INGRESOS_ITEMS);
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
            var DataSource2 = db.FLUJO_INGRESOS_ITEMS.ToList();
            ViewBag.dataSource2 = DataSource2;
            return View();
        }	
		public ActionResult GetOrderData(DataManager dm)
        {
            IEnumerable DataSource = db.FLUJO_INGRESOS_ITEMS.ToList();
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
            var count = DataSource.Cast<FLUJO_INGRESOS_ITEMS>().Count();
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
        public ActionResult PerformInsert(EditParams_FLUJO_INGRESOS_ITEMS param)
        {
            db.FLUJO_INGRESOS_ITEMS.Add(param.value);
            db.SaveChanges();
			var data = db.FLUJO_INGRESOS_ITEMS.ToList();
			var value = data.Last();
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        //Actualizar grid
        public ActionResult PerformUpdate(EditParams_FLUJO_INGRESOS_ITEMS param)
        {
            
			FLUJO_INGRESOS_ITEMS table = db.FLUJO_INGRESOS_ITEMS.Single(o => o.COD_FLUJO_INGRESOS_ITEMS == param.value.COD_FLUJO_INGRESOS_ITEMS);

            db.Entry(table).CurrentValues.SetValues(param.value);
            db.SaveChanges();
			return RedirectToAction("GetOrderData");
			
        }

        //Borrar grid
        public ActionResult PerformDelete(int key, string keyColumn)
        {
            db.FLUJO_INGRESOS_ITEMS.Remove(db.FLUJO_INGRESOS_ITEMS.Single(o => o.COD_FLUJO_INGRESOS_ITEMS== key));
            db.SaveChanges();
            return RedirectToAction("GetOrderData");
            
        }
    }
}
