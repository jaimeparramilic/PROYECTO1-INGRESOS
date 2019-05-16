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
    public class CONTRATO_ROL_CARGOController : Controller
    {
        private test_payc_contabilidadEntities db = new test_payc_contabilidadEntities();

        // GET: CONTRATO_ROL_CARGO
        public ActionResult Index()
        {
            var cONTRATO_ROL_CARGO = db.CONTRATO_ROL_CARGO.Include(c => c.CARGOS).Include(c => c.CONTRATOS_ROL);
            return View(cONTRATO_ROL_CARGO.ToList());
        }

        // GET: CONTRATO_ROL_CARGO/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CONTRATO_ROL_CARGO cONTRATO_ROL_CARGO = db.CONTRATO_ROL_CARGO.Find(id);
            if (cONTRATO_ROL_CARGO == null)
            {
                return HttpNotFound();
            }
            return View(cONTRATO_ROL_CARGO);
        }

        // GET: CONTRATO_ROL_CARGO/Create
        public ActionResult Create()
        {
            ViewBag.COD_CARGO = new SelectList(db.CARGOS, "COD_CARGO", "DESCRIPCION_CARGO");
            ViewBag.COD_CONTRATO_ROL = new SelectList(db.CONTRATOS_ROL, "COD_CONTRATO_ROL", "OBSERVACIONES");
            return View();
        }

        // POST: CONTRATO_ROL_CARGO/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COD_CONTRATO_ROL,COD_CONTRATO_ROL_CARGO,COD_CARGO")] CONTRATO_ROL_CARGO cONTRATO_ROL_CARGO)
        {
            if (ModelState.IsValid)
            {
                db.CONTRATO_ROL_CARGO.Add(cONTRATO_ROL_CARGO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.COD_CARGO = new SelectList(db.CARGOS, "COD_CARGO", "DESCRIPCION_CARGO", cONTRATO_ROL_CARGO.COD_CARGO);
            ViewBag.COD_CONTRATO_ROL = new SelectList(db.CONTRATOS_ROL, "COD_CONTRATO_ROL", "OBSERVACIONES", cONTRATO_ROL_CARGO.COD_CONTRATO_ROL);
            return View(cONTRATO_ROL_CARGO);
        }

        // GET: CONTRATO_ROL_CARGO/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CONTRATO_ROL_CARGO cONTRATO_ROL_CARGO = db.CONTRATO_ROL_CARGO.Find(id);
            if (cONTRATO_ROL_CARGO == null)
            {
                return HttpNotFound();
            }
            ViewBag.COD_CARGO = new SelectList(db.CARGOS, "COD_CARGO", "DESCRIPCION_CARGO", cONTRATO_ROL_CARGO.COD_CARGO);
            ViewBag.COD_CONTRATO_ROL = new SelectList(db.CONTRATOS_ROL, "COD_CONTRATO_ROL", "OBSERVACIONES", cONTRATO_ROL_CARGO.COD_CONTRATO_ROL);
            return View(cONTRATO_ROL_CARGO);
        }

        // POST: CONTRATO_ROL_CARGO/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COD_CONTRATO_ROL,COD_CONTRATO_ROL_CARGO,COD_CARGO")] CONTRATO_ROL_CARGO cONTRATO_ROL_CARGO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cONTRATO_ROL_CARGO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.COD_CARGO = new SelectList(db.CARGOS, "COD_CARGO", "DESCRIPCION_CARGO", cONTRATO_ROL_CARGO.COD_CARGO);
            ViewBag.COD_CONTRATO_ROL = new SelectList(db.CONTRATOS_ROL, "COD_CONTRATO_ROL", "OBSERVACIONES", cONTRATO_ROL_CARGO.COD_CONTRATO_ROL);
            return View(cONTRATO_ROL_CARGO);
        }

        // GET: CONTRATO_ROL_CARGO/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CONTRATO_ROL_CARGO cONTRATO_ROL_CARGO = db.CONTRATO_ROL_CARGO.Find(id);
            if (cONTRATO_ROL_CARGO == null)
            {
                return HttpNotFound();
            }
            return View(cONTRATO_ROL_CARGO);
        }

        // POST: CONTRATO_ROL_CARGO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            CONTRATO_ROL_CARGO cONTRATO_ROL_CARGO = db.CONTRATO_ROL_CARGO.Find(id);
            db.CONTRATO_ROL_CARGO.Remove(cONTRATO_ROL_CARGO);
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
            var DataSource2 = db.CONTRATO_ROL_CARGO.ToList();
            ViewBag.dataSource2 = DataSource2;
            return View();
        }	
		public ActionResult GetOrderData(DataManager dm)
        {
            IEnumerable DataSource = db.CONTRATO_ROL_CARGO.ToList();
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
            var count = DataSource.Cast<CONTRATO_ROL_CARGO>().Count();
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
        public ActionResult PerformInsert(EditParams_CONTRATO_ROL_CARGO param)
        {
            db.CONTRATO_ROL_CARGO.Add(param.value);
            db.SaveChanges();
			var data = db.CONTRATO_ROL_CARGO.ToList();
			var value = data.Last();
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        //Actualizar grid
        public ActionResult PerformUpdate(EditParams_CONTRATO_ROL_CARGO param)
        {
            
			CONTRATO_ROL_CARGO table = db.CONTRATO_ROL_CARGO.Single(o => o.COD_CONTRATO_ROL_CARGO == param.value.COD_CONTRATO_ROL_CARGO);

            db.Entry(table).CurrentValues.SetValues(param.value);
            db.SaveChanges();
			return RedirectToAction("GetOrderData");
			
        }

        //Borrar grid
        public ActionResult PerformDelete(int key, string keyColumn)
        {
            db.CONTRATO_ROL_CARGO.Remove(db.CONTRATO_ROL_CARGO.Single(o => o.COD_CONTRATO_ROL_CARGO== key));
            db.SaveChanges();
            return RedirectToAction("GetOrderData");
            
        }
    }
}
