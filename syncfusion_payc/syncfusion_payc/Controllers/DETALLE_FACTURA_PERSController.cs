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
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using syncfusion_payc.Models;
using Microsoft.AspNet.Identity;

namespace syncfusion_payc.Controllers
{
    public class DETALLE_FACTURA_PERSController : Controller
    {
        private test_payc_contabilidadEntities db = new test_payc_contabilidadEntities();
        static string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection1"].ConnectionString;
        // GET: DETALLE_FACTURA_PERS
        public ActionResult Index()
        {
            var dETALLE_FACTURA_PERS = db.DETALLE_FACTURA_PERS.Include(d => d.CAUSA_ESTADO).Include(d => d.CONCEPTOS).Include(d => d.CONTRATO_PROYECTO).Include(d => d.ROLES).Include(d => d.ESTADOS_DETALLE).Include(d => d.ESTADOS_FACTURAS).Include(d => d.FACTURAS).Include(d => d.FORMAS_PAGO_FECHAS);
            return View(dETALLE_FACTURA_PERS.ToList());
        }

        // GET: DETALLE_FACTURA_PERS/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DETALLE_FACTURA_PERS dETALLE_FACTURA_PERS = db.DETALLE_FACTURA_PERS.Find(id);
            if (dETALLE_FACTURA_PERS == null)
            {
                return HttpNotFound();
            }
            return View(dETALLE_FACTURA_PERS);
        }

        // GET: DETALLE_FACTURA_PERS/Create
        public ActionResult Create()
        {
            ViewBag.COD_CAUSA_ESTADO = new SelectList(db.CAUSA_ESTADO, "COD_CAUSA_ESTADO", "DESCRIPCION");
            ViewBag.COD_CONCEPTO_PSL = new SelectList(db.CONCEPTOS, "COD_CONCEPTO_PSL", "CODIGO_EN_PSL");
            ViewBag.COD_CONTRATO_PROYECTO = new SelectList(db.CONTRATO_PROYECTO, "COD_CONTRATO_PROYECTO", "COMPLETA");
            ViewBag.COD_ROL = new SelectList(db.ROLES, "COD_ROL", "DESCRIPCION");
            ViewBag.COD_ESTADO_DETALLE = new SelectList(db.ESTADOS_DETALLE, "COD_ESTADO_DETALLE", "DESCRIPCION");
            ViewBag.COD_ESTADO_FACTURA = new SelectList(db.ESTADOS_FACTURAS, "COD_ESTADO_FACTURA", "DESCRIPCION");
            ViewBag.COD_FACTURA = new SelectList(db.FACTURAS, "COD_FACTURA", "NUMERO_FACTURA");
            ViewBag.COD_FORMAS_PAGO_FECHAS = new SelectList(db.FORMAS_PAGO_FECHAS, "COD_FORMAS_PAGO_FECHAS", "PERIODO_TEXTO");
            return View();
        }

