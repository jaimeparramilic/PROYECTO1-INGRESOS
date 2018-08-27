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
    public class ITEMS_CONTRATOController : Controller
    {
        private test_payc_contabilidadEntities db = new test_payc_contabilidadEntities();

        // GET: ITEMS_CONTRATO
        public ActionResult Index()
        {
            var iTEMS_CONTRATO = db.ITEMS_CONTRATO.Include(i => i.CONTRATO_PROYECTO);
            return View(iTEMS_CONTRATO.ToList());
        }

        // GET: ITEMS_CONTRATO/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ITEMS_CONTRATO iTEMS_CONTRATO = db.ITEMS_CONTRATO.Find(id);
            if (iTEMS_CONTRATO == null)
            {
                return HttpNotFound();
            }
            return View(iTEMS_CONTRATO);
        }

        // GET: ITEMS_CONTRATO/Create
        public ActionResult Create()
        {
            ViewBag.COD_CONTRATO_PROYECTO = new SelectList(db.CONTRATO_PROYECTO, "COD_CONTRATO_PROYECTO", "COD_CONTRATO_PROYECTO");
            return View();
        }

        // POST: ITEMS_CONTRATO/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COD_ITEM_CONTRATO,COD_CONTRATO_PROYECTO,DESCRIPCION,ITEM_REEMBOLZABLE,REUTILIZABLE,COSTO_INICIAL_UNITARIO,COSTO_MENSUAL_UNITARIO,CANTIDAD,FECHA_INI_USO,MESES_USO,OBSERVACIONES")] ITEMS_CONTRATO iTEMS_CONTRATO)
        {
            if (ModelState.IsValid)
            {
                db.ITEMS_CONTRATO.Add(iTEMS_CONTRATO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.COD_CONTRATO_PROYECTO = new SelectList(db.CONTRATO_PROYECTO, "COD_CONTRATO_PROYECTO", "COD_CONTRATO_PROYECTO", iTEMS_CONTRATO.COD_CONTRATO_PROYECTO);
            return View(iTEMS_CONTRATO);
        }

        // GET: ITEMS_CONTRATO/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ITEMS_CONTRATO iTEMS_CONTRATO = db.ITEMS_CONTRATO.Find(id);
            if (iTEMS_CONTRATO == null)
            {
                return HttpNotFound();
            }
            ViewBag.COD_CONTRATO_PROYECTO = new SelectList(db.CONTRATO_PROYECTO, "COD_CONTRATO_PROYECTO", "COD_CONTRATO_PROYECTO", iTEMS_CONTRATO.COD_CONTRATO_PROYECTO);
            return View(iTEMS_CONTRATO);
        }

        // POST: ITEMS_CONTRATO/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COD_ITEM_CONTRATO,COD_CONTRATO_PROYECTO,DESCRIPCION,ITEM_REEMBOLZABLE,REUTILIZABLE,COSTO_INICIAL_UNITARIO,COSTO_MENSUAL_UNITARIO,CANTIDAD,FECHA_INI_USO,MESES_USO,OBSERVACIONES")] ITEMS_CONTRATO iTEMS_CONTRATO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iTEMS_CONTRATO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.COD_CONTRATO_PROYECTO = new SelectList(db.CONTRATO_PROYECTO, "COD_CONTRATO_PROYECTO", "COD_CONTRATO_PROYECTO", iTEMS_CONTRATO.COD_CONTRATO_PROYECTO);
            return View(iTEMS_CONTRATO);
        }

        // GET: ITEMS_CONTRATO/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ITEMS_CONTRATO iTEMS_CONTRATO = db.ITEMS_CONTRATO.Find(id);
            if (iTEMS_CONTRATO == null)
            {
                return HttpNotFound();
            }
            return View(iTEMS_CONTRATO);
        }

        // POST: ITEMS_CONTRATO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            ITEMS_CONTRATO iTEMS_CONTRATO = db.ITEMS_CONTRATO.Find(id);
            db.ITEMS_CONTRATO.Remove(iTEMS_CONTRATO);
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
            var DataSource2 = db.ITEMS_CONTRATO.ToList();
            ViewBag.dataSource2 = DataSource2;
            return View();
        }	
		public ActionResult GetOrderData(DataManager dm)
        {
            IEnumerable DataSource = db.ITEMS_CONTRATO.ToList();
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
            var count = DataSource.Cast<ITEMS_CONTRATO>().Count();
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
        public ActionResult PerformInsert(EditParams_ITEMS_CONTRATO param)
        {
            db.ITEMS_CONTRATO.Add(param.value);
            db.SaveChanges();
			var data = db.ITEMS_CONTRATO.ToList();
			var value = data.Last();
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        //Actualizar grid
        public ActionResult PerformUpdate(EditParams_ITEMS_CONTRATO param)
        {
            
			ITEMS_CONTRATO table = db.ITEMS_CONTRATO.Single(o => o.COD_ITEM_CONTRATO == param.value.COD_ITEM_CONTRATO);

            db.Entry(table).CurrentValues.SetValues(param.value);
            db.SaveChanges();
			return RedirectToAction("GetOrderData");
			
        }

        //Borrar grid
        public ActionResult PerformDelete(int key, string keyColumn)
        {
            db.ITEMS_CONTRATO.Remove(db.ITEMS_CONTRATO.Single(o => o.COD_ITEM_CONTRATO== key));
            db.SaveChanges();
            return RedirectToAction("GetOrderData");
            
        }
    }
}
