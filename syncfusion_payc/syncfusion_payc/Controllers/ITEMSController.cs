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
    public class ITEMSController : Controller
    {
        private test_payc_contabilidadEntities db = new test_payc_contabilidadEntities();

        // GET: ITEMS
        public ActionResult Index()
        {
            return View(db.ITEMS.ToList());
        }

        // GET: ITEMS/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ITEMS iTEMS = db.ITEMS.Find(id);
            if (iTEMS == null)
            {
                return HttpNotFound();
            }
            return View(iTEMS);
        }

        // GET: ITEMS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ITEMS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COD_ITEM,DESCRIPCION")] ITEMS iTEMS)
        {
            if (ModelState.IsValid)
            {
                db.ITEMS.Add(iTEMS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(iTEMS);
        }

        // GET: ITEMS/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ITEMS iTEMS = db.ITEMS.Find(id);
            if (iTEMS == null)
            {
                return HttpNotFound();
            }
            return View(iTEMS);
        }

        // POST: ITEMS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COD_ITEM,DESCRIPCION")] ITEMS iTEMS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iTEMS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(iTEMS);
        }

        // GET: ITEMS/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ITEMS iTEMS = db.ITEMS.Find(id);
            if (iTEMS == null)
            {
                return HttpNotFound();
            }
            return View(iTEMS);
        }

        // POST: ITEMS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            ITEMS iTEMS = db.ITEMS.Find(id);
            db.ITEMS.Remove(iTEMS);
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
            var DataSource2 = db.ITEMS.ToList();
            ViewBag.dataSource2 = DataSource2;
            return View();
        }	
		public ActionResult GetOrderData(DataManager dm)
        {
            IEnumerable DataSource = db.ITEMS.ToList();
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
            var count = DataSource.Cast<ITEMS>().Count();
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
        public ActionResult PerformInsert(EditParams_ITEMS param)
        {
            db.ITEMS.Add(param.value);
            db.SaveChanges();
			var data = db.ITEMS.ToList();
			var value = data.Last();
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        //Actualizar grid
        public ActionResult PerformUpdate(EditParams_ITEMS param)
        {
            
			ITEMS table = db.ITEMS.Single(o => o.COD_ITEM == param.value.COD_ITEM);

            db.Entry(table).CurrentValues.SetValues(param.value);
            db.SaveChanges();
			return RedirectToAction("GetOrderData");
			
        }

        //Borrar grid
        public ActionResult PerformDelete(int key, string keyColumn)
        {
            db.ITEMS.Remove(db.ITEMS.Single(o => o.COD_ITEM== key));
            db.SaveChanges();
            return RedirectToAction("GetOrderData");
            
        }
    }
}