        // POST: DETALLE_FACTURA_PERS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COD_DETALLE_FACTURA_PERS,COD_CONTRATO_PROYECTO,COD_ROL,COD_FORMAS_PAGO_FECHAS,VALOR_SIN_IMPUESTOS,FECHA_REGISTRO,USUARIO,COD_ESTADO_FACTURA,COD_CAUSA_ESTADO,OBSERVACIONES,COD_FACTURA,COD_ESTADO_DETALLE,COD_CONCEPTO_PSL")] DETALLE_FACTURA_PERS dETALLE_FACTURA_PERS)
        {
            if (ModelState.IsValid)
            {
                db.DETALLE_FACTURA_PERS.Add(dETALLE_FACTURA_PERS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.COD_CAUSA_ESTADO = new SelectList(db.CAUSA_ESTADO, "COD_CAUSA_ESTADO", "DESCRIPCION", dETALLE_FACTURA_PERS.COD_CAUSA_ESTADO);
            ViewBag.COD_CONCEPTO_PSL = new SelectList(db.CONCEPTOS, "COD_CONCEPTO_PSL", "CODIGO_EN_PSL", dETALLE_FACTURA_PERS.COD_CONCEPTO_PSL);
            ViewBag.COD_CONTRATO_PROYECTO = new SelectList(db.CONTRATO_PROYECTO, "COD_CONTRATO_PROYECTO", "COMPLETA", dETALLE_FACTURA_PERS.COD_CONTRATO_PROYECTO);
            ViewBag.COD_ROL = new SelectList(db.ROLES, "COD_ROL", "DESCRIPCION", dETALLE_FACTURA_PERS.COD_ROL);
            ViewBag.COD_ESTADO_DETALLE = new SelectList(db.ESTADOS_DETALLE, "COD_ESTADO_DETALLE", "DESCRIPCION", dETALLE_FACTURA_PERS.COD_ESTADO_DETALLE);
            ViewBag.COD_ESTADO_FACTURA = new SelectList(db.ESTADOS_FACTURAS, "COD_ESTADO_FACTURA", "DESCRIPCION", dETALLE_FACTURA_PERS.COD_ESTADO_FACTURA);
            ViewBag.COD_FACTURA = new SelectList(db.FACTURAS, "COD_FACTURA", "NUMERO_FACTURA", dETALLE_FACTURA_PERS.COD_FACTURA);
            ViewBag.COD_FORMAS_PAGO_FECHAS = new SelectList(db.FORMAS_PAGO_FECHAS, "COD_FORMAS_PAGO_FECHAS", "PERIODO_TEXTO", dETALLE_FACTURA_PERS.COD_FORMAS_PAGO_FECHAS);
            return View(dETALLE_FACTURA_PERS);
        }

        // GET: DETALLE_FACTURA_PERS/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DETALLE_FACTURA_PERS dETALLE_FACTURA_PERS = db.DETALLE_FACTURA_PERS.Find(id);
            if (dETALLE_FACTURA_PERS == null)
            {
                return HttpNotFound();
            }
            ViewBag.COD_CAUSA_ESTADO = new SelectList(db.CAUSA_ESTADO, "COD_CAUSA_ESTADO", "DESCRIPCION", dETALLE_FACTURA_PERS.COD_CAUSA_ESTADO);
            ViewBag.COD_CONCEPTO_PSL = new SelectList(db.CONCEPTOS, "COD_CONCEPTO_PSL", "CODIGO_EN_PSL", dETALLE_FACTURA_PERS.COD_CONCEPTO_PSL);
            ViewBag.COD_CONTRATO_PROYECTO = new SelectList(db.CONTRATO_PROYECTO, "COD_CONTRATO_PROYECTO", "COMPLETA", dETALLE_FACTURA_PERS.COD_CONTRATO_PROYECTO);
            ViewBag.COD_ROL = new SelectList(db.ROLES, "COD_ROL", "DESCRIPCION", dETALLE_FACTURA_PERS.COD_ROL);
            ViewBag.COD_ESTADO_DETALLE = new SelectList(db.ESTADOS_DETALLE, "COD_ESTADO_DETALLE", "DESCRIPCION", dETALLE_FACTURA_PERS.COD_ESTADO_DETALLE);
            ViewBag.COD_ESTADO_FACTURA = new SelectList(db.ESTADOS_FACTURAS, "COD_ESTADO_FACTURA", "DESCRIPCION", dETALLE_FACTURA_PERS.COD_ESTADO_FACTURA);
            ViewBag.COD_FACTURA = new SelectList(db.FACTURAS, "COD_FACTURA", "NUMERO_FACTURA", dETALLE_FACTURA_PERS.COD_FACTURA);
            ViewBag.COD_FORMAS_PAGO_FECHAS = new SelectList(db.FORMAS_PAGO_FECHAS, "COD_FORMAS_PAGO_FECHAS", "PERIODO_TEXTO", dETALLE_FACTURA_PERS.COD_FORMAS_PAGO_FECHAS);
            return View(dETALLE_FACTURA_PERS);
        }

        // POST: DETALLE_FACTURA_PERS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COD_DETALLE_FACTURA_PERS,COD_CONTRATO_PROYECTO,COD_ROL,COD_FORMAS_PAGO_FECHAS,VALOR_SIN_IMPUESTOS,FECHA_REGISTRO,USUARIO,COD_ESTADO_FACTURA,COD_CAUSA_ESTADO,OBSERVACIONES,COD_FACTURA,COD_ESTADO_DETALLE,COD_CONCEPTO_PSL")] DETALLE_FACTURA_PERS dETALLE_FACTURA_PERS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dETALLE_FACTURA_PERS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.COD_CAUSA_ESTADO = new SelectList(db.CAUSA_ESTADO, "COD_CAUSA_ESTADO", "DESCRIPCION", dETALLE_FACTURA_PERS.COD_CAUSA_ESTADO);
            ViewBag.COD_CONCEPTO_PSL = new SelectList(db.CONCEPTOS, "COD_CONCEPTO_PSL", "CODIGO_EN_PSL", dETALLE_FACTURA_PERS.COD_CONCEPTO_PSL);
            ViewBag.COD_CONTRATO_PROYECTO = new SelectList(db.CONTRATO_PROYECTO, "COD_CONTRATO_PROYECTO", "COMPLETA", dETALLE_FACTURA_PERS.COD_CONTRATO_PROYECTO);
            ViewBag.COD_ROL = new SelectList(db.ROLES, "COD_ROL", "DESCRIPCION", dETALLE_FACTURA_PERS.COD_ROL);
            ViewBag.COD_ESTADO_DETALLE = new SelectList(db.ESTADOS_DETALLE, "COD_ESTADO_DETALLE", "DESCRIPCION", dETALLE_FACTURA_PERS.COD_ESTADO_DETALLE);
            ViewBag.COD_ESTADO_FACTURA = new SelectList(db.ESTADOS_FACTURAS, "COD_ESTADO_FACTURA", "DESCRIPCION", dETALLE_FACTURA_PERS.COD_ESTADO_FACTURA);
            ViewBag.COD_FACTURA = new SelectList(db.FACTURAS, "COD_FACTURA", "NUMERO_FACTURA", dETALLE_FACTURA_PERS.COD_FACTURA);
            ViewBag.COD_FORMAS_PAGO_FECHAS = new SelectList(db.FORMAS_PAGO_FECHAS, "COD_FORMAS_PAGO_FECHAS", "PERIODO_TEXTO", dETALLE_FACTURA_PERS.COD_FORMAS_PAGO_FECHAS);
            return View(dETALLE_FACTURA_PERS);
        }

