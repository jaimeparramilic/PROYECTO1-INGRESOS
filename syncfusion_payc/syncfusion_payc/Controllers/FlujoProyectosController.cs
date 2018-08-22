using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using syncfusion_payc.Models;
using System.IO;
using Syncfusion.JavaScript;
using Syncfusion.JavaScript.DataSources;
using System.Web.Script.Serialization;
using System.Globalization;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.AspNet.Identity;

namespace syncfusion_payc.Controllers
{
    public class FlujoProyectosController : Controller
    {
        private test_payc_contabilidadEntities db = new test_payc_contabilidadEntities();
        // Ver
        static string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection1"].ConnectionString;
        #region acciones relacionadas con vistas
        public ActionResult Index()
        {
            db.Configuration.ProxyCreationEnabled = false;
            db.Configuration.LazyLoadingEnabled = false;
            ViewBag.datasource = db.PROYECTOS.ToList();
            ViewBag.datasource_clientes = db.CLIENTES.ToList();
            ViewBag.datasource_forma_pago = db.FORMAS_PAGO.ToList();
            ViewBag.datasource_contratos= db.CONTRATOS.ToList();
            return View();
        }

        //Adicionar
        public ActionResult Add()
        {
            db.Configuration.ProxyCreationEnabled = false;
            db.Configuration.LazyLoadingEnabled = false;
            ViewBag.datasource = db.PROYECTOS.ToList();
            ViewBag.datasource_clientes = db.CLIENTES.ToList();
            ViewBag.datasource_forma_pago = db.FORMAS_PAGO.ToList();

            return View();
        }

        public ActionResult Incrementos()
        {
            db.Configuration.ProxyCreationEnabled = false;
            db.Configuration.LazyLoadingEnabled = false;
            
            return View();
        }

        //Editar
        public ActionResult Edit(long? id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            db.Configuration.LazyLoadingEnabled = false;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CONTRATO_PROYECTO cont = db.CONTRATO_PROYECTO.Find(id);
            if (cont == null)
            {
                return HttpNotFound();
            }
            try
            {
                ViewBag.datasource = db.PROYECTOS.ToList();
                ViewBag.datasource_clientes = db.CLIENTES.ToList();
                ViewBag.datasource_forma_pago = db.FORMAS_PAGO.ToList();
            }
            catch {
                ViewBag.datasource_forma_pago = db.FORMAS_PAGO.ToList();
                ViewBag.datasource_clientes = db.CLIENTES.ToList();
            }
            
            ViewBag.contrato_proyecto = cont;
            try
            {
                CONTRATOS cont1 = db.CONTRATOS.Find(cont.COD_CONTRATO);
                ViewBag.contrato = cont1;
            }
            catch { }
            try
            {
                PROYECTOS proy = db.PROYECTOS.Find(cont.COD_PROYECTO);
                ViewBag.proyecto = proy;
            }
            catch
            {

            }
            try
            {
                List<CONTRATOS_CONDICIONES> cont2 = db.CONTRATOS_CONDICIONES.Where(o => o.COD_CONTRATO_PROYECTO == id).ToList();

                ViewBag.condiciones = cont2;
            }
            catch { }
            string lista = "";
            List<string> condiciones = new List<string>();
            try
            {
                ViewBag.lista1 = String.Join(",", db.TAG_ORDEN.Where(o => o.COD_CONTRATO_PROYECTO == id).Select(o => o.TAG));
                //Lista
                lista = String.Join(",", db.CONTRATOS_CONDICIONES.Where(o => o.COD_CONTRATO_PROYECTO == id).Select(o => o.COD_TIPO_CONDICION.ToString()));
                condiciones = db.CONTRATOS_CONDICIONES.Where(o => o.COD_CONTRATO_PROYECTO == id).Select(o => o.COD_TIPO_CONDICION.ToString()).ToList();
            }
            catch
            {
               
                condiciones.Add("");
                ViewBag.lista1 = condiciones;
            }
            //Lista condiciones
            ViewBag.lista = lista;
            
           
            ViewBag.condiciones = condiciones;
            return View();
        }

        

