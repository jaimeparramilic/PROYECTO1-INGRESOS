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
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.AspNet.Identity;
using syncfusion_payc.Utilidades;

namespace syncfusion_payc.Controllers
{
    public class VISTA_ORDENES_CENTRO_COSTOSController : Controller
    {
        private test_payc_contabilidadEntities db = new test_payc_contabilidadEntities();
        static string connecString = ConfigurationManager.ConnectionStrings["DefaultConnection1"].ConnectionString;

        // GET: VISTA_ORDENES_CENTRO_COSTOS
        public ActionResult Index()
        {
            return View(db.VISTA_ORDENES_CENTRO_COSTOS.ToList());
        }

        // GET: VISTA_ORDENES_CENTRO_COSTOS/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VISTA_ORDENES_CENTRO_COSTOS vISTA_ORDENES_CENTRO_COSTOS = db.VISTA_ORDENES_CENTRO_COSTOS.Find(id);
            if (vISTA_ORDENES_CENTRO_COSTOS == null)
            {
                return HttpNotFound();
            }
            return View(vISTA_ORDENES_CENTRO_COSTOS);
        }

        // GET: VISTA_ORDENES_CENTRO_COSTOS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VISTA_ORDENES_CENTRO_COSTOS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COD_CONTRATO_PROYECTO,COD_CONTRATO,COD_PROYECTO,COD_FORMA_PAGO,COMPLETA,MODIFICADO_POR,FECHA_ULTIMA_MODIFICACION,CREADO_POR,FECHA_CREACION,CENTRO_COSTOS,COD_ESTADO_ORDEN_SERVICIO,ESTADO_PSL,DESCRIPCION,FECHA_INICIO_EJECUCION, FECHA_FIN_EJECUCION, ESTADO_CENTRO_COSTO")] VISTA_ORDENES_CENTRO_COSTOS vISTA_ORDENES_CENTRO_COSTOS)
        {
            if (ModelState.IsValid)
            {
                db.VISTA_ORDENES_CENTRO_COSTOS.Add(vISTA_ORDENES_CENTRO_COSTOS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vISTA_ORDENES_CENTRO_COSTOS);
        }

        // GET: VISTA_ORDENES_CENTRO_COSTOS/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VISTA_ORDENES_CENTRO_COSTOS vISTA_ORDENES_CENTRO_COSTOS = db.VISTA_ORDENES_CENTRO_COSTOS.Find(id);
            if (vISTA_ORDENES_CENTRO_COSTOS == null)
            {
                return HttpNotFound();
            }
            return View(vISTA_ORDENES_CENTRO_COSTOS);
        }

        // POST: VISTA_ORDENES_CENTRO_COSTOS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COD_CONTRATO_PROYECTO,COD_CONTRATO,COD_PROYECTO,COD_FORMA_PAGO,COMPLETA,MODIFICADO_POR,FECHA_ULTIMA_MODIFICACION,CREADO_POR,FECHA_CREACION,CENTRO_COSTOS,COD_ESTADO_ORDEN_SERVICIO,ESTADO_PSL,DESCRIPCION,FECHA_INICIO_EJECUCION, FECHA_FIN_EJECUCION, ESTADO_CENTRO_COSTO")] VISTA_ORDENES_CENTRO_COSTOS vISTA_ORDENES_CENTRO_COSTOS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vISTA_ORDENES_CENTRO_COSTOS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vISTA_ORDENES_CENTRO_COSTOS);
        }

        // GET: VISTA_ORDENES_CENTRO_COSTOS/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VISTA_ORDENES_CENTRO_COSTOS vISTA_ORDENES_CENTRO_COSTOS = db.VISTA_ORDENES_CENTRO_COSTOS.Find(id);
            if (vISTA_ORDENES_CENTRO_COSTOS == null)
            {
                return HttpNotFound();
            }
            return View(vISTA_ORDENES_CENTRO_COSTOS);
        }

        // POST: VISTA_ORDENES_CENTRO_COSTOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            VISTA_ORDENES_CENTRO_COSTOS vISTA_ORDENES_CENTRO_COSTOS = db.VISTA_ORDENES_CENTRO_COSTOS.Find(id);
            db.VISTA_ORDENES_CENTRO_COSTOS.Remove(vISTA_ORDENES_CENTRO_COSTOS);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult crear_centro_costo(long COD_CONTRATO_PROYECTO, 
                                                string descrip_contrato)
        {
            //DateTime hoy = DateTime.Today;
            string usuario = User.Identity.GetUserName();
            string queryString = " UPDATE CONTRATO_PROYECTO SET "
                +"COD_ESTADO_ORDEN_SERVICIO = 1 WHERE COD_CONTRATO_PROYECTO = " 
                + COD_CONTRATO_PROYECTO.ToString() + ";";

            //Ejecución del query
            using (SqlConnection connection = new SqlConnection(connecString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                connection.Open();
                command.ExecuteNonQuery();
            }

            //Enviar correo avisando de la creación del centro de costo
            Email.EnviarEmail("smtp.gmail.com", 587, "centro.costo.estado.payc@gmail.com",
                "1234payc", "centro.costo.estado.payc@gmail.com",
                "desarrollo.analitica@payc.com.co", "Creación de nuevo centro de costo",
                "El contrato proyecto con código: " + COD_CONTRATO_PROYECTO +
                " "+ descrip_contrato
                +", fue actualizado en su estado de orden de servicio, como APROBADA");

            return Json(new { success = true, responseText = "SI" }, JsonRequestBehavior.AllowGet);
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
            var DataSource2 = db.VISTA_ORDENES_CENTRO_COSTOS.ToList();
            ViewBag.dataSource2 = DataSource2;
            return View();
        }	
		public ActionResult GetOrderData(DataManager dm)
        {
            IEnumerable DataSource = db.VISTA_ORDENES_CENTRO_COSTOS.ToList();
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
            var count = DataSource.Cast<VISTA_ORDENES_CENTRO_COSTOS>().Count();
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
        public ActionResult PerformInsert(EditParams_VISTA_ORDENES_CENTRO_COSTOS param)
        {
            db.VISTA_ORDENES_CENTRO_COSTOS.Add(param.value);
            db.SaveChanges();
			var data = db.VISTA_ORDENES_CENTRO_COSTOS.ToList();
			var value = data.Last();
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        //Actualizar grid
        public ActionResult PerformUpdate(EditParams_VISTA_ORDENES_CENTRO_COSTOS param)
        {
            
			VISTA_ORDENES_CENTRO_COSTOS table = db.VISTA_ORDENES_CENTRO_COSTOS.Single(o => o.COD_CONTRATO_PROYECTO == param.value.COD_CONTRATO_PROYECTO);

            db.Entry(table).CurrentValues.SetValues(param.value);
            db.SaveChanges();
			return RedirectToAction("GetOrderData");
			
        }

        //Borrar grid
        public ActionResult PerformDelete(int key, string keyColumn)
        {
            db.VISTA_ORDENES_CENTRO_COSTOS.Remove(db.VISTA_ORDENES_CENTRO_COSTOS.Single(o => o.COD_CONTRATO_PROYECTO== key));
            db.SaveChanges();
            return RedirectToAction("GetOrderData");
            
        }
    }
}
