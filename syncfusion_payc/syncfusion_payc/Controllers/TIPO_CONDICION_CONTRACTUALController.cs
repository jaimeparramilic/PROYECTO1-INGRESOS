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
    public class TIPO_CONDICION_CONTRACTUALController : Controller
    {
        private test_payc_contabilidadEntities db = new test_payc_contabilidadEntities();

        // GET: TIPO_CONDICION_CONTRACTUAL
        public ActionResult Index()
        {
            return View(db.TIPO_CONDICION_CONTRACTUAL.ToList());
        }

        // GET: TIPO_CONDICION_CONTRACTUAL/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPO_CONDICION_CONTRACTUAL tIPO_CONDICION_CONTRACTUAL = db.TIPO_CONDICION_CONTRACTUAL.Find(id);
            if (tIPO_CONDICION_CONTRACTUAL == null)
            {
                return HttpNotFound();
            }
            return View(tIPO_CONDICION_CONTRACTUAL);
        }

        // GET: TIPO_CONDICION_CONTRACTUAL/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TIPO_CONDICION_CONTRACTUAL/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COD_TIPO_CONDICION,DESCRIPCION")] TIPO_CONDICION_CONTRACTUAL tIPO_CONDICION_CONTRACTUAL)
        {
            if (ModelState.IsValid)
            {
                db.TIPO_CONDICION_CONTRACTUAL.Add(tIPO_CONDICION_CONTRACTUAL);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tIPO_CONDICION_CONTRACTUAL);
        }

        // GET: TIPO_CONDICION_CONTRACTUAL/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPO_CONDICION_CONTRACTUAL tIPO_CONDICION_CONTRACTUAL = db.TIPO_CONDICION_CONTRACTUAL.Find(id);
            if (tIPO_CONDICION_CONTRACTUAL == null)
            {
                return HttpNotFound();
            }
            return View(tIPO_CONDICION_CONTRACTUAL);
        }

        // POST: TIPO_CONDICION_CONTRACTUAL/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COD_TIPO_CONDICION,DESCRIPCION")] TIPO_CONDICION_CONTRACTUAL tIPO_CONDICION_CONTRACTUAL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tIPO_CONDICION_CONTRACTUAL).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tIPO_CONDICION_CONTRACTUAL);
        }

        // GET: TIPO_CONDICION_CONTRACTUAL/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPO_CONDICION_CONTRACTUAL tIPO_CONDICION_CONTRACTUAL = db.TIPO_CONDICION_CONTRACTUAL.Find(id);
            if (tIPO_CONDICION_CONTRACTUAL == null)
            {
                return HttpNotFound();
            }
            return View(tIPO_CONDICION_CONTRACTUAL);
        }

        // POST: TIPO_CONDICION_CONTRACTUAL/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            TIPO_CONDICION_CONTRACTUAL tIPO_CONDICION_CONTRACTUAL = db.TIPO_CONDICION_CONTRACTUAL.Find(id);
            db.TIPO_CONDICION_CONTRACTUAL.Remove(tIPO_CONDICION_CONTRACTUAL);
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
            var DataSource2 = db.TIPO_CONDICION_CONTRACTUAL.ToList();
            ViewBag.dataSource2 = DataSource2;
            return View();
        }	
		public ActionResult GetOrderData(DataManager dm)
        {
            IEnumerable DataSource = db.TIPO_CONDICION_CONTRACTUAL.ToList();
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
            var count = DataSource.Cast<TIPO_CONDICION_CONTRACTUAL>().Count();
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
        public ActionResult PerformInsert(EditParams_TIPO_CONDICION_CONTRACTUAL param)
        {
            db.TIPO_CONDICION_CONTRACTUAL.Add(param.value);
            db.SaveChanges();
			var data = db.TIPO_CONDICION_CONTRACTUAL.ToList();
			var value = data.Last();
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        //Actualizar grid
        public ActionResult PerformUpdate(EditParams_TIPO_CONDICION_CONTRACTUAL param)
        {
            
			TIPO_CONDICION_CONTRACTUAL table = db.TIPO_CONDICION_CONTRACTUAL.Single(o => o.COD_TIPO_CONDICION == param.value.COD_TIPO_CONDICION);

            db.Entry(table).CurrentValues.SetValues(param.value);
            db.SaveChanges();
			return RedirectToAction("GetOrderData");
			
        }

        //Borrar grid
        public ActionResult PerformDelete(int key, string keyColumn)
        {
            db.TIPO_CONDICION_CONTRACTUAL.Remove(db.TIPO_CONDICION_CONTRACTUAL.Single(o => o.COD_TIPO_CONDICION== key));
            db.SaveChanges();
            return RedirectToAction("GetOrderData");
            
        }
    }
}
