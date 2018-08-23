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
    public class CONTRATOSController : Controller
    {
        private test_payc_contabilidadEntities db = new test_payc_contabilidadEntities();

        // GET: CONTRATOS
        public ActionResult Index()
        {
            var cONTRATOS = db.CONTRATOS.Include(c => c.CLIENTES);
            return View(cONTRATOS.ToList());
        }

        // GET: CONTRATOS/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CONTRATOS cONTRATOS = db.CONTRATOS.Find(id);
            if (cONTRATOS == null)
            {
                return HttpNotFound();
            }
            return View(cONTRATOS);
        }

        // GET: CONTRATOS/Create
        public ActionResult Create()
        {
            ViewBag.COD_CLIENTE = new SelectList(db.CLIENTES, "COD_CLIENTE", "DESCRIPCION");
            return View();
        }

        // POST: CONTRATOS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COD_CONTRATO,DESCRIPCION,COD_CLIENTE,FECHA_FIRMA,RUTA_ACTA_INICIO,FECHA_INICIO_EJECUCION,FECHA_FIN_EJECUCION,VALOR_CONTRATO,ORDEN_SERVICIO,RUTA_DOCUMENTO")] CONTRATOS cONTRATOS)
        {
            if (ModelState.IsValid)
            {
                db.CONTRATOS.Add(cONTRATOS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.COD_CLIENTE = new SelectList(db.CLIENTES, "COD_CLIENTE", "DESCRIPCION", cONTRATOS.COD_CLIENTE);
            return View(cONTRATOS);
        }

        // GET: CONTRATOS/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CONTRATOS cONTRATOS = db.CONTRATOS.Find(id);
            if (cONTRATOS == null)
            {
                return HttpNotFound();
            }
            ViewBag.COD_CLIENTE = new SelectList(db.CLIENTES, "COD_CLIENTE", "DESCRIPCION", cONTRATOS.COD_CLIENTE);
            return View(cONTRATOS);
        }

        // POST: CONTRATOS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COD_CONTRATO,DESCRIPCION,COD_CLIENTE,FECHA_FIRMA,RUTA_ACTA_INICIO,FECHA_INICIO_EJECUCION,FECHA_FIN_EJECUCION,VALOR_CONTRATO,ORDEN_SERVICIO,RUTA_DOCUMENTO")] CONTRATOS cONTRATOS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cONTRATOS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.COD_CLIENTE = new SelectList(db.CLIENTES, "COD_CLIENTE", "DESCRIPCION", cONTRATOS.COD_CLIENTE);
            return View(cONTRATOS);
        }

        // GET: CONTRATOS/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CONTRATOS cONTRATOS = db.CONTRATOS.Find(id);
            if (cONTRATOS == null)
            {
                return HttpNotFound();
            }
            return View(cONTRATOS);
        }

        // POST: CONTRATOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            CONTRATOS cONTRATOS = db.CONTRATOS.Find(id);
            db.CONTRATOS.Remove(cONTRATOS);
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
            var DataSource2 = db.CONTRATOS.ToList();
            ViewBag.dataSource2 = DataSource2;
            return View();
        }	
		public ActionResult GetOrderData(DataManager dm)
        {
            IEnumerable DataSource = db.CONTRATOS.ToList();
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
            var count = DataSource.Cast<CONTRATOS>().Count();
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
        public ActionResult PerformInsert(EditParams_CONTRATOS param)
        {
            db.CONTRATOS.Add(param.value);
            db.SaveChanges();
			var data = db.CONTRATOS.ToList();
			var value = data.Last();
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        //Actualizar grid
        public ActionResult PerformUpdate(EditParams_CONTRATOS param)
        {
            
			CONTRATOS table = db.CONTRATOS.Single(o => o.COD_CONTRATO == param.value.COD_CONTRATO);

            db.Entry(table).CurrentValues.SetValues(param.value);
            db.SaveChanges();
			return RedirectToAction("GetOrderData");
			
        }

        //Borrar grid
        public ActionResult PerformDelete(int key, string keyColumn)
        {
            db.CONTRATOS.Remove(db.CONTRATOS.Single(o => o.COD_CONTRATO== key));
            db.SaveChanges();
            return RedirectToAction("GetOrderData");
            
        }
    }
}
