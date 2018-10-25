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
using syncfusion_payc.Utilidades;
using System.Configuration;
using System.Data.SqlClient;
using Microsoft.AspNet.Identity;

namespace syncfusion_payc.Controllers
{
    public class VISTA_CARTERA_INDEXController : Controller
    {
        private test_payc_contabilidadEntities db = new test_payc_contabilidadEntities();
        static string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection1"].ConnectionString;
        // GET: VISTA_CARTERA_INDEX
        public ActionResult Index()
        {
            int ret = 0;
            string error = "";
            // Insertar facturas q falten en tabla CARTERA
            error = Utilidades.Cartera.IniciarCartera(out ret);
            
            return View(db.VISTA_CARTERA_INDEX.ToList());
        }

        public ActionResult Gestionar(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Insertar fila en tabla ASIGNACION_CARTERA
            // *** PENDIENTE validar que no exista ya para este COD_CARTERA
            int cod_ret = 0;
            VISTA_CARTERA_INDEX table = db.VISTA_CARTERA_INDEX.Single(o => o.COD_CONTRATO_PROYECTO == id);
            CONTRATO_PROYECTO cont_pro = db.CONTRATO_PROYECTO.Single(o => o.COD_CONTRATO_PROYECTO == id);
            CONTRATOS cont = db.CONTRATOS.Single(o => o.COD_CONTRATO == cont_pro.COD_CONTRATO);
            CLIENTES cliente = db.CLIENTES.Single(o => o.COD_CLIENTE == cont.COD_CLIENTE);

            ViewBag.CLIENTE = table.DESCRIPCION;
            ViewBag.CECO = table.CENTRO_COSTOS;
            ViewBag.COD_CONTRATO_PROYECTO = table.COD_CONTRATO_PROYECTO;
            ViewBag.CORREO_RESPONSABLE = cont_pro.CORREO_RESPONSABLE;
            ViewBag.TELEFONO_RESPONSABLE = cont_pro.TELEFONO_RESPONSABLE;
            ViewBag.TELEFONO_CLIENTE = cliente.TELEFONO_FACTURACION;
            ViewBag.CORREO_CLIENTE = cliente.CORREO_FACTURACION;
            ViewBag.UserName = table.GESTOR;
            return View();
        }

        // GET: VISTA_CARTERA_INDEX/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VISTA_CARTERA_INDEX vISTA_CARTERA_INDEX = db.VISTA_CARTERA_INDEX.Find(id);
            if (vISTA_CARTERA_INDEX == null)
            {
                return HttpNotFound();
            }
            return View(vISTA_CARTERA_INDEX);
        }

        // GET: VISTA_CARTERA_INDEX/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VISTA_CARTERA_INDEX/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COD_CLIENTE,DESCRIPCION,GESTOR,VALOR_SIN_IMPUESTOS,NUMERO_FACTURA,FECHA_FACTURA,ESTADO_CARTERA,RANKING,COD_FACTURA,COD_CARTERA")] VISTA_CARTERA_INDEX vISTA_CARTERA_INDEX)
        {
            if (ModelState.IsValid)
            {
                db.VISTA_CARTERA_INDEX.Add(vISTA_CARTERA_INDEX);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vISTA_CARTERA_INDEX);
        }

