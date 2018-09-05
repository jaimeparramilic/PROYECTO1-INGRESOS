﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using System.Web.Mvc;
using Syncfusion.JavaScript;
using Syncfusion.JavaScript.DataSources;
using System.Data.Entity;
using System.Net;

using syncfusion_payc.Models;

using Microsoft.AspNet.Identity;
namespace syncfusion_payc.Controllers
{
    public class DETALLE_FACTURA_ITEMController : Controller
    {
        private test_payc_contabilidadEntities db = new test_payc_contabilidadEntities();

        // GET: DETALLE_FACTURA_ITEM
        public ActionResult Index()
        {
            var dETALLE_FACTURA_ITEM = db.DETALLE_FACTURA_ITEM.Include(d => d.CAUSA_ESTADO).Include(d => d.CONCEPTOS).Include(d => d.CONTRATO_PROYECTO).Include(d => d.ESTADOS_DETALLE).Include(d => d.ESTADOS_FACTURAS).Include(d => d.FACTURAS).Include(d => d.FORMAS_PAGO_FECHAS).Include(d => d.ITEMS_CONTRATO);
            return View(dETALLE_FACTURA_ITEM.ToList());
        }

        // GET: DETALLE_FACTURA_ITEM/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DETALLE_FACTURA_ITEM dETALLE_FACTURA_ITEM = db.DETALLE_FACTURA_ITEM.Find(id);
            if (dETALLE_FACTURA_ITEM == null)
            {
                return HttpNotFound();
            }
            return View(dETALLE_FACTURA_ITEM);
        }

        // GET: DETALLE_FACTURA_ITEM/Create
        public ActionResult Create()
        {
            ViewBag.COD_CAUSA_ESTADO = new SelectList(db.CAUSA_ESTADO, "COD_CAUSA_ESTADO", "DESCRIPCION");
            ViewBag.COD_CONCEPTO_PSL = new SelectList(db.CONCEPTOS, "COD_CONCEPTO_PSL", "CODIGO_EN_PSL");
            ViewBag.COD_CONTRATO_PROYECTO = new SelectList(db.CONTRATO_PROYECTO, "COD_CONTRATO_PROYECTO", "COMPLETA");
            ViewBag.COD_ESTADO_DETALLE = new SelectList(db.ESTADOS_DETALLE, "COD_ESTADO_DETALLE", "DESCRIPCION");
            ViewBag.COD_ESTADO_FACTURA = new SelectList(db.ESTADOS_FACTURAS, "COD_ESTADO_FACTURA", "DESCRIPCION");
            ViewBag.COD_FACTURA = new SelectList(db.FACTURAS, "COD_FACTURA", "NUMERO_FACTURA");
            ViewBag.COD_FORMAS_PAGO_FECHAS = new SelectList(db.FORMAS_PAGO_FECHAS, "COD_FORMAS_PAGO_FECHAS", "PERIODO_TEXTO");
            ViewBag.COD_ITEM_CONTRATO = new SelectList(db.ITEMS_CONTRATO, "COD_ITEM_CONTRATO", "ITEM_REEMBOLZABLE");
            return View();
        }

