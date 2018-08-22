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
    public class VISTA_PENDIENTES_RETIROController : Controller
    {
        private test_payc_contabilidadEntities db = new test_payc_contabilidadEntities();

        // GET: VISTA_PENDIENTES_RETIRO
        public ActionResult Index()
        {
            return View(db.VISTA_PENDIENTES_RETIRO.ToList());
        }

        // GET: VISTA_PENDIENTES_RETIRO/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VISTA_PENDIENTES_RETIRO vISTA_PENDIENTES_RETIRO = db.VISTA_PENDIENTES_RETIRO.Find(id);
            if (vISTA_PENDIENTES_RETIRO == null)
            {
                return HttpNotFound();
            }
            return View(vISTA_PENDIENTES_RETIRO);
        }

        // GET: VISTA_PENDIENTES_RETIRO/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VISTA_PENDIENTES_RETIRO/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COD_CONTRATO_PROYECTO,FECHA_FIN,FECHA_INI,COD_COLABORADOR,COD_CARGO,NOMBRES,APELLIDOS,COD_TIPO_DE_CONTRATO,CENTROS_COSTOS,CEDULA,CENTRO_COSTOS_PROYECTO,DESCRIPCION,FECHA_FIN_PACTADA,DESCRIPCION_ROL,HOY")] VISTA_PENDIENTES_RETIRO vISTA_PENDIENTES_RETIRO)
        {
            if (ModelState.IsValid)
            {
                db.VISTA_PENDIENTES_RETIRO.Add(vISTA_PENDIENTES_RETIRO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vISTA_PENDIENTES_RETIRO);
        }

        // GET: VISTA_PENDIENTES_RETIRO/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VISTA_PENDIENTES_RETIRO vISTA_PENDIENTES_RETIRO = db.VISTA_PENDIENTES_RETIRO.Find(id);
            if (vISTA_PENDIENTES_RETIRO == null)
            {
                return HttpNotFound();
            }
            return View(vISTA_PENDIENTES_RETIRO);
        }

        // POST: VISTA_PENDIENTES_RETIRO/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COD_CONTRATO_PROYECTO,FECHA_FIN,FECHA_INI,COD_COLABORADOR,COD_CARGO,NOMBRES,APELLIDOS,COD_TIPO_DE_CONTRATO,CENTROS_COSTOS,CEDULA,CENTRO_COSTOS_PROYECTO,DESCRIPCION,FECHA_FIN_PACTADA,DESCRIPCION_ROL,HOY")] VISTA_PENDIENTES_RETIRO vISTA_PENDIENTES_RETIRO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vISTA_PENDIENTES_RETIRO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vISTA_PENDIENTES_RETIRO);
        }

        // GET: VISTA_PENDIENTES_RETIRO/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VISTA_PENDIENTES_RETIRO vISTA_PENDIENTES_RETIRO = db.VISTA_PENDIENTES_RETIRO.Find(id);
            if (vISTA_PENDIENTES_RETIRO == null)
            {
                return HttpNotFound();
            }
            return View(vISTA_PENDIENTES_RETIRO);
        }

        // POST: VISTA_PENDIENTES_RETIRO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            VISTA_PENDIENTES_RETIRO vISTA_PENDIENTES_RETIRO = db.VISTA_PENDIENTES_RETIRO.Find(id);
            db.VISTA_PENDIENTES_RETIRO.Remove(vISTA_PENDIENTES_RETIRO);
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
            var DataSource2 = db.VISTA_PENDIENTES_RETIRO.ToList();
            ViewBag.dataSource2 = DataSource2;
            return View();
        }	
		public ActionResult GetOrderData(DataManager dm)
        {
            IEnumerable DataSource = db.VISTA_PENDIENTES_RETIRO.ToList();
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
            var count = DataSource.Cast<VISTA_PENDIENTES_RETIRO>().Count();
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
        public ActionResult PerformInsert(EditParams_VISTA_PENDIENTES_RETIRO param)
        {
            db.VISTA_PENDIENTES_RETIRO.Add(param.value);
            db.SaveChanges();
			var data = db.VISTA_PENDIENTES_RETIRO.ToList();
			var value = data.Last();
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        //Actualizar grid
        public ActionResult PerformUpdate(EditParams_VISTA_PENDIENTES_RETIRO param)
        {
            
			VISTA_PENDIENTES_RETIRO table = db.VISTA_PENDIENTES_RETIRO.Single(o => o.COD_COLABORADOR == param.value.COD_COLABORADOR);

            db.Entry(table).CurrentValues.SetValues(param.value);
            db.SaveChanges();
			return RedirectToAction("GetOrderData");
			
        }

        //Borrar grid
        public ActionResult PerformDelete(int key, string keyColumn)
        {
            db.VISTA_PENDIENTES_RETIRO.Remove(db.VISTA_PENDIENTES_RETIRO.Single(o => o.COD_COLABORADOR== key));
            db.SaveChanges();
            return RedirectToAction("GetOrderData");
            
        }
    }
}
