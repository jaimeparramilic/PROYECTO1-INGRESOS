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
using syncfusion_payc.Utilidades;

namespace syncfusion_payc.Controllers
{
    public class CENTROS_COSTOSController : Controller
    {
        private test_payc_contabilidadEntities db = new test_payc_contabilidadEntities();

        // GET: CENTROS_COSTOS
        public ActionResult Index()
        {
            var cENTROS_COSTOS = db.CENTROS_COSTOS.Include(c => c.ESTADOS_CECO);
            return View(cENTROS_COSTOS.ToList());
        }

        // GET: CENTROS_COSTOS/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CENTROS_COSTOS cENTROS_COSTOS = db.CENTROS_COSTOS.Find(id);
            if (cENTROS_COSTOS == null)
            {
                return HttpNotFound();
            }
            return View(cENTROS_COSTOS);
        }

        // GET: CENTROS_COSTOS/Create
        public ActionResult Create()
        {
            ViewBag.COD_ESTADO_CECO = new SelectList(db.ESTADOS_CECO, "COD_ESTADO_CECO", "DESCRIPCION");
            return View();
        }

        // POST: CENTROS_COSTOS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COD_CECO,CECO_PSL,DESCRIPCION,COD_ESTADO_CECO")] CENTROS_COSTOS cENTROS_COSTOS)
        {
            if (ModelState.IsValid)
            {
                db.CENTROS_COSTOS.Add(cENTROS_COSTOS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.COD_ESTADO_CECO = new SelectList(db.ESTADOS_CECO, "COD_ESTADO_CECO", "DESCRIPCION", cENTROS_COSTOS.COD_ESTADO_CECO);
            return View(cENTROS_COSTOS);
        }

        // GET: CENTROS_COSTOS/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CENTROS_COSTOS cENTROS_COSTOS = db.CENTROS_COSTOS.Find(id);
            if (cENTROS_COSTOS == null)
            {
                return HttpNotFound();
            }
            ViewBag.COD_ESTADO_CECO = new SelectList(db.ESTADOS_CECO, "COD_ESTADO_CECO", "DESCRIPCION", cENTROS_COSTOS.COD_ESTADO_CECO);
            return View(cENTROS_COSTOS);
        }

        // POST: CENTROS_COSTOS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COD_CECO,CECO_PSL,DESCRIPCION,COD_ESTADO_CECO")] CENTROS_COSTOS cENTROS_COSTOS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cENTROS_COSTOS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.COD_ESTADO_CECO = new SelectList(db.ESTADOS_CECO, "COD_ESTADO_CECO", "DESCRIPCION", cENTROS_COSTOS.COD_ESTADO_CECO);
            return View(cENTROS_COSTOS);
        }

        // GET: CENTROS_COSTOS/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CENTROS_COSTOS cENTROS_COSTOS = db.CENTROS_COSTOS.Find(id);
            if (cENTROS_COSTOS == null)
            {
                return HttpNotFound();
            }
            return View(cENTROS_COSTOS);
        }

        // POST: CENTROS_COSTOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            CENTROS_COSTOS cENTROS_COSTOS = db.CENTROS_COSTOS.Find(id);
            db.CENTROS_COSTOS.Remove(cENTROS_COSTOS);
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
            var DataSource2 = db.CENTROS_COSTOS.ToList();
            ViewBag.dataSource2 = DataSource2;
            return View();
        }	
		public ActionResult GetOrderData(DataManager dm)
        {
            IEnumerable DataSource = db.CENTROS_COSTOS.ToList();
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
            var count = DataSource.Cast<CENTROS_COSTOS>().Count();
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
        public ActionResult PerformInsert(EditParams_CENTROS_COSTOS param)
        {
            db.CENTROS_COSTOS.Add(param.value);
            db.SaveChanges();
			var data = db.CENTROS_COSTOS.ToList();
			var value = data.Last();
            // Enviar correo avisando de la creación del centro de costo
            //string nombre = ConsultaSQL.NombreEstadoCentroCosto(Convert.ToInt32(param.value.COD_ESTADO_CECO));
            //Email.EnviarEmail("smtp.gmail.com", 587, "centro.costo.estado.payc@gmail.com",
            //    "1234payc", "centro.costo.estado.payc@gmail.com",
            //    "desarrollo.analitica@payc.com.co", "Creación de nuevo centro de costo",
            //    "El centro de costo: "+ param.value.DESCRIPCION + 
            //    ", fue creado en la aplicación del proyecto de articulación nómina-facturación-cartera: " +
            //    "IntegrApp, con estado: "+ nombre);

            return Json(value, JsonRequestBehavior.AllowGet);
        }

        //Actualizar grid
        public ActionResult PerformUpdate(EditParams_CENTROS_COSTOS param)
        {
            
			CENTROS_COSTOS table = db.CENTROS_COSTOS.Single(o => o.COD_CECO == param.value.COD_CECO);

            db.Entry(table).CurrentValues.SetValues(param.value);
            db.SaveChanges();
			return RedirectToAction("GetOrderData");
			
        }

        //Borrar grid
        public ActionResult PerformDelete(int key, string keyColumn)
        {
            db.CENTROS_COSTOS.Remove(db.CENTROS_COSTOS.Single(o => o.COD_CECO== key));
            db.SaveChanges();
            return RedirectToAction("GetOrderData");
            
        }
    }
}