        // POST: DETALLE_FACTURA_ITEM/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COD_DETALLE_FACTURA_ITEM,COD_CONTRATO_PROYECTO,COD_ITEM_CONTRATO,COD_FORMAS_PAGO_FECHAS,VALOR_SIN_IMPUESTOS,FECHA_REGISTRO,USUARIO,COD_ESTADO_FACTURA,COD_CAUSA_ESTADO,OBSERVACIONES,COD_FACTURA,COD_ESTADO_DETALLE,COD_CONCEPTO_PSL")] DETALLE_FACTURA_ITEM dETALLE_FACTURA_ITEM)
        {
            if (ModelState.IsValid)
            {
                db.DETALLE_FACTURA_ITEM.Add(dETALLE_FACTURA_ITEM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.COD_CAUSA_ESTADO = new SelectList(db.CAUSA_ESTADO, "COD_CAUSA_ESTADO", "DESCRIPCION", dETALLE_FACTURA_ITEM.COD_CAUSA_ESTADO);
            ViewBag.COD_CONCEPTO_PSL = new SelectList(db.CONCEPTOS, "COD_CONCEPTO_PSL", "CODIGO_EN_PSL", dETALLE_FACTURA_ITEM.COD_CONCEPTO_PSL);
            ViewBag.COD_CONTRATO_PROYECTO = new SelectList(db.CONTRATO_PROYECTO, "COD_CONTRATO_PROYECTO", "COMPLETA", dETALLE_FACTURA_ITEM.COD_CONTRATO_PROYECTO);
            ViewBag.COD_ESTADO_DETALLE = new SelectList(db.ESTADOS_DETALLE, "COD_ESTADO_DETALLE", "DESCRIPCION", dETALLE_FACTURA_ITEM.COD_ESTADO_DETALLE);
            ViewBag.COD_ESTADO_FACTURA = new SelectList(db.ESTADOS_FACTURAS, "COD_ESTADO_FACTURA", "DESCRIPCION", dETALLE_FACTURA_ITEM.COD_ESTADO_FACTURA);
            ViewBag.COD_FACTURA = new SelectList(db.FACTURAS, "COD_FACTURA", "NUMERO_FACTURA", dETALLE_FACTURA_ITEM.COD_FACTURA);
            ViewBag.COD_FORMAS_PAGO_FECHAS = new SelectList(db.FORMAS_PAGO_FECHAS, "COD_FORMAS_PAGO_FECHAS", "PERIODO_TEXTO", dETALLE_FACTURA_ITEM.COD_FORMAS_PAGO_FECHAS);
            ViewBag.COD_ITEM_CONTRATO = new SelectList(db.ITEMS_CONTRATO, "COD_ITEM_CONTRATO", "ITEM_REEMBOLZABLE", dETALLE_FACTURA_ITEM.COD_ITEM_CONTRATO);
            return View(dETALLE_FACTURA_ITEM);
        }

        // GET: DETALLE_FACTURA_ITEM/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DETALLE_FACTURA_ITEM dETALLE_FACTURA_ITEM = db.DETALLE_FACTURA_ITEM.Find(id);
            if (dETALLE_FACTURA_ITEM == null)
            {
                return HttpNotFound();
            }
            ViewBag.COD_CAUSA_ESTADO = new SelectList(db.CAUSA_ESTADO, "COD_CAUSA_ESTADO", "DESCRIPCION", dETALLE_FACTURA_ITEM.COD_CAUSA_ESTADO);
            ViewBag.COD_CONCEPTO_PSL = new SelectList(db.CONCEPTOS, "COD_CONCEPTO_PSL", "CODIGO_EN_PSL", dETALLE_FACTURA_ITEM.COD_CONCEPTO_PSL);
            ViewBag.COD_CONTRATO_PROYECTO = new SelectList(db.CONTRATO_PROYECTO, "COD_CONTRATO_PROYECTO", "COMPLETA", dETALLE_FACTURA_ITEM.COD_CONTRATO_PROYECTO);
            ViewBag.COD_ESTADO_DETALLE = new SelectList(db.ESTADOS_DETALLE, "COD_ESTADO_DETALLE", "DESCRIPCION", dETALLE_FACTURA_ITEM.COD_ESTADO_DETALLE);
            ViewBag.COD_ESTADO_FACTURA = new SelectList(db.ESTADOS_FACTURAS, "COD_ESTADO_FACTURA", "DESCRIPCION", dETALLE_FACTURA_ITEM.COD_ESTADO_FACTURA);
            ViewBag.COD_FACTURA = new SelectList(db.FACTURAS, "COD_FACTURA", "NUMERO_FACTURA", dETALLE_FACTURA_ITEM.COD_FACTURA);
            ViewBag.COD_FORMAS_PAGO_FECHAS = new SelectList(db.FORMAS_PAGO_FECHAS, "COD_FORMAS_PAGO_FECHAS", "PERIODO_TEXTO", dETALLE_FACTURA_ITEM.COD_FORMAS_PAGO_FECHAS);
            ViewBag.COD_ITEM_CONTRATO = new SelectList(db.ITEMS_CONTRATO, "COD_ITEM_CONTRATO", "ITEM_REEMBOLZABLE", dETALLE_FACTURA_ITEM.COD_ITEM_CONTRATO);
            return View(dETALLE_FACTURA_ITEM);
        }

        // POST: DETALLE_FACTURA_ITEM/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COD_DETALLE_FACTURA_ITEM,COD_CONTRATO_PROYECTO,COD_ITEM_CONTRATO,COD_FORMAS_PAGO_FECHAS,VALOR_SIN_IMPUESTOS,FECHA_REGISTRO,USUARIO,COD_ESTADO_FACTURA,COD_CAUSA_ESTADO,OBSERVACIONES,COD_FACTURA,COD_ESTADO_DETALLE,COD_CONCEPTO_PSL")] DETALLE_FACTURA_ITEM dETALLE_FACTURA_ITEM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dETALLE_FACTURA_ITEM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.COD_CAUSA_ESTADO = new SelectList(db.CAUSA_ESTADO, "COD_CAUSA_ESTADO", "DESCRIPCION", dETALLE_FACTURA_ITEM.COD_CAUSA_ESTADO);
            ViewBag.COD_CONCEPTO_PSL = new SelectList(db.CONCEPTOS, "COD_CONCEPTO_PSL", "CODIGO_EN_PSL", dETALLE_FACTURA_ITEM.COD_CONCEPTO_PSL);
            ViewBag.COD_CONTRATO_PROYECTO = new SelectList(db.CONTRATO_PROYECTO, "COD_CONTRATO_PROYECTO", "COMPLETA", dETALLE_FACTURA_ITEM.COD_CONTRATO_PROYECTO);
            ViewBag.COD_ESTADO_DETALLE = new SelectList(db.ESTADOS_DETALLE, "COD_ESTADO_DETALLE", "DESCRIPCION", dETALLE_FACTURA_ITEM.COD_ESTADO_DETALLE);
            ViewBag.COD_ESTADO_FACTURA = new SelectList(db.ESTADOS_FACTURAS, "COD_ESTADO_FACTURA", "DESCRIPCION", dETALLE_FACTURA_ITEM.COD_ESTADO_FACTURA);
            ViewBag.COD_FACTURA = new SelectList(db.FACTURAS, "COD_FACTURA", "NUMERO_FACTURA", dETALLE_FACTURA_ITEM.COD_FACTURA);
            ViewBag.COD_FORMAS_PAGO_FECHAS = new SelectList(db.FORMAS_PAGO_FECHAS, "COD_FORMAS_PAGO_FECHAS", "PERIODO_TEXTO", dETALLE_FACTURA_ITEM.COD_FORMAS_PAGO_FECHAS);
            ViewBag.COD_ITEM_CONTRATO = new SelectList(db.ITEMS_CONTRATO, "COD_ITEM_CONTRATO", "ITEM_REEMBOLZABLE", dETALLE_FACTURA_ITEM.COD_ITEM_CONTRATO);
            return View(dETALLE_FACTURA_ITEM);
        }

