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
        static string connectionString1 = ConfigurationManager.ConnectionStrings["DefaultConnection3"].ConnectionString;
        #region acciones default scaffolding
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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        #endregion
        #region acciones crear o cerrar centros de costos
        public ActionResult crear_centro_costo(long COD_CONTRATO_PROYECTO, string descrip_contrato,string CENTRO_COSTOS)
        {
           
            //Query para revisar que no exista el centor de costos
            string query = @"SELECT  [igecodigo] FROM [SSF_PAYC].[dbo].[co_ingeeleimp] " +
                @"           WHERE igecompania='01' AND igedivision='01' AND igecodigo = '" +CENTRO_COSTOS.ToString()+ @"'";

            string existececo = "NO";
            using (SqlConnection connection = new SqlConnection(connectionString1))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    existececo = dr.GetValue(0).ToString();
                }
                connection.Close();
            }
            bool success = true;
            if (existececo == "NO")
            {
                //Query para modificar estado del centro de costos
                string queryString = " UPDATE CONTRATO_PROYECTO SET "
                    + "COD_ESTADO_ORDEN_SERVICIO = 1 WHERE COD_CONTRATO_PROYECTO = "
                    + COD_CONTRATO_PROYECTO.ToString() + ";";

                //Ejecución del query
                using (SqlConnection connection = new SqlConnection(connecString))
                {
                    SqlCommand command = new SqlCommand(queryString, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                }

                //Query para insertar el centro de costos

                
                string query1 = @"INSERT INTO [SSF_PAYC].[dbo].[co_ingeeleimp] ([igecodigo]
                                  ,[igeidentificador]
                                  ,[igecompania]
                                  ,[igedivision]
                                  ,[igenombcort]
                                  ,[igenomblarg]
                                  ,[igeimpuesto]
                                  ,[eobcodigo]
                                  ,[eobnombre]
                                  ,[eobfecha]
                                  ,[eobusuario]
                                  ,[igedivisconta]
                                  ,[igecodalter]
                                  ,[igedesactivadepre]) 
	                              (SELECT [igecodigo]
                                  ,[igeidentificador]
                                  ,[igecompania]
                                  ,[igedivision]
								  ,case when len([igenombcort])>=30
									then left([igenombcort], 30) 
									else [igenombcort] end [igenombcort]
                                  ,case when len([igenomblarg])>=45
								  then left([igenomblarg], 45)
								  else [igenomblarg] end [igenomblarg]
                                  ,[igeimpuesto]
                                  ,[eobcodigo]
                                  ,[eobnombre]
                                  ,[eobfecha]
                                  ,[eobusuario]
                                  ,[igedivisconta]
                                  ,[igecodalter]
                                  ,[igedesactivadepre]
                              FROM [104.196.158.138].[test_payc_contabilidad].[dbo].[VISTA_INGEELIMP] WHERE COD_CONTRATO_PROYECTO=" + COD_CONTRATO_PROYECTO.ToString()+")";

                //Correr query
                using (SqlConnection connection = new SqlConnection(connectionString1))
                {
                    SqlCommand command = new SqlCommand(query1, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                }

                //Enviar correo avisando de la creación del centro de costo
                Email.EnviarEmail("smtp.gmail.com", 587, "centro.costo.estado.payc@gmail.com",
                    "1234payc", "centro.costo.estado.payc@gmail.com",
                    "director.analitica@payc.com.co", "Creación de nuevo centro de costo",
                    "La orden de servicio con centro de costos: " + CENTRO_COSTOS+
                    "-" + descrip_contrato
                    + ", fue creado");
            }
            else
            {
                //Query para modificar estado del centro de costos
                string queryString = " UPDATE CONTRATO_PROYECTO SET "
                    + "COD_ESTADO_ORDEN_SERVICIO = 1 WHERE COD_CONTRATO_PROYECTO = "
                    + COD_CONTRATO_PROYECTO.ToString() + ";";

                //Ejecución del query
                using (SqlConnection connection = new SqlConnection(connecString))
                {
                    SqlCommand command = new SqlCommand(queryString, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                }

                string query1 = " UPDATE [SSF_PAYC].[dbo].[co_ingeeleimp] SET eobnombre='Activo', eobcodigo='AC' WHERE igecodigo='" + CENTRO_COSTOS + "'";

                using (SqlConnection connection = new SqlConnection(connectionString1))
                {
                    SqlCommand command = new SqlCommand(query1, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                }

            }

            return Json(new { success = success, responseText = existececo }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult cerrar_centro_costo(long COD_CONTRATO_PROYECTO, string descrip_contrato, string CENTRO_COSTOS)
        {
            //DateTime hoy = DateTime.Today;
            string usuario = User.Identity.GetUserName();
            string queryString = " UPDATE CONTRATO_PROYECTO SET "
                + "COD_ESTADO_ORDEN_SERVICIO = 4 WHERE COD_CONTRATO_PROYECTO = "
                + COD_CONTRATO_PROYECTO.ToString() + ";";

            //Ejecución del query
            using (SqlConnection connection = new SqlConnection(connecString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                connection.Open();
                command.ExecuteNonQuery();
            }

            string result = "SI";
            bool success = true;
            //modificar centro de costos en PSL
            try
            {
                string query1 = " UPDATE [SSF_PAYC].[dbo].[co_ingeeleimp] SET eobnombre='Suspendido', eobcodigo='SU' WHERE igecodigo='" + CENTRO_COSTOS + "'";

                using (SqlConnection connection = new SqlConnection(connectionString1))
                {
                    SqlCommand command = new SqlCommand(query1, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch
            {
                result = "NO";
                success = false;
            }
            //Enviar correo avisando del CIERRE del centro de costo
            Email.EnviarEmail("smtp.gmail.com", 587, "centro.costo.estado.payc@gmail.com",
                "1234payc", "centro.costo.estado.payc@gmail.com",
                "director.analitica@payc.com.co", "CIERRE centro de costo",
                "El centro de costos con código: " + CENTRO_COSTOS +
                "-" + descrip_contrato
                + " se a sido cerrado");

            return Json(new { success = success, responseText = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
        #region acciones grid
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

            CONTRATO_PROYECTO table = db.CONTRATO_PROYECTO.Single(o => o.COD_CONTRATO_PROYECTO == param.value.COD_CONTRATO_PROYECTO);

            table.CENTRO_COSTOS = param.value.CENTRO_COSTOS;
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
        #endregion
    }
}
