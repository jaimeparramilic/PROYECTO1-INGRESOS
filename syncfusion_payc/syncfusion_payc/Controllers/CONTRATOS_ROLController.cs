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
    public class CONTRATOS_ROLController : Controller
    {
        private test_payc_contabilidadEntities db = new test_payc_contabilidadEntities();

        // GET: CONTRATOS_ROL
        public ActionResult Index()
        {
            var cONTRATOS_ROL = db.CONTRATOS_ROL.Include(c => c.CONTRATO_PROYECTO).Include(c => c.ROLES);
            return View(cONTRATOS_ROL.ToList());
        }

        // GET: CONTRATOS_ROL/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CONTRATOS_ROL cONTRATOS_ROL = db.CONTRATOS_ROL.Find(id);
            if (cONTRATOS_ROL == null)
            {
                return HttpNotFound();
            }
            return View(cONTRATOS_ROL);
        }

        // GET: CONTRATOS_ROL/Create
        public ActionResult Create()
        {
            ViewBag.COD_CONTRATO_PROYECTO = new SelectList(db.CONTRATO_PROYECTO, "COD_CONTRATO_PROYECTO", "COD_CONTRATO_PROYECTO");
            ViewBag.COD_ROL = new SelectList(db.ROLES, "COD_ROL", "DESCRIPCION");
            return View();
        }

        // POST: CONTRATOS_ROL/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COD_CONTRATO_ROL,COD_ROL,COD_CONTRATO_PROYECTO,FECHA_INI,MESES,VALOR_MENSUAL_SIN_PRESTACIONES,PRESTACIONES,VALOR_MENSUAL_PRESTACIONES,FACTOR_MULTIPLICADOR,VALOR_MENSUAL_PRESTACIONES_MULTIPLICADOR,DEDICACION,OBSERVACIONES")] CONTRATOS_ROL cONTRATOS_ROL)
        {
            if (ModelState.IsValid)
            {
                db.CONTRATOS_ROL.Add(cONTRATOS_ROL);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.COD_CONTRATO_PROYECTO = new SelectList(db.CONTRATO_PROYECTO, "COD_CONTRATO_PROYECTO", "COD_CONTRATO_PROYECTO", cONTRATOS_ROL.COD_CONTRATO_PROYECTO);
            ViewBag.COD_ROL = new SelectList(db.ROLES, "COD_ROL", "DESCRIPCION", cONTRATOS_ROL.COD_ROL);
            return View(cONTRATOS_ROL);
        }

        // GET: CONTRATOS_ROL/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CONTRATOS_ROL cONTRATOS_ROL = db.CONTRATOS_ROL.Find(id);
            if (cONTRATOS_ROL == null)
            {
                return HttpNotFound();
            }
            ViewBag.COD_CONTRATO_PROYECTO = new SelectList(db.CONTRATO_PROYECTO, "COD_CONTRATO_PROYECTO", "COD_CONTRATO_PROYECTO", cONTRATOS_ROL.COD_CONTRATO_PROYECTO);
            ViewBag.COD_ROL = new SelectList(db.ROLES, "COD_ROL", "DESCRIPCION", cONTRATOS_ROL.COD_ROL);
            return View(cONTRATOS_ROL);
        }

        // POST: CONTRATOS_ROL/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COD_CONTRATO_ROL,COD_ROL,COD_CONTRATO_PROYECTO,FECHA_INI,MESES,VALOR_MENSUAL_SIN_PRESTACIONES,PRESTACIONES,VALOR_MENSUAL_PRESTACIONES,FACTOR_MULTIPLICADOR,VALOR_MENSUAL_PRESTACIONES_MULTIPLICADOR,DEDICACION,OBSERVACIONES")] CONTRATOS_ROL cONTRATOS_ROL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cONTRATOS_ROL).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.COD_CONTRATO_PROYECTO = new SelectList(db.CONTRATO_PROYECTO, "COD_CONTRATO_PROYECTO", "COD_CONTRATO_PROYECTO", cONTRATOS_ROL.COD_CONTRATO_PROYECTO);
            ViewBag.COD_ROL = new SelectList(db.ROLES, "COD_ROL", "DESCRIPCION", cONTRATOS_ROL.COD_ROL);
            return View(cONTRATOS_ROL);
        }

        // GET: CONTRATOS_ROL/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CONTRATOS_ROL cONTRATOS_ROL = db.CONTRATOS_ROL.Find(id);
            if (cONTRATOS_ROL == null)
            {
                return HttpNotFound();
            }
            return View(cONTRATOS_ROL);
        }

        // POST: CONTRATOS_ROL/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            CONTRATOS_ROL cONTRATOS_ROL = db.CONTRATOS_ROL.Find(id);
            db.CONTRATOS_ROL.Remove(cONTRATOS_ROL);
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
            var DataSource2 = db.CONTRATOS_ROL.ToList();
            ViewBag.dataSource2 = DataSource2;
            return View();
        }	
		public ActionResult GetOrderData(DataManager dm)
        {
            IEnumerable DataSource = db.CONTRATOS_ROL.ToList();
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
            var count = DataSource.Cast<CONTRATOS_ROL>().Count();
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
        public ActionResult PerformInsert(EditParams_CONTRATOS_ROL param)
        {
            db.CONTRATOS_ROL.Add(param.value);
            db.SaveChanges();
			var data = db.CONTRATOS_ROL.ToList();
			var value = data.Last();
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        //Actualizar grid
        public ActionResult PerformUpdate(EditParams_CONTRATOS_ROL param)
        {
            
			CONTRATOS_ROL table = db.CONTRATOS_ROL.Single(o => o.COD_CONTRATO_ROL == param.value.COD_CONTRATO_ROL);

            db.Entry(table).CurrentValues.SetValues(param.value);
            db.SaveChanges();
			return RedirectToAction("GetOrderData");
			
        }

        //Borrar grid
        public ActionResult PerformDelete(int key, string keyColumn)
        {
            db.CONTRATOS_ROL.Remove(db.CONTRATOS_ROL.Single(o => o.COD_CONTRATO_ROL== key));
            db.SaveChanges();
            return RedirectToAction("GetOrderData");
            
        }
    }
}