        // GET: DETALLE_FACTURA_ITEM/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DETALLE_FACTURA_ITEM dETALLE_FACTURA_ITEM = db.DETALLE_FACTURA_ITEM.Find(id);
            if (dETALLE_FACTURA_ITEM == null)
            {
                return HttpNotFound();
            }
            return View(dETALLE_FACTURA_ITEM);
        }

        // POST: DETALLE_FACTURA_ITEM/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            DETALLE_FACTURA_ITEM dETALLE_FACTURA_ITEM = db.DETALLE_FACTURA_ITEM.Find(id);
            db.DETALLE_FACTURA_ITEM.Remove(dETALLE_FACTURA_ITEM);
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
            var DataSource2 = db.DETALLE_FACTURA_ITEM.ToList();
            ViewBag.dataSource2 = DataSource2;
            return View();
        }	
		public ActionResult GetOrderData(DataManager dm)
        {
            IEnumerable DataSource = db.DETALLE_FACTURA_ITEM.ToList();
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
            var count = DataSource.Cast<DETALLE_FACTURA_ITEM>().Count();
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
        public ActionResult PerformInsert(EditParams_DETALLE_FACTURA_ITEM param)
        {
            DateTime hoy = DateTime.Today;
            string usuario = User.Identity.GetUserName();
            DETALLE_FACTURA_ITEM table = db.DETALLE_FACTURA_ITEM.Single(o => o.COD_DETALLE_FACTURA_ITEM == param.value.COD_DETALLE_FACTURA_ITEM);
            if (table.VALOR_SIN_IMPUESTOS != param.value.VALOR_SIN_IMPUESTOS)
            {
                param.value.FECHA_REGISTRO = hoy;
                param.value.USUARIO = usuario;
                db.DETALLE_FACTURA_ITEM.Add(param.value);
                table.COD_ESTADO_DETALLE = 2;
               
            }
            else
            {
                table.FECHA_REGISTRO = hoy;
                table.USUARIO = usuario;
                table.COD_ESTADO_DETALLE = 1;
                table.COD_CONCEPTO_PSL = param.value.COD_CONCEPTO_PSL;
            }
            db.SaveChanges();
            return RedirectToAction("GetOrderData");
        }

        //Actualizar grid
        public ActionResult PerformUpdate(EditParams_DETALLE_FACTURA_ITEM param)
        {

            DateTime hoy = DateTime.Today;
            string usuario = User.Identity.GetUserName();
            DETALLE_FACTURA_ITEM table = db.DETALLE_FACTURA_ITEM.Single(o => o.COD_DETALLE_FACTURA_ITEM == param.value.COD_DETALLE_FACTURA_ITEM);
            if (table.VALOR_SIN_IMPUESTOS != param.value.VALOR_SIN_IMPUESTOS)
            {
                param.value.FECHA_REGISTRO = hoy;
                param.value.USUARIO = usuario;
                db.DETALLE_FACTURA_ITEM.Add(param.value);
                table.COD_ESTADO_DETALLE = 2;

            }
            else
            {
                table.FECHA_REGISTRO = hoy;
                table.USUARIO = usuario;
                table.COD_ESTADO_DETALLE = 1;
                table.COD_CONCEPTO_PSL = param.value.COD_CONCEPTO_PSL;
            }
            db.SaveChanges();
            return RedirectToAction("GetOrderData");

        }

        //Borrar grid
        public ActionResult PerformDelete(int key, string keyColumn)
        {
            db.DETALLE_FACTURA_ITEM.Remove(db.DETALLE_FACTURA_ITEM.Single(o => o.COD_DETALLE_FACTURA_ITEM== key));
            db.SaveChanges();
            return RedirectToAction("GetOrderData");
            
        }
    }
}