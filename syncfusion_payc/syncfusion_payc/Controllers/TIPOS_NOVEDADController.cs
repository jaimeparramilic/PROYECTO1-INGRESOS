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
    public class TIPOS_NOVEDADController : Controller
    {
        private test_payc_contabilidadEntities db = new test_payc_contabilidadEntities();

        // GET: TIPOS_NOVEDAD
        public ActionResult Index()
        {
            return View(db.TIPOS_NOVEDAD.ToList());
        }

        // GET: TIPOS_NOVEDAD/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPOS_NOVEDAD tIPOS_NOVEDAD = db.TIPOS_NOVEDAD.Find(id);
            if (tIPOS_NOVEDAD == null)
            {
                return HttpNotFound();
            }
            return View(tIPOS_NOVEDAD);
        }

        // GET: TIPOS_NOVEDAD/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TIPOS_NOVEDAD/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COD_TIPO_NOVEDAD,DESCRIPCION")] TIPOS_NOVEDAD tIPOS_NOVEDAD)
        {
            if (ModelState.IsValid)
            {
                db.TIPOS_NOVEDAD.Add(tIPOS_NOVEDAD);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tIPOS_NOVEDAD);
        }

        // GET: TIPOS_NOVEDAD/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPOS_NOVEDAD tIPOS_NOVEDAD = db.TIPOS_NOVEDAD.Find(id);
            if (tIPOS_NOVEDAD == null)
            {
                return HttpNotFound();
            }
            return View(tIPOS_NOVEDAD);
        }

        // POST: TIPOS_NOVEDAD/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COD_TIPO_NOVEDAD,DESCRIPCION")] TIPOS_NOVEDAD tIPOS_NOVEDAD)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tIPOS_NOVEDAD).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tIPOS_NOVEDAD);
        }

        // GET: TIPOS_NOVEDAD/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPOS_NOVEDAD tIPOS_NOVEDAD = db.TIPOS_NOVEDAD.Find(id);
            if (tIPOS_NOVEDAD == null)
            {
                return HttpNotFound();
            }
            return View(tIPOS_NOVEDAD);
        }

        // POST: TIPOS_NOVEDAD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            TIPOS_NOVEDAD tIPOS_NOVEDAD = db.TIPOS_NOVEDAD.Find(id);
            db.TIPOS_NOVEDAD.Remove(tIPOS_NOVEDAD);
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
            var DataSource2 = db.TIPOS_NOVEDAD.ToList();
            ViewBag.dataSource2 = DataSource2;
            return View();
        }	
		public ActionResult GetOrderData(DataManager dm)
        {
            IEnumerable DataSource = db.TIPOS_NOVEDAD.ToList();
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
            var count = DataSource.Cast<TIPOS_NOVEDAD>().Count();
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
        public ActionResult PerformInsert(EditParams_TIPOS_NOVEDAD param)
        {
            db.TIPOS_NOVEDAD.Add(param.value);
            db.SaveChanges();
			var data = db.TIPOS_NOVEDAD.ToList();
			var value = data.Last();
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        //Actualizar grid
        public ActionResult PerformUpdate(EditParams_TIPOS_NOVEDAD param)
        {
            
			TIPOS_NOVEDAD table = db.TIPOS_NOVEDAD.Single(o => o.COD_TIPO_NOVEDAD == param.value.COD_TIPO_NOVEDAD);

            db.Entry(table).CurrentValues.SetValues(param.value);
            db.SaveChanges();
			return RedirectToAction("GetOrderData");
			
        }

        //Borrar grid
        public ActionResult PerformDelete(int key, string keyColumn)
        {
            db.TIPOS_NOVEDAD.Remove(db.TIPOS_NOVEDAD.Single(o => o.COD_TIPO_NOVEDAD== key));
            db.SaveChanges();
            return RedirectToAction("GetOrderData");
            
        }
    }
}
