using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.ComponentModel;
using System.Web;
using System.Web.Mvc;
using Syncfusion.JavaScript;
using Syncfusion.JavaScript.DataSources;
using System.Data.Entity;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Syncfusion.Linq;
using Syncfusion.Compression;
using Syncfusion.DocIO;
using Syncfusion.XlsIO;
using Syncfusion.JavaScript.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Syncfusion.EJ.Export;
using Syncfusion.XlsIO;
using Syncfusion.EJ.Export;
using System.Web;
using syncfusion_payc.Models;
using System.IO;
using System.Drawing;
using System.Globalization;
using Microsoft.AspNet.Identity;
using System.Data.SqlClient;
using System.Configuration;

namespace syncfusion_payc.Controllers
{
    public class VISTA_DETALLE_ADJUNTOS_PERSController : Controller
    {
        private test_payc_contabilidadEntities db = new test_payc_contabilidadEntities();
        static string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection1"].ConnectionString;
        #region acciones vistas base
        // GET: VISTA_DETALLE_ADJUNTOS_PERS
        public ActionResult Index()
        {
            return View(db.VISTA_DETALLE_ADJUNTOS_PERS.ToList());
        }

        // GET: VISTA_DETALLE_ADJUNTOS_PERS/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VISTA_DETALLE_ADJUNTOS_PERS vISTA_DETALLE_ADJUNTOS_PERS = db.VISTA_DETALLE_ADJUNTOS_PERS.Find(id);
            if (vISTA_DETALLE_ADJUNTOS_PERS == null)
            {
                return HttpNotFound();
            }
            return View(vISTA_DETALLE_ADJUNTOS_PERS);
        }

        // GET: VISTA_DETALLE_ADJUNTOS_PERS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VISTA_DETALLE_ADJUNTOS_PERS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,COD_DETALLE_FACTURA_ADJUNTO_PERS,COD_CONTRATO_PROYECTO,COD_ROL,COD_COLABORADOR,COD_FORMAS_PAGO_FECHAS,FECHA_REGISTRO,USUARIO,COD_ESTADO_FACTURA,COD_CAUSA_ESTADO,OBSERVACIONES,COD_FACTURA,COD_ESTADO_DETALLE,COD_CONCEPTO_PSL,COD_GRUPO_FACTURA,HORAS_ED,HORAS_EN,HORAS_FD,HORAS_FN,ADICIONES,HORAS_AUSENCIA,DESCUENTO_AUSENCIA,FECHA_INI,FECHA_FIN,VALOR_DIAS_LAB,VALOR_SIN_IMPUESTOS,NOMBRES,APELLIDOS,CEDULA,FECHA_FORMA_PAGO,NOMBRE_PROYECTO,CENTRO_COSTOS,NOMBRE_ROL,FECHA_INICIO_EJECUCION,FECHA_FIN_EJECUCION")] VISTA_DETALLE_ADJUNTOS_PERS vISTA_DETALLE_ADJUNTOS_PERS)
        {
            if (ModelState.IsValid)
            {
                db.VISTA_DETALLE_ADJUNTOS_PERS.Add(vISTA_DETALLE_ADJUNTOS_PERS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vISTA_DETALLE_ADJUNTOS_PERS);
        }

        // GET: VISTA_DETALLE_ADJUNTOS_PERS/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VISTA_DETALLE_ADJUNTOS_PERS vISTA_DETALLE_ADJUNTOS_PERS = db.VISTA_DETALLE_ADJUNTOS_PERS.Find(id);
            if (vISTA_DETALLE_ADJUNTOS_PERS == null)
            {
                return HttpNotFound();
            }
            return View(vISTA_DETALLE_ADJUNTOS_PERS);
        }

