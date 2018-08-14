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
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.AspNet.Identity;
namespace syncfusion_payc.Controllers
{
    public class CONTRATO_COLABORADORController : Controller
    {
        private test_payc_contabilidadEntities db = new test_payc_contabilidadEntities();
        static string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection1"].ConnectionString;
        #region vistas
        // GET: CONTRATO_COLABORADOR
        public ActionResult Index()
        {
            var cONTRATO_COLABORADOR = db.CONTRATO_COLABORADOR.Include(c => c.COLABORADORES).Include(c => c.ROLES);
            return View(cONTRATO_COLABORADOR.ToList());
        }
        public ActionResult Pendientes()
        {
            var pENDIENTES = db.PENDIENTES;
            
            return View(pENDIENTES.ToList());
        }
        #endregion
        #region acciones bd
        // GET: CONTRATO_COLABORADOR/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CONTRATO_COLABORADOR cONTRATO_COLABORADOR = db.CONTRATO_COLABORADOR.Find(id);
            if (cONTRATO_COLABORADOR == null)
            {
                return HttpNotFound();
            }
            return View(cONTRATO_COLABORADOR);
        }

        // GET: CONTRATO_COLABORADOR/Create
        public ActionResult Create()
        {
            ViewBag.COD_COLABORADOR = new SelectList(db.COLABORADORES, "COD_COLABORADOR", "DESCRIPCION");
            ViewBag.COD_ROL = new SelectList(db.ROLES, "COD_ROL", "DESCRIPCION");
            return View();
        }

        // POST: CONTRATO_COLABORADOR/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COD_CONTRATO_COLABORADOR,COD_COLABORADOR,COD_CONTRATO_PROYECTO,COD_ROL,FECHA_INI,FECHA_FIN")] CONTRATO_COLABORADOR cONTRATO_COLABORADOR)
        {
            if (ModelState.IsValid)
            {
                db.CONTRATO_COLABORADOR.Add(cONTRATO_COLABORADOR);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.COD_COLABORADOR = new SelectList(db.COLABORADORES, "COD_COLABORADOR", "DESCRIPCION", cONTRATO_COLABORADOR.COD_COLABORADOR);
            ViewBag.COD_ROL = new SelectList(db.ROLES, "COD_ROL", "DESCRIPCION", cONTRATO_COLABORADOR.COD_ROL);
            return View(cONTRATO_COLABORADOR);
        }

        // GET: CONTRATO_COLABORADOR/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CONTRATO_COLABORADOR cONTRATO_COLABORADOR = db.CONTRATO_COLABORADOR.Find(id);
            if (cONTRATO_COLABORADOR == null)
            {
                return HttpNotFound();
            }
            ViewBag.COD_COLABORADOR = new SelectList(db.COLABORADORES, "COD_COLABORADOR", "DESCRIPCION", cONTRATO_COLABORADOR.COD_COLABORADOR);
            ViewBag.COD_ROL = new SelectList(db.ROLES, "COD_ROL", "DESCRIPCION", cONTRATO_COLABORADOR.COD_ROL);
            return View(cONTRATO_COLABORADOR);
        }

