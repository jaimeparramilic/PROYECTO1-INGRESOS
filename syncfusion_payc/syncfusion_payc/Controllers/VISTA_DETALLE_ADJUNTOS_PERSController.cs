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
        public ActionResult ExcelExport(string gridModel,long COD_FACTURA,long COD_CONTRATO_PROYECTO)
        {
            ExcelExport exp = new ExcelExport();
            
            var DataSource = db.VISTA_DETALLE_FACTURAS_REPORTE.Where(o=> o.COD_CONTRATO_PROYECTO == COD_CONTRATO_PROYECTO).Select(x=> new { x.PERIODO_FACTURACION,x.NUMERO_FACTURA,x.CENTRO_COSTOS,x.NOMBRE_PROYECTO, x.TIPO_ELEMENTO,x.NOMBRE_ROL,x.NOMBRE_PERSONA,x.FECHA_INGRESO,x.FECHA_RETIRO_EN_CONTRATO,x.VALOR_SIN_IMPUESTOS,x.SALARIO_COMERCIAL_SIN_PRESTACIONES_CON_INCREMENTOS,x.PRESTACIONES,x.VALOR_DIAS_LAB,x.DESCUENTO_AUSENCIA, x.HORAS_AUSENCIA, x.DIAS_AUSENCIA, x.ADICIONES,x.HORAS_ED,x.HORAS_EN, x.HORAS_FD,x.HORAS_FN, x.NOVEDADES }).ToList();
            int contar = DataSource.Count() + 1;
            DataTable tabla = DataSource.ToDataTable();
            //Características EXCEL
            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                IApplication application = excelEngine.Excel;
                application.DefaultVersion = ExcelVersion.Excel2013;
                IWorkbook workbook = application.Workbooks.Create(1);
                IWorksheet worksheet = workbook.Worksheets[0];
                worksheet.Name = "BASE DE DATOS";
                worksheet.Range["A1:V1"].CellStyle.FillBackground= Syncfusion.XlsIO.ExcelKnownColors.Brown;
                worksheet.Range["A1:V1"].CellStyle.Font.Color = Syncfusion.XlsIO.ExcelKnownColors.White;
                worksheet.Range["A1:V"+contar.ToString()].CellStyle.Borders.LineStyle = Syncfusion.XlsIO.ExcelLineStyle.Thin;
                worksheet.Range["A1:V" + contar.ToString()].CellStyle.Borders[ExcelBordersIndex.DiagonalDown].LineStyle = Syncfusion.XlsIO.ExcelLineStyle.None;
                worksheet.Range["A1:V" + contar.ToString()].CellStyle.Borders[ExcelBordersIndex.DiagonalUp].LineStyle = Syncfusion.XlsIO.ExcelLineStyle.None;
                worksheet.Range["A2:V" + contar.ToString()].Borders.Color = Syncfusion.XlsIO.ExcelKnownColors.Black;
                worksheet.Range["A1:V1"].Borders.Color = Syncfusion.XlsIO.ExcelKnownColors.White;
                worksheet.Range["A1:V1"].CellStyle.Font.Bold = true;
                
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
                worksheet.Range["F1"].Text = "Rol / Item";
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
                worksheet.InsertRow(1);
                worksheet.InsertRow(1);

                worksheet.Range["B1"].Text = "PAYC - ARCHIVO CON DETALLE ADJUNTO A LA FACTURA";
                worksheet.Range["B1:V1"].Merge();
                worksheet.Range["B1:V1"].Borders.LineStyle = Syncfusion.XlsIO.ExcelLineStyle.Double;
                worksheet.Range["B1:V1"].Borders.Color = Syncfusion.XlsIO.ExcelKnownColors.Black;
                worksheet.Range["B1:V1"].CellStyle.Borders[ExcelBordersIndex.DiagonalDown].LineStyle = Syncfusion.XlsIO.ExcelLineStyle.None;
                worksheet.Range["B1:V1"].CellStyle.Borders[ExcelBordersIndex.DiagonalUp].LineStyle = Syncfusion.XlsIO.ExcelLineStyle.None;
                worksheet.Range["B1:V1"].HorizontalAlignment = ExcelHAlign.HAlignJustify;
                worksheet.Range["B1:V1"].VerticalAlignment= ExcelVAlign.VAlignCenter;
                worksheet.Range["B1:V1"].CellStyle.Font.Bold = true;
                worksheet.Range["B1:V1"].Merge();
                
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

                IWorksheet pivot = workbook.Worksheets.Create();
                pivot.Name = "TABLA DINAMICA";
                IPivotCache cache = workbook.PivotCaches.Add(worksheet["A3:U" + (contar + 2).ToString()]);
                IPivotTable pivotTable = pivot.PivotTables.Add("PivotTable1", pivot["A3"], cache);
                pivotTable.Fields[4].Axis = PivotAxisTypes.Row;
                pivotTable.Fields[3].Axis = PivotAxisTypes.Row;
                pivotTable.Fields[2].Axis = PivotAxisTypes.Row;
                pivotTable.Fields[1].Axis = PivotAxisTypes.Row;
                pivotTable.Fields[5].Axis = PivotAxisTypes.Row;
                pivotTable.Fields[6].Axis = PivotAxisTypes.Row;
                pivotTable.Fields[0].Axis = PivotAxisTypes.Column;

                
                IPivotField field1 = pivotTable.Fields[9];
                pivotTable.DataFields.Add(field1, "Sum", PivotSubtotalTypes.Sum);
                /*IPivotField field2 = pivotTable.Fields[10];
                pivotTable.DataFields.Add(field2, "Sum", PivotSubtotalTypes.Sum);
                IPivotField field3 = pivotTable.Fields[11];
                pivotTable.DataFields.Add(field3, "Sum", PivotSubtotalTypes.Sum);
                IPivotField field4 = pivotTable.Fields[12];
                pivotTable.DataFields.Add(field4, "Sum", PivotSubtotalTypes.Sum);
                IPivotField field5 = pivotTable.Fields[13];
                pivotTable.DataFields.Add(field5, "Sum", PivotSubtotalTypes.Sum);
                IPivotField field6 = pivotTable.Fields[14];
                pivotTable.DataFields.Add(field6, "Sum", PivotSubtotalTypes.Sum);
                IPivotField field7 = pivotTable.Fields[15];
                pivotTable.DataFields.Add(field7, "Sum", PivotSubtotalTypes.Sum);
                IPivotField field8 = pivotTable.Fields[16];
                pivotTable.DataFields.Add(field8, "Sum", PivotSubtotalTypes.Sum);
                IPivotField field9 = pivotTable.Fields[17];
                pivotTable.DataFields.Add(field9, "Sum", PivotSubtotalTypes.Sum);
                IPivotField field10 = pivotTable.Fields[18];
                pivotTable.DataFields.Add(field10, "Sum", PivotSubtotalTypes.Sum);
                IPivotField field11 = pivotTable.Fields[19];
                pivotTable.DataFields.Add(field11, "Sum", PivotSubtotalTypes.Sum);
                IPivotField field12 = pivotTable.Fields[20];
                pivotTable.DataFields.Add(field12, "Sum", PivotSubtotalTypes.Sum);*/

                pivotTable.BuiltInStyle = PivotBuiltInStyles.PivotStyleDark2;
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
