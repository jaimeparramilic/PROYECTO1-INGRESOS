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
    public class FLUJO_INGRESOS_ROLController : Controller
    {
        private test_payc_contabilidadEntities db = new test_payc_contabilidadEntities();

        // GET: FLUJO_INGRESOS_ROL
        public ActionResult Index()
        {
            var fLUJO_INGRESOS_ROL = db.FLUJO_INGRESOS_ROL.Include(f => f.CONTRATO_PROYECTO).Include(f => f.FORMAS_PAGO_FECHAS).Include(f => f.ROLES);
            return View(fLUJO_INGRESOS_ROL.ToList());
        }

        // GET: FLUJO_INGRESOS_ROL/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FLUJO_INGRESOS_ROL fLUJO_INGRESOS_ROL = db.FLUJO_INGRESOS_ROL.Find(id);
            if (fLUJO_INGRESOS_ROL == null)
            {
                return HttpNotFound();
            }
            return View(fLUJO_INGRESOS_ROL);
        }

        // GET: FLUJO_INGRESOS_ROL/Create
        public ActionResult Create()
        {
            ViewBag.COD_CONTRATO_PROYECTO = new SelectList(db.CONTRATO_PROYECTO, "COD_CONTRATO_PROYECTO", "COMPLETA");
            ViewBag.COD_FORMAS_PAGO_FECHAS = new SelectList(db.FORMAS_PAGO_FECHAS, "COD_FORMAS_PAGO_FECHAS", "PERIODO_TEXTO");
            ViewBag.COD_ROL = new SelectList(db.ROLES, "COD_ROL", "DESCRIPCION");
            return View();
        }

        // POST: FLUJO_INGRESOS_ROL/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COD_FLUJO_INGRESOS_ROL,COD_FORMAS_PAGO_FECHAS,COD_ROL,COD_CONTRATO_PROYECTO,ETAPA,VALOR_SIN_PRESTACIONES,VALOR_CON_PRESTACIONES,VALOR_FACTOR_MULTIPLICADOR")] FLUJO_INGRESOS_ROL fLUJO_INGRESOS_ROL)
        {
            if (ModelState.IsValid)
            {
                db.FLUJO_INGRESOS_ROL.Add(fLUJO_INGRESOS_ROL);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.COD_CONTRATO_PROYECTO = new SelectList(db.CONTRATO_PROYECTO, "COD_CONTRATO_PROYECTO", "COMPLETA", fLUJO_INGRESOS_ROL.COD_CONTRATO_PROYECTO);
            ViewBag.COD_FORMAS_PAGO_FECHAS = new SelectList(db.FORMAS_PAGO_FECHAS, "COD_FORMAS_PAGO_FECHAS", "PERIODO_TEXTO", fLUJO_INGRESOS_ROL.COD_FORMAS_PAGO_FECHAS);
            ViewBag.COD_ROL = new SelectList(db.ROLES, "COD_ROL", "DESCRIPCION", fLUJO_INGRESOS_ROL.COD_ROL);
            return View(fLUJO_INGRESOS_ROL);
        }

        // GET: FLUJO_INGRESOS_ROL/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FLUJO_INGRESOS_ROL fLUJO_INGRESOS_ROL = db.FLUJO_INGRESOS_ROL.Find(id);
            if (fLUJO_INGRESOS_ROL == null)
            {
                return HttpNotFound();
            }
            ViewBag.COD_CONTRATO_PROYECTO = new SelectList(db.CONTRATO_PROYECTO, "COD_CONTRATO_PROYECTO", "COMPLETA", fLUJO_INGRESOS_ROL.COD_CONTRATO_PROYECTO);
            ViewBag.COD_FORMAS_PAGO_FECHAS = new SelectList(db.FORMAS_PAGO_FECHAS, "COD_FORMAS_PAGO_FECHAS", "PERIODO_TEXTO", fLUJO_INGRESOS_ROL.COD_FORMAS_PAGO_FECHAS);
            ViewBag.COD_ROL = new SelectList(db.ROLES, "COD_ROL", "DESCRIPCION", fLUJO_INGRESOS_ROL.COD_ROL);
            return View(fLUJO_INGRESOS_ROL);
        }

        // POST: FLUJO_INGRESOS_ROL/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COD_FLUJO_INGRESOS_ROL,COD_FORMAS_PAGO_FECHAS,COD_ROL,COD_CONTRATO_PROYECTO,ETAPA,VALOR_SIN_PRESTACIONES,VALOR_CON_PRESTACIONES,VALOR_FACTOR_MULTIPLICADOR")] FLUJO_INGRESOS_ROL fLUJO_INGRESOS_ROL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fLUJO_INGRESOS_ROL).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.COD_CONTRATO_PROYECTO = new SelectList(db.CONTRATO_PROYECTO, "COD_CONTRATO_PROYECTO", "COMPLETA", fLUJO_INGRESOS_ROL.COD_CONTRATO_PROYECTO);
            ViewBag.COD_FORMAS_PAGO_FECHAS = new SelectList(db.FORMAS_PAGO_FECHAS, "COD_FORMAS_PAGO_FECHAS", "PERIODO_TEXTO", fLUJO_INGRESOS_ROL.COD_FORMAS_PAGO_FECHAS);
            ViewBag.COD_ROL = new SelectList(db.ROLES, "COD_ROL", "DESCRIPCION", fLUJO_INGRESOS_ROL.COD_ROL);
            return View(fLUJO_INGRESOS_ROL);
        }

        // GET: FLUJO_INGRESOS_ROL/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FLUJO_INGRESOS_ROL fLUJO_INGRESOS_ROL = db.FLUJO_INGRESOS_ROL.Find(id);
            if (fLUJO_INGRESOS_ROL == null)
            {
                return HttpNotFound();
            }
            return View(fLUJO_INGRESOS_ROL);
        }

        // POST: FLUJO_INGRESOS_ROL/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            FLUJO_INGRESOS_ROL fLUJO_INGRESOS_ROL = db.FLUJO_INGRESOS_ROL.Find(id);
            db.FLUJO_INGRESOS_ROL.Remove(fLUJO_INGRESOS_ROL);
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
            var DataSource2 = db.FLUJO_INGRESOS_ROL.ToList();
            ViewBag.dataSource2 = DataSource2;
            return View();
        }	
		public ActionResult GetOrderData(DataManager dm)
        {
            IEnumerable DataSource = db.FLUJO_INGRESOS_ROL.ToList();
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
            var count = DataSource.Cast<FLUJO_INGRESOS_ROL>().Count();
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
        public ActionResult PerformInsert(EditParams_FLUJO_INGRESOS_ROL param)
        {
            db.FLUJO_INGRESOS_ROL.Add(param.value);
            db.SaveChanges();
			var data = db.FLUJO_INGRESOS_ROL.ToList();
			var value = data.Last();
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        //Actualizar grid
        public ActionResult PerformUpdate(EditParams_FLUJO_INGRESOS_ROL param)
        {
            
			FLUJO_INGRESOS_ROL table = db.FLUJO_INGRESOS_ROL.Single(o => o.COD_FLUJO_INGRESOS_ROL == param.value.COD_FLUJO_INGRESOS_ROL);

            db.Entry(table).CurrentValues.SetValues(param.value);
            db.SaveChanges();
			return RedirectToAction("GetOrderData");
			
        }

        //Borrar grid
        public ActionResult PerformDelete(int key, string keyColumn)
        {
            db.FLUJO_INGRESOS_ROL.Remove(db.FLUJO_INGRESOS_ROL.Single(o => o.COD_FLUJO_INGRESOS_ROL== key));
            db.SaveChanges();
            return RedirectToAction("GetOrderData");
            
        }
    }
}