        // POST: CONTRATOS_ROL/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            CONTRATOS_ROL cONTRATOS_ROL = db.CONTRATOS_ROL.Find(id);
            db.CONTRATOS_ROL.Remove(cONTRATOS_ROL);
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

        // Crear
        public ActionResult Create()
        {
            ViewBag.datasource = new FlujoProyectosViewModels();
            
            return View();
        }
        #endregion
        #region guardar elementos documentales
        //Almacenar archivo contrato
        [AcceptVerbs("Post")]
        public void Save_contrato()
        {
            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Length > 0)
            {
                // Get the files using the name attribute as a key. 
                var httpPostedFile = System.Web.HttpContext.Current.Request.Files["CARGUE_ARCHIVOS"];

                if (httpPostedFile != null)
                {
                    var fileSave = System.Web.HttpContext.Current.Server.MapPath("contratos");
                    if (!Directory.Exists(fileSave))
                    {
                        Directory.CreateDirectory(fileSave);
                    }

                    var fileSavePath = Path.Combine(fileSave, httpPostedFile.FileName);
                    if (!System.IO.File.Exists(fileSavePath))
                    {    /*To save files at server*/
                        httpPostedFile.SaveAs(fileSavePath);
                        HttpResponse Response = System.Web.HttpContext.Current.Response;
                        Response.Clear();
                        Response.ContentType = "application/json; charset=utf-8";
                        Response.StatusDescription = "Archivo cargado exitosamente";
                        Response.Write(httpPostedFile.FileName);
                        Response.End();
                    }
                    else
                    {
                        HttpResponse Response = System.Web.HttpContext.Current.Response;
                        Response.Clear();
                        //Aca va el tratamiento para duplicados
                        //Response.Status = "400 ya existe un archivo con el mismo nombre, por favor renombrelo";
                        //Response.StatusCode = 400;
                        Response.ContentType = "application/json; charset=utf-8";
                        Response.StatusDescription = "Ya existe un archivo con el mismo nombre";
                        Response.Write(httpPostedFile.FileName);
                        Response.End();
                        
                    }
                }
            }
        }

