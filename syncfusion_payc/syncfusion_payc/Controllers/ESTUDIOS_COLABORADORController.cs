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
    public class ESTUDIOS_COLABORADORController : Controller
    {
        private test_payc_contabilidadEntities db = new test_payc_contabilidadEntities();

        // GET: ESTUDIOS_COLABORADOR
        public ActionResult Index()
        {
            var eSTUDIOS_COLABORADOR = db.ESTUDIOS_COLABORADOR.Include(e => e.COLABORADORES);
            return View(eSTUDIOS_COLABORADOR.ToList());
        }

        // GET: ESTUDIOS_COLABORADOR/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ESTUDIOS_COLABORADOR eSTUDIOS_COLABORADOR = db.ESTUDIOS_COLABORADOR.Find(id);
            if (eSTUDIOS_COLABORADOR == null)
            {
                return HttpNotFound();
            }
            return View(eSTUDIOS_COLABORADOR);
        }

        // GET: ESTUDIOS_COLABORADOR/Create
        public ActionResult Create()
        {
            ViewBag.COD_COLABORADOR = new SelectList(db.COLABORADORES, "COD_COLABORADOR", "DESCRIPCION");
            return View();
        }

        // POST: ESTUDIOS_COLABORADOR/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COD_ESTUDIOS,COD_COLABORADOR,NIVEL_ESTUDIO,TITULO_ESTUDIO,FECHA_GRADO,INSTITUCION_GRADO")] ESTUDIOS_COLABORADOR eSTUDIOS_COLABORADOR)
        {
            if (ModelState.IsValid)
            {
                db.ESTUDIOS_COLABORADOR.Add(eSTUDIOS_COLABORADOR);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.COD_COLABORADOR = new SelectList(db.COLABORADORES, "COD_COLABORADOR", "DESCRIPCION", eSTUDIOS_COLABORADOR.COD_COLABORADOR);
            return View(eSTUDIOS_COLABORADOR);
        }

        // GET: ESTUDIOS_COLABORADOR/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ESTUDIOS_COLABORADOR eSTUDIOS_COLABORADOR = db.ESTUDIOS_COLABORADOR.Find(id);
            if (eSTUDIOS_COLABORADOR == null)
            {
                return HttpNotFound();
            }
            ViewBag.COD_COLABORADOR = new SelectList(db.COLABORADORES, "COD_COLABORADOR", "DESCRIPCION", eSTUDIOS_COLABORADOR.COD_COLABORADOR);
            return View(eSTUDIOS_COLABORADOR);
        }

        // POST: ESTUDIOS_COLABORADOR/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COD_ESTUDIOS,COD_COLABORADOR,NIVEL_ESTUDIO,TITULO_ESTUDIO,FECHA_GRADO,INSTITUCION_GRADO")] ESTUDIOS_COLABORADOR eSTUDIOS_COLABORADOR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eSTUDIOS_COLABORADOR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.COD_COLABORADOR = new SelectList(db.COLABORADORES, "COD_COLABORADOR", "DESCRIPCION", eSTUDIOS_COLABORADOR.COD_COLABORADOR);
            return View(eSTUDIOS_COLABORADOR);
        }

        // GET: ESTUDIOS_COLABORADOR/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ESTUDIOS_COLABORADOR eSTUDIOS_COLABORADOR = db.ESTUDIOS_COLABORADOR.Find(id);
            if (eSTUDIOS_COLABORADOR == null)
            {
                return HttpNotFound();
            }
            return View(eSTUDIOS_COLABORADOR);
        }

        // POST: ESTUDIOS_COLABORADOR/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            ESTUDIOS_COLABORADOR eSTUDIOS_COLABORADOR = db.ESTUDIOS_COLABORADOR.Find(id);
            db.ESTUDIOS_COLABORADOR.Remove(eSTUDIOS_COLABORADOR);
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
            var DataSource2 = db.ESTUDIOS_COLABORADOR.ToList();
            ViewBag.dataSource2 = DataSource2;
            return View();
        }	
		public ActionResult GetOrderData(DataManager dm)
        {
            IEnumerable DataSource = db.ESTUDIOS_COLABORADOR.ToList();
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
            var count = DataSource.Cast<ESTUDIOS_COLABORADOR>().Count();
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
        public ActionResult PerformInsert(EditParams_ESTUDIOS_COLABORADOR param)
        {
            db.ESTUDIOS_COLABORADOR.Add(param.value);
            db.SaveChanges();
			var data = db.ESTUDIOS_COLABORADOR.ToList();
			var value = data.Last();
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        //Actualizar grid
        public ActionResult PerformUpdate(EditParams_ESTUDIOS_COLABORADOR param)
        {
            
			ESTUDIOS_COLABORADOR table = db.ESTUDIOS_COLABORADOR.Single(o => o.COD_ESTUDIOS == param.value.COD_ESTUDIOS);

            db.Entry(table).CurrentValues.SetValues(param.value);
            db.SaveChanges();
			return RedirectToAction("GetOrderData");
			
        }

        //Borrar grid
        public ActionResult PerformDelete(int key, string keyColumn)
        {
            db.ESTUDIOS_COLABORADOR.Remove(db.ESTUDIOS_COLABORADOR.Single(o => o.COD_ESTUDIOS== key));
            db.SaveChanges();
            return RedirectToAction("GetOrderData");
            
        }
    }
}
