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
namespace syncfusion_payc.Controllers
{
    public class VISTA_DETALLE_ADJUNTOS_PERSController : Controller
    {
        private test_payc_contabilidadEntities db = new test_payc_contabilidadEntities();

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
        public ActionResult PerformInsert(EditParams_VISTA_DETALLE_ADJUNTOS_PERS param)
        {
            db.VISTA_DETALLE_ADJUNTOS_PERS.Add(param.value);
            db.SaveChanges();
			var data = db.VISTA_DETALLE_ADJUNTOS_PERS.ToList();
			var value = data.Last();
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        //Actualizar grid
        public ActionResult PerformUpdate(EditParams_VISTA_DETALLE_ADJUNTOS_PERS param)
        {
            
			VISTA_DETALLE_ADJUNTOS_PERS table = db.VISTA_DETALLE_ADJUNTOS_PERS.Single(o => o.COD_DETALLE_FACTURA_ADJUNTO_PERS == param.value.COD_DETALLE_FACTURA_ADJUNTO_PERS);

            db.Entry(table).CurrentValues.SetValues(param.value);
            db.SaveChanges();
			return RedirectToAction("GetOrderData");
			
        }

        //Borrar grid
        public ActionResult PerformDelete(int key, string keyColumn)
        {
            db.VISTA_DETALLE_ADJUNTOS_PERS.Remove(db.VISTA_DETALLE_ADJUNTOS_PERS.Single(o => o.COD_DETALLE_FACTURA_ADJUNTO_PERS== key));
            db.SaveChanges();
            return RedirectToAction("GetOrderData");
            
        }

        //Novedades nomina asociados al adjunto
        public ActionResult GetOrderData_novedades(DataManager dm)
        {
            IEnumerable DataSource = db.VISTA_REGISTRO_NOVEDADES.ToList();
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
            var count = DataSource.Cast<VISTA_REGISTRO_NOVEDADES>().Count();
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

        //Adjunto exportar
        [System.Web.Http.ActionName("ExcelExport")]
        [AcceptVerbs("POST")]
        public ActionResult ExcelExport(string gridModel,long COD_FACTURA)
        {
            ExcelExport exp = new ExcelExport();
            
            IList<VISTA_DETALLE_ADJUNTO_PERS_EXPORT> DataSource = db.VISTA_DETALLE_ADJUNTO_PERS_EXPORT.Where(o=> o.COD_FACTURA == COD_FACTURA).ToList();
            
            DataTable tabla = DataSource.ToDataTable();
            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                IApplication application = excelEngine.Excel;
                application.DefaultVersion = ExcelVersion.Excel2013;
                IWorkbook workbook = application.Workbooks.Create(1);
                IWorksheet worksheet = workbook.Worksheets[0];
                
                worksheet.Range["A1:Q1"].CellStyle.FillBackground= Syncfusion.XlsIO.ExcelKnownColors.Brown;
                worksheet.Range["A1:Q1"].CellStyle.Font.Color = Syncfusion.XlsIO.ExcelKnownColors.White;
                worksheet.Range["A1:Q30"].CellStyle.Borders.LineStyle = Syncfusion.XlsIO.ExcelLineStyle.Thin;
                worksheet.Range["A1:Q30"].CellStyle.Borders[ExcelBordersIndex.DiagonalDown].LineStyle = Syncfusion.XlsIO.ExcelLineStyle.None;
                worksheet.Range["A1:Q30"].CellStyle.Borders[ExcelBordersIndex.DiagonalUp].LineStyle = Syncfusion.XlsIO.ExcelLineStyle.None;
                worksheet.Range["A2:Q30"].Borders.Color = Syncfusion.XlsIO.ExcelKnownColors.Black;
                worksheet.Range["A1:Q1"].Borders.Color = Syncfusion.XlsIO.ExcelKnownColors.White;
                //Initialize the DataTable
                DataTable table = tabla;
                var fileSave = System.Web.HttpContext.Current.Server.MapPath("adjuntosfactura");
                if (!Directory.Exists(fileSave))
                {
                    Directory.CreateDirectory(fileSave);
                }
                //Import DataTable to the worksheet.
                worksheet.ImportDataTable(table, true, 1, 1);
                worksheet.InsertRow(1);
                worksheet.InsertRow(1);
                worksheet.Range["A1"].Text = "ARCHIVO CON DETALLE ADJUNTO A LA FACTURA";
                worksheet.Range["A1:Q1"].Merge();
                worksheet.Range["A1:Q1"].Borders.LineStyle = Syncfusion.XlsIO.ExcelLineStyle.Double;
                worksheet.Range["A1:Q1"].Borders.Color = Syncfusion.XlsIO.ExcelKnownColors.Black;
                worksheet.Range["A1:Q1"].CellStyle.Borders[ExcelBordersIndex.DiagonalDown].LineStyle = Syncfusion.XlsIO.ExcelLineStyle.None;
                worksheet.Range["A1:Q1"].CellStyle.Borders[ExcelBordersIndex.DiagonalUp].LineStyle = Syncfusion.XlsIO.ExcelLineStyle.None;
                worksheet.Range["A1:Q1"].HorizontalAlignment = ExcelHAlign.HAlignCenterAcrossSelection;
                int i = 1;
                while (i <= 16) { 
                    worksheet.AutofitColumn(i);
                    i = i + 1;
                }
                worksheet.SetColumnWidth(17, 40);
                worksheet.Range["A3:Q32"].WrapText = true;

                var fileSavePath = Path.Combine(fileSave, "Adjunto_"+COD_FACTURA+".xlsx");
                workbook.SaveAs(fileSavePath);
            }
            return Json(new { result = COD_FACTURA.ToString(), success = true }, JsonRequestBehavior.AllowGet);
        }
        
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

    }
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
}
