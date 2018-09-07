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
namespace syncfusion_payc.Controllers
{
    public class FACTURASController : Controller
    {
        private test_payc_contabilidadEntities db = new test_payc_contabilidadEntities();
        static string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection1"].ConnectionString;
        #region vistas / acciones default
        // GET: FACTURAS
        public ActionResult Index()
        {
            var fACTURAS = db.FACTURAS.Include(f => f.CONTRATO_PROYECTO).Include(f => f.ESTADOS_FACTURAS).Include(f => f.FORMAS_PAGO_FECHAS);
            return View(fACTURAS.ToList());
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
            IEnumerable DataSource = db.VISTA_CONTRATO_PROYECTO_FACTURAS.ToList();
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
            var count = DataSource.Cast<VISTA_CONTRATO_PROYECTO_FACTURAS>().Count();
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
            DateTime temp_fecha = new DateTime(param.value.FECHA_FACTURA.Value.Year, param.value.FECHA_FACTURA.Value.Month, 1);
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
            string result = string.Empty;

            try
            {

                //Funcion
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Modelos_Matematicos") + @"\valor_facturar_temp.R";

                //
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

                //ViewBag.Result = result + "," + rCodeFilePath;
                result = result + "," + rCodeFilePath + "," + path;
            }
            catch (Exception ex)
            {

                //throw new Exception("R Script failed: " + result, ex);
                result = ex.ToString() + "," + rCodeFilePath ;
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
                table1.VALOR_SIN_IMPUESTOS = float.Parse(valor_factura);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

            }
            return Json(new { success = true, responseText = result }, JsonRequestBehavior.AllowGet);
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

    }
}
