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
    public class PROYECTOSController : Controller
    {
        private test_payc_contabilidadEntities db = new test_payc_contabilidadEntities();

        // GET: PROYECTOS
        public ActionResult Index()
        {
            return View(db.PROYECTOS.ToList());
        }

        // GET: PROYECTOS/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PROYECTOS pROYECTOS = db.PROYECTOS.Find(id);
            if (pROYECTOS == null)
            {
                return HttpNotFound();
            }
            return View(pROYECTOS);
        }

        // GET: PROYECTOS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PROYECTOS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COD_PROYECTO,CENTRO_COSTOS,DESCRIPCION,AREA,PLAZO_PREVIA,FECHA_INI_PREVIA,PLAZO_OBRA,FECHA_INI_OBRA,PLAZO_LIQUIDACION,FECHA_INI_LIQUIDACION,ESTRUCTURA,CIMENTACION,SOTANOS,PISOS,VALOR_PROYECTO,TIPO_OBRA,DIRECCION,TIPO_SERVICIO")] PROYECTOS pROYECTOS)
        {
            if (ModelState.IsValid)
            {
                db.PROYECTOS.Add(pROYECTOS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pROYECTOS);
        }

        // GET: PROYECTOS/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PROYECTOS pROYECTOS = db.PROYECTOS.Find(id);
            if (pROYECTOS == null)
            {
                return HttpNotFound();
            }
            return View(pROYECTOS);
        }

        // POST: PROYECTOS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COD_PROYECTO,CENTRO_COSTOS,DESCRIPCION,AREA,PLAZO_PREVIA,FECHA_INI_PREVIA,PLAZO_OBRA,FECHA_INI_OBRA,PLAZO_LIQUIDACION,FECHA_INI_LIQUIDACION,ESTRUCTURA,CIMENTACION,SOTANOS,PISOS,VALOR_PROYECTO,TIPO_OBRA,DIRECCION,TIPO_SERVICIO")] PROYECTOS pROYECTOS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pROYECTOS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pROYECTOS);
        }

        // GET: PROYECTOS/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PROYECTOS pROYECTOS = db.PROYECTOS.Find(id);
            if (pROYECTOS == null)
            {
                return HttpNotFound();
            }
            return View(pROYECTOS);
        }

        // POST: PROYECTOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            PROYECTOS pROYECTOS = db.PROYECTOS.Find(id);
            db.PROYECTOS.Remove(pROYECTOS);
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
            var DataSource2 = db.PROYECTOS.ToList();
            ViewBag.dataSource2 = DataSource2;
            return View();
        }	
		public ActionResult GetOrderData(DataManager dm)
        {
            IEnumerable DataSource = db.PROYECTOS.ToList();
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
            var count = DataSource.Cast<PROYECTOS>().Count();
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
        public ActionResult PerformInsert(EditParams_PROYECTOS param)
        {
            db.PROYECTOS.Add(param.value);
            db.SaveChanges();
			var data = db.PROYECTOS.ToList();
			var value = data.Last();
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        //Actualizar grid
        public ActionResult PerformUpdate(EditParams_PROYECTOS param)
        {
            
			PROYECTOS table = db.PROYECTOS.Single(o => o.COD_PROYECTO == param.value.COD_PROYECTO);

            db.Entry(table).CurrentValues.SetValues(param.value);
            db.SaveChanges();
			return RedirectToAction("GetOrderData");
			
        }

        //Borrar grid
        public ActionResult PerformDelete(int key, string keyColumn)
        {
            db.PROYECTOS.Remove(db.PROYECTOS.Single(o => o.COD_PROYECTO== key));
            db.SaveChanges();
            return RedirectToAction("GetOrderData");
            
        }
    }
}
