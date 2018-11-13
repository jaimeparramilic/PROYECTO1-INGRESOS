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
    public class VISTA_GESTION_CARTERAController : Controller
    {
        private test_payc_contabilidadEntities db = new test_payc_contabilidadEntities();

        // GET: VISTA_GESTION_CARTERA
        public ActionResult Index()
        {
            return View(db.VISTA_GESTION_CARTERA.ToList());
        }

        // GET: VISTA_GESTION_CARTERA/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VISTA_GESTION_CARTERA vISTA_GESTION_CARTERA = db.VISTA_GESTION_CARTERA.Find(id);
            if (vISTA_GESTION_CARTERA == null)
            {
                return HttpNotFound();
            }
            return View(vISTA_GESTION_CARTERA);
        }

        // GET: VISTA_GESTION_CARTERA/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VISTA_GESTION_CARTERA/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COD_CARTERA,COD_FACTURA,ESTADO_CARTERA,UserName,COD_CONTRATO_PROYECTO,COD_FORMAS_PAGO_FECHAS,NUMERO_FACTURA,FECHA_FACTURA,COD_ESTADO_FACTURA,VALOR_SIN_IMPUESTOS,RANKING,DIAS")] VISTA_GESTION_CARTERA vISTA_GESTION_CARTERA)
        {
            if (ModelState.IsValid)
            {
                db.VISTA_GESTION_CARTERA.Add(vISTA_GESTION_CARTERA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vISTA_GESTION_CARTERA);
        }

        // GET: VISTA_GESTION_CARTERA/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VISTA_GESTION_CARTERA vISTA_GESTION_CARTERA = db.VISTA_GESTION_CARTERA.Find(id);
            if (vISTA_GESTION_CARTERA == null)
            {
                return HttpNotFound();
            }
            return View(vISTA_GESTION_CARTERA);
        }

        // POST: VISTA_GESTION_CARTERA/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COD_CARTERA,COD_FACTURA,ESTADO_CARTERA,UserName,COD_CONTRATO_PROYECTO,COD_FORMAS_PAGO_FECHAS,NUMERO_FACTURA,FECHA_FACTURA,COD_ESTADO_FACTURA,VALOR_SIN_IMPUESTOS,RANKING,DIAS")] VISTA_GESTION_CARTERA vISTA_GESTION_CARTERA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vISTA_GESTION_CARTERA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vISTA_GESTION_CARTERA);
        }

        // GET: VISTA_GESTION_CARTERA/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VISTA_GESTION_CARTERA vISTA_GESTION_CARTERA = db.VISTA_GESTION_CARTERA.Find(id);
            if (vISTA_GESTION_CARTERA == null)
            {
                return HttpNotFound();
            }
            return View(vISTA_GESTION_CARTERA);
        }

        // POST: VISTA_GESTION_CARTERA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            VISTA_GESTION_CARTERA vISTA_GESTION_CARTERA = db.VISTA_GESTION_CARTERA.Find(id);
            db.VISTA_GESTION_CARTERA.Remove(vISTA_GESTION_CARTERA);
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
            var DataSource2 = db.VISTA_GESTION_CARTERA.ToList();
            ViewBag.dataSource2 = DataSource2;
            return View();
        }	
		public ActionResult GetOrderData(DataManager dm)
        {
            IEnumerable DataSource = db.VISTA_GESTION_CARTERA.ToList();
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
            var count = DataSource.Cast<VISTA_GESTION_CARTERA>().Count();
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
        public ActionResult PerformInsert(EditParams_VISTA_GESTION_CARTERA param)
        {
            db.VISTA_GESTION_CARTERA.Add(param.value);
            db.SaveChanges();
			var data = db.VISTA_GESTION_CARTERA.ToList();
			var value = data.Last();
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        //Actualizar grid
        public ActionResult PerformUpdate(EditParams_VISTA_GESTION_CARTERA param)
        {
            
			VISTA_GESTION_CARTERA table = db.VISTA_GESTION_CARTERA.Single(o => o.COD_CARTERA == param.value.COD_CARTERA);

            db.Entry(table).CurrentValues.SetValues(param.value);
            db.SaveChanges();
			return RedirectToAction("GetOrderData");
			
        }

        //Borrar grid
        public ActionResult PerformDelete(int key, string keyColumn)
        {
            db.VISTA_GESTION_CARTERA.Remove(db.VISTA_GESTION_CARTERA.Single(o => o.COD_CARTERA== key));
            db.SaveChanges();
            return RedirectToAction("GetOrderData");
            
        }
    }
}