        // POST: VISTA_DETALLE_ADJUNTOS_PERS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,COD_DETALLE_FACTURA_ADJUNTO_PERS,COD_CONTRATO_PROYECTO,COD_ROL,COD_COLABORADOR,COD_FORMAS_PAGO_FECHAS,FECHA_REGISTRO,USUARIO,COD_ESTADO_FACTURA,COD_CAUSA_ESTADO,OBSERVACIONES,COD_FACTURA,COD_ESTADO_DETALLE,COD_CONCEPTO_PSL,COD_GRUPO_FACTURA,HORAS_ED,HORAS_EN,HORAS_FD,HORAS_FN,ADICIONES,HORAS_AUSENCIA,DESCUENTO_AUSENCIA,FECHA_INI,FECHA_FIN,VALOR_DIAS_LAB,VALOR_SIN_IMPUESTOS,NOMBRES,APELLIDOS,CEDULA,FECHA_FORMA_PAGO,NOMBRE_PROYECTO,CENTRO_COSTOS,NOMBRE_ROL,FECHA_INICIO_EJECUCION,FECHA_FIN_EJECUCION")] VISTA_DETALLE_ADJUNTOS_PERS vISTA_DETALLE_ADJUNTOS_PERS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vISTA_DETALLE_ADJUNTOS_PERS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vISTA_DETALLE_ADJUNTOS_PERS);
        }

        // GET: VISTA_DETALLE_ADJUNTOS_PERS/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VISTA_DETALLE_ADJUNTOS_PERS vISTA_DETALLE_ADJUNTOS_PERS = db.VISTA_DETALLE_ADJUNTOS_PERS.Find(id);
            if (vISTA_DETALLE_ADJUNTOS_PERS == null)
            {
                return HttpNotFound();
            }
            return View(vISTA_DETALLE_ADJUNTOS_PERS);
        }

        // POST: VISTA_DETALLE_ADJUNTOS_PERS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            VISTA_DETALLE_ADJUNTOS_PERS vISTA_DETALLE_ADJUNTOS_PERS = db.VISTA_DETALLE_ADJUNTOS_PERS.Find(id);
            db.VISTA_DETALLE_ADJUNTOS_PERS.Remove(vISTA_DETALLE_ADJUNTOS_PERS);
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
        #region grids
        //Aca inicia syncfusion

        //Traer data
        public ActionResult UrlAdaptor()
        {
            var DataSource2 = db.VISTA_DETALLE_ADJUNTOS_PERS.ToList();
            ViewBag.dataSource2 = DataSource2;
            return View();
        }	
		public ActionResult GetOrderData(DataManager dm)
        {
            IEnumerable DataSource = db.VISTA_DETALLE_ADJUNTOS_PERS.ToList();
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
            var count = DataSource.Cast<VISTA_DETALLE_ADJUNTOS_PERS>().Count();
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
        //public ActionResult PerformInsert(EditParams_DETALLE_FACTURA_PERS param) // lo comenté porque croe que me estaba equivocando al traer un objeto parametro del tipo detalle factura pers.....creo que está bien con el de vista detalle adjunto pers por lo que en él esta toda la info y a aprtir de ese objeto crear uno del tipo detalle factura para realizar el insert en esa taba tambien
        public ActionResult PerformInsert(EditParams_VISTA_DETALLE_ADJUNTOS_PERS param)
        {
            if (param.value.COD_DETALLE_FACTURA_ADJUNTO_PERS != 0) { 

                long estado_modificado = 2; //Se actualiza a 2 el 20190524 porque el 2 ya es modificado////Este es el estado EDITADO MANUALMENTE con el que se identifica un registro que es editado y por lo tanto al ser un registro editado manualmente para nuestro registro quedará eliminado (con esta flag de este estado) y se ingresará el edit como un registro nuevo con estado COD_ESTADO_DETALLE=4: REGISTRO MANUAL
                DETALLE_FACTURA_ADJUNTO_PERS selected_detalle_factura_adjunto_pers = db.DETALLE_FACTURA_ADJUNTO_PERS.Single(o => o.COD_DETALLE_FACTURA_ADJUNTO_PERS == param.value.COD_DETALLE_FACTURA_ADJUNTO_PERS);
                selected_detalle_factura_adjunto_pers.COD_ESTADO_DETALLE = estado_modificado;
                db.SaveChanges();
                //EDICIÓN DE LA TABLA DETALLE_FACTURA_PERS
                //PARA LA TABLA DETALLE_FACTURA_PERS hay que tener en cuenta que el registro enviado (desde la grid ROLES de la vista verificar con la acción edit+save)envía parametro tipo VISTA_DETALLE_ADJUNTOS_PERS y este no tiene entre sus campos el COD_DETALLE_FACTURA_PERS por lo que no es posible identificarlo con su identificador único entonces se revisa si buscar con la concatenación de detalle_factura cod_contrato_proyecto valor_sin_impuestos cod_rol fecha_registro  y cod_concepto_psl (la concatenación de todas estas columnas para garantizar que es exactamente el mismo registro)
                //DETALLE_FACTURA_PERS selected_detalle_factura_pers = db.DETALLE_FACTURA_PERS.Single(o => o.COD_DETALLE_FACTURA_PERS == param.value. ); // COMENTADO PORQUE SE OBSERVA QUE LA VISTA VISTA_DETALLE_ADJUNTOS_PERS NO ENVIA OMO PARAMETRO EL COD_DETALLE_FACTURA_PERS (ENVIA EL COD_DETALLE_FAVTURA_ADJUNTO_PERS MAS NO EL NO ADJUNTO)
                //db.SaveChanges();

            }


            db.Configuration.ProxyCreationEnabled = false;
            db.Configuration.LazyLoadingEnabled = false;
            DateTime hoy = DateTime.Today;
            string usuario = User.Identity.GetUserName();
            param.value.FECHA_REGISTRO = hoy;
            param.value.USUARIO = usuario;
            param.value.COD_ESTADO_DETALLE = 1;

            //Se crea el objeto tipo detalle_factura_pers a partir del objeto params (tipo EditParams_VISTA_DETALLE_ADJUNTOS_PERS)
            #region //Se crea el objeto tipo detalle_factura_pers a partir del objeto params (tipo EditParams_VISTA_DETALLE_ADJUNTOS_PERS)
            //EditParams_DETALLE_FACTURA_PERS DETALLE_FACTURA_PERS_EditParams = new EditParams_DETALLE_FACTURA_PERS(); //qué diferencia hay usando el editparams como este?
            DETALLE_FACTURA_PERS DETALLE_FACTURA_PERS_ = new DETALLE_FACTURA_PERS();

            DETALLE_FACTURA_PERS_.COD_CONTRATO_PROYECTO = param.value.COD_CONTRATO_PROYECTO;
            DETALLE_FACTURA_PERS_.COD_ROL = param.value.COD_ROL;
            DETALLE_FACTURA_PERS_.COD_FORMAS_PAGO_FECHAS = param.value.COD_FORMAS_PAGO_FECHAS;
            DETALLE_FACTURA_PERS_.VALOR_SIN_IMPUESTOS = param.value.VALOR_SIN_IMPUESTOS;
            DETALLE_FACTURA_PERS_.FECHA_REGISTRO = param.value.FECHA_REGISTRO;
            DETALLE_FACTURA_PERS_.USUARIO = param.value.USUARIO;
            DETALLE_FACTURA_PERS_.COD_ESTADO_FACTURA = param.value.COD_ESTADO_FACTURA;
            DETALLE_FACTURA_PERS_.COD_CAUSA_ESTADO = param.value.COD_CAUSA_ESTADO;
            DETALLE_FACTURA_PERS_.OBSERVACIONES = null;
            DETALLE_FACTURA_PERS_.COD_FACTURA = param.value.COD_FACTURA;
            DETALLE_FACTURA_PERS_.COD_ESTADO_DETALLE = 1;//Se actualiza a 1 el 20190524 porque el 1 se identifica ya con el generado o admin//// SE PONE 4 QUE ES EL ESTADO REGISTRO MANUAL// Este es el campo que 1 es vigente y 2 es modificado y por defecto en el insert de verificar lo tenemos en =1 asignado en el controlador. Seguiría así?
            DETALLE_FACTURA_PERS_.COD_CONCEPTO_PSL = param.value.COD_CONCEPTO_PSL;
            DETALLE_FACTURA_PERS_.COD_GRUPO_FACTURA = param.value.COD_GRUPO_FACTURA;
            #endregion //Se crea el objeto tipo detalle_factura_pers a partir del objeto params (tipo EditParams_VISTA_DETALLE_ADJUNTOS_PERS)

            //Se guarda el objeto creado tipo detalle_factura_pers en la base de datos
            #region //Se guarda el objeto creado tipo detalle_factura_pers en la base de datos
            db.DETALLE_FACTURA_PERS.Add(DETALLE_FACTURA_PERS_);
            db.SaveChanges();
            #endregion //Se guarda el objeto creado tipo detalle_factura_pers en la base de datos


            //Se crea el objeto tipo detalle_factura_adjunto_pers a partir del objeto params (tipo EditParams_VISTA_DETALLE_ADJUNTOS_PERS)
            #region //Se crea el objeto tipo detalle_factura_adjunto_pers a partir del objeto params (tipo EditParams_VISTA_DETALLE_ADJUNTOS_PERS)
            //EditParams_DETALLE_FACTURA_PERS DETALLE_FACTURA_PERS_EditParams = new EditParams_DETALLE_FACTURA_PERS(); //qué diferencia hay usando el editparams como este?
            DETALLE_FACTURA_ADJUNTO_PERS DETALLE_FACTURA_ADJUNTO_PERS_ = new DETALLE_FACTURA_ADJUNTO_PERS();

            DETALLE_FACTURA_ADJUNTO_PERS_.COD_CONTRATO_PROYECTO = param.value.COD_CONTRATO_PROYECTO;
            DETALLE_FACTURA_ADJUNTO_PERS_.COD_ROL = param.value.COD_ROL;
            DETALLE_FACTURA_ADJUNTO_PERS_.COD_COLABORADOR = param.value.COD_COLABORADOR;//param.value.NOMBRE_PERSONA;
            DETALLE_FACTURA_ADJUNTO_PERS_.COD_FORMAS_PAGO_FECHAS = param.value.COD_FORMAS_PAGO_FECHAS;
            DETALLE_FACTURA_ADJUNTO_PERS_.FECHA_REGISTRO = param.value.FECHA_REGISTRO;
            DETALLE_FACTURA_ADJUNTO_PERS_.USUARIO = param.value.USUARIO;
            DETALLE_FACTURA_ADJUNTO_PERS_.COD_ESTADO_FACTURA = param.value.COD_ESTADO_FACTURA;
            DETALLE_FACTURA_ADJUNTO_PERS_.COD_CAUSA_ESTADO = param.value.COD_CAUSA_ESTADO;
            DETALLE_FACTURA_ADJUNTO_PERS_.OBSERVACIONES = null;//param.value.COD_CONTRATO_PROYECTO;
            DETALLE_FACTURA_ADJUNTO_PERS_.COD_FACTURA = param.value.COD_FACTURA;
            DETALLE_FACTURA_ADJUNTO_PERS_.COD_ESTADO_DETALLE = 1;//// SE PONE 4 QUE ES EL ESTADO REGISTRO MANUAL//Este es el campo que 1 es vigente y 2 es modificado y por defecto en el insert de verificar lo tenemos en =1 asignado en el controlador. Seguiría así?
            DETALLE_FACTURA_ADJUNTO_PERS_.COD_CONCEPTO_PSL = param.value.COD_CONCEPTO_PSL;
            DETALLE_FACTURA_ADJUNTO_PERS_.COD_GRUPO_FACTURA = param.value.COD_GRUPO_FACTURA;
            DETALLE_FACTURA_ADJUNTO_PERS_.HORAS_ED = param.value.HORAS_ED;
            DETALLE_FACTURA_ADJUNTO_PERS_.HORAS_EN = param.value.HORAS_EN;
            DETALLE_FACTURA_ADJUNTO_PERS_.HORAS_FD = param.value.HORAS_FD;
            DETALLE_FACTURA_ADJUNTO_PERS_.HORAS_FN = param.value.HORAS_FN;
            DETALLE_FACTURA_ADJUNTO_PERS_.ADICIONES = param.value.ADICIONES;
            DETALLE_FACTURA_ADJUNTO_PERS_.HORAS_AUSENCIA = param.value.HORAS_AUSENCIA;
            DETALLE_FACTURA_ADJUNTO_PERS_.DESCUENTO_AUSENCIA = param.value.DESCUENTO_AUSENCIA;
            DETALLE_FACTURA_ADJUNTO_PERS_.FECHA_INI = param.value.FECHA_INI;
            DETALLE_FACTURA_ADJUNTO_PERS_.VALOR_DIAS_LAB = param.value.VALOR_DIAS_LAB;
            DETALLE_FACTURA_ADJUNTO_PERS_.VALOR_SIN_IMPUESTOS = param.value.VALOR_SIN_IMPUESTOS;

            #endregion //Se crea el objeto tipo detalle_factura_adjunto_pers a partir del objeto params (tipo EditParams_VISTA_DETALLE_ADJUNTOS_PERS)

            //Se guarda el objeto creado tipo detalle_factura_pers en la base de datos
            #region //Se guarda el objeto creado tipo detalle_factura_pers en la base de datos
            db.DETALLE_FACTURA_ADJUNTO_PERS.Add(DETALLE_FACTURA_ADJUNTO_PERS_);
            db.SaveChanges();
            #endregion //Se guarda el objeto creado tipo detalle_factura_pers en la base de datos






            try

            {

                string query = @"SELECT [TOTAL_FACTURA] FROM [test_payc_contabilidad].[dbo].[TOTAL_FACTURAS] WHERE COD_FACTURA=" + param.value.COD_FACTURA.ToString();
                string valor_factura = "0";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        valor_factura = dr.GetValue(0).ToString();
                    }
                    connection.Close();
                }

                FACTURAS table1 = db.FACTURAS.Single(o => o.COD_FACTURA == param.value.COD_FACTURA);
                table1.VALOR_SIN_IMPUESTOS = Decimal.Parse(valor_factura);
                db.SaveChanges();
                ////REIVISAR PORQUE GENERÓ PROBLEMAS
                //var data = db.DETALLE_FACTURA_PERS.ToList();
                //var value = data.Last();
                //return Json(value, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new { success = true, responseText = ex.ToString() }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { success = true, responseText = "SI" }, JsonRequestBehavior.AllowGet);





            // db.VISTA_DETALLE_ADJUNTOS_PERS.Add(param.value);
            // db.SaveChanges();
			// var data = db.VISTA_DETALLE_ADJUNTOS_PERS.ToList();
			// var value = data.Last();
            // return Json(value, JsonRequestBehavior.AllowGet);
        }

        //PERFORM UPDATE
   //     public ActionResult PerformUpdate(EditParams_VISTA_DETALLE_ADJUNTOS_PERS param)
   //     {


   ////         //DETALLE_FACTURA_PERS DETALLE_FACTURA_PERS_ = new DETALLE_FACTURA_PERS();
   ////         //DETALLE_FACTURA_ADJUNTO_PERS DETALLE_FACTURA_ADJUNTO_PERS_ = new DETALLE_FACTURA_ADJUNTO_PERS();


   ////         try

   ////         {
   ////             long estado_modificado = 5; //Este es el estado EDITADO MANUALMENTE con el que se identifica un registro que es editado y por lo tanto al ser un registro editado manualmente para nuestro registro quedará eliminado (con esta flag de este estado) y se ingresará el edit como un registro nuevo con estado COD_ESTADO_DETALLE=4: REGISTRO MANUAL
   ////             DETALLE_FACTURA_ADJUNTO_PERS selected_detalle_factura_adjunto_pers = db.DETALLE_FACTURA_ADJUNTO_PERS.Single(o => o.COD_DETALLE_FACTURA_ADJUNTO_PERS == param.value.COD_DETALLE_FACTURA_ADJUNTO_PERS);
   ////             selected_detalle_factura_adjunto_pers.COD_ESTADO_DETALLE = estado_modificado;
   ////             db.SaveChanges();
   ////             //EDICIÓN DE LA TABLA DETALLE_FACTURA_PERS
   ////             //PARA LA TABLA DETALLE_FACTURA_PERS hay que tener en cuenta que el registro enviado (desde la grid ROLES de la vista verificar con la acción edit+save)envía parametro tipo VISTA_DETALLE_ADJUNTOS_PERS y este no tiene entre sus campos el COD_DETALLE_FACTURA_PERS por lo que no es posible identificarlo con su identificador único entonces se revisa si buscar con la concatenación de detalle_factura cod_contrato_proyecto valor_sin_impuestos cod_rol fecha_registro  y cod_concepto_psl (la concatenación de todas estas columnas para garantizar que es exactamente el mismo registro)
   ////             //DETALLE_FACTURA_PERS selected_detalle_factura_pers = db.DETALLE_FACTURA_PERS.Single(o => o.COD_DETALLE_FACTURA_PERS == param.value. ); // COMENTADO PORQUE SE OBSERVA QUE LA VISTA VISTA_DETALLE_ADJUNTOS_PERS NO ENVIA OMO PARAMETRO EL COD_DETALLE_FACTURA_PERS (ENVIA EL COD_DETALLE_FAVTURA_ADJUNTO_PERS MAS NO EL NO ADJUNTO)
   ////             //db.SaveChanges();

   ////             ////REIVISAR PORQUE GENERÓ PROBLEMAS
   ////             //var data = db.DETALLE_FACTURA_PERS.ToList();
   ////             //var value = data.Last();
   ////             //return Json(value, JsonRequestBehavior.AllowGet);
   ////             return RedirectToAction("PerformInsert", new { id = 1 });

   ////         }
   ////         catch (Exception ex)
   ////         {
   ////             return Json(new { success = true, responseText = ex.ToString() }, JsonRequestBehavior.AllowGet);
   ////         }
   ////         //VISTA_DETALLE_ADJUNTOS_PERS table = db.VISTA_DETALLE_ADJUNTOS_PERS.Single(o => o.COD_DETALLE_FACTURA_ADJUNTO_PERS == param.value.COD_DETALLE_FACTURA_ADJUNTO_PERS);

   ////         //db.Entry(table).CurrentValues.SetValues(param.value);
   ////         //db.SaveChanges();
			//////return RedirectToAction("GetOrderData");
			
   //     }

        //Borrar grid


        public ActionResult PerformDelete(int key, string keyColumn)
        {
            long estado_modificado = 2; //El estado modificado es un flag para no tomarlo en cuenta. Solo se toma en cunta el estado 1
            DETALLE_FACTURA_ADJUNTO_PERS selected_detalle_factura_adjunto_pers = db.DETALLE_FACTURA_ADJUNTO_PERS.Single(o => o.COD_DETALLE_FACTURA_ADJUNTO_PERS == key);
            selected_detalle_factura_adjunto_pers.COD_ESTADO_DETALLE = estado_modificado;
            //db.VISTA_DETALLE_ADJUNTOS_PERS.Remove(db.VISTA_DETALLE_ADJUNTOS_PERS.Single(o => o.COD_DETALLE_FACTURA_ADJUNTO_PERS== key));
            db.SaveChanges();
            //return RedirectToAction("GetOrderData");
            return Json(new { success = true, responseText = "SI" }, JsonRequestBehavior.AllowGet);

        }

        //Novedades nomina asociados al adjunto
        public ActionResult GetOrderData_novedades(DataManager dm)
        {
            IEnumerable DataSource = db.VISTA_NOVEDADES_DETALLE_ADJUNTO_PERS.ToList();
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
            var count = DataSource.Cast<VISTA_NOVEDADES_DETALLE_ADJUNTO_PERS>().Count();
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
        #endregion
        #region exportar excel
        //Adjunto exportar
        [System.Web.Http.ActionName("ExcelExport")]
        [AcceptVerbs("POST")]
        public ActionResult ExcelExport(string gridModel,long COD_FACTURA,long COD_CONTRATO_PROYECTO)
        {
            ExcelExport exp = new ExcelExport();
            CultureInfo cult= CultureInfo.CreateSpecificCulture("es-ES");
            FACTURAS factura = db.FACTURAS.Single(o => o.COD_FACTURA == COD_FACTURA);
            DateTime periodo_fin = new DateTime(factura.FECHA_FACTURA.Value.Year, factura.FECHA_FACTURA.Value.Month, 1);
            DateTime periodo_ini = periodo_fin.AddMonths(-2);
            DateTime periodo_fact = new DateTime(factura.FECHA_FACTURA.Value.Year, factura.FECHA_FACTURA.Value.Month, 1);
            var DataSource = db.VISTA_DETALLE_FACTURAS_REPORTE.Where(o=> o.COD_CONTRATO_PROYECTO == COD_CONTRATO_PROYECTO && o.PERIODO_FACTURACION<=periodo_fin && o.PERIODO_FACTURACION >= periodo_ini).Select(x=> new { x.PERIODO_FACTURACION,x.NUMERO_FACTURA_PRODUCTIVO,x.CENTRO_COSTOS,x.NOMBRE_PROYECTO, x.TIPO_ELEMENTO,x.NOMBRE_ROL,x.NOMBRE_PERSONA, x.FECHA_INGRESO,x.FECHA_RETIRO_EN_CONTRATO,x.VALOR_SIN_IMPUESTOS,x.SALARIO_COMERCIAL_SIN_PRESTACIONES_CON_INCREMENTOS,x.PRESTACIONES,x.VALOR_DIAS_LAB,x.DESCUENTO_AUSENCIA, x.HORAS_AUSENCIA, x.DIAS_AUSENCIA, x.ADICIONES,x.HORAS_ED,x.HORAS_EN, x.HORAS_FD,x.HORAS_FN, x.NOVEDADES, x.DEDICACION, x.NUMERO_FACTURA }).ToList();
            CONTRATO_PROYECTO_DESCRIPCION contrato_proyecto = db.CONTRATO_PROYECTO_DESCRIPCION.Single(o => o.COD_CONTRATO_PROYECTO == COD_CONTRATO_PROYECTO);
            
            int contar = DataSource.Count() + 1;
            DataTable tabla = DataSource.ToDataTable();
            //Características EXCEL
            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                IApplication application = excelEngine.Excel;
                application.DefaultVersion = ExcelVersion.Excel2013;
                IWorkbook workbook = application.Workbooks.Create(1);
                IWorksheet pivot = workbook.Worksheets[0];
                IWorksheet  worksheet = workbook.Worksheets.Create();
                
                worksheet.Name = "BASE DE DATOS";
                worksheet.Range["A1:X1"].CellStyle.FillBackground= Syncfusion.XlsIO.ExcelKnownColors.Brown;
                worksheet.Range["A1:X1"].CellStyle.Font.Color = Syncfusion.XlsIO.ExcelKnownColors.White;
                worksheet.Range["A1:X"+contar.ToString()].CellStyle.Borders.LineStyle = Syncfusion.XlsIO.ExcelLineStyle.Thin;
                worksheet.Range["A1:X" + contar.ToString()].CellStyle.Borders[ExcelBordersIndex.DiagonalDown].LineStyle = Syncfusion.XlsIO.ExcelLineStyle.None;
                worksheet.Range["A1:X" + contar.ToString()].CellStyle.Borders[ExcelBordersIndex.DiagonalUp].LineStyle = Syncfusion.XlsIO.ExcelLineStyle.None;
                worksheet.Range["A2:X" + (contar+1).ToString()].Borders.Color = Syncfusion.XlsIO.ExcelKnownColors.Black;
                worksheet.Range["A1:X1"].Borders.Color = Syncfusion.XlsIO.ExcelKnownColors.White;
                worksheet.Range["A1:X1"].CellStyle.Font.Bold = true;
                
                //Initialize the DataTable
                DataTable table = tabla;
                var fileSave = System.Web.HttpContext.Current.Server.MapPath("adjuntosfactura");
                if (!Directory.Exists(fileSave))
                {
                    Directory.CreateDirectory(fileSave);
                }
                
                
                worksheet.ImportDataTable(table, true, 1, 1);
                worksheet.Range["A1"].Text = "Periodo Facturación";
                worksheet.Range["B1"].Text = "No Factura";
                worksheet.Range["C1"].Text = "Centro de costo";
                worksheet.Range["D1"].Text = "Nombre del proyecto";
                worksheet.Range["E1"].Text = "Tipo elemento (Persona o Item)";
                worksheet.Range["F1"].Text = "Rol / Otros conceptos";
                worksheet.Range["G1"].Text = "Nombre colaborador / Item";
                worksheet.Range["H1"].Text = "Fecha Ingreso";
                worksheet.Range["I1"].Text = "Fecha Retiro";
                worksheet.Range["J1"].Text = "Valor a pagar";
                worksheet.Range["K1"].Text = "Salario básico";
                worksheet.Range["L1"].Text = "Prestaciones %";
                worksheet.Range["M1"].Text = "Salario incluidas prestaciones";
                worksheet.Range["N1"].Text = "Descuentos (Novedades)";
                worksheet.Range["O1"].Text = "Total horas novedades";
                worksheet.Range["P1"].Text = "Total días novedades";
                worksheet.Range["Q1"].Text = "Horas Extra";
                worksheet.Range["R1"].Text = "HE Diurnas";
                worksheet.Range["S1"].Text = "HE Nocturnas";
                worksheet.Range["T1"].Text = "HE Festivas Diurnas";
                worksheet.Range["U1"].Text = "HE Festivas Nocturnas";
                worksheet.Range["V1"].Text = "Detalle Novedades";
                worksheet.Range["W1"].Text = "Dedicación";
                worksheet.Range["X1"].Text = "Número factura proforma";
                worksheet.InsertRow(1);
                worksheet.InsertRow(1);

                worksheet.Range["B1"].Formula = @"""PAYC - PERIODO FACTURADO - "+ periodo_fact.ToString("y") +@""""+ @"&CHAR(10)& """ + contrato_proyecto.DESCRIPCION + @"""& CHAR(10) & ""BASE DE DATOS ARCHIVO CON DETALLE ADJUNTO A LA FACTURA""";
                worksheet.Range["B1:X1"].Merge();
                worksheet.Range["B1:X1"].Borders.LineStyle = Syncfusion.XlsIO.ExcelLineStyle.Double;
                worksheet.Range["B1:X1"].Borders.Color = Syncfusion.XlsIO.ExcelKnownColors.Black;
                worksheet.Range["B1:X1"].CellStyle.Borders[ExcelBordersIndex.DiagonalDown].LineStyle = Syncfusion.XlsIO.ExcelLineStyle.None;
                worksheet.Range["B1:X1"].CellStyle.Borders[ExcelBordersIndex.DiagonalUp].LineStyle = Syncfusion.XlsIO.ExcelLineStyle.None;
                worksheet.Range["B1:X1"].HorizontalAlignment = ExcelHAlign.HAlignJustify;
                worksheet.Range["B1:X1"].VerticalAlignment= ExcelVAlign.VAlignCenter;
                worksheet.Range["B1:X1"].CellStyle.Font.Bold = true;
                worksheet.Range["B1:X1"].Merge();
                worksheet.Range["B1:X1"].WrapText = true;
                worksheet.Range["A1"].RowHeight = 60;
                worksheet.Range["A1"].Borders.LineStyle = Syncfusion.XlsIO.ExcelLineStyle.Double;
                worksheet.Range["A1"].Borders.Color = Syncfusion.XlsIO.ExcelKnownColors.Black;
                worksheet.Range["A1"].CellStyle.Borders[ExcelBordersIndex.DiagonalDown].LineStyle = Syncfusion.XlsIO.ExcelLineStyle.None;
                worksheet.Range["A1"].CellStyle.Borders[ExcelBordersIndex.DiagonalUp].LineStyle = Syncfusion.XlsIO.ExcelLineStyle.None;
                worksheet.Range["A1"].HorizontalAlignment = ExcelHAlign.HAlignJustify;
                
                worksheet.Range["A1"].CellStyle.Font.Bold = true;
                IPictureShape shape = worksheet.Pictures.AddPicture(1, 1, Path.Combine(fileSave+ "/logopayc1.png"));
                shape.Top = 20;
                shape.Left = 24;
                shape.Height = 40;
                shape.Width = 40;
                int i = 1;
                while (i <= 21) { 
                    worksheet.AutofitColumn(i);
                    i = i + 1;
                }
                worksheet.SetColumnWidth(22, 70);
                worksheet.Range["A3:U"+(contar+2).ToString()].WrapText = true;

                //IWorksheet pivot = workbook.Worksheets.Create();
                pivot.Name = "TABLA DINAMICA";
                IPivotCache cache = workbook.PivotCaches.Add(worksheet["A3:X" + (contar + 2).ToString()]);
                IPivotTable pivotTable = pivot.PivotTables.Add("PivotTable1", pivot["A5"], cache);
                pivotTable.Fields[4].Axis = PivotAxisTypes.Row;
                pivotTable.Fields[5].Axis = PivotAxisTypes.Row;
                pivotTable.Fields[6].Axis = PivotAxisTypes.Row;
                pivotTable.Fields[22].Axis = PivotAxisTypes.Row;
                pivotTable.Fields[11].Axis = PivotAxisTypes.Row;
                pivotTable.Fields[7].Axis = PivotAxisTypes.Row;
                pivotTable.Fields[8].Axis = PivotAxisTypes.Row;
                
                //pivotTable.Fields[21].Axis = PivotAxisTypes.Row;
                //pivotTable.Fields[3].Axis = PivotAxisTypes.Page;
                pivotTable.Fields[0].Axis = PivotAxisTypes.Column;

                //Apply page field filter
                IPivotField pageField = pivotTable.Fields[3];

                //Select multiple items in page field to filter
                
                pageField.Items[0].Visible = true;

                
                pivotTable.Fields[4].Subtotals = PivotSubtotalTypes.None;
                pivotTable.Fields[5].Subtotals = PivotSubtotalTypes.None;
                pivotTable.Fields[6].Subtotals = PivotSubtotalTypes.None;
                pivotTable.Fields[22].Subtotals = PivotSubtotalTypes.None;
                pivotTable.Fields[7].Subtotals = PivotSubtotalTypes.None;
                pivotTable.Fields[8].Subtotals = PivotSubtotalTypes.None;
                pivotTable.Fields[11].Subtotals = PivotSubtotalTypes.None;
                //pivotTable.Fields[21].Subtotals = PivotSubtotalTypes.None;
                pivotTable.Fields[0].NumberFormat = "mmm yyyy";
                pivotTable.Fields[11].NumberFormat = "0%";
                pivotTable.Fields[9].NumberFormat = "$ #,##0.0";
               
                pivotTable.Fields[0].Subtotals = PivotSubtotalTypes.None;
                IPivotField field1 = pivotTable.Fields[9];
                pivotTable.DataFields.Add(field1, "Valor Facturación", PivotSubtotalTypes.Sum);
                IPivotTableOptions pivotOption = pivotTable.Options;
                pivotOption.RowLayout = PivotTableRowLayout.Tabular;
                
                
                pivotTable.BuiltInStyle = PivotBuiltInStyles.PivotStyleMedium2;
                pivot.Range["D6:BB6"].NumberFormat = "mmm dd yyyy";
                //Encabezado dinámica

                

                pivot.Range["B1"].Formula = @"""PAYC - PERIODO FACTURADO - " + periodo_fact.ToString("y") + @"""" + @"&CHAR(10)&""" + contrato_proyecto.DESCRIPCION + @""" &CHAR(10) & ""REPORTE DINÁMICO CON DETALLE ADJUNTO A LA FACTURA""";
                pivot.Range["B1:J1"].Merge();
                pivot.Range["B1:J1"].Borders.LineStyle = Syncfusion.XlsIO.ExcelLineStyle.Double;
                pivot.Range["B1:J1"].Borders.Color = Syncfusion.XlsIO.ExcelKnownColors.Black;
                pivot.Range["B1:J1"].CellStyle.Borders[ExcelBordersIndex.DiagonalDown].LineStyle = Syncfusion.XlsIO.ExcelLineStyle.None;
                pivot.Range["B1:J1"].CellStyle.Borders[ExcelBordersIndex.DiagonalUp].LineStyle = Syncfusion.XlsIO.ExcelLineStyle.None;
                pivot.Range["B1:J1"].HorizontalAlignment = ExcelHAlign.HAlignJustify;
                pivot.Range["B1:J1"].VerticalAlignment = ExcelVAlign.VAlignCenter;
                pivot.Range["B1:J1"].CellStyle.Font.Bold = true;
                pivot.Range["B1:J1"].Merge();

                pivot.Range["A1"].RowHeight = 60;
                pivot.Range["A1"].Borders.LineStyle = Syncfusion.XlsIO.ExcelLineStyle.Double;
                pivot.Range["A1"].Borders.Color = Syncfusion.XlsIO.ExcelKnownColors.Black;
                pivot.Range["A1"].CellStyle.Borders[ExcelBordersIndex.DiagonalDown].LineStyle = Syncfusion.XlsIO.ExcelLineStyle.None;
                pivot.Range["A1"].CellStyle.Borders[ExcelBordersIndex.DiagonalUp].LineStyle = Syncfusion.XlsIO.ExcelLineStyle.None;
                pivot.Range["A1"].HorizontalAlignment = ExcelHAlign.HAlignJustify;

                pivot.Range["A1"].CellStyle.Font.Bold = true;
                IPictureShape shape1 = pivot.Pictures.AddPicture(1, 1, Path.Combine(fileSave + "/logopayc1.png"));
                shape1.Top = 20;
                shape1.Left = 24;
                shape1.Height = 40;
                shape1.Width = 40;

                var fileSavePath = Path.Combine(fileSave, "Adjunto_"+COD_FACTURA+".xlsx");
                workbook.SaveAs(fileSavePath);
            }
            return Json(new { result = COD_FACTURA.ToString(), success = true }, JsonRequestBehavior.AllowGet);
        }
        #endregion
        #region utilidades adicionales
        private GridProperties ConvertGridObject(string gridProperty)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            IEnumerable div = (IEnumerable)serializer.Deserialize(gridProperty, typeof(IEnumerable));
            GridProperties gridProp = new GridProperties();
            foreach (KeyValuePair<string, object> ds in div)
            {
                var property = gridProp.GetType().GetProperty(ds.Key, BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase);
                if (property != null)
                {
                    Type type = property.PropertyType;
                    string serialize = serializer.Serialize(ds.Value);
                    object value = serializer.Deserialize(serialize, type);
                    property.SetValue(gridProp, value, null);
                }
            }
            return gridProp;
        }
        #endregion
    }
    #region utilidades adicionales
    public static class Test
    {
        public static DataTable ToDataTable<T>(this IList<T> data)
        {
            PropertyDescriptorCollection properties =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }
    }
    #endregion

}
