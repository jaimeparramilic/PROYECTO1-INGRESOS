using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Syncfusion.JavaScript;
using Syncfusion.JavaScript.DataSources;
using System.Data.Entity;
using System.Net;
using syncfusion_payc.Models;
using System.IO;
using Microsoft.AspNet.Identity;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Globalization;
using syncfusion_payc.Utilidades;
namespace syncfusion_payc.Controllers
{
    public class FACTURASController : Controller
    {
        private test_payc_contabilidadEntities db = new test_payc_contabilidadEntities();
        static string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection1"].ConnectionString;
        static string connectionString1 = ConfigurationManager.ConnectionStrings["DefaultConnection3"].ConnectionString;
        #region vistas / acciones default
        // GET: FACTURAS
        public ActionResult Index()
        {
            //var fACTURAS = db.FACTURAS.Include(f => f.CONTRATO_PROYECTO).Include(f => f.ESTADOS_FACTURAS).Include(f => f.FORMAS_PAGO_FECHAS);
            return View();
        }

        // GET: FACTURAS/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FACTURAS fACTURAS = db.FACTURAS.Find(id);
            if (fACTURAS == null)
            {
                return HttpNotFound();
            }
            return View(fACTURAS);
        }

        // GET: FACTURAS/Create
        public ActionResult Create()
        {
            ViewBag.COD_CONTRATO_PROYECTO = new SelectList(db.CONTRATO_PROYECTO, "COD_CONTRATO_PROYECTO", "COMPLETA");
            ViewBag.COD_ESTADO_FACTURA = new SelectList(db.ESTADOS_FACTURAS, "COD_ESTADOS_FACTURAS", "DESCRIPCION");
            ViewBag.COD_FORMAS_PAGO_FECHAS = new SelectList(db.FORMAS_PAGO_FECHAS, "COD_FORMAS_PAGO_FECHAS", "PERIODO_TEXTO");
            return View();
        }

        // POST: FACTURAS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COD_FACTURA,COD_CONTRATO_PROYECTO,COD_FORMAS_PAGO_FECHAS,NUMERO_FACTURA,FECHA_FACTURA,COD_ESTADO_FACTURA,VALOR_SIN_IMPUESTOS,VALOR_CON_IMPUESTOS,RANKING")] FACTURAS fACTURAS)
        {
            if (ModelState.IsValid)
            {
                db.FACTURAS.Add(fACTURAS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.COD_CONTRATO_PROYECTO = new SelectList(db.CONTRATO_PROYECTO, "COD_CONTRATO_PROYECTO", "COMPLETA", fACTURAS.COD_CONTRATO_PROYECTO);
            ViewBag.COD_ESTADO_FACTURA = new SelectList(db.ESTADOS_FACTURAS, "COD_ESTADOS_FACTURAS", "DESCRIPCION", fACTURAS.COD_ESTADO_FACTURA);
            ViewBag.COD_FORMAS_PAGO_FECHAS = new SelectList(db.FORMAS_PAGO_FECHAS, "COD_FORMAS_PAGO_FECHAS", "PERIODO_TEXTO", fACTURAS.COD_FORMAS_PAGO_FECHAS);
            return View(fACTURAS);
        }

        // GET: FACTURAS/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FACTURAS fACTURAS = db.FACTURAS.Find(id);
            if (fACTURAS == null)
            {
                return HttpNotFound();
            }
            ViewBag.COD_CONTRATO_PROYECTO = new SelectList(db.CONTRATO_PROYECTO, "COD_CONTRATO_PROYECTO", "COMPLETA", fACTURAS.COD_CONTRATO_PROYECTO);
            ViewBag.COD_ESTADO_FACTURA = new SelectList(db.ESTADOS_FACTURAS, "COD_ESTADOS_FACTURAS", "DESCRIPCION", fACTURAS.COD_ESTADO_FACTURA);
            ViewBag.COD_FORMAS_PAGO_FECHAS = new SelectList(db.FORMAS_PAGO_FECHAS, "COD_FORMAS_PAGO_FECHAS", "PERIODO_TEXTO", fACTURAS.COD_FORMAS_PAGO_FECHAS);
            return View(fACTURAS);
        }

        // POST: FACTURAS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COD_FACTURA,COD_CONTRATO_PROYECTO,COD_FORMAS_PAGO_FECHAS,NUMERO_FACTURA,FECHA_FACTURA,COD_ESTADO_FACTURA,VALOR_SIN_IMPUESTOS,VALOR_CON_IMPUESTOS,RANKING")] FACTURAS fACTURAS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fACTURAS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.COD_CONTRATO_PROYECTO = new SelectList(db.CONTRATO_PROYECTO, "COD_CONTRATO_PROYECTO", "COMPLETA", fACTURAS.COD_CONTRATO_PROYECTO);
            ViewBag.COD_ESTADO_FACTURA = new SelectList(db.ESTADOS_FACTURAS, "COD_ESTADOS_FACTURAS", "DESCRIPCION", fACTURAS.COD_ESTADO_FACTURA);
            ViewBag.COD_FORMAS_PAGO_FECHAS = new SelectList(db.FORMAS_PAGO_FECHAS, "COD_FORMAS_PAGO_FECHAS", "PERIODO_TEXTO", fACTURAS.COD_FORMAS_PAGO_FECHAS);
            return View(fACTURAS);
        }

