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
    public class GESTION_CARTERAController : Controller
    {
        private test_payc_contabilidadEntities db = new test_payc_contabilidadEntities();

        // GET: GESTION_CARTERA
        public ActionResult Index()
        {
            var gESTION_CARTERA = db.GESTION_CARTERA.Include(g => g.TIPOS_GESTION).Include(g => g.CARTERA);
            return View(gESTION_CARTERA.ToList());
        }

        // GET: GESTION_CARTERA/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GESTION_CARTERA gESTION_CARTERA = db.GESTION_CARTERA.Find(id);
            if (gESTION_CARTERA == null)
            {
                return HttpNotFound();
            }
            return View(gESTION_CARTERA);
        }

        // GET: GESTION_CARTERA/Create
        public ActionResult Create()
        {
            ViewBag.TIPO_GESTION = new SelectList(db.TIPOS_GESTION, "COD_TIPO_GESTION", "DESCRIPCION");
            ViewBag.COD_CARTERA = new SelectList(db.CARTERA, "COD_CARTERA", "UserName");
            return View();
        }

        // POST: GESTION_CARTERA/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COD_GESTION,COD_CARTERA,UserName,TIPO_GESTION,FECHA_GESTION,DESCRIPCION")] GESTION_CARTERA gESTION_CARTERA)
        {
            if (ModelState.IsValid)
            {
                db.GESTION_CARTERA.Add(gESTION_CARTERA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TIPO_GESTION = new SelectList(db.TIPOS_GESTION, "COD_TIPO_GESTION", "DESCRIPCION", gESTION_CARTERA.TIPO_GESTION);
            ViewBag.COD_CARTERA = new SelectList(db.CARTERA, "COD_CARTERA", "UserName", gESTION_CARTERA.COD_CARTERA);
            return View(gESTION_CARTERA);
        }

        // GET: GESTION_CARTERA/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GESTION_CARTERA gESTION_CARTERA = db.GESTION_CARTERA.Find(id);
            if (gESTION_CARTERA == null)
            {
                return HttpNotFound();
            }
            ViewBag.TIPO_GESTION = new SelectList(db.TIPOS_GESTION, "COD_TIPO_GESTION", "DESCRIPCION", gESTION_CARTERA.TIPO_GESTION);
            ViewBag.COD_CARTERA = new SelectList(db.CARTERA, "COD_CARTERA", "UserName", gESTION_CARTERA.COD_CARTERA);
            return View(gESTION_CARTERA);
        }

        // POST: GESTION_CARTERA/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COD_GESTION,COD_CARTERA,UserName,TIPO_GESTION,FECHA_GESTION,DESCRIPCION")] GESTION_CARTERA gESTION_CARTERA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gESTION_CARTERA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TIPO_GESTION = new SelectList(db.TIPOS_GESTION, "COD_TIPO_GESTION", "DESCRIPCION", gESTION_CARTERA.TIPO_GESTION);
            ViewBag.COD_CARTERA = new SelectList(db.CARTERA, "COD_CARTERA", "UserName", gESTION_CARTERA.COD_CARTERA);
            return View(gESTION_CARTERA);
        }

        // GET: GESTION_CARTERA/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GESTION_CARTERA gESTION_CARTERA = db.GESTION_CARTERA.Find(id);
            if (gESTION_CARTERA == null)
            {
                return HttpNotFound();
            }
            return View(gESTION_CARTERA);
        }

        // POST: GESTION_CARTERA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            GESTION_CARTERA gESTION_CARTERA = db.GESTION_CARTERA.Find(id);
            db.GESTION_CARTERA.Remove(gESTION_CARTERA);
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
            var DataSource2 = db.GESTION_CARTERA.ToList();
            ViewBag.dataSource2 = DataSource2;
            return View();
        }	
		public ActionResult GetOrderData(DataManager dm)
        {
            IEnumerable DataSource = db.GESTION_CARTERA.ToList();
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
            var count = DataSource.Cast<GESTION_CARTERA>().Count();
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
        public ActionResult PerformInsert(EditParams_GESTION_CARTERA param)
        {
            db.GESTION_CARTERA.Add(param.value);
            db.SaveChanges();
			var data = db.GESTION_CARTERA.ToList();
			var value = data.Last();
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        //Actualizar grid
        public ActionResult PerformUpdate(EditParams_GESTION_CARTERA param)
        {
            
			GESTION_CARTERA table = db.GESTION_CARTERA.Single(o => o.COD_GESTION == param.value.COD_GESTION);

            db.Entry(table).CurrentValues.SetValues(param.value);
            db.SaveChanges();
			return RedirectToAction("GetOrderData");
			
        }

        //Borrar grid
        public ActionResult PerformDelete(int key, string keyColumn)
        {
            db.GESTION_CARTERA.Remove(db.GESTION_CARTERA.Single(o => o.COD_GESTION== key));
            db.SaveChanges();
            return RedirectToAction("GetOrderData");
            
        }
    }
}