        // GET: DETALLE_FACTURA_PERS/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DETALLE_FACTURA_PERS dETALLE_FACTURA_PERS = db.DETALLE_FACTURA_PERS.Find(id);
            if (dETALLE_FACTURA_PERS == null)
            {
                return HttpNotFound();
            }
            return View(dETALLE_FACTURA_PERS);
        }

        // POST: DETALLE_FACTURA_PERS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            DETALLE_FACTURA_PERS dETALLE_FACTURA_PERS = db.DETALLE_FACTURA_PERS.Find(id);
            db.DETALLE_FACTURA_PERS.Remove(dETALLE_FACTURA_PERS);
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
            var DataSource2 = db.DETALLE_FACTURA_PERS.ToList();
            ViewBag.dataSource2 = DataSource2;
            return View();
        }	
		public ActionResult GetOrderData(DataManager dm)
        {
            IEnumerable DataSource = db.DETALLE_FACTURA_PERS.ToList();
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
            var count = DataSource.Cast<DETALLE_FACTURA_PERS>().Count();
            if (dm.Skip != 0)
            {
                DataSource = ds.PerformSkip(DataSource, dm.Skip);
            }
            if (dm.Take != 0)
            {
                DataSource = ds.PerformTake(DataSource, dm.Take);
            }
            return Json(new { result = DataSource, count = count, aggregate = aggregate }, JsonRequestBehavior.AllowGet);     
        }

        //Perform file insertion 
        //Recibe el objeto editparams con nombre param, este contiene en param.value recibida de lado del cliente, es decir, la información a guardar.

        public ActionResult PerformInsert(EditParams_DETALLE_FACTURA_PERS param)
        {
            DateTime hoy = DateTime.Today;
            string usuario = User.Identity.GetUserName();
            param.value.FECHA_REGISTRO = hoy;
            param.value.USUARIO = usuario;
            param.value.COD_ESTADO_DETALLE = 1;
            db.DETALLE_FACTURA_PERS.Add(param.value);
            db.SaveChanges();
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
            }
            catch (Exception ex)
            {

            }
           var data = db.DETALLE_FACTURA_PERS.ToList();
           var value = data.Last();
           return Json(value, JsonRequestBehavior.AllowGet);

        }


        //Actualizar grid
        public ActionResult PerformUpdate(EditParams_DETALLE_FACTURA_PERS param)
        {

            DateTime hoy = DateTime.Today;
            string usuario = User.Identity.GetUserName();
            DETALLE_FACTURA_PERS table = db.DETALLE_FACTURA_PERS.Single(o => o.COD_DETALLE_FACTURA_PERS== param.value.COD_DETALLE_FACTURA_PERS);
            if (table.VALOR_SIN_IMPUESTOS != param.value.VALOR_SIN_IMPUESTOS)
            {
                param.value.FECHA_REGISTRO = hoy;
                param.value.USUARIO = usuario;
                db.DETALLE_FACTURA_PERS.Add(param.value);
                table.COD_ESTADO_DETALLE = 2;

            }
            else
            {
                table.FECHA_REGISTRO = hoy;
                table.USUARIO = usuario;
                table.COD_ESTADO_DETALLE = 1;
                table.COD_CONCEPTO_PSL = param.value.COD_CONCEPTO_PSL;
                table.COD_GRUPO_FACTURA = param.value.COD_GRUPO_FACTURA;
            }
            db.SaveChanges();
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
            }
            catch (Exception ex)
            {

            }
            return RedirectToAction("GetOrderData");

        }

        //Borrar grid
        public ActionResult PerformDelete(int key, string keyColumn)
        {
            db.DETALLE_FACTURA_PERS.Remove(db.DETALLE_FACTURA_PERS.Single(o => o.COD_DETALLE_FACTURA_PERS== key));
            db.SaveChanges();
            return RedirectToAction("GetOrderData");
            
        }
    }
}
