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
    public class CONTRATO_PROYECTOController : Controller
    {
        private test_payc_contabilidadEntities db = new test_payc_contabilidadEntities();

        // GET: CONTRATO_PROYECTO
        public ActionResult Index()
        {
            var cONTRATO_PROYECTO = db.CONTRATO_PROYECTO.Include(c => c.CONTRATOS).Include(c => c.FORMAS_PAGO).Include(c => c.PROYECTOS);
            return View(cONTRATO_PROYECTO.ToList());
        }

        // GET: CONTRATO_PROYECTO/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CONTRATO_PROYECTO cONTRATO_PROYECTO = db.CONTRATO_PROYECTO.Find(id);
            if (cONTRATO_PROYECTO == null)
            {
                return HttpNotFound();
            }
            return View(cONTRATO_PROYECTO);
        }

        // GET: CONTRATO_PROYECTO/Create
        public ActionResult Create()
        {
            ViewBag.COD_CONTRATO = new SelectList(db.CONTRATOS, "COD_CONTRATO", "DESCRIPCION");
            ViewBag.COD_FORMA_PAGO = new SelectList(db.FORMAS_PAGO, "COD_FORMA_PAGO", "DESCRIPCION");
            ViewBag.COD_PROYECTO = new SelectList(db.PROYECTOS, "COD_PROYECTO", "DESCRIPCION");
            return View();
        }

        // POST: CONTRATO_PROYECTO/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COD_CONTRATO_PROYECTO,COD_CONTRATO,COD_PROYECTO,COD_FORMA_PAGO")] CONTRATO_PROYECTO cONTRATO_PROYECTO)
        {
            if (ModelState.IsValid)
            {
                db.CONTRATO_PROYECTO.Add(cONTRATO_PROYECTO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.COD_CONTRATO = new SelectList(db.CONTRATOS, "COD_CONTRATO", "DESCRIPCION", cONTRATO_PROYECTO.COD_CONTRATO);
            ViewBag.COD_FORMA_PAGO = new SelectList(db.FORMAS_PAGO, "COD_FORMA_PAGO", "DESCRIPCION", cONTRATO_PROYECTO.COD_FORMA_PAGO);
            ViewBag.COD_PROYECTO = new SelectList(db.PROYECTOS, "COD_PROYECTO", "DESCRIPCION", cONTRATO_PROYECTO.COD_PROYECTO);
            return View(cONTRATO_PROYECTO);
        }

        // GET: CONTRATO_PROYECTO/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CONTRATO_PROYECTO cONTRATO_PROYECTO = db.CONTRATO_PROYECTO.Find(id);
            if (cONTRATO_PROYECTO == null)
            {
                return HttpNotFound();
            }
            ViewBag.COD_CONTRATO = new SelectList(db.CONTRATOS, "COD_CONTRATO", "DESCRIPCION", cONTRATO_PROYECTO.COD_CONTRATO);
            ViewBag.COD_FORMA_PAGO = new SelectList(db.FORMAS_PAGO, "COD_FORMA_PAGO", "DESCRIPCION", cONTRATO_PROYECTO.COD_FORMA_PAGO);
            ViewBag.COD_PROYECTO = new SelectList(db.PROYECTOS, "COD_PROYECTO", "DESCRIPCION", cONTRATO_PROYECTO.COD_PROYECTO);
            return View(cONTRATO_PROYECTO);
        }

        // POST: CONTRATO_PROYECTO/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COD_CONTRATO_PROYECTO,COD_CONTRATO,COD_PROYECTO,COD_FORMA_PAGO")] CONTRATO_PROYECTO cONTRATO_PROYECTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cONTRATO_PROYECTO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.COD_CONTRATO = new SelectList(db.CONTRATOS, "COD_CONTRATO", "DESCRIPCION", cONTRATO_PROYECTO.COD_CONTRATO);
            ViewBag.COD_FORMA_PAGO = new SelectList(db.FORMAS_PAGO, "COD_FORMA_PAGO", "DESCRIPCION", cONTRATO_PROYECTO.COD_FORMA_PAGO);
            ViewBag.COD_PROYECTO = new SelectList(db.PROYECTOS, "COD_PROYECTO", "DESCRIPCION", cONTRATO_PROYECTO.COD_PROYECTO);
            return View(cONTRATO_PROYECTO);
        }

        // GET: CONTRATO_PROYECTO/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CONTRATO_PROYECTO cONTRATO_PROYECTO = db.CONTRATO_PROYECTO.Find(id);
            if (cONTRATO_PROYECTO == null)
            {
                return HttpNotFound();
            }
            return View(cONTRATO_PROYECTO);
        }

        // POST: CONTRATO_PROYECTO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            CONTRATO_PROYECTO cONTRATO_PROYECTO = db.CONTRATO_PROYECTO.Find(id);
            db.CONTRATO_PROYECTO.Remove(cONTRATO_PROYECTO);
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
            var DataSource2 = db.CONTRATO_PROYECTO.ToList();
            ViewBag.dataSource2 = DataSource2;
            return View();
        }	
		public ActionResult GetOrderData(DataManager dm)
        {
            IEnumerable DataSource = db.CONTRATO_PROYECTO.ToList();
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
            var count = DataSource.Cast<CONTRATO_PROYECTO>().Count();
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
        public ActionResult PerformInsert(EditParams_CONTRATO_PROYECTO param)
        {
            db.CONTRATO_PROYECTO.Add(param.value);
            db.SaveChanges();
			var data = db.CONTRATO_PROYECTO.ToList();
			var value = data.Last();
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        //Actualizar grid
        public ActionResult PerformUpdate(EditParams_CONTRATO_PROYECTO param)
        {
            
			CONTRATO_PROYECTO table = db.CONTRATO_PROYECTO.Single(o => o.COD_CONTRATO_PROYECTO == param.value.COD_CONTRATO_PROYECTO);

            db.Entry(table).CurrentValues.SetValues(param.value);
            db.SaveChanges();
			return RedirectToAction("GetOrderData");
			
        }

        //Borrar grid
        public ActionResult PerformDelete(int key, string keyColumn)
        {
            db.CONTRATO_PROYECTO.Remove(db.CONTRATO_PROYECTO.Single(o => o.COD_CONTRATO_PROYECTO== key));
            db.SaveChanges();
            return RedirectToAction("GetOrderData");
            
        }
    }
}
