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
    public class REGISTRO_ITEMS_OTROS_COSTOSController : Controller
    {
        private test_payc_contabilidadEntities db = new test_payc_contabilidadEntities();

        // GET: REGISTRO_ITEMS_OTROS_COSTOS
        public ActionResult Index()
        {
            var rEGISTRO_ITEMS_OTROS_COSTOS = db.REGISTRO_ITEMS_OTROS_COSTOS.Include(r => r.FORMAS_PAGO_FECHAS).Include(r => r.ITEMS_CONTRATO).Include(r => r.CONTRATO_PROYECTO);
            return View(rEGISTRO_ITEMS_OTROS_COSTOS.ToList());
        }

        // GET: REGISTRO_ITEMS_OTROS_COSTOS/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            REGISTRO_ITEMS_OTROS_COSTOS rEGISTRO_ITEMS_OTROS_COSTOS = db.REGISTRO_ITEMS_OTROS_COSTOS.Find(id);
            if (rEGISTRO_ITEMS_OTROS_COSTOS == null)
            {
                return HttpNotFound();
            }
            return View(rEGISTRO_ITEMS_OTROS_COSTOS);
        }

        // GET: REGISTRO_ITEMS_OTROS_COSTOS/Create
        public ActionResult Create()
        {
            ViewBag.COD_FORMAS_PAGO_FECHAS = new SelectList(db.FORMAS_PAGO_FECHAS, "COD_FORMAS_PAGO_FECHAS", "PERIODO_TEXTO");
            ViewBag.COD_ITEM_CONTRATO = new SelectList(db.ITEMS_CONTRATO, "COD_ITEM_CONTRATO", "DESCRIPCION");
            ViewBag.COD_CONTRATO_PROYECTO = new SelectList(db.CONTRATO_PROYECTO, "COD_CONTRATO_PROYECTO", "COMPLETA");
            return View();
        }

        // POST: REGISTRO_ITEMS_OTROS_COSTOS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COD_REGISTRO_ITEMS,COD_ITEM_CONTRATO,COD_CONTRATO_PROYECTO,COD_FORMAS_PAGO_FECHAS,VALOR_COMERCIAL,CANTIDAD,PARAMETRO1,PARAMETRO2,PARAMETRO3,PARAMETRO4,PARAMETRON")] REGISTRO_ITEMS_OTROS_COSTOS rEGISTRO_ITEMS_OTROS_COSTOS)
        {
            if (ModelState.IsValid)
            {
                db.REGISTRO_ITEMS_OTROS_COSTOS.Add(rEGISTRO_ITEMS_OTROS_COSTOS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.COD_FORMAS_PAGO_FECHAS = new SelectList(db.FORMAS_PAGO_FECHAS, "COD_FORMAS_PAGO_FECHAS", "PERIODO_TEXTO", rEGISTRO_ITEMS_OTROS_COSTOS.COD_FORMAS_PAGO_FECHAS);
            ViewBag.COD_ITEM_CONTRATO = new SelectList(db.ITEMS_CONTRATO, "COD_ITEM_CONTRATO", "DESCRIPCION", rEGISTRO_ITEMS_OTROS_COSTOS.COD_ITEM_CONTRATO);
            ViewBag.COD_CONTRATO_PROYECTO = new SelectList(db.CONTRATO_PROYECTO, "COD_CONTRATO_PROYECTO", "COMPLETA", rEGISTRO_ITEMS_OTROS_COSTOS.COD_CONTRATO_PROYECTO);
            return View(rEGISTRO_ITEMS_OTROS_COSTOS);
        }

        // GET: REGISTRO_ITEMS_OTROS_COSTOS/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            REGISTRO_ITEMS_OTROS_COSTOS rEGISTRO_ITEMS_OTROS_COSTOS = db.REGISTRO_ITEMS_OTROS_COSTOS.Find(id);
            if (rEGISTRO_ITEMS_OTROS_COSTOS == null)
            {
                return HttpNotFound();
            }
            ViewBag.COD_FORMAS_PAGO_FECHAS = new SelectList(db.FORMAS_PAGO_FECHAS, "COD_FORMAS_PAGO_FECHAS", "PERIODO_TEXTO", rEGISTRO_ITEMS_OTROS_COSTOS.COD_FORMAS_PAGO_FECHAS);
            ViewBag.COD_ITEM_CONTRATO = new SelectList(db.ITEMS_CONTRATO, "COD_ITEM_CONTRATO", "DESCRIPCION", rEGISTRO_ITEMS_OTROS_COSTOS.COD_ITEM_CONTRATO);
            ViewBag.COD_CONTRATO_PROYECTO = new SelectList(db.CONTRATO_PROYECTO, "COD_CONTRATO_PROYECTO", "COMPLETA", rEGISTRO_ITEMS_OTROS_COSTOS.COD_CONTRATO_PROYECTO);
            return View(rEGISTRO_ITEMS_OTROS_COSTOS);
        }

        // POST: REGISTRO_ITEMS_OTROS_COSTOS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COD_REGISTRO_ITEMS,COD_ITEM_CONTRATO,COD_CONTRATO_PROYECTO,COD_FORMAS_PAGO_FECHAS,VALOR_COMERCIAL,CANTIDAD,PARAMETRO1,PARAMETRO2,PARAMETRO3,PARAMETRO4,PARAMETRON")] REGISTRO_ITEMS_OTROS_COSTOS rEGISTRO_ITEMS_OTROS_COSTOS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rEGISTRO_ITEMS_OTROS_COSTOS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.COD_FORMAS_PAGO_FECHAS = new SelectList(db.FORMAS_PAGO_FECHAS, "COD_FORMAS_PAGO_FECHAS", "PERIODO_TEXTO", rEGISTRO_ITEMS_OTROS_COSTOS.COD_FORMAS_PAGO_FECHAS);
            ViewBag.COD_ITEM_CONTRATO = new SelectList(db.ITEMS_CONTRATO, "COD_ITEM_CONTRATO", "DESCRIPCION", rEGISTRO_ITEMS_OTROS_COSTOS.COD_ITEM_CONTRATO);
            ViewBag.COD_CONTRATO_PROYECTO = new SelectList(db.CONTRATO_PROYECTO, "COD_CONTRATO_PROYECTO", "COMPLETA", rEGISTRO_ITEMS_OTROS_COSTOS.COD_CONTRATO_PROYECTO);
            return View(rEGISTRO_ITEMS_OTROS_COSTOS);
        }

        // GET: REGISTRO_ITEMS_OTROS_COSTOS/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            REGISTRO_ITEMS_OTROS_COSTOS rEGISTRO_ITEMS_OTROS_COSTOS = db.REGISTRO_ITEMS_OTROS_COSTOS.Find(id);
            if (rEGISTRO_ITEMS_OTROS_COSTOS == null)
            {
                return HttpNotFound();
            }
            return View(rEGISTRO_ITEMS_OTROS_COSTOS);
        }

        // POST: REGISTRO_ITEMS_OTROS_COSTOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            REGISTRO_ITEMS_OTROS_COSTOS rEGISTRO_ITEMS_OTROS_COSTOS = db.REGISTRO_ITEMS_OTROS_COSTOS.Find(id);
            db.REGISTRO_ITEMS_OTROS_COSTOS.Remove(rEGISTRO_ITEMS_OTROS_COSTOS);
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
            var DataSource2 = db.REGISTRO_ITEMS_OTROS_COSTOS.ToList();
            ViewBag.dataSource2 = DataSource2;
            return View();
        }	

		public ActionResult GetOrderData(DataManager dm)
        {
            IEnumerable DataSource = db.REGISTRO_ITEMS_OTROS_COSTOS.ToList();
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
            var count = DataSource.Cast<REGISTRO_ITEMS_OTROS_COSTOS>().Count();
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
        public ActionResult PerformInsert(EditParams_REGISTRO_ITEMS_OTROS_COSTOS param)
        {
            db.REGISTRO_ITEMS_OTROS_COSTOS.Add(param.value);
            db.SaveChanges();
			var data = db.REGISTRO_ITEMS_OTROS_COSTOS.ToList();
			var value = data.Last();
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        //Actualizar grid
        public ActionResult PerformUpdate(EditParams_REGISTRO_ITEMS_OTROS_COSTOS param)
        {
            
			REGISTRO_ITEMS_OTROS_COSTOS table = db.REGISTRO_ITEMS_OTROS_COSTOS.Single(o => o.COD_REGISTRO_ITEMS == param.value.COD_REGISTRO_ITEMS);

            db.Entry(table).CurrentValues.SetValues(param.value);
            db.SaveChanges();
			return RedirectToAction("GetOrderData");
			
        }

        //Borrar grid
        public ActionResult PerformDelete(int key, string keyColumn)
        {
            db.REGISTRO_ITEMS_OTROS_COSTOS.Remove(db.REGISTRO_ITEMS_OTROS_COSTOS.Single(o => o.COD_REGISTRO_ITEMS== key));
            db.SaveChanges();
            return RedirectToAction("GetOrderData");
            
        }

        //Traer 
        #region lista items_otros_costos
        //Funcion para filtrar la lista de colaboradores
        public ActionResult lista_items_otros_costos(long COD_CONTRATO_PROYECTO)
        {
            IEnumerable DataSource = db.VISTA_ITEMS_CONTRATO_DESCRIPCION.Where(o => o.COD_CONTRATO_PROYECTO == COD_CONTRATO_PROYECTO).ToList();

            return Json(new { success = true, responseText = "SI", data = DataSource }, "application/json", JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