        // GET: VISTA_CARTERA_INDEX/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VISTA_CARTERA_INDEX vISTA_CARTERA_INDEX = db.VISTA_CARTERA_INDEX.Find(id);
            if (vISTA_CARTERA_INDEX == null)
            {
                return HttpNotFound();
            }
            return View(vISTA_CARTERA_INDEX);
        }

        // POST: VISTA_CARTERA_INDEX/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COD_CLIENTE,DESCRIPCION,GESTOR,VALOR_SIN_IMPUESTOS,NUMERO_FACTURA,FECHA_FACTURA,ESTADO_CARTERA,RANKING,COD_FACTURA,COD_CARTERA")] VISTA_CARTERA_INDEX vISTA_CARTERA_INDEX)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vISTA_CARTERA_INDEX).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vISTA_CARTERA_INDEX);
        }

        // GET: VISTA_CARTERA_INDEX/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VISTA_CARTERA_INDEX vISTA_CARTERA_INDEX = db.VISTA_CARTERA_INDEX.Find(id);
            if (vISTA_CARTERA_INDEX == null)
            {
                return HttpNotFound();
            }
            return View(vISTA_CARTERA_INDEX);
        }

        // POST: VISTA_CARTERA_INDEX/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            VISTA_CARTERA_INDEX vISTA_CARTERA_INDEX = db.VISTA_CARTERA_INDEX.Find(id);
            db.VISTA_CARTERA_INDEX.Remove(vISTA_CARTERA_INDEX);
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

		public ActionResult UrlAdaptor()
        {
            var DataSource2 = db.VISTA_CARTERA_INDEX.ToList();
            ViewBag.dataSource2 = DataSource2;
            return View();
        }	

		public ActionResult GetOrderData(DataManager dm)
        {
            IEnumerable DataSource = db.VISTA_CARTERA_INDEX.ToList();
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
            var count = DataSource.Cast<VISTA_CARTERA_INDEX>().Count();
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
        public ActionResult PerformInsert(EditParams_VISTA_CARTERA_INDEX param)
        {
            db.VISTA_CARTERA_INDEX.Add(param.value);
            db.SaveChanges();
			var data = db.VISTA_CARTERA_INDEX.ToList();
			var value = data.Last();
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        //Actualizar grid
        public ActionResult PerformUpdate(EditParams_VISTA_CARTERA_INDEX param)
        {    
            string query = "UPDATE [test_payc_contabilidad].dbo.CARTERA SET UserName='" + param.value.GESTOR + "' WHERE COD_FACTURA IN (SELECT COD_FACTURA FROM dbo.FACTURAS WHERE COD_CONTRATO_PROYECTO='"+ param.value.COD_CONTRATO_PROYECTO+ "')";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
            

            return RedirectToAction("GetOrderData");
			
        }

        //Borrar grid
        public ActionResult PerformDelete(int key, string keyColumn)
        {
            db.VISTA_CARTERA_INDEX.Remove(db.VISTA_CARTERA_INDEX.Single(o => o.COD_CLIENTE== key));
            db.SaveChanges();
            return RedirectToAction("GetOrderData");
            
        }
        //---------------------------------------------------
        // ASIGNACION_CARTERA
        public ActionResult UrlAdaptor_ASIGN_CART()
        {
            var DataSource2 = db.ASIGNACION_CARTERA.ToList();
            ViewBag.dataSource2 = DataSource2;
            return View();
        }

        public ActionResult GetOrderData_ASIGN_CART(DataManager dm)
        {
            IEnumerable DataSource = db.ASIGNACION_CARTERA.ToList();
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
            var count = DataSource.Cast<ASIGNACION_CARTERA>().Count();
            if (dm.Skip != 0)
            {
                DataSource = ds.PerformSkip(DataSource, dm.Skip);
            }
            if (dm.Take != 0)
            {
                DataSource = ds.PerformTake(DataSource, dm.Take);
            }
            return Json(new { result = DataSource, count = count }, JsonRequestBehavior.AllowGet);
        }

        //Perform file insertion 
        public ActionResult PerformInsert_ASIGN_CART(EditParams_ASIGNACION_CARTERA param)
        {
            db.ASIGNACION_CARTERA.Add(param.value);
            db.SaveChanges();
            var data = db.ASIGNACION_CARTERA.ToList();
            var value = data.Last();
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        //Actualizar grid
        public ActionResult PerformUpdate_ASIGN_CART(EditParams_ASIGNACION_CARTERA param)
        {

            ASIGNACION_CARTERA table = db.ASIGNACION_CARTERA.Single(o => o.COD_ASIGN_CARTERA == param.value.COD_ASIGN_CARTERA);

            db.Entry(table).CurrentValues.SetValues(param.value);
            db.SaveChanges();
            return RedirectToAction("GetOrderData");

        }

        //Borrar grid
        public ActionResult PerformDelete_ASIGN_CART(int key, string keyColumn)
        {
            db.ASIGNACION_CARTERA.Remove(db.ASIGNACION_CARTERA.Single(o => o.COD_ASIGN_CARTERA == key));
            db.SaveChanges();
            return RedirectToAction("GetOrderData");

        }

        //Función que genera el cuerpo del correo electrónico para el cliente
        public ActionResult traer_info_cliente(long COD_CONTRATO_PROYECTO)
        {

            //Traer codigo factura
            string query = @"SELECT * FROM [dbo].[VISTA_GESTION_CARTERA] WHERE COD_CONTRATO_PROYECTO='"+COD_CONTRATO_PROYECTO+"'";
            string result = "<p><table  ><tr><th style='border:solid 1px;'>NÚMERO FACTURA</th><th style='border:solid 1px;'>FECHA FACTURA</th><th style='border:solid 1px;'>VALOR FACTURA</th></tr>";
            string maxnumfac = "0";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    result = result + "<tr><td style='border:solid 1px;'>" + dr["NUMERO_FACTURA"].ToString() + "</td><td style='border:solid 1px;'>" + dr.GetDateTime(7).ToString("dd/MM/yyyy") + "</td><td style='border:solid 1px;'>" + String.Format("{0:c}", dr["VALOR_SIN_IMPUESTOS"]) +"</td></tr>";
                }
                connection.Close();
            }
            result = result + "</table></p>";
            return Json(new { success = true, responseText = result }, JsonRequestBehavior.AllowGet);
        }

        //Función que permite el envío de los correos asociados a la gestión de cartera
        public ActionResult enviar_correo_gestion(string CORREO, string HTML)
        {
            //Enviar correo avisando el envío de facturas
            try
            {
                Email.EnviarEmailHtml("smtp.gmail.com", 587, "centro.costo.estado.payc@gmail.com",
                "1234payc", "centro.costo.estado.payc@gmail.com",
                CORREO, "Facturas pendientes de pago - PAYC",
                 HTML);
                return Json(new { success = true, responseText = "Mensaje enviado exitosamente" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = true, responseText = "Ha ocurrido un error, por favor, vuelva a intentarlo. Si el problema persiste, contáctese con los administradores del sistema" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Función que registra las acciones de la gestión de cartera
        public ActionResult registrar_accion_gestion(long COD_CONTRATO_PROYECTO,long TIPO_GESTION,string DESCRIPCION)
        {
            //Almacenar accion de gestión
            try
            {
                string usuario = User.Identity.GetUserName();
                GESTION_CARTERA gest = new GESTION_CARTERA();
                gest.COD_CONTRATO_PROYECTO = COD_CONTRATO_PROYECTO;
                gest.DESCRIPCION = DESCRIPCION;
                gest.TIPO_GESTION = TIPO_GESTION;
                DateTime hoy = DateTime.Today;
                gest.UserName = usuario;
                gest.FECHA_GESTION = hoy;
                db.GESTION_CARTERA.Add(gest);
                db.SaveChanges();
                return Json(new { success = true, responseText = "Mensaje enviado exitosamente" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                
                return Json(new { success = true, responseText = "Ha ocurrido un error, por favor, vuelva a intentarlo. Si el problema persiste, contáctese con los administradores del sistema" }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}
