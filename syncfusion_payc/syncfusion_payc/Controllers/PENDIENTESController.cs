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
    public class PENDIENTESController : Controller
    {
        private test_payc_contabilidadEntities db = new test_payc_contabilidadEntities();

        // GET: PENDIENTES
        public ActionResult Index()
        {
            return View(db.PENDIENTES.ToList());
        }

        // GET: PENDIENTES/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PENDIENTES pENDIENTES = db.PENDIENTES.Find(id);
            if (pENDIENTES == null)
            {
                return HttpNotFound();
            }
            return View(pENDIENTES);
        }

        // GET: PENDIENTES/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PENDIENTES/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COD_CONTRATO_PROYECTO,COD_CONTRATO,ORDEN_SERVICIO,CENTRO_COSTOS,FECHA_INICIO_EJECUCION,FECHA_FIN_EJECUCION,TIPO_SERVICIO,DESCRIPCION,TIPO_OBRA")] PENDIENTES pENDIENTES)
        {
            if (ModelState.IsValid)
            {
                db.PENDIENTES.Add(pENDIENTES);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pENDIENTES);
        }

        // GET: PENDIENTES/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PENDIENTES pENDIENTES = db.PENDIENTES.Find(id);
            if (pENDIENTES == null)
            {
                return HttpNotFound();
            }
            return View(pENDIENTES);
        }

        // POST: PENDIENTES/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COD_CONTRATO_PROYECTO,COD_CONTRATO,ORDEN_SERVICIO,CENTRO_COSTOS,FECHA_INICIO_EJECUCION,FECHA_FIN_EJECUCION,TIPO_SERVICIO,DESCRIPCION,TIPO_OBRA")] PENDIENTES pENDIENTES)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pENDIENTES).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pENDIENTES);
        }

        // GET: PENDIENTES/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PENDIENTES pENDIENTES = db.PENDIENTES.Find(id);
            if (pENDIENTES == null)
            {
                return HttpNotFound();
            }
            return View(pENDIENTES);
        }

        // POST: PENDIENTES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            PENDIENTES pENDIENTES = db.PENDIENTES.Find(id);
            db.PENDIENTES.Remove(pENDIENTES);
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
            var DataSource2 = db.PENDIENTES.ToList();
            ViewBag.dataSource2 = DataSource2;
            return View();
        }	
		public ActionResult GetOrderData(DataManager dm)
        {
            IEnumerable DataSource = db.PENDIENTES.ToList();
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
            var count = DataSource.Cast<PENDIENTES>().Count();
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
        /*public ActionResult PerformInsert(EditParams_PENDIENTES param)
        {
            db.PENDIENTES.Add(param.value);
            db.SaveChanges();
			var data = db.PENDIENTES.ToList();
			var value = data.Last();
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        //Actualizar grid
        public ActionResult PerformUpdate(EditParams_PENDIENTES param)
        {
            
			PENDIENTES table = db.PENDIENTES.Single(o => o.COD_CONTRATO_PROYECTO == param.value.COD_CONTRATO_PROYECTO);

            db.Entry(table).CurrentValues.SetValues(param.value);
            db.SaveChanges();
			return RedirectToAction("GetOrderData");
			
        }

        //Borrar grid
        public ActionResult PerformDelete(int key, string keyColumn)
        {
            db.PENDIENTES.Remove(db.PENDIENTES.Single(o => o.COD_CONTRATO_PROYECTO== key));
            db.SaveChanges();
            return RedirectToAction("GetOrderData");
            
        }*/
    }
}
