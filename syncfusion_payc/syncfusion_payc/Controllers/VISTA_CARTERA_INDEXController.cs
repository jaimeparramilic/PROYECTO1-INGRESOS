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
    public class VISTA_CARTERA_INDEXController : Controller
    {
        private test_payc_contabilidadEntities db = new test_payc_contabilidadEntities();

        // GET: VISTA_CARTERA_INDEX
        public ActionResult Index()
        {
            int ret = 0;
            string error = "";
            // Insertar facturas q falten en tabla CARTERA
            error = Utilidades.Cartera.IniciarCartera(out ret);
            
            return View(db.VISTA_CARTERA_INDEX.ToList());
        }

        public ActionResult Asignar(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Insertar fila en tabla ASIGNACION_CARTERA
            // *** PENDIENTE validar que no exista ya para este COD_CARTERA
            int cod_ret = 0;
            string sql_ins, error = "", temp;
            var user = User.Identity;
            string usuar = user.Name;
            if (usuar == null) { usuar = "Name"; };
            DateTime now = DateTime.Now.Date;
            sql_ins = "INSERT INTO ASIGNACION_CARTERA (COD_CARTERA,UserName,FECHA_ASIGNACION) "
                + "VALUES(" + id.ToString() + ", \"" + usuar + "\", \"" + now.ToShortDateString() + "\" );";
            sql_ins = sql_ins.Replace("\"", "'");
            //temp = "INSERT INTO xTEMPO (texto) VALUES ('"+ sql_ins + "');";
            //error = Utilidades.ExecSQL.ExecNoQuery(temp, out cod_ret);
            error = Utilidades.ExecSQL.ExecNoQuery(sql_ins, out cod_ret);

            ViewBag.COD_CARTERA = id;
            var aSIGNACION_CARTERA = db.ASIGNACION_CARTERA.Include(a => a.CARTERA);
            return View(aSIGNACION_CARTERA.ToList());
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

        //Traer data

        
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
            
			VISTA_CARTERA_INDEX table = db.VISTA_CARTERA_INDEX.Single(o => o.COD_CLIENTE == param.value.COD_CLIENTE);

            db.Entry(table).CurrentValues.SetValues(param.value);
            db.SaveChanges();
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


    }
}