        // GET: FACTURAS/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FACTURAS fACTURAS = db.FACTURAS.Find(id);
            if (fACTURAS == null)
            {
                return HttpNotFound();
            }
            return View(fACTURAS);
        }

        // POST: FACTURAS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            FACTURAS fACTURAS = db.FACTURAS.Find(id);
            db.FACTURAS.Remove(fACTURAS);
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
        #region verificar
        public ActionResult Verificar(long? id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            db.Configuration.LazyLoadingEnabled = false;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DATOS_VERIFICAR_FACTURA DatVerificarFactu = db.DATOS_VERIFICAR_FACTURA.Find(id);
            
            if (DatVerificarFactu == null)
            {
                return HttpNotFound();
            }
            ViewBag.COD_FACTURA = DatVerificarFactu.COD_FACTURA;
            ViewBag.COD_CONTRATO_PROYECTO = DatVerificarFactu.COD_CONTRATO_PROYECTO;
            ViewBag.COD_FORMAS_PAGO_FECHAS = DatVerificarFactu.COD_FORMAS_PAGO_FECHAS;
            ViewBag.COD_ESTADO_FACTURA = DatVerificarFactu.COD_ESTADO_FACTURA;
            ViewBag.DESCRIPCION_PROYECTO = DatVerificarFactu.DESCRIPCION;
            ViewBag.PERIODO_FACTURAR = DatVerificarFactu.PERIODO_FACTURAR;
            ViewBag.ESTADO_FACTURA = DatVerificarFactu.COD_ESTADO_FACTURA;

            //Consulta para traer total
            ViewBag.TOTAL_FACTURA = "0";
            string query = @"SELECT FORMAT([TOTAL_FACTURA],'C','es-CO') FROM [test_payc_contabilidad].[dbo].[TOTAL_FACTURAS] WHERE COD_FACTURA=" + id.ToString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    ViewBag.TOTAL_FACTURA = dr.GetValue(0).ToString();
                }
                connection.Close();
            }

            return View();
        }
