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
    public class ITEMS_ROLESController : Controller
    {
        private test_payc_contabilidadEntities db = new test_payc_contabilidadEntities();

        // GET: ITEMS_ROLES
        public ActionResult Index()
        {
            var iTEMS_ROLES = db.ITEMS_ROLES.Include(i => i.CONTRATO_PROYECTO);
            return View(iTEMS_ROLES.ToList());
        }

        // GET: ITEMS_ROLES/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ITEMS_ROLES iTEMS_ROLES = db.ITEMS_ROLES.Find(id);
            if (iTEMS_ROLES == null)
            {
                return HttpNotFound();
            }
            return View(iTEMS_ROLES);
        }

        // GET: ITEMS_ROLES/Create
        public ActionResult Create()
        {
            ViewBag.COD_CONTRATO_PROYECTO = new SelectList(db.CONTRATO_PROYECTO, "COD_CONTRATO_PROYECTO", "COMPLETA");
            ViewBag.COD_ITEM_CONTRATO = new SelectList(db.ITEMS, "COD_ITEM", "DESCRIPCION");
            ViewBag.COD_ROL = new SelectList(db.ROLES, "COD_ROL", "DESCRIPCION");
            return View();
        }

        // POST: ITEMS_ROLES/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COD_ITEM_ROL,COD_ITEM_CONTRATO,COD_ROL,COD_CONTRATO_PROYECTO")] ITEMS_ROLES iTEMS_ROLES)
        {
            if (ModelState.IsValid)
            {
                db.ITEMS_ROLES.Add(iTEMS_ROLES);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.COD_CONTRATO_PROYECTO = new SelectList(db.CONTRATO_PROYECTO, "COD_CONTRATO_PROYECTO", "COMPLETA", iTEMS_ROLES.COD_CONTRATO_PROYECTO);
            ViewBag.COD_ITEM_CONTRATO = new SelectList(db.ITEMS, "COD_ITEM", "DESCRIPCION", iTEMS_ROLES.COD_ITEM_CONTRATO);
            ViewBag.COD_ROL = new SelectList(db.ROLES, "COD_ROL", "DESCRIPCION", iTEMS_ROLES.COD_ROL);
            return View(iTEMS_ROLES);
        }

        // GET: ITEMS_ROLES/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ITEMS_ROLES iTEMS_ROLES = db.ITEMS_ROLES.Find(id);
            if (iTEMS_ROLES == null)
            {
                return HttpNotFound();
            }
            ViewBag.COD_CONTRATO_PROYECTO = new SelectList(db.CONTRATO_PROYECTO, "COD_CONTRATO_PROYECTO", "COMPLETA", iTEMS_ROLES.COD_CONTRATO_PROYECTO);
            ViewBag.COD_ITEM_CONTRATO = new SelectList(db.ITEMS, "COD_ITEM", "DESCRIPCION", iTEMS_ROLES.COD_ITEM_CONTRATO);
            ViewBag.COD_ROL = new SelectList(db.ROLES, "COD_ROL", "DESCRIPCION", iTEMS_ROLES.COD_ROL);
            return View(iTEMS_ROLES);
        }

        // POST: ITEMS_ROLES/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COD_ITEM_ROL,COD_ITEM_CONTRATO,COD_ROL,COD_CONTRATO_PROYECTO")] ITEMS_ROLES iTEMS_ROLES)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iTEMS_ROLES).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.COD_CONTRATO_PROYECTO = new SelectList(db.CONTRATO_PROYECTO, "COD_CONTRATO_PROYECTO", "COMPLETA", iTEMS_ROLES.COD_CONTRATO_PROYECTO);
            ViewBag.COD_ITEM_CONTRATO = new SelectList(db.ITEMS, "COD_ITEM", "DESCRIPCION", iTEMS_ROLES.COD_ITEM_CONTRATO);
            ViewBag.COD_ROL = new SelectList(db.ROLES, "COD_ROL", "DESCRIPCION", iTEMS_ROLES.COD_ROL);
            return View(iTEMS_ROLES);
        }

        // GET: ITEMS_ROLES/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ITEMS_ROLES iTEMS_ROLES = db.ITEMS_ROLES.Find(id);
            if (iTEMS_ROLES == null)
            {
                return HttpNotFound();
            }
            return View(iTEMS_ROLES);
        }

        // POST: ITEMS_ROLES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            ITEMS_ROLES iTEMS_ROLES = db.ITEMS_ROLES.Find(id);
            db.ITEMS_ROLES.Remove(iTEMS_ROLES);
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
            var DataSource2 = db.ITEMS_ROLES.ToList();
            ViewBag.dataSource2 = DataSource2;
            return View();
        }	

		public ActionResult GetOrderData(DataManager dm)
        {
            IEnumerable DataSource = db.ITEMS_ROLES.ToList();
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
            var count = DataSource.Cast<ITEMS_ROLES>().Count();
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
        public ActionResult PerformInsert(EditParams_ITEMS_ROLES param)
        {
            db.ITEMS_ROLES.Add(param.value);
            db.SaveChanges();
			var data = db.ITEMS_ROLES.ToList();
			var value = data.Last();
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        //Actualizar grid
        public ActionResult PerformUpdate(EditParams_ITEMS_ROLES param)
        {
            
			ITEMS_ROLES table = db.ITEMS_ROLES.Single(o => o.COD_ITEM_ROL == param.value.COD_ITEM_ROL);

            db.Entry(table).CurrentValues.SetValues(param.value);
            db.SaveChanges();
			return RedirectToAction("GetOrderData");
			
        }

        //Borrar grid
        public ActionResult PerformDelete(int key, string keyColumn)
        {
            db.ITEMS_ROLES.Remove(db.ITEMS_ROLES.Single(o => o.COD_ITEM_ROL== key));
            db.SaveChanges();
            return RedirectToAction("GetOrderData");
            
        }
    }
}