        //Almacenar archivo contrato
        [AcceptVerbs("Post")]
        public void Save_acta()
        {
            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Length > 0)
            {
                // Get the files using the name attribute as a key. 
                var httpPostedFile = System.Web.HttpContext.Current.Request.Files["CARGUE_ACTA"];

                if (httpPostedFile != null)
                {
                    var fileSave = System.Web.HttpContext.Current.Server.MapPath("actas");
                    if (!Directory.Exists(fileSave))
                    {
                        Directory.CreateDirectory(fileSave);
                    }

                    var fileSavePath = Path.Combine(fileSave, httpPostedFile.FileName);
                    if (!System.IO.File.Exists(fileSavePath))
                    {    /*To save files at server*/
                        httpPostedFile.SaveAs(fileSavePath);
                        HttpResponse Response = System.Web.HttpContext.Current.Response;
                        Response.Clear();
                        Response.ContentType = "application/json; charset=utf-8";
                        Response.StatusDescription = "Archivo cargado exitosamente";
                        Response.Write(httpPostedFile.FileName);
                        Response.End();
                    }
                    else
                    {
                        HttpResponse Response = System.Web.HttpContext.Current.Response;
                        Response.Clear();
                        //Aca va el tratamiento para duplicados
                        //Response.Status = "400 ya existe un archivo con el mismo nombre, por favor renombrelo";
                        //Response.StatusCode = 400;
                        Response.ContentType = "application/json; charset=utf-8";
                        Response.StatusDescription = "Ya existe un archivo con el mismo nombre";
                        Response.Write(httpPostedFile.FileName);
                        Response.End();

                    }
                }
            }
        }

        //Almacenar archivo anexo
        [AcceptVerbs("Post")]
        public void Save_anexos()
        {
            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Length > 0)
            {
                // Get the files using the name attribute as a key. 
                var httpPostedFile = System.Web.HttpContext.Current.Request.Files["CARGUE_ANEXOS"];

                if (httpPostedFile != null)
                {
                    var fileSave = System.Web.HttpContext.Current.Server.MapPath("anexos_roles");
                    if (!Directory.Exists(fileSave))
                    {
                        Directory.CreateDirectory(fileSave);
                    }

                    var fileSavePath = Path.Combine(fileSave, httpPostedFile.FileName);
                    if (!System.IO.File.Exists(fileSavePath))
                    {    /*To save files at server*/
                        httpPostedFile.SaveAs(fileSavePath);
                        HttpResponse Response = System.Web.HttpContext.Current.Response;
                        Response.Clear();
                        Response.ContentType = "application/json; charset=utf-8";
                        Response.StatusDescription = "Archivo cargado exitosamente";
                        Response.Write(httpPostedFile.FileName);
                        Response.End();
                    }
                    else
                    {
                        HttpResponse Response = System.Web.HttpContext.Current.Response;
                        Response.Clear();
                        //Aca va el tratamiento para duplicados
                        //Response.Status = "400 ya existe un archivo con el mismo nombre, por favor renombrelo";
                        //Response.StatusCode = 400;
                        Response.ContentType = "application/json; charset=utf-8";
                        Response.StatusDescription = "Ya existe un archivo con el mismo nombre";
                        Response.Write(httpPostedFile.FileName);
                        Response.End();

                    }
                }
            }
        }

        [HttpPost]
        public ActionResult Duplicados(string archivo)
        {
            var fileSave = System.Web.HttpContext.Current.Server.MapPath("archivos");
            var fileSavePath = Path.Combine(fileSave, archivo);
            Response.StatusCode = (int)HttpStatusCode.OK;

            if (System.IO.File.Exists(fileSavePath))
            {
                return Json(new { success = true, responseText = "si" }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = true, responseText = "no" }, JsonRequestBehavior.AllowGet);
        }

        //Eliminar Archivo contrato
        public ActionResult remove_contrato(string fileNames)
        {
            try
            {
                var fileSave = System.Web.HttpContext.Current.Server.MapPath("contratos");

                //var fileName = System.Web.HttpContext.Current.Request.Files["CARGUE_ARCHIVOS"].FileName;
                var fileSavePath = Path.Combine(fileSave, fileNames);
                if (System.IO.File.Exists(fileSavePath))
                {
                    System.IO.File.Delete(fileSavePath);
                }
                
                return Json("SI", JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                
                return Json("SI", JsonRequestBehavior.AllowGet);
            }
        }

        //Eliminar Archivo acta
        public ActionResult Remove_acta(string fileNames)
        {

            try
            {
                var fileSave = System.Web.HttpContext.Current.Server.MapPath("actas");

                //var fileName = System.Web.HttpContext.Current.Request.Files["CARGUE_ARCHIVOS"].FileName;
                var fileSavePath = Path.Combine(fileSave, fileNames);
                if (System.IO.File.Exists(fileSavePath))
                {
                    System.IO.File.Delete(fileSavePath);
                }
                return Json("SI", JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json("SI", JsonRequestBehavior.AllowGet);
            }
        }

        //Eliminar Archivo anexo
        public ActionResult Remove_anexos(string fileNames)
        {

            try
            {
                var fileSave = System.Web.HttpContext.Current.Server.MapPath("anexos_roles");

                //var fileName = System.Web.HttpContext.Current.Request.Files["CARGUE_ARCHIVOS"].FileName;
                var fileSavePath = Path.Combine(fileSave, fileNames);
                if (System.IO.File.Exists(fileSavePath))
                {
                    System.IO.File.Delete(fileSavePath);
                }
                return Json("SI", JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json("SI", JsonRequestBehavior.AllowGet);
            }
        }
        #endregion
        #region cargue datos roles

        //Url adaptor ejemplo
        public ActionResult UrlAdaptor()
        {
            var DataSource2 = db.CONTRATOS_ROL.ToList();
            ViewBag.dataSourcem = DataSource2;
            return View();
        }	
    // Traer datos rol
		public ActionResult GetOrderData_rol(DataManager dm)
        {
            IEnumerable DataSource = db.CONTRATOS_ROL.ToList();
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
            var count = DataSource.Cast<CONTRATOS_ROL>().Count();
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

    // Insert de datos rol
        public ActionResult PerformInsert_rol(EditParams_CONTRATOS_ROL param)
        {
            db.CONTRATOS_ROL.Add(param.value);
            db.SaveChanges();
			var data = db.CONTRATOS_ROL.ToList();
			var value = data.Last();
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        //Actualizar grid rol
        public ActionResult PerformUpdate_rol(EditParams_CONTRATOS_ROL param)
        {
            CONTRATOS_ROL table = db.CONTRATOS_ROL.Single(o => o.COD_CONTRATO_ROL == param.value.COD_CONTRATO_ROL);
            db.Entry(table).CurrentValues.SetValues(param.value);
            db.SaveChanges();
			return RedirectToAction("GetOrderData_rol");
			
        }

        //Borrar grid rol
        public ActionResult PerformDelete_rol(int key, string keyColumn)
        {
            db.CONTRATOS_ROL.Remove(db.CONTRATOS_ROL.Single(o => o.COD_CONTRATO_ROL== key));
            db.SaveChanges();
            return RedirectToAction("GetOrderData_rol");
            
        }
        #endregion
        #region cargue de datos items

        //Traer elementos items
        public ActionResult GetOrderData_item(DataManager dm)
        {
            IEnumerable DataSource = db.ITEMS_CONTRATO.ToList();
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
            var count = DataSource.Cast<ITEMS_CONTRATO>().Count();
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

        //Insertar elementos items 
        public ActionResult PerformInsert_item(EditParams_ITEMS_CONTRATO param)
        {
            db.ITEMS_CONTRATO.Add(param.value);
            db.SaveChanges();
            var data = db.ITEMS_CONTRATO.ToList();
            var value = data.Last();
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        //Actualizar items
        public ActionResult PerformUpdate_item(EditParams_ITEMS_CONTRATO param)
        {

            ITEMS_CONTRATO table = db.ITEMS_CONTRATO.Single(o => o.COD_ITEM == param.value.COD_ITEM);

            db.Entry(table).CurrentValues.SetValues(param.value);
            db.SaveChanges();
            return RedirectToAction("GetOrderData_item");

        }

        //Borrar items
        public ActionResult PerformDelete_item(int key, string keyColumn)
        {
            db.ITEMS_CONTRATO.Remove(db.ITEMS_CONTRATO.Single(o => o.COD_ITEM == key));
            db.SaveChanges();
            return RedirectToAction("GetOrderData_item");

        }
        #endregion
        #region GUARDAR ETAPAS
        #region etapa1
        //Public guardar contrato
        [HttpPost]
        public ActionResult guardar_contrato(CONTRATOS CONTRATO)
        {
            string descripcion = CONTRATO.DESCRIPCION;
            db.CONTRATOS.Add(CONTRATO);
            db.SaveChanges();
            //Chequear si la descripcion es nula
            if (descripcion == "")
            {
                CONTRATO.DESCRIPCION = "SIN DOCUMENTO CONTRATO ID" + CONTRATO.COD_CONTRATO;
                CONTRATOS table = db.CONTRATOS.Single(o => o.COD_CONTRATO == CONTRATO.COD_CONTRATO);
                db.Entry(table).CurrentValues.SetValues(CONTRATO);
                db.SaveChanges();
            }
            return Json(new { success = true, responseText = CONTRATO.COD_CONTRATO.ToString()}, JsonRequestBehavior.AllowGet);
        }
        //Public actualizar contrato
        [HttpPost]
        public ActionResult actualizar_contrato(CONTRATOS CONTRATO)
        {
            CONTRATOS table = db.CONTRATOS.Single(o => o.COD_CONTRATO == CONTRATO.COD_CONTRATO);
            db.Entry(table).CurrentValues.SetValues(CONTRATO);
            db.SaveChanges();
            return Json(new { success = true, responseText = CONTRATO.COD_CONTRATO.ToString() }, JsonRequestBehavior.AllowGet);
        }

        #endregion
        #region etapa2
        [HttpPost]
        public ActionResult guardar_proyecto(PROYECTOS PROYECTO, int [] TIPO_CONDICIONES,long COD_CONTRATO,long COD_FORMA_PAGO, string[] TAGS)
        {
            //Guardar el proyecto
            db.PROYECTOS.Add(PROYECTO);
            db.SaveChanges();

            //crear una string para guardar la respuesta
            string retornar = PROYECTO.COD_PROYECTO.ToString();
            //Guardar la relación contrato proyecto
            CONTRATO_PROYECTO cont_pro = new CONTRATO_PROYECTO();
            cont_pro.COD_CONTRATO = COD_CONTRATO;
            cont_pro.COD_PROYECTO = PROYECTO.COD_PROYECTO;
            cont_pro.COD_FORMA_PAGO = COD_FORMA_PAGO;
            cont_pro.COD_ESTADO_ORDEN_SERVICIO = 2;
            cont_pro.MODIFICADO_POR = User.Identity.GetUserName();
            DateTime hoy = DateTime.Today;
            cont_pro.FECHA_ULTIMA_MODIFICACION = hoy;
            db.CONTRATO_PROYECTO.Add(cont_pro);
            db.SaveChanges();
            //Guardar tipos condiiones
            foreach(int CONDICION in TIPO_CONDICIONES)
            {
                if (CONDICION > 0)
                {
                    CONTRATOS_CONDICIONES TEMP = new CONTRATOS_CONDICIONES();
                    DateTime localDate = DateTime.Now;
                    TEMP.COD_CONTRATO_PROYECTO = cont_pro.COD_CONTRATO_PROYECTO;
                    TEMP.COD_TIPO_CONDICION = CONDICION;
                    TEMP.FECHA_INCLUSION = localDate;
                    TEMP.VIGENTE = "SI";
                    db.CONTRATOS_CONDICIONES.Add(TEMP);
                   
                }
            }
            //Guardar tags
            foreach (string tag in TAGS)
            {
                if (tag != "")
                {
                    TAG_ORDEN TEMP = new TAG_ORDEN();
                    TEMP.COD_CONTRATO_PROYECTO = cont_pro.COD_CONTRATO_PROYECTO;
                    TEMP.TAG = tag;
                    db.TAG_ORDEN.Add(TEMP);
                }
            }
            db.SaveChanges();
            //Realizar cargue inicial de incrementos
            if (db.INCREMENTO_ORDEN.Where(o => o.COD_CONTRATO_PROYECTO == cont_pro.COD_CONTRATO_PROYECTO).ToList().Count() == 0)
            {
                cargue_inicial_incrementos(cont_pro.COD_CONTRATO_PROYECTO);
            }
            retornar = retornar + "," + cont_pro.COD_CONTRATO_PROYECTO.ToString();
            return Json(new { success = true, responseText = retornar }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult actualizar_proyecto(PROYECTOS PROYECTO, long[] TIPO_CONDICIONES, long COD_CONTRATO, long COD_FORMA_PAGO,long COD_CONTRATO_PROYECTO, string[] TAGS)
        {
            //Actualizar proyecto el proyecto
            PROYECTOS table = db.PROYECTOS.Single(o => o.COD_PROYECTO == PROYECTO.COD_PROYECTO);
            db.Entry(table).CurrentValues.SetValues(PROYECTO);
            db.SaveChanges();

            //Actualizar contrato_proyecto
            try
            {

                CONTRATO_PROYECTO tabletemp = db.CONTRATO_PROYECTO.Single(o => o.COD_CONTRATO_PROYECTO == COD_CONTRATO_PROYECTO);
                //CONTRATO_PROYECTO temp1 = new CONTRATO_PROYECTO();
                tabletemp.COD_CONTRATO = COD_CONTRATO;
                tabletemp.COD_PROYECTO = PROYECTO.COD_PROYECTO;
                tabletemp.COD_FORMA_PAGO = COD_FORMA_PAGO;
                tabletemp.MODIFICADO_POR= User.Identity.GetUserName();
                DateTime hoy = DateTime.Today;
                tabletemp.FECHA_ULTIMA_MODIFICACION = hoy;

                db.SaveChanges();
            }
            catch
            {
                //Si no existe debido a que proviene de un refresh
                CONTRATO_PROYECTO cont_pro = new CONTRATO_PROYECTO();
                cont_pro.COD_CONTRATO = COD_CONTRATO;
                cont_pro.COD_PROYECTO = PROYECTO.COD_PROYECTO;
                cont_pro.COD_FORMA_PAGO = COD_FORMA_PAGO;
                cont_pro.MODIFICADO_POR = User.Identity.GetUserName();
                DateTime hoy = DateTime.Today;
                cont_pro.FECHA_ULTIMA_MODIFICACION = hoy;
                db.CONTRATO_PROYECTO.Add(cont_pro);
                db.SaveChanges();
            }
            //Eliminar condiciones
            try
            {
                db.CONTRATOS_CONDICIONES.RemoveRange(db.CONTRATOS_CONDICIONES.Where(o => o.COD_CONTRATO_PROYECTO == COD_CONTRATO_PROYECTO));
                db.SaveChanges();
            }
            catch(Exception ex)
            {
            }
            //Eliminar tags
            try
            {
                db.TAG_ORDEN.RemoveRange(db.TAG_ORDEN.Where(o => o.COD_CONTRATO_PROYECTO == COD_CONTRATO_PROYECTO));
                db.SaveChanges();
            }
            catch (Exception ex)
            {
            }
            //Actualizar tipos condiciones
            foreach (long CONDICION in TIPO_CONDICIONES)
            {
                if (CONDICION > 0)
                {
                    CONTRATOS_CONDICIONES TEMP = new CONTRATOS_CONDICIONES();
                    DateTime localDate = DateTime.Now;
                    TEMP.COD_CONTRATO_PROYECTO = COD_CONTRATO_PROYECTO;
                    TEMP.COD_TIPO_CONDICION = CONDICION;
                    TEMP.FECHA_INCLUSION = localDate;
                    TEMP.VIGENTE = "SI";
                    db.CONTRATOS_CONDICIONES.Add(TEMP);
                }
            }
            //Guardar tags
            foreach (string tag in TAGS)
            {
                if (tag != "")
                {
                    TAG_ORDEN TEMP = new TAG_ORDEN();
                    TEMP.COD_CONTRATO_PROYECTO = COD_CONTRATO_PROYECTO;
                    TEMP.TAG = tag;
                    db.TAG_ORDEN.Add(TEMP);
                }
            }
            //Guardar cambios
            db.SaveChanges();
            //Realizar cargue inicial de incrementos
            if (db.INCREMENTO_ORDEN.Where(o => o.COD_CONTRATO_PROYECTO == COD_CONTRATO_PROYECTO).ToList().Count() == 0)
            {
                cargue_inicial_incrementos(COD_CONTRATO_PROYECTO);
                
            }
            string retornar = PROYECTO.COD_PROYECTO.ToString();
            retornar = retornar + "," + COD_CONTRATO_PROYECTO.ToString();
            return Json(new { success = true, responseText = retornar }, JsonRequestBehavior.AllowGet);
        }
        #endregion
        #endregion
        #region regenerar flujos
        //Funcion para regenerar el flujo del rol
        public ActionResult regenerar_flujo_rol(long COD_CONTRATO_PROYECTO)
        {
            //Query para recalcular
            string queryString = @" DELETE FROM [test_payc_contabilidad].[dbo].[FLUJO_INGRESOS_ROL] WHERE COD_CONTRATO_PROYECTO=" + COD_CONTRATO_PROYECTO.ToString() + @";
                                    INSERT INTO [test_payc_contabilidad].[dbo].[FLUJO_INGRESOS_ROL]
                                            ([COD_FORMAS_PAGO_FECHAS]
                                            ,[COD_ROL]
                                            ,[COD_CONTRATO_PROYECTO]
                                            ,[ETAPA]
                                            ,[VALOR_SIN_PRESTACIONES]
                                            ,[VALOR_CON_PRESTACIONES]
                                            ,[VALOR_FACTOR_MULTIPLICADOR]) (SELECT [COD_FORMAS_PAGO_FECHAS]
                                            ,[COD_ROL]
                                            ,[COD_CONTRATO_PROYECTO]
                                            ,[ETAPA]
                                            ,[VALOR_SIN_PRESTACIONES]
                                            ,[VALOR_CON_PRESTACIONES]
                                            ,[VALOR_FACTOR_MULTIPLICADOR] FROM [test_payc_contabilidad].[dbo].GENERACION_FLUJOS_ROL3 WHERE COD_CONTRATO_PROYECTO=" + COD_CONTRATO_PROYECTO.ToString() + @");";
           
            //Ejecución del query
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                
                connection.Open();
                command.ExecuteNonQuery();
            }
            return Json(new { success = true, responseText = "SI" }, JsonRequestBehavior.AllowGet);
        }

        //Funcion para regenerar el flujo del item
        public ActionResult regenerar_flujo_item(long COD_CONTRATO_PROYECTO)
        {
            //Query para recalcular
            string queryString = @" DELETE FROM [test_payc_contabilidad].[dbo].[FLUJO_INGRESOS_ITEMS] WHERE COD_CONTRATO_PROYECTO=" + COD_CONTRATO_PROYECTO.ToString() + @";
                                    INSERT INTO [test_payc_contabilidad].[dbo].[FLUJO_INGRESOS_ITEMS]
                                          ([COD_FORMAS_PAGO_FECHAS]
                                          ,[COD_ITEM]
                                          ,[COD_CONTRATO_PROYECTO]
                                          ,[ETAPA]
                                          ,[VALOR_FIJO]
                                          ,[VALOR_VARIABLE]
                                          ,[VALOR_TOTAL]) (SELECT [COD_FORMAS_PAGO_FECHAS]
                                          ,[COD_ITEM]
                                          ,[COD_CONTRATO_PROYECTO]
                                          ,[ETAPA]
                                          ,[VALOR_FIJO]
                                          ,[VALOR_VARIABLE]
                                          ,[VALOR_TOTAL] FROM [test_payc_contabilidad].[dbo].GENERACION_FLUJOS_ITEM3 WHERE COD_CONTRATO_PROYECTO=" + COD_CONTRATO_PROYECTO.ToString() + @");";

            //Ejecución del query
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                connection.Open();
                command.ExecuteNonQuery();
            }
            return Json(new { success = true, responseText = "SI" }, JsonRequestBehavior.AllowGet);
        }
        #endregion
        #region Index orden de servicio
        public ActionResult GetOrderData_contrato_proyecto(DataManager dm)
        {
            IEnumerable DataSource = db.ORDENES_SERVICIO_INDEX.ToList();
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
            var count = DataSource.Cast<ORDENES_SERVICIO_INDEX>().Count();
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
        //Borrar grid
        public ActionResult PerformDelete_contrato_proyecto(int key, string keyColumn)
        {
            db.CONTRATO_PROYECTO.Remove(db.CONTRATO_PROYECTO.Single(o => o.COD_CONTRATO_PROYECTO == key));
            db.SaveChanges();
            return RedirectToAction("GetOrderData_contrato_proyecto");

        }
        #endregion
        #region completa
        public ActionResult cerrar_cargue(long COD_CONTRATO_PROYECTO)
        {
            //Buscar proyecto
            CONTRATO_PROYECTO tabletemp = db.CONTRATO_PROYECTO.Single(o => o.COD_CONTRATO_PROYECTO == COD_CONTRATO_PROYECTO);
            tabletemp.COMPLETA = "SI";
            tabletemp.MODIFICADO_POR = User.Identity.GetUserName();
            DateTime hoy = DateTime.Today;
            tabletemp.FECHA_ULTIMA_MODIFICACION = hoy;
            tabletemp.CREADO_POR = User.Identity.GetUserName();
            tabletemp.FECHA_CREACION = hoy;
            
            db.SaveChanges();

            return Json(new { success = true, responseText = "SI" }, JsonRequestBehavior.AllowGet);
        }
        #endregion
        #region finalizar o revertir
        public ActionResult finalizar(long COD_CONTRATO_PROYECTO)
        {
            //Buscar proyecto
            CONTRATO_PROYECTO tabletemp = db.CONTRATO_PROYECTO.Single(o => o.COD_CONTRATO_PROYECTO == COD_CONTRATO_PROYECTO);
            tabletemp.COD_ESTADO_ORDEN_SERVICIO = 1;
            tabletemp.MODIFICADO_POR = User.Identity.GetUserName();
            DateTime hoy = DateTime.Today;
            tabletemp.FECHA_ULTIMA_MODIFICACION = hoy;
            db.SaveChanges();
            return Json(new { success = true, responseText = "SI" }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult revertir(long COD_CONTRATO_PROYECTO)
        {
            //Buscar proyecto
            CONTRATO_PROYECTO tabletemp = db.CONTRATO_PROYECTO.Single(o => o.COD_CONTRATO_PROYECTO == COD_CONTRATO_PROYECTO);
            tabletemp.COD_ESTADO_ORDEN_SERVICIO = 2;
            tabletemp.MODIFICADO_POR = User.Identity.GetUserName();
            DateTime hoy = DateTime.Today;
            tabletemp.FECHA_ULTIMA_MODIFICACION = hoy;
            db.SaveChanges();
            return Json(new { success = true, responseText = "SI" }, JsonRequestBehavior.AllowGet);
        }
        #endregion
        #region Incrementos Salariales
        //Funcion que realiza el cargue inicial de incrementos
        public void cargue_inicial_incrementos(long COD_CONTRATO_PROYECTO)
        {
            string queryString = @"INSERT INTO[test_payc_contabilidad].[dbo].[INCREMENTO_ORDEN] (COD_CONTRATO_PROYECTO, FACTOR_INCREMENTO, FECHA_INCREMENTO) SELECT " + COD_CONTRATO_PROYECTO.ToString() + ", FACTOR_INCREMENTO, FECHA_FORMA_PAGO FROM[test_payc_contabilidad].[dbo].[INCREMENTOS_ANUALES_FECHA]";
            //Ejecución del query
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        //Cargue de lista incermentos salariales
        public ActionResult GetOrderData_incrementos(DataManager dm)
        {
            IEnumerable DataSource = db.INCREMENTO_ORDEN.ToList();
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
            var count = DataSource.Cast<INCREMENTO_ORDEN>().Count();
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
        public ActionResult PerformInsert_incrementos(EditParams_INCREMENTO_ORDEN param)
        {
            db.INCREMENTO_ORDEN.Add(param.value);
            db.SaveChanges();
            var data = db.INCREMENTO_ORDEN.ToList();
            var value = data.Last();
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        //Actualizar grid
        public ActionResult PerformUpdate_incrementos(EditParams_INCREMENTO_ORDEN param)
        {

            INCREMENTO_ORDEN table = db.INCREMENTO_ORDEN.Single(o => o.COD_INCREMENTO_ORDEN == param.value.COD_INCREMENTO_ORDEN);

            db.Entry(table).CurrentValues.SetValues(param.value);
            db.SaveChanges();
            return RedirectToAction("GetOrderData_incrementos");

        }

        //Borrar grid
        public ActionResult PerformDelete_incrementos(int key, string keyColumn)
        {
            db.INCREMENTO_ORDEN.Remove(db.INCREMENTO_ORDEN.Single(o => o.COD_INCREMENTO_ORDEN == key));
            db.SaveChanges();
            return RedirectToAction("GetOrderData_incrementos");

        }
        #endregion
    }
}