        // POST: CONTRATO_COLABORADOR/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COD_CONTRATO_COLABORADOR,COD_COLABORADOR,COD_CONTRATO_PROYECTO,COD_ROL,FECHA_INI,FECHA_FIN")] CONTRATO_COLABORADOR cONTRATO_COLABORADOR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cONTRATO_COLABORADOR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.COD_COLABORADOR = new SelectList(db.COLABORADORES, "COD_COLABORADOR", "DESCRIPCION", cONTRATO_COLABORADOR.COD_COLABORADOR);
            ViewBag.COD_ROL = new SelectList(db.ROLES, "COD_ROL", "DESCRIPCION", cONTRATO_COLABORADOR.COD_ROL);
            return View(cONTRATO_COLABORADOR);
        }

        // GET: CONTRATO_COLABORADOR/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CONTRATO_COLABORADOR cONTRATO_COLABORADOR = db.CONTRATO_COLABORADOR.Find(id);
            if (cONTRATO_COLABORADOR == null)
            {
                return HttpNotFound();
            }
            return View(cONTRATO_COLABORADOR);
        }

        // POST: CONTRATO_COLABORADOR/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            CONTRATO_COLABORADOR cONTRATO_COLABORADOR = db.CONTRATO_COLABORADOR.Find(id);
            db.CONTRATO_COLABORADOR.Remove(cONTRATO_COLABORADOR);
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

        #endregion
        #region grids
        public ActionResult UrlAdaptor()
        {
            var DataSource2 = db.CONTRATO_COLABORADOR.ToList();
            ViewBag.dataSource2 = DataSource2;
            return View();
        }

        //Traer datos de contrato colaborador
		public ActionResult GetOrderData(DataManager dm)
        {
            IEnumerable DataSource = db.CONTRATO_COLABORADOR_COMERCIAL.ToList();
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
            var count = DataSource.Cast<CONTRATO_COLABORADOR_COMERCIAL>().Count();
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
        public ActionResult PerformInsert(EditParams_CONTRATO_COLABORADOR_COMERCIAL param)
        {

            CONTRATO_COLABORADOR cont = new CONTRATO_COLABORADOR();
            cont.COD_CONTRATO_PROYECTO = param.value.COD_CONTRATO_PROYECTO;
            cont.COD_ROL = param.value.COD_ROL;
            cont.FECHA_FIN = param.value.FECHA_FIN;
            cont.FECHA_INI = param.value.FECHA_INI_COLABORADOR;
            cont.COD_COLABORADOR = param.value.COD_COLABORADOR;
            db.CONTRATO_COLABORADOR.Add(cont);
            db.SaveChanges();
			var data = db.CONTRATO_COLABORADOR.ToList();
			var value = data.Last();
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        //Actualizar grid
        public ActionResult PerformUpdate(EditParams_CONTRATO_COLABORADOR_COMERCIAL param)
        {
            
			CONTRATO_COLABORADOR table = db.CONTRATO_COLABORADOR.Single(o => o.COD_CONTRATO_COLABORADOR == param.value.COD_CONTRATO_COLABORADOR);
            
            table.COD_CONTRATO_PROYECTO = param.value.COD_CONTRATO_PROYECTO;
            table.COD_ROL = param.value.COD_ROL;
            table.FECHA_FIN = param.value.FECHA_FIN;
            table.FECHA_INI = param.value.FECHA_INI_COLABORADOR;
            table.COD_COLABORADOR = param.value.COD_COLABORADOR;
            
            db.SaveChanges();
			return RedirectToAction("GetOrderData");
			
        }

        //Borrar grid
        public ActionResult PerformDelete(int key, string keyColumn)
        {
            db.CONTRATO_COLABORADOR.Remove(db.CONTRATO_COLABORADOR.Single(o => o.COD_CONTRATO_COLABORADOR== key));
            db.SaveChanges();
            return RedirectToAction("GetOrderData");
            
        }

        //traer datos de pendientes
        public ActionResult GetOrderData_pendientes(DataManager dm)
        {
            IEnumerable DataSource = db.PENDIENTES.ToList();
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
            var count = DataSource.Cast<PENDIENTES>().Count();
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

        //Traer datos de contrato proyecto
        public ActionResult GetOrderData_contrato_proyecto(DataManager dm)
        {
            IEnumerable DataSource = db.CONTRATO_COLABORADOR_INDEX.ToList();
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
            var count = DataSource.Cast<CONTRATO_COLABORADOR_INDEX> ().Count();
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

        //Insert contrato proyecto
        public ActionResult PerformInsert_contrato_proyecto(EditParams_CONTRATO_PROYECTO param)
        {
            db.CONTRATO_PROYECTO.Add(param.value);
            db.SaveChanges();
            var data = db.CONTRATO_PROYECTO.ToList();
            var value = data.Last();
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        //Actualizar grid contrato proyecto
        public ActionResult PerformUpdate_contrato_proyecto(EditParams_CONTRATO_PROYECTO param)
        {

            CONTRATO_PROYECTO table = db.CONTRATO_PROYECTO.Single(o => o.COD_CONTRATO_PROYECTO == param.value.COD_CONTRATO_PROYECTO);

            db.Entry(table).CurrentValues.SetValues(param.value);
            db.SaveChanges();
            return RedirectToAction("GetOrderData");

        }

        //Borrar grid contrato proyecto
        public ActionResult PerformDelete_contrato_proyecto(int key, string keyColumn)
        {
            db.CONTRATO_PROYECTO.Remove(db.CONTRATO_PROYECTO.Single(o => o.COD_CONTRATO_PROYECTO == key));
            db.SaveChanges();
            return RedirectToAction("GetOrderData");

        }
        #endregion
        #region generacion de colaboradores pendientes
        //Query para recalcular

        //Funcion para regenerar el flujo del rol
        public ActionResult generar_colaboradores_pendientes(long COD_CONTRATO_PROYECTO)
        {
            //Query para recalcular
            string queryString = @"INSERT INTO [test_payc_contabilidad].[dbo].[CONTRATO_COLABORADOR]
                                    ([COD_CONTRATO_PROYECTO]
                                    ,[COD_ROL]
                                    ,[FECHA_FIN]) 
                                    (SELECT [COD_CONTRATO_PROYECTO]
                                    ,[COD_ROL]
                                    ,[FECHA_FIN] 
                                    FROM [test_payc_contabilidad].[dbo].[GENERACION_COLABORADORES_PENDIENTES] 
                                    WHERE COD_CONTRATO_PROYECTO=" + COD_CONTRATO_PROYECTO.ToString() + @"
                                    AND COD_ROL IS NOT NULL AND FECHA_FIN IS NOT NULL
);";
            
            //Ejecución del query
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                connection.Open();
                command.ExecuteNonQuery();
            }
            return Json(new { success = true, responseText = "SI" }, JsonRequestBehavior.AllowGet);
        }

        //Funcion para validar asignación
        public ActionResult validar_asignacion(long COD_CONTRATO_PROYECTO)
        {
            List<string> mensaje_error = new List<string>();
            int vacios = 0;
            
            string queryString = @"SELECT ISNULL(COD_COLABORADOR,null) AS COD_COLABORADOR, 
                            ISNULL(COD_ROL,null) AS COD_ROL,
                            ISNULL(FECHA_INI,null) AS FECHA_INI,
                            ISNULL(FECHA_FIN,null) AS FECHA_FIN 
                            FROM [test_payc_contabilidad].[dbo].[CONTRATO_COLABORADOR] 
                            WHERE COD_CONTRATO_PROYECTO=" + COD_CONTRATO_PROYECTO.ToString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                int col_colaborador = 0;
                int col_rol = 1;

                int col_fecha_ini = 2;
                int col_fecha_fin = 3;
                connection.Open();
                SqlCommand command = new SqlCommand(queryString, connection);

                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        
                        if (reader.IsDBNull(col_colaborador) || reader.IsDBNull(col_rol) || reader.IsDBNull(col_fecha_ini) || reader.IsDBNull(col_fecha_fin))
                        {
                            vacios = vacios + 1;
                            if (reader.IsDBNull(col_rol))
                            {
                                mensaje_error.Add("Exite un rol vacio");
                            }
                            else
                            {
                                long rol_error = Convert.ToInt64(reader["COD_ROL"].ToString());
                                ROLES table = db.ROLES.Single(o => o.COD_ROL == rol_error);
                                mensaje_error.Add("El rol " + table.DESCRIPCION + " cuenta con campos vacíos");
                            }
                        }

                    }
                }
                connection.Close();
            }
            
            if (vacios == 0)
            {
                //Check pendientes
                int roles_pendientes = 0;
                queryString = @"SELECT  [COD_ROL],
		                        [ROL_TEXTO]
                                ,MIN([FECHA_FORMA_PAGO]) AS FECHA_INI_VACIO
	                            ,MAX([FECHA_FORMA_PAGO]) AS FECHA_FIN_VACIO
                                ,[COD_COLABORADOR]
                                ,[NOMBRE]
                                FROM [test_payc_contabilidad].[dbo].[ORDENES_SERVICIO_ROLES_COLABORADOR] WHERE COD_COLABORADOR IS NULL AND COD_CONTRATO_PROYECTO=" + COD_CONTRATO_PROYECTO.ToString() + @"
                                GROUP BY COD_ROL, ROL_TEXTO, COD_COLABORADOR, NOMBRE";
                
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(queryString, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            if (reader["FECHA_INI_VACIO"].ToString() != reader["FECHA_FIN_VACIO"].ToString()) {
                                roles_pendientes = roles_pendientes + 1;
                                mensaje_error.Add("El rol " + reader["ROL_TEXTO"].ToString() + " no cuenta con colaboradores asignados para las fechas entre " + reader["FECHA_INI_VACIO"].ToString() + " y " + reader["FECHA_FIN_VACIO"].ToString());
                            }
                        }
                    }
                    connection.Close();
                }
                if (roles_pendientes == 0)
                {
                    //Check colaborador duplicado
                    queryString = @"SELECT * FROM [test_payc_contabilidad].[dbo].[CHECK_COLABORADOR_MES] WHERE COD_CONTRATO_PROYECTO=" + COD_CONTRATO_PROYECTO.ToString() + @"
                                    AND CUENTA>1";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(queryString, connection);
                        
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                mensaje_error.Add("El rol " + reader["ROL_TEXTO"].ToString() + " Cuenta con más de un colaborador para la fecha: " + reader["FECHA_FORMA_PAGO"].ToString());
                            }
                        }
                        connection.Close();
                    }
                }

            }
            
            return Json(new { success = true, responseText = "SI",data=mensaje_error }, "application/json", JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
