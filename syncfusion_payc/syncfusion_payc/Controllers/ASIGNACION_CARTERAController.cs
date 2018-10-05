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
    public class ASIGNACION_CARTERAController : Controller
    {
        private test_payc_contabilidadEntities db = new test_payc_contabilidadEntities();

        // GET: ASIGNACION_CARTERA
        public ActionResult Index()
        {
            var aSIGNACION_CARTERA = db.ASIGNACION_CARTERA.Include(a => a.CARTERA);
            return View(aSIGNACION_CARTERA.ToList());
        }

        // GET: ASIGNACION_CARTERA/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ASIGNACION_CARTERA aSIGNACION_CARTERA = db.ASIGNACION_CARTERA.Find(id);
            if (aSIGNACION_CARTERA == null)
            {
                return HttpNotFound();
            }
            return View(aSIGNACION_CARTERA);
        }

        // GET: ASIGNACION_CARTERA/Create
        public ActionResult Create()
        {
            ViewBag.COD_CARTERA = new SelectList(db.CARTERA, "COD_CARTERA", "COD_CARTERA");
            return View();
        }

        // POST: ASIGNACION_CARTERA/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COD_ASIGN_CARTERA,COD_CARTERA,UserName,FECHA_ASIGNACION")] ASIGNACION_CARTERA aSIGNACION_CARTERA)
        {
            if (ModelState.IsValid)
            {
                db.ASIGNACION_CARTERA.Add(aSIGNACION_CARTERA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.COD_CARTERA = new SelectList(db.CARTERA, "COD_CARTERA", "COD_CARTERA", aSIGNACION_CARTERA.COD_CARTERA);
            return View(aSIGNACION_CARTERA);
        }

        // GET: ASIGNACION_CARTERA/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ASIGNACION_CARTERA aSIGNACION_CARTERA = db.ASIGNACION_CARTERA.Find(id);
            if (aSIGNACION_CARTERA == null)
            {
                return HttpNotFound();
            }
            ViewBag.COD_CARTERA = new SelectList(db.CARTERA, "COD_CARTERA", "COD_CARTERA", aSIGNACION_CARTERA.COD_CARTERA);
            return View(aSIGNACION_CARTERA);
        }

        // POST: ASIGNACION_CARTERA/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COD_ASIGN_CARTERA,COD_CARTERA,UserName,FECHA_ASIGNACION")] ASIGNACION_CARTERA aSIGNACION_CARTERA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aSIGNACION_CARTERA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.COD_CARTERA = new SelectList(db.CARTERA, "COD_CARTERA", "COD_CARTERA", aSIGNACION_CARTERA.COD_CARTERA);
            return View(aSIGNACION_CARTERA);
        }

        // GET: ASIGNACION_CARTERA/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ASIGNACION_CARTERA aSIGNACION_CARTERA = db.ASIGNACION_CARTERA.Find(id);
            if (aSIGNACION_CARTERA == null)
            {
                return HttpNotFound();
            }
            return View(aSIGNACION_CARTERA);
        }

        // POST: ASIGNACION_CARTERA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            ASIGNACION_CARTERA aSIGNACION_CARTERA = db.ASIGNACION_CARTERA.Find(id);
            db.ASIGNACION_CARTERA.Remove(aSIGNACION_CARTERA);
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
            var DataSource2 = db.ASIGNACION_CARTERA.ToList();
            ViewBag.dataSource2 = DataSource2;
            return View();
        }	
		public ActionResult GetOrderData(DataManager dm)
        {
            IEnumerable DataSource = db.ASIGNACION_CARTERA.ToList();
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
            var count = DataSource.Cast<ASIGNACION_CARTERA>().Count();
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
        public ActionResult PerformInsert(EditParams_ASIGNACION_CARTERA param)
        {
            db.ASIGNACION_CARTERA.Add(param.value);
            db.SaveChanges();
			var data = db.ASIGNACION_CARTERA.ToList();
			var value = data.Last();
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        //Actualizar grid
        public ActionResult PerformUpdate(EditParams_ASIGNACION_CARTERA param)
        {
            
			ASIGNACION_CARTERA table = db.ASIGNACION_CARTERA.Single(o => o.COD_ASIGN_CARTERA == param.value.COD_ASIGN_CARTERA);

            db.Entry(table).CurrentValues.SetValues(param.value);
            db.SaveChanges();
			return RedirectToAction("GetOrderData");
			
        }

        //Borrar grid
        public ActionResult PerformDelete(int key, string keyColumn)
        {
            db.ASIGNACION_CARTERA.Remove(db.ASIGNACION_CARTERA.Single(o => o.COD_ASIGN_CARTERA== key));
            db.SaveChanges();
            return RedirectToAction("GetOrderData");
            
        }
    }
}