#endregion
        #region Adjuntar
        public ActionResult Adjunto(long? id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            db.Configuration.LazyLoadingEnabled = false;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DATOS_VERIFICAR_FACTURA DatVerificarFactu = db.DATOS_VERIFICAR_FACTURA.Find(id);

            if (DatVerificarFactu == null)
            {
                return HttpNotFound();
            }
            ViewBag.COD_FACTURA = DatVerificarFactu.COD_FACTURA;
            ViewBag.COD_CONTRATO_PROYECTO = DatVerificarFactu.COD_CONTRATO_PROYECTO;
            ViewBag.COD_FORMAS_PAGO_FECHAS = DatVerificarFactu.COD_FORMAS_PAGO_FECHAS;
            ViewBag.COD_ESTADO_FACTURA = DatVerificarFactu.COD_ESTADO_FACTURA;
            ViewBag.DESCRIPCION_PROYECTO = DatVerificarFactu.DESCRIPCION;
            ViewBag.PERIODO_FACTURAR = DatVerificarFactu.PERIODO_FACTURAR;
            ViewBag.ESTADO_FACTURA = DatVerificarFactu.COD_ESTADO_FACTURA;

            //Consulta para traer total
            ViewBag.TOTAL_FACTURA = "0";
            string query = @"SELECT FORMAT([TOTAL_FACTURA],'C','es-CO') FROM [test_payc_contabilidad].[dbo].[TOTAL_FACTURAS] WHERE COD_FACTURA=" + id.ToString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    ViewBag.TOTAL_FACTURA = dr.GetValue(0).ToString();
                }
                connection.Close();
            }

            return View();
        }
        #endregion
        #region grid index
        //Aca inicia syncfusion

        //Traer data

        public ActionResult UrlAdaptor()
        {
            var DataSource2 = db.FACTURAS.ToList();
            ViewBag.dataSource2 = DataSource2;
            return View();
        }	

		public ActionResult GetOrderData(DataManager dm)
        {
            IEnumerable DataSource = db.FACTURAS.ToList();
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
            var count = DataSource.Cast<FACTURAS>().Count();
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
        public ActionResult PerformInsert(EditParams_FACTURAS param)
        {
            db.FACTURAS.Add(param.value);
            db.SaveChanges();
			var data = db.FACTURAS.ToList();
			var value = data.Last();
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        //Actualizar grid
        public ActionResult PerformUpdate(EditParams_FACTURAS param)
        {
            
			FACTURAS table = db.FACTURAS.Single(o => o.COD_FACTURA == param.value.COD_FACTURA);

            db.Entry(table).CurrentValues.SetValues(param.value);
            db.SaveChanges();
			return RedirectToAction("GetOrderData");
			
        }

        //Borrar grid
        public ActionResult PerformDelete(int key, string keyColumn)
        {
            db.FACTURAS.Remove(db.FACTURAS.Single(o => o.COD_FACTURA== key));
            db.SaveChanges();
            return RedirectToAction("GetOrderData");
            
        }

        public ActionResult GetOrderData_centros_factura(DataManager dm)
        {
            IEnumerable DataSource = db.VISTA_CONTRATO_PROYECTO_FACTURAS1.ToList();
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
            var count = DataSource.Cast<VISTA_CONTRATO_PROYECTO_FACTURAS1>().Count();
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
        #region validar factura
        //Funcion para regenerar el flujo del rol
        public ActionResult validar_factura(long COD_CONTRATO_PROYECTO,long COD_FORMAS_PAGO_FECHAS, long COD_FACTURA)
        {
            string error = "NO";

            try
            {
                IEnumerable items_sin_concepto = db.DETALLE_FACTURA_ITEM.Where(o => o.COD_FACTURA == COD_FACTURA && o.COD_CONTRATO_PROYECTO == COD_CONTRATO_PROYECTO && o.COD_FORMAS_PAGO_FECHAS == COD_FORMAS_PAGO_FECHAS && o.COD_ESTADO_DETALLE == 1 && o.COD_CONCEPTO_PSL == null).ToList();
                var count=items_sin_concepto.Cast<DETALLE_FACTURA_ITEM>().Count();
                if (count > 0)
                {
                    error = "SI";
                }
            }
            catch
            {

            }

            try
            {
                IEnumerable pers_sin_concepto = db.DETALLE_FACTURA_PERS.Where(o => o.COD_FACTURA == COD_FACTURA && o.COD_CONTRATO_PROYECTO == COD_CONTRATO_PROYECTO && o.COD_FORMAS_PAGO_FECHAS == COD_FORMAS_PAGO_FECHAS && o.COD_ESTADO_DETALLE == 1 && o.COD_CONCEPTO_PSL == null).ToList();
                var count = pers_sin_concepto.Cast<DETALLE_FACTURA_PERS>().Count();
                if (count > 0)
                {
                    error = "SI";
                }
            }
            catch
            {

            }
            if (error == "NO")
            {
                FACTURAS table = db.FACTURAS.Single(o => o.COD_FACTURA == COD_FACTURA);
                table.COD_ESTADO_FACTURA = 2;
                db.SaveChanges();
            }

            return Json(new { success = true, responseText = error }, JsonRequestBehavior.AllowGet);
        }
        #endregion
        #region ejecución R
        public ActionResult valor_facturar(EditParams_FACTURAS param)
        {
            //Cargar formas pago fechas
            
            DateTime temp11 = param.value.FECHA_FACTURA.Value;
            if (param.value.FECHA_EMISION.HasValue)
            {
                //temp11 = param.value.FECHA_EMISION.Value;
                
            }
            else
            {
                param.value.FECHA_EMISION = param.value.FECHA_FACTURA;
            }

            DateTime temp_fecha = new DateTime(temp11.Year, temp11.Month, 1);
            FORMAS_PAGO_FECHAS table = db.FORMAS_PAGO_FECHAS.Single(o => o.FECHA_FORMA_PAGO == temp_fecha);
            param.value.COD_ESTADO_FACTURA = 1;
            param.value.COD_FORMAS_PAGO_FECHAS = table.COD_FORMAS_PAGO_FECHAS;
            //Crear factura
            DateTime hoy = DateTime.Today;
            string usuario = User.Identity.GetUserName();
            FACTURAS factura = new FACTURAS();
            factura.COD_CONTRATO_PROYECTO = param.value.COD_CONTRATO_PROYECTO;
            factura.COD_ESTADO_FACTURA = 1;
            factura.COD_FORMAS_PAGO_FECHAS = param.value.COD_FORMAS_PAGO_FECHAS;
            factura.VALOR_SIN_IMPUESTOS = param.value.VALOR_SIN_IMPUESTOS;
            factura.FECHA_FACTURA = param.value.FECHA_FACTURA;
            factura.COD_CONCEPTO_PSL= param.value.COD_CONCEPTO_PSL;
            factura.FECHA_EMISION = param.value.FECHA_EMISION;
            db.FACTURAS.Add(factura);
            db.SaveChanges();

            //Guardar ID de la factura recien creada
            var data = db.FACTURAS.ToList();
            var value = data.Last();

            long COD_FACTURA = value.COD_FACTURA;
            //Script a ejecutar
            var rCodeFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Modelos_Matematicos") + @"\valor_facturar.R";

            //Ubicación ejecutable
            var rScriptExecutablePath = @"C:/Program Files/R/R-3.5.1/bin/Rscript.exe";

            //Variable a retornar
            string result = "";
            bool success1 = true;
            try
            {

                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Modelos_Matematicos") + @"\valor_facturar_temp.R";
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                //Escribir en archivo
                if (!System.IO.File.Exists(path))
                {
                    System.IO.File.Copy(rCodeFilePath, path);
                    using (StreamWriter sw = System.IO.File.AppendText(path))
                    {
                        sw.WriteLine("factura(" +COD_FACTURA+ ")");
                    }
                }

                var info = new ProcessStartInfo();
                info.FileName = rScriptExecutablePath;
                info.WorkingDirectory = Path.GetDirectoryName(rScriptExecutablePath);
                info.Arguments = path;
                info.RedirectStandardInput = false;
                info.RedirectStandardOutput = true;
                info.UseShellExecute =false;
                info.CreateNoWindow = true;
                info.RedirectStandardOutput = true;
                info.RedirectStandardError = true;
                //Process.Start(rScriptExecutablePath, path);
                using (var proc = new Process())
                {
                    proc.StartInfo = info;
                    proc.Start();
                    result = proc.StandardOutput.ReadToEnd();
                    proc.WaitForExit();
                    proc.Close();
                }

                if (result == "")
                {
                    success1 = false;
                    result = "Existe algún problema con la asignación de profesionales, roles al proyecto o no existen flujos de ingresos";
                }
                else
                {
                    //ViewBag.Result = result + "," + rCodeFilePath;
                    result = result;
                }
            }
            catch (Exception ex)
            {

                //throw new Exception("R Script failed: " + result, ex);
                result = "Existe algún problema con la asignación de profesionales, roles al proyecto o no existen flujos de ingresos";
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Existe algún problema con la asignación de profesionales o roles al proyecto, revice las asignaciones");
                success1 = false;
            }
            try
            {
                string query = @"SELECT [TOTAL_FACTURA] FROM [test_payc_contabilidad].[dbo].[TOTAL_FACTURAS] WHERE COD_FACTURA=" + COD_FACTURA.ToString();
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
                FACTURAS table1 = db.FACTURAS.Single(o => o.COD_FACTURA == COD_FACTURA);
                table1.VALOR_SIN_IMPUESTOS = Decimal.Parse(valor_factura);
                db.SaveChanges();
                
            }
            catch (Exception ex)
            {

                result = "Ocurrio un error durante el cálculo del total, por favor vuelva a intentarlo";
                success1 = false;

                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Ocurrio un error durante el cálculo del total, por favor vuelva a intentarlo");
            }
            return Json(new { success = success1, responseText = result }, JsonRequestBehavior.AllowGet);

        }

        #endregion
        #region totales factura
        //Funcion para refrescar totales
        public ActionResult refrescar_total(long COD_FACTURA)
        {
            string result = "";
            string query = @"SELECT FORMAT([TOTAL_FACTURA],'C','es-CO') FROM [test_payc_contabilidad].[dbo].[TOTAL_FACTURAS] WHERE COD_FACTURA=" + COD_FACTURA.ToString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    result = dr.GetValue(0).ToString();
                }
                connection.Close();
            }

            return Json(new { success = true, responseText = result }, JsonRequestBehavior.AllowGet);
        }

        #endregion
        #region enviar a psl
        public ActionResult facturar(long COD_FACTURA)
        {
            string result = "SI";
            //Consulta para importar encabezado factura
            try
            {
                //Traer codigo factura
                string query = @"SELECT MAX(CAST([edvnumedocuclie] AS INT)) AS MAX_CODIGO
                                 FROM [ssf_pruebas].[dbo].[ca_encdocvta] WHERE (edvtipoconsclie='F00' OR edvtipoconsclie='FI00') AND edvcompania='01' AND edvdivision='01'";

                string maxnumfac = "0";
                using (SqlConnection connection = new SqlConnection(connectionString1))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        maxnumfac = dr.GetValue(0).ToString(); 
                    }
                    connection.Close();
                }

                //Si se logró traer el número de factura
                if (maxnumfac != "0")
                {
                    query = @"UPDATE [104.196.158.138].[test_payc_contabilidad].[dbo].[SECUENCIA_NUM_FACT_PSL] 
	                        SET [SECUENCIA_PSL] = (SELECT TOP 1 MAX(CAST([edvnumedocuclie] AS INT)) + 1 AS MAX_CODIGO
	                        FROM [ssf_pruebas].[dbo].[VISTA_MAXIMO_FACTURAS] 
	                        WHERE (edvtipoconsclie='F00' OR edvtipoconsclie='FI00') AND edvcompania='01' AND edvdivision='01')";
                    //Insertar encabezado factura
                    using (SqlConnection connection = new SqlConnection(connectionString1))
                    {
                        SqlCommand command = new SqlCommand(query, connection);
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }

                    //Extraer numero factura
                    query = "SELECT * FROM [test_payc_contabilidad].[dbo].[SECUENCIA_NUM_FACT_PSL]";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlCommand command = new SqlCommand(query, connection);
                        connection.Open();
                        SqlDataReader dr = command.ExecuteReader();
                        while (dr.Read())
                        {
                            maxnumfac = dr.GetValue(0).ToString();
                        }
                        connection.Close();
                    }

                    string query1 = @"INSERT INTO [ssf_pruebas].[dbo].[ca_encdocvtaentra] ([edvconseingre]
                  ,[edvcontrol]
                  ,[edvvaloconimp]
                  ,[edvnumedocuclie]
                  ,[edvtipoconsclie]
                  ,[edvcompania]
                  ,[edvtipodocuclie]
                  ,[edvclasdocuclie]
                  ,[edvdivision]
                  ,[edvcliente]
                  ,[edvconcepto]
                  ,[edvmoneda]
                  ,[edvtotamoneloca]
                  ,[edvtotamonenego]
                  ,[edvcentroresp]
                  ,[eobusuario]
                  ,[edvfechexpe]
                  ,[edvfechaconta]
                  ,[edvvalobruto]
                  ,[edvvaloneto]
                  ,[edvfechinteobra]
                  ,[edvformapago]
                  ,[edvidentificador]
                    ,[edvcomentario])
	              (SELECT 
	              [edvconseingre]
                  ,[edvcontrol]
                  ,[edvvaloconimp]
                  ,[edvnumedocuclie]
                  ,[edvtipoconsclie]
                  ,[edvcompania]
                  ,[edvtipodocuclie]
                  ,[edvclasdocuclie]
                  ,[edvdivision]
                  ,[edvcliente]
                  ,[edvconcepto]
                  ,[edvmoneda]
                  ,[edvtotamoneloca]
                  ,[edvtotamonenego]
                  ,[edvcentroresp]
                  ,[eobusuario]
                  ,[edvfechexpe]
                  ,[edvfechaconta]
                  ,[edvvalobruto]
                  ,[edvvaloneto]
                  ,[edvfechinteobra]
                  ,[edvformapago]
                  ,[edvidentificador],[edvcomentario] FROM [104.196.158.138].[test_payc_contabilidad].[dbo].[VISTA_ENCDOCVTAENTRA_MULTIPLES_FACTURAS_PRUEBAS] 
                                      WHERE edvconseingre=" + COD_FACTURA.ToString() + @")";

                    //Consulta para importar detalle factura
                    string query2 = @"INSERT INTO [ssf_pruebas].[dbo].[ca_detdocvtaentra] 
                   ([ddvconseingre]
                  ,[ddvcontrol]
                  ,[ddvcompania]
                  ,[ddvnumedocu]
                  ,[ddvtipocons]
                  ,[ddvconseregis]
                  ,[ddvconcecxc]
                  ,[ddvunidaventa]
                  ,[ddvunidaempaq]
                  ,[ddvcanfacunivta]
                  ,[ddvcanfacuniemp]
                  ,[ddvprecunitbrut]
                  ,[ddvprecunitneto]
                  ,[ddvprectotabrut]
                  ,[ddvprectotaneto]
                  ,[ddvdivision]
                  ,[ddvcentrorespo]
                   ,[ddvcomentario])
                   (SELECT [ddvconseregis]
                  ,[ddvcontrol]
                  ,[ddvcompania]
                  ,[ddvnumedocu]
                  ,[ddvtipocons]
                  ,[ddvconseregis] AS ddvconseregis1
                  ,[ddvconcecxc]
                  ,[ddvunidaventa]
                  ,[ddvunidaempaq]
                  ,[ddvcanfacunivta]
                  ,[ddvcanfacuniemp]
                  ,[ddvprecunitbrut]
                  ,[ddvprecunitneto]
                  ,[ddvprectotabrut]
                  ,[ddvprectotaneto]
                  ,[ddvdivision]
                  ,[ddvcentrorespo],[ddvcomentario] FROM [104.196.158.138].[test_payc_contabilidad].[dbo].[VISTA_DETDOCVTAENTRA_MULTIPLES_FACTURAS_PRUEBAS] 
                                    WHERE ddvconseingre=" + COD_FACTURA.ToString() + @")";
                    //Insertar encabezado factura
                    using (SqlConnection connection = new SqlConnection(connectionString1))
                    {
                        SqlCommand command = new SqlCommand(query1, connection);
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }

                    //Insertar detalle factura
                    using (SqlConnection connection = new SqlConnection(connectionString1))
                    {
                        SqlCommand command = new SqlCommand(query2, connection);
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }

                    //Cambiar estado factura
                    FACTURAS factura = db.FACTURAS.Find(COD_FACTURA);
                    long cod = 3;
                    factura.COD_ESTADO_FACTURA = cod;
                    factura.NUMERO_FACTURA = maxnumfac.ToString();
                    db.SaveChanges();

                    //Enviar correo avisando el envío de facturas
                    Email.EnviarEmail("smtp.gmail.com", 587, "centro.costo.estado.payc@gmail.com",
                        "1234payc", "centro.costo.estado.payc@gmail.com",
                        "director.analitica@payc.com.co", "Factura importada",
                        "La factura con código " + maxnumfac.ToString() +
                        
                         " ha sido enviada para importación");

                    //Modificar consecutivo de tipo consecutivos en PSL
                    query = @"UPDATE [PAYC_REMOTO].[ssf_pruebas].[dbo].[un_tiposconse] 
                            SET [icculticonsasig] = '" + maxnumfac.ToString()
                            + @"' WHERE icccompania='01' AND icccodigo='F00'";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlCommand command = new SqlCommand(query, connection);
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }
                else
                {
                    result = "Error de identificación de maximo numero factura";
                }
            }
            catch (Exception ex)
            {
                result = ex.ToString();
            }
            return Json(new { success = true, responseText = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
        #region enviar a psl Productivo
    
        public ActionResult facturarP(long COD_FACTURA)
        {
            string result = "SI";
            //Consulta para importar encabezado factura
            try
            {
                //Traer codigo factura
                string query = @"SELECT MAX(CAST([edvnumedocuclie] AS INT)) AS MAX_CODIGO
                                 FROM [ssf_pruebas].[dbo].[ca_encdocvta] WHERE (edvtipoconsclie='F00' OR edvtipoconsclie='FI00') AND edvcompania='01' AND edvdivision='01'";

                string maxnumfac = "0";
                using (SqlConnection connection = new SqlConnection(connectionString1))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        maxnumfac = dr.GetValue(0).ToString();
                    }
                    connection.Close();
                }
                result = maxnumfac;
                //Si se logró traer el número de factura
                if (maxnumfac != "0")
                {
                    query = @"UPDATE [104.196.158.138].[test_payc_contabilidad].[dbo].[SECUENCIA_NUM_FACT_PSL_PRODUCTIVO] 
	                        SET [SECUENCIA_PSL] = (SELECT TOP 1 MAX(CAST([edvnumedocuclie] AS INT)) + 1 AS MAX_CODIGO
	                        FROM [ssf_pruebas].[dbo].[VISTA_MAXIMO_FACTURAS] 
	                        WHERE (edvtipoconsclie='F00' OR edvtipoconsclie='FI00') AND edvcompania='01' AND edvdivision='01')";
                    //Insertar encabezado factura
                    using (SqlConnection connection = new SqlConnection(connectionString1))
                    {
                        SqlCommand command = new SqlCommand(query, connection);
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }

                    //Extraer numero factura
                    query = "SELECT * FROM [test_payc_contabilidad].[dbo].[SECUENCIA_NUM_FACT_PSL_PRODUCTIVO]";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlCommand command = new SqlCommand(query, connection);
                        connection.Open();
                        SqlDataReader dr = command.ExecuteReader();
                        while (dr.Read())
                        {
                            maxnumfac = dr.GetValue(0).ToString();
                        }
                        connection.Close();
                    }

                    string query1 = @"INSERT INTO [ssf_pruebas].[dbo].[ca_encdocvtaentra] ([edvconseingre]
                  ,[edvcontrol]
                  ,[edvvaloconimp]
                  ,[edvnumedocuclie]
                  ,[edvtipoconsclie]
                  ,[edvcompania]
                  ,[edvtipodocuclie]
                  ,[edvclasdocuclie]
                  ,[edvdivision]
                  ,[edvcliente]
                  ,[edvconcepto]
                  ,[edvmoneda]
                  ,[edvtotamoneloca]
                  ,[edvtotamonenego]
                  ,[edvcentroresp]
                  ,[eobusuario]
                  ,[edvfechexpe]
                  ,[edvfechaconta]
                  ,[edvvalobruto]
                  ,[edvvaloneto]
                  ,[edvfechinteobra]
                  ,[edvformapago]
                  ,[edvidentificador]
                    ,[edvcomentario])
	              (SELECT 
	              [edvconseingre]
                  ,[edvcontrol]
                  ,[edvvaloconimp]
                  ,[edvnumedocuclie]
                  ,[edvtipoconsclie]
                  ,[edvcompania]
                  ,[edvtipodocuclie]
                  ,[edvclasdocuclie]
                  ,[edvdivision]
                  ,[edvcliente]
                  ,[edvconcepto]
                  ,[edvmoneda]
                  ,[edvtotamoneloca]
                  ,[edvtotamonenego]
                  ,[edvcentroresp]
                  ,[eobusuario]
                  ,[edvfechexpe]
                  ,[edvfechaconta]
                  ,[edvvalobruto]
                  ,[edvvaloneto]
                  ,[edvfechinteobra]
                  ,[edvformapago]
                  ,[edvidentificador],[edvcomentario] FROM [104.196.158.138].[test_payc_contabilidad].[dbo].[VISTA_ENCDOCVTAENTRA_MULTIPLES_FACTURAS_PRODUCTIVA] 
                                      WHERE edvconseingre=" + COD_FACTURA.ToString() + @")";

                    //Consulta para importar detalle factura
                    string query2 = @"INSERT INTO [ssf_pruebas].[dbo].[ca_detdocvtaentra] 
                   ([ddvconseingre]
                  ,[ddvcontrol]
                  ,[ddvcompania]
                  ,[ddvnumedocu]
                  ,[ddvtipocons]
                  ,[ddvconseregis]
                  ,[ddvconcecxc]
                  ,[ddvunidaventa]
                  ,[ddvunidaempaq]
                  ,[ddvcanfacunivta]
                  ,[ddvcanfacuniemp]
                  ,[ddvprecunitbrut]
                  ,[ddvprecunitneto]
                  ,[ddvprectotabrut]
                  ,[ddvprectotaneto]
                  ,[ddvdivision]
                  ,[ddvcentrorespo]
                   ,[ddvcomentario])
                   (SELECT [ddvconseregis]
                  ,[ddvcontrol]
                  ,[ddvcompania]
                  ,[ddvnumedocu]
                  ,[ddvtipocons]
                  ,[ddvconseregis] AS ddvconseregis1
                  ,[ddvconcecxc]
                  ,[ddvunidaventa]
                  ,[ddvunidaempaq]
                  ,[ddvcanfacunivta]
                  ,[ddvcanfacuniemp]
                  ,[ddvprecunitbrut]
                  ,[ddvprecunitneto]
                  ,[ddvprectotabrut]
                  ,[ddvprectotaneto]
                  ,[ddvdivision]
                  ,[ddvcentrorespo],[ddvcomentario] FROM [104.196.158.138].[test_payc_contabilidad].[dbo].[VISTA_DETDOCVTAENTRA_MULTIPLES_FACTURAS_PRODUCTIVA] 
                                    WHERE ddvconseingre=" + COD_FACTURA.ToString() + @")";
                    //Insertar encabezado factura
                    using (SqlConnection connection = new SqlConnection(connectionString1))
                    {
                        SqlCommand command = new SqlCommand(query1, connection);
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }

                    //Insertar detalle factura
                    using (SqlConnection connection = new SqlConnection(connectionString1))
                    {
                        SqlCommand command = new SqlCommand(query2, connection);
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }

                    //Cambiar estado factura
                    FACTURAS factura = db.FACTURAS.Find(COD_FACTURA);
                    long cod = 3;
                    factura.COD_ESTADO_FACTURA = cod;
                    factura.NUMERO_FACTURA_PRODUCTIVO= maxnumfac.ToString();
                    db.SaveChanges();

                    //Enviar correo avisando el envío de facturas
                    Email.EnviarEmail("smtp.gmail.com", 587, "centro.costo.estado.payc@gmail.com",
                        "1234payc", "centro.costo.estado.payc@gmail.com",
                        "director.analitica@payc.com.co", "Factura importada",
                        "La factura con código " + maxnumfac.ToString() +

                         " ha sido enviada para importación");

                    //Modificar consecutivo de tipo consecutivos en PSL
                    query = @"UPDATE [PAYC_REMOTO].[ssf_pruebas].[dbo].[un_tiposconse] 
                            SET [icculticonsasig] = '" + maxnumfac.ToString()
                            + @"' WHERE icccompania='01' AND icccodigo='F00'";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlCommand command = new SqlCommand(query, connection);
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }
                else
                {
                    result = "Error de identificación de maximo numero factura";
                }
            }
            catch (Exception ex)
            {
                result = ex.ToString();
            }
            return Json(new { success = true, responseText = result }, JsonRequestBehavior.AllowGet);
        }


        #endregion
    }
}
