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

namespace syncfusion_payc.Controllers
{
    public class COLABORADORESController : Controller
    {
        private test_payc_contabilidadEntities db = new test_payc_contabilidadEntities();

        // GET: COLABORADORES
        public ActionResult Index()
        {
            var cOLABORADORES = db.COLABORADORES.Include(c => c.CARGOS);
            return View(cOLABORADORES.ToList());
        }

        // VISTA RETIROS
        public ActionResult Retiros()
        {
            
            return View();
        }

        // GET: COLABORADORES/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COLABORADORES cOLABORADORES = db.COLABORADORES.Find(id);
            if (cOLABORADORES == null)
            {
                return HttpNotFound();
            }
            return View(cOLABORADORES);
        }

        // GET: COLABORADORES/Create
        public ActionResult Create()
        {
            ViewBag.COD_CARGO = new SelectList(db.CARGOS, "COD_CARGO", "DESCRIPCION_CARGO");
            return View();
        }

        // POST: COLABORADORES/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COD_COLABORADOR,DESCRIPCION,CEDULA,GENERO,FECHA_NACIMIENTO,CELULAR,CORREO_ELECTRONICO,ESTADO_CIVIL,CENTROS_COSTOS,FECHA_INGRESO,TIPO_DE_CONTRATO,COD_CARGO,ESTADO")] COLABORADORES cOLABORADORES)
        {
            if (ModelState.IsValid)
            {
                db.COLABORADORES.Add(cOLABORADORES);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.COD_CARGO = new SelectList(db.CARGOS, "COD_CARGO", "DESCRIPCION_CARGO", cOLABORADORES.COD_CARGO);
            return View(cOLABORADORES);
        }

        // GET: COLABORADORES/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COLABORADORES cOLABORADORES = db.COLABORADORES.Find(id);
            if (cOLABORADORES == null)
            {
                return HttpNotFound();
            }
            ViewBag.COD_CARGO = new SelectList(db.CARGOS, "COD_CARGO", "DESCRIPCION_CARGO", cOLABORADORES.COD_CARGO);
            return View(cOLABORADORES);
        }

        // POST: COLABORADORES/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COD_COLABORADOR,DESCRIPCION,CEDULA,GENERO,FECHA_NACIMIENTO,CELULAR,CORREO_ELECTRONICO,ESTADO_CIVIL,CENTROS_COSTOS,FECHA_INGRESO,TIPO_DE_CONTRATO,COD_CARGO,ESTADO")] COLABORADORES cOLABORADORES)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cOLABORADORES).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.COD_CARGO = new SelectList(db.CARGOS, "COD_CARGO", "DESCRIPCION_CARGO", cOLABORADORES.COD_CARGO);
            return View(cOLABORADORES);
        }

        // GET: COLABORADORES/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COLABORADORES cOLABORADORES = db.COLABORADORES.Find(id);
            if (cOLABORADORES == null)
            {
                return HttpNotFound();
            }
            return View(cOLABORADORES);
        }

        // POST: COLABORADORES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            COLABORADORES cOLABORADORES = db.COLABORADORES.Find(id);
            db.COLABORADORES.Remove(cOLABORADORES);
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
            var DataSource2 = db.COLABORADORES.ToList();
            ViewBag.dataSource2 = DataSource2;
            return View();
        }	
		public ActionResult GetOrderData(DataManager dm)
        {
            IEnumerable DataSource = db.COLARADORES_CONCAT_ESTUDIOS.ToList();
            //IEnumerable DataSource2 = db.ESTUDIOS_COLABORADOR.ToList();
            
            DataOperations ds = new DataOperations();
            List<string> str = new List<string>();
            db.Configuration.ProxyCreationEnabled = false;
            db.Configuration.LazyLoadingEnabled = false;
			if (dm.Search != null && dm.Search.Count > 0)
            {
                DataSource = ds.PerformSearching(DataSource, dm.Search);
                
                //DataSource2 = ds.PerformSearching(DataSource2, dm.Search);
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
            var count = DataSource.Cast<COLARADORES_CONCAT_ESTUDIOS>().Count();
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
        public ActionResult PerformInsert(EditParams_COLABORADORES_CONCAT_ESTUDIOS param)
        {
            COLABORADORES temp = new COLABORADORES();
            temp.COD_CARGO = param.value.COD_CARGO;
            temp.CEDULA = param.value.CEDULA;
            temp.CELULAR = param.value.CELULAR;
            temp.CENTROS_COSTOS = param.value.CENTROS_COSTOS;
            temp.CORREO_ELECTRONICO = param.value.CORREO_ELECTRONICO;
            temp.NOMBRES = param.value.NOMBRES;
            temp.APELLIDOS = param.value.APELLIDOS;
            temp.DESCRIPCION = param.value.NOMBRES + " " + param.value.APELLIDOS;
            temp.COD_ESTADO_COLABORADOR = param.value.COD_ESTADO_COLABORADOR;
            temp.ESTADO_CIVIL = param.value.ESTADO_CIVIL;
            temp.FECHA_INGRESO = param.value.FECHA_INGRESO;
            temp.FECHA_NACIMIENTO = param.value.FECHA_NACIMIENTO;
            temp.COD_GENERO = param.value.COD_GENERO;
            temp.COD_TIPO_DE_CONTRATO = param.value.COD_TIPO_DE_CONTRATO;
            db.COLABORADORES.Add(temp);
            db.SaveChanges();
			var data = db.COLABORADORES.ToList();
			var value = data.Last();
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        //Actualizar grid
        public ActionResult PerformUpdate(EditParams_COLABORADORES_CONCAT_ESTUDIOS param)
        {

            COLABORADORES temp = db.COLABORADORES.Single(o => o.COD_COLABORADOR == param.value.COD_COLABORADOR);
            temp.COD_CARGO = param.value.COD_CARGO;
            temp.CEDULA = param.value.CEDULA;
            temp.CELULAR = param.value.CELULAR;
            temp.CENTROS_COSTOS = param.value.CENTROS_COSTOS;
            temp.CORREO_ELECTRONICO = param.value.CORREO_ELECTRONICO;
            temp.COD_ESTADO_COLABORADOR = param.value.COD_ESTADO_COLABORADOR;
            temp.NOMBRES= param.value.NOMBRES;
            temp.APELLIDOS = param.value.APELLIDOS;
            temp.DESCRIPCION = param.value.NOMBRES + " " + param.value.APELLIDOS;
            temp.ESTADO_CIVIL = param.value.ESTADO_CIVIL;
            temp.FECHA_INGRESO = param.value.FECHA_INGRESO;
            temp.FECHA_NACIMIENTO = param.value.FECHA_NACIMIENTO;
            temp.COD_GENERO = param.value.COD_GENERO;
            temp.COD_TIPO_DE_CONTRATO = param.value.COD_TIPO_DE_CONTRATO;
            db.SaveChanges();
			return RedirectToAction("GetOrderData");
        }

        //Borrar grid
        public ActionResult PerformDelete(int key, string keyColumn)
        {
            db.COLABORADORES.Remove(db.COLABORADORES.Single(o => o.COD_COLABORADOR== key));
            db.SaveChanges();
            return RedirectToAction("GetOrderData");
            
        }

        //Traer información proximos retiros
        public ActionResult GetOrderData_retiros(DataManager dm)
        {
            IEnumerable DataSource = db.VISTA_PENDIENTES_RETIRO.ToList();
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
            var count = DataSource.Cast<VISTA_PENDIENTES_RETIRO>().Count();
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
    }
}
