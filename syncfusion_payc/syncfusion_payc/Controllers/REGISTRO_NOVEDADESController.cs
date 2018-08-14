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
    public class REGISTRO_NOVEDADESController : Controller
    {
        private test_payc_contabilidadEntities db = new test_payc_contabilidadEntities();

        // GET: REGISTRO_NOVEDADES
        public ActionResult Index()
        {
            var rEGISTRO_NOVEDADES = db.REGISTRO_NOVEDADES.Include(r => r.COLABORADORES).Include(r => r.CONTRATO_PROYECTO).Include(r => r.FORMAS_PAGO_FECHAS).Include(r => r.TIPOS_NOVEDAD);
            return View(rEGISTRO_NOVEDADES.ToList());
        }

        // GET: REGISTRO_NOVEDADES/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            REGISTRO_NOVEDADES rEGISTRO_NOVEDADES = db.REGISTRO_NOVEDADES.Find(id);
            if (rEGISTRO_NOVEDADES == null)
            {
                return HttpNotFound();
            }
            return View(rEGISTRO_NOVEDADES);
        }

        // GET: REGISTRO_NOVEDADES/Create
        public ActionResult Create()
        {
            ViewBag.COD_COLABORADOR = new SelectList(db.COLABORADORES, "COD_COLABORADOR", "DESCRIPCION");
            ViewBag.COD_CONTRATO_PROYECTO = new SelectList(db.CONTRATO_PROYECTO, "COD_CONTRATO_PROYECTO", "COMPLETA");
            ViewBag.COD_FORMAS_PAGO_FECHAS = new SelectList(db.FORMAS_PAGO_FECHAS, "COD_FORMAS_PAGO_FECHAS", "PERIODO_TEXTO");
            ViewBag.COD_TIPO_NOVEDAD = new SelectList(db.TIPOS_NOVEDAD, "COD_TIPO_NOVEDAD", "DESCRIPCION");
            return View();
        }

        // POST: REGISTRO_NOVEDADES/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COD_REGISTRO_NOVEDADES,COD_COLABORADOR,COD_CONTRATO_PROYECTO,COD_TIPO_NOVEDAD,COD_FORMAS_PAGO_FECHAS,FECHA_INICIO_NOVEDAD,FECHA_FIN_NOVEDAD")] REGISTRO_NOVEDADES rEGISTRO_NOVEDADES)
        {
            if (ModelState.IsValid)
            {
                db.REGISTRO_NOVEDADES.Add(rEGISTRO_NOVEDADES);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.COD_COLABORADOR = new SelectList(db.COLABORADORES, "COD_COLABORADOR", "DESCRIPCION", rEGISTRO_NOVEDADES.COD_COLABORADOR);
            ViewBag.COD_CONTRATO_PROYECTO = new SelectList(db.CONTRATO_PROYECTO, "COD_CONTRATO_PROYECTO", "COMPLETA", rEGISTRO_NOVEDADES.COD_CONTRATO_PROYECTO);
            ViewBag.COD_FORMAS_PAGO_FECHAS = new SelectList(db.FORMAS_PAGO_FECHAS, "COD_FORMAS_PAGO_FECHAS", "PERIODO_TEXTO", rEGISTRO_NOVEDADES.COD_FORMAS_PAGO_FECHAS);
            ViewBag.COD_TIPO_NOVEDAD = new SelectList(db.TIPOS_NOVEDAD, "COD_TIPO_NOVEDAD", "DESCRIPCION", rEGISTRO_NOVEDADES.COD_TIPO_NOVEDAD);
            return View(rEGISTRO_NOVEDADES);
        }

        // GET: REGISTRO_NOVEDADES/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            REGISTRO_NOVEDADES rEGISTRO_NOVEDADES = db.REGISTRO_NOVEDADES.Find(id);
            if (rEGISTRO_NOVEDADES == null)
            {
                return HttpNotFound();
            }
            ViewBag.COD_COLABORADOR = new SelectList(db.COLABORADORES, "COD_COLABORADOR", "DESCRIPCION", rEGISTRO_NOVEDADES.COD_COLABORADOR);
            ViewBag.COD_CONTRATO_PROYECTO = new SelectList(db.CONTRATO_PROYECTO, "COD_CONTRATO_PROYECTO", "COMPLETA", rEGISTRO_NOVEDADES.COD_CONTRATO_PROYECTO);
            ViewBag.COD_FORMAS_PAGO_FECHAS = new SelectList(db.FORMAS_PAGO_FECHAS, "COD_FORMAS_PAGO_FECHAS", "PERIODO_TEXTO", rEGISTRO_NOVEDADES.COD_FORMAS_PAGO_FECHAS);
            ViewBag.COD_TIPO_NOVEDAD = new SelectList(db.TIPOS_NOVEDAD, "COD_TIPO_NOVEDAD", "DESCRIPCION", rEGISTRO_NOVEDADES.COD_TIPO_NOVEDAD);
            return View(rEGISTRO_NOVEDADES);
        }

        // POST: REGISTRO_NOVEDADES/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COD_REGISTRO_NOVEDADES,COD_COLABORADOR,COD_CONTRATO_PROYECTO,COD_TIPO_NOVEDAD,COD_FORMAS_PAGO_FECHAS,FECHA_INICIO_NOVEDAD,FECHA_FIN_NOVEDAD")] REGISTRO_NOVEDADES rEGISTRO_NOVEDADES)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rEGISTRO_NOVEDADES).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.COD_COLABORADOR = new SelectList(db.COLABORADORES, "COD_COLABORADOR", "DESCRIPCION", rEGISTRO_NOVEDADES.COD_COLABORADOR);
            ViewBag.COD_CONTRATO_PROYECTO = new SelectList(db.CONTRATO_PROYECTO, "COD_CONTRATO_PROYECTO", "COMPLETA", rEGISTRO_NOVEDADES.COD_CONTRATO_PROYECTO);
            ViewBag.COD_FORMAS_PAGO_FECHAS = new SelectList(db.FORMAS_PAGO_FECHAS, "COD_FORMAS_PAGO_FECHAS", "PERIODO_TEXTO", rEGISTRO_NOVEDADES.COD_FORMAS_PAGO_FECHAS);
            ViewBag.COD_TIPO_NOVEDAD = new SelectList(db.TIPOS_NOVEDAD, "COD_TIPO_NOVEDAD", "DESCRIPCION", rEGISTRO_NOVEDADES.COD_TIPO_NOVEDAD);
            return View(rEGISTRO_NOVEDADES);
        }

        // GET: REGISTRO_NOVEDADES/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            REGISTRO_NOVEDADES rEGISTRO_NOVEDADES = db.REGISTRO_NOVEDADES.Find(id);
            if (rEGISTRO_NOVEDADES == null)
            {
                return HttpNotFound();
            }
            return View(rEGISTRO_NOVEDADES);
        }

        // POST: REGISTRO_NOVEDADES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            REGISTRO_NOVEDADES rEGISTRO_NOVEDADES = db.REGISTRO_NOVEDADES.Find(id);
            db.REGISTRO_NOVEDADES.Remove(rEGISTRO_NOVEDADES);
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
            var DataSource2 = db.REGISTRO_NOVEDADES.ToList();
            ViewBag.dataSource2 = DataSource2;
            return View();
        }	
		public ActionResult GetOrderData(DataManager dm)
        {
            IEnumerable DataSource = db.REGISTRO_NOVEDADES.ToList();
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
            var count = DataSource.Cast<REGISTRO_NOVEDADES>().Count();
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
        public ActionResult PerformInsert(EditParams_REGISTRO_NOVEDADES param)
        {
            db.REGISTRO_NOVEDADES.Add(param.value);
            db.SaveChanges();
			var data = db.REGISTRO_NOVEDADES.ToList();
			var value = data.Last();
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        //Actualizar grid
        public ActionResult PerformUpdate(EditParams_REGISTRO_NOVEDADES param)
        {
            
			REGISTRO_NOVEDADES table = db.REGISTRO_NOVEDADES.Single(o => o.COD_REGISTRO_NOVEDADES == param.value.COD_REGISTRO_NOVEDADES);

            db.Entry(table).CurrentValues.SetValues(param.value);
            db.SaveChanges();
			return RedirectToAction("GetOrderData");
			
        }

        //Borrar grid
        public ActionResult PerformDelete(int key, string keyColumn)
        {
            db.REGISTRO_NOVEDADES.Remove(db.REGISTRO_NOVEDADES.Single(o => o.COD_REGISTRO_NOVEDADES== key));
            db.SaveChanges();
            return RedirectToAction("GetOrderData");
            
        }
    }
}
