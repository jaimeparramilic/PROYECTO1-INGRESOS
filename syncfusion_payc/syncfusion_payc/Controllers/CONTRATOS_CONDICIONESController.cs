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

using syncfusion_payc.Models;

namespace syncfusion_payc.Controllers
{
    public class CONTRATOS_CONDICIONESController : Controller
    {
        private test_payc_contabilidadEntities db = new test_payc_contabilidadEntities();

        // GET: CONTRATOS_CONDICIONES
        public ActionResult Index()
        {
            //var cONTRATOS_CONDICIONES = db.CONTRATOS_CONDICIONES_VISTA;
            return View();
        }

        // GET: CONTRATOS_CONDICIONES/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CONTRATOS_CONDICIONES cONTRATOS_CONDICIONES = db.CONTRATOS_CONDICIONES.Find(id);
            if (cONTRATOS_CONDICIONES == null)
            {
                return HttpNotFound();
            }
            return View(cONTRATOS_CONDICIONES);
        }

        // GET: CONTRATOS_CONDICIONES/Create
        public ActionResult Create()
        {
            ViewBag.COD_CONTRATO_PROYECTO = new SelectList(db.CONTRATO_PROYECTO, "COD_CONTRATO_PROYECTO", "COMPLETA");
            ViewBag.COD_TIPO_CONDICION = new SelectList(db.TIPO_CONDICION_CONTRACTUAL, "COD_TIPO_CONDICION", "DESCRIPCION");
            return View();
        }

        // POST: CONTRATOS_CONDICIONES/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COD_CONTRATO_CONDICION,COD_CONTRATO_PROYECTO,COD_TIPO_CONDICION,VIGENTE,FECHA_INCLUSION,FECHA_EXCLUSION")] CONTRATOS_CONDICIONES cONTRATOS_CONDICIONES)
        {
            if (ModelState.IsValid)
            {
                db.CONTRATOS_CONDICIONES.Add(cONTRATOS_CONDICIONES);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.COD_CONTRATO_PROYECTO = new SelectList(db.CONTRATO_PROYECTO, "COD_CONTRATO_PROYECTO", "COMPLETA", cONTRATOS_CONDICIONES.COD_CONTRATO_PROYECTO);
            ViewBag.COD_TIPO_CONDICION = new SelectList(db.TIPO_CONDICION_CONTRACTUAL, "COD_TIPO_CONDICION", "DESCRIPCION", cONTRATOS_CONDICIONES.COD_TIPO_CONDICION);
            return View(cONTRATOS_CONDICIONES);
        }

        // GET: CONTRATOS_CONDICIONES/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CONTRATOS_CONDICIONES cONTRATOS_CONDICIONES = db.CONTRATOS_CONDICIONES.Find(id);
            if (cONTRATOS_CONDICIONES == null)
            {
                return HttpNotFound();
            }
            ViewBag.COD_CONTRATO_PROYECTO = new SelectList(db.CONTRATO_PROYECTO, "COD_CONTRATO_PROYECTO", "COMPLETA", cONTRATOS_CONDICIONES.COD_CONTRATO_PROYECTO);
            ViewBag.COD_TIPO_CONDICION = new SelectList(db.TIPO_CONDICION_CONTRACTUAL, "COD_TIPO_CONDICION", "DESCRIPCION", cONTRATOS_CONDICIONES.COD_TIPO_CONDICION);
            return View(cONTRATOS_CONDICIONES);
        }

        // POST: CONTRATOS_CONDICIONES/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COD_CONTRATO_CONDICION,COD_CONTRATO_PROYECTO,COD_TIPO_CONDICION,VIGENTE,FECHA_INCLUSION,FECHA_EXCLUSION")] CONTRATOS_CONDICIONES cONTRATOS_CONDICIONES)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cONTRATOS_CONDICIONES).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.COD_CONTRATO_PROYECTO = new SelectList(db.CONTRATO_PROYECTO, "COD_CONTRATO_PROYECTO", "COMPLETA", cONTRATOS_CONDICIONES.COD_CONTRATO_PROYECTO);
            ViewBag.COD_TIPO_CONDICION = new SelectList(db.TIPO_CONDICION_CONTRACTUAL, "COD_TIPO_CONDICION", "DESCRIPCION", cONTRATOS_CONDICIONES.COD_TIPO_CONDICION);
            return View(cONTRATOS_CONDICIONES);
        }

        // GET: CONTRATOS_CONDICIONES/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CONTRATOS_CONDICIONES cONTRATOS_CONDICIONES = db.CONTRATOS_CONDICIONES.Find(id);
            if (cONTRATOS_CONDICIONES == null)
            {
                return HttpNotFound();
            }
            return View(cONTRATOS_CONDICIONES);
        }

        // POST: CONTRATOS_CONDICIONES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            CONTRATOS_CONDICIONES cONTRATOS_CONDICIONES = db.CONTRATOS_CONDICIONES.Find(id);
            db.CONTRATOS_CONDICIONES.Remove(cONTRATOS_CONDICIONES);
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
            var DataSource2 = db.CONTRATOS_CONDICIONES.ToList();
            ViewBag.dataSource2 = DataSource2;
            return View();
        }	

		public ActionResult GetOrderData(DataManager dm)
        {
            IEnumerable DataSource = db.CONTRATOS_CONDICIONES_VISTA.ToList();
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
            var count = DataSource.Cast<CONTRATOS_CONDICIONES_VISTA>().Count();
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
        public ActionResult PerformInsert(EditParams_CONTRATOS_CONDICIONES_VISTA param)
        {
            CONTRATOS_CONDICIONES temp = new CONTRATOS_CONDICIONES();
            temp.COD_CONTRATO_PROYECTO = param.value.COD_CONTRATO_PROYECTO;
            temp.COD_TIPO_CONDICION = param.value.COD_TIPO_CONDICION;
            temp.VIGENTE = "SI";
            temp.FECHA_INCLUSION= DateTime.Today;
            db.CONTRATOS_CONDICIONES.Add(temp);
            db.SaveChanges();
			var data = db.CONTRATOS_CONDICIONES_VISTA.ToList();
			var value = data.Last();
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        //Actualizar grid
        public ActionResult PerformUpdate(EditParams_CONTRATOS_CONDICIONES param)
        {
            
			CONTRATOS_CONDICIONES temp = db.CONTRATOS_CONDICIONES.Single(o => o.COD_CONTRATO_CONDICION == param.value.COD_CONTRATO_CONDICION);
           
            temp.COD_CONTRATO_PROYECTO = param.value.COD_CONTRATO_PROYECTO;
            temp.COD_TIPO_CONDICION = param.value.COD_TIPO_CONDICION;
            if (param.value.VIGENTE == "NO")
            {
                temp.VIGENTE = "NO";
                temp.FECHA_EXCLUSION = DateTime.Today;
            }
            else
            {
                temp.VIGENTE = "SI";
                temp.FECHA_INCLUSION= DateTime.Today;
            }
      
            db.SaveChanges();
			return RedirectToAction("GetOrderData");
			
        }

        //Borrar grid
        public ActionResult PerformDelete(int key, string keyColumn)
        {
            CONTRATOS_CONDICIONES temp = db.CONTRATOS_CONDICIONES.Single(o => o.COD_CONTRATO_CONDICION ==key);
            temp.VIGENTE = "NO";
            temp.FECHA_EXCLUSION= DateTime.Today;
            db.SaveChanges();
            return RedirectToAction("GetOrderData");
            
        }
    }
}
