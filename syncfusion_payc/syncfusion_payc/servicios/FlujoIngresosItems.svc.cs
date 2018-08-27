using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using syncfusion_payc.Models;
using Syncfusion.JavaScript;
using System.Configuration;

using System.Web.Script.Serialization;
using System.Data.SqlServerCe;

using Syncfusion.Olap.Reports;

using OLAPUTILS = Syncfusion.JavaScript.Olap;
using Syncfusion.PivotAnalysis.Base;
using syncfusion_payc;
using System.Globalization;
using System.Threading;
namespace syncfusion_payc.servicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "FlujoIngresosItems" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione FlujoIngresosItems.svc o FlujoIngresosItems.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class FlujoIngresosItems : IFlujoIngresosItems
    {
        //Declaración de variables
        PivotGrid htmlHelper = new PivotGrid();
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        Dictionary<string, object> dict = new Dictionary<string, object>();
        static int cultureIDInfoval = 1033;
        static string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection1"].ConnectionString;
        string conStringforDB = ConfigurationManager.ConnectionStrings["DefaultConnection1"].ConnectionString;
        private test_payc_contabilidadEntities db = new test_payc_contabilidadEntities();

        //Inicialización grid
        public Dictionary<string, object> InitializeGrid(string action, object customObject)

        {
            dynamic customData = serializer.Deserialize<dynamic>(customObject.ToString());

            string customObject1 = customData["COD_CONTRATO_PROYECTO"].ToString();
            htmlHelper.PivotReport = BindDefaultData();
            if (customObject1.Contains("\""))
            {
                customObject1 = customObject1.Replace("\"", "");
            }
            customObject1 = new string(customObject1.Where(c => char.IsDigit(c)).ToArray());

            long contrato = Convert.ToInt64(customObject1);
            var refresh = false;
            int reintentos = 1;
            while (!refresh && reintentos < 10)
            {
                try
                {
                   
                    contrato = Convert.ToInt64(contrato);
                    var flujo_contrato = db.VISTA_FLUJO_INGRESOS_ITEMS.Where(c => c.COD_CONTRATO_PROYECTO == contrato && c.ESTADO == "SI").ToList();
                    dict = htmlHelper.GetJsonData(action, flujo_contrato);
                    refresh = true;
                }
                catch
                {
                    Thread.Sleep(3000);
                    reintentos = reintentos + 1;
                }
            }

                
            return dict;
        }

        //Traer elementos
        public Dictionary<string, object> FetchMembers(string action, string headerTag, string sortedHeaders, string currentReport)
        {
            htmlHelper.PopulateData(currentReport);
            dict = htmlHelper.GetJsonData(action, db.VISTA_FLUJO_INGRESOS_ITEMS.ToList(), headerTag, sortedHeaders);

            return dict;
        }

        //Filtrado
        public Dictionary<string, object> Filtering(string action, string filterParams, string sortedHeaders, string currentReport)
        {
            htmlHelper.PopulateData(currentReport);
            dict = htmlHelper.GetJsonData(action, db.VISTA_FLUJO_INGRESOS_ITEMS.ToList(), filterParams, sortedHeaders);
            return dict;
        }

        //Modificación estados
        public Dictionary<string, object> NodeStateModified(string action, string headerTag, string dropAxis, string sortedHeaders, string filterParams, string currentReport)
        {
            htmlHelper.PopulateData(currentReport);
            dict = htmlHelper.GetJsonData(action, db.VISTA_FLUJO_INGRESOS_ITEMS.ToList(), headerTag, dropAxis, filterParams, sortedHeaders);
            return dict;
        }

        //Nodo vaciado
        public Dictionary<string, object> NodeDropped(string action, string dropAxis, string headerTag, string sortedHeaders, string filterParams, string currentReport)
        {
            htmlHelper.PopulateData(currentReport);
            dict = htmlHelper.GetJsonData(action, db.VISTA_FLUJO_INGRESOS_ITEMS.ToList(), dropAxis, headerTag, filterParams, sortedHeaders);
            return dict;
        }

        //Ordenar
        public Dictionary<string, object> Sorting(string action, string sortedHeaders, string currentReport)
        {
            htmlHelper.PopulateData(currentReport);
            dict = htmlHelper.GetJsonData(action, db.VISTA_FLUJO_INGRESOS_ITEMS.ToList(), sortedHeaders);
            return dict;
        }

        //Campos Calculados
        public Dictionary<string, object> CalculatedField(string action, string headerTag, string currentReport)
        {
            htmlHelper.PopulateData(currentReport);
            dict = htmlHelper.GetJsonData(action, db.VISTA_FLUJO_INGRESOS_ITEMS.ToList(), null, headerTag);
            return dict;
        }

        //Exportación
        public void Export(System.IO.Stream stream)
        {
            System.IO.StreamReader sReader = new System.IO.StreamReader(stream);
            string args = System.Web.HttpContext.Current.Server.UrlDecode(sReader.ReadToEnd()).Remove(0, 5);
            Dictionary<string, string> gridParams = serializer.Deserialize<Dictionary<string, string>>(args);
            htmlHelper.PopulateData(gridParams["currentReport"]);
            string fileName = "Sample";
            htmlHelper.ExportPivotGrid(db.VISTA_FLUJO_INGRESOS_ITEMS.ToList(), args, fileName, System.Web.HttpContext.Current.Response);
        }

        //Guardar reporte en bd reportres
        public Dictionary<string, object> SaveReport(string reportName, string operationalMode, string olapReport, string clientReports)
        {
            string mode = operationalMode;
            bool isDuplicate = true;
            SqlCeConnection con = new SqlCeConnection() { ConnectionString = conStringforDB };
            con.Open();
            SqlCeCommand cmd1 = null;
            foreach (DataRow row in GetDataTable().Rows)
            {
                if ((row.ItemArray[0] as string).Equals(reportName))
                {
                    isDuplicate = false;
                    cmd1 = new SqlCeCommand("update ReportsTable set Report=@Reports where ReportName like @ReportName", con);
                }
            }
            if (isDuplicate)
            {
                cmd1 = new SqlCeCommand("insert into ReportsTable Values(@ReportName,@Reports)", con);
            }
            cmd1.Parameters.AddWithValue("@ReportName", reportName);
            //cmd1.Parameters.Add("@Reports", OLAPUTILS.Utils.GetReportStream(clientReports).ToArray());
            if (mode == "serverMode")
                cmd1.Parameters.AddWithValue("@Reports", OLAPUTILS.Utils.GetReportStream(clientReports).ToArray());
            else if (mode == "clientMode")
                cmd1.Parameters.AddWithValue("@Reports", Encoding.UTF8.GetBytes(clientReports).ToArray());
            cmd1.ExecuteNonQuery();
            con.Close();
            return null;
        }

        //Cargar reporte de bd reportes
        public Dictionary<string, object> LoadReportFromDB(string reportName, string operationalMode, string olapReport, string clientReports)
        {
            byte[] reportString = new byte[2 * 1024];
            PivotReport report = new PivotReport();
            var reports = "";
            string mode = operationalMode;
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            if (mode == "serverMode" && !string.IsNullOrEmpty(clientReports))
            {
                reports = clientReports;
            }
            else
            {
                foreach (DataRow row in GetDataTable().Rows)
                {
                    if ((row.ItemArray[0] as string).Equals(reportName))
                    {
                        if (mode == "clientMode")
                        {
                            reportString = (row.ItemArray[1] as byte[]);
                            dictionary.Add("report", Encoding.UTF8.GetString(reportString));
                            break;
                        }
                        else if (mode == "serverMode")
                        {
                            reports = OLAPUTILS.Utils.CompressData(row.ItemArray[1] as byte[]);
                            break;
                        }
                    }
                }
            }
            if (reports != "")
            {
                //htmlHelper.ReportManipulations.

                report = htmlHelper.DeserializedReports(reports);
                //report = htmlHelper.
                htmlHelper.PivotReport = report;
                dictionary = htmlHelper.GetJsonData("loadOperation", db.VISTA_FLUJO_INGRESOS_ITEMS.ToList(), "Load Report", reportName);
            }
            return dictionary;
        }

        //Traer tabla
        private DataTable GetDataTable()
        {
            SqlCeConnection con = new SqlCeConnection() { ConnectionString = conStringforDB };
            con.Open();
            DataSet dSet = new DataSet();
            new SqlCeDataAdapter("Select * from ReportsTable", con).Fill(dSet);
            con.Close();
            return dSet.Tables[0];
        }

        //Actualizar
        public Dictionary<string, object> DeferUpdate(string action, string filterParams, string sortedHeaders, string currentReport)
        {
            htmlHelper.PopulateData(currentReport);
            dict = htmlHelper.GetJsonData(action, db.VISTA_FLUJO_INGRESOS_ITEMS.ToList(), null, null, null, sortedHeaders, filterParams);
            return dict;
        }

        //Editar celda
        public Dictionary<string, object> CellEditing(string action, string index, string valueHeaders, string summaryValues, string currentReport, object customObject)
        {
            dynamic customData = serializer.Deserialize<dynamic>(customObject.ToString());
            string columna = customData["fila"].ToString();
            //Debug.WriteLine(columna);
            DateTime temp = DateTime.ParseExact(customData["columna"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            long id_contrato_proyecto = Convert.ToInt64(customData["id_contrato_proyecto"].ToString());
            VISTA_FLUJO_INGRESOS_ITEMS table = db.VISTA_FLUJO_INGRESOS_ITEMS.Single(o => o.FECHA_FORMA_PAGO == temp && o.DESCRIPCION == columna && o.COD_CONTRATO_PROYECTO == id_contrato_proyecto && o.ESTADO == "SI");
            long id_flujo_ingresos_rol = table.COD_FLUJO_INGRESOS_ITEMS;
            DateTime hoy = DateTime.Today;
            FLUJO_INGRESOS_ITEMS table1 = db.FLUJO_INGRESOS_ITEMS.Single(o => o.COD_FLUJO_INGRESOS_ITEMS == id_flujo_ingresos_rol && o.ESTADO == "SI");
            FLUJO_INGRESOS_ITEMS tabletemp = new FLUJO_INGRESOS_ITEMS();
            table1.ESTADO = "NO";
            table1.COD_FORMAS_PAGO_FECHAS = table1.COD_FORMAS_PAGO_FECHAS;
            table1.USUARIO_REGISTRO = table1.USUARIO_REGISTRO;
            table1.FECHA_REGISTRO = table1.FECHA_REGISTRO;
            table1.ETAPA = table1.ETAPA;
            db.Entry(table1).CurrentValues.SetValues(table1);
            tabletemp.VALOR_TOTAL = float.Parse(summaryValues.Replace("$", "").Replace(",", ""));
            tabletemp.VALOR_FIJO = 0;
            tabletemp.VALOR_VARIABLE = 0;
            tabletemp.COD_CONTRATO_PROYECTO = table1.COD_CONTRATO_PROYECTO;
            tabletemp.COD_FORMAS_PAGO_FECHAS = table1.COD_FORMAS_PAGO_FECHAS;
            tabletemp.COD_ITEM_CONTRATO = table1.COD_ITEM_CONTRATO;
            tabletemp.ETAPA = table1.ETAPA;
            tabletemp.ESTADO = "SI";
            tabletemp.USUARIO_REGISTRO = System.Web.HttpContext.Current.User.Identity.Name;
            tabletemp.FECHA_REGISTRO = hoy;
            db.FLUJO_INGRESOS_ITEMS.Add(tabletemp);
            db.SaveChanges();
            htmlHelper.PopulateData(currentReport);
            var flujo_contrato = db.VISTA_FLUJO_INGRESOS_ITEMS.Where(c => c.COD_CONTRATO_PROYECTO == id_contrato_proyecto && c.ESTADO == "SI").ToList();
            dict = htmlHelper.GetJsonData(action, flujo_contrato, index, summaryValues, valueHeaders);
            return dict;
        }

        //Configuración inicial
        private PivotReport BindDefaultData()
        {
            PivotReport pivotSetting = new PivotReport();
            SortElement sortElement = new SortElement(AxisPosition.Slicer, Syncfusion.Olap.Reports.SortOrder.DESC, true);
            pivotSetting.PivotRows.Add(new PivotItem { FieldMappingName = "DESCRIPCION", FieldHeader = "ITEMS", TotalHeader = "Total" });
            pivotSetting.PivotColumns.Add(new PivotItem { FieldMappingName = "FECHA_FORMA_PAGO", FieldHeader = "FECHAS", TotalHeader = "Total", Format = "dd/MM/yyyy", Comparer = new DateComparer("dd/MM/yyyy") });
            pivotSetting.PivotCalculations.Add(new PivotComputationInfo { CalculationName = "SUMA TOTAL", Description = "VALOR TOTAL", FieldName = "VALOR_TOTAL", Format = "c0", SummaryType = Syncfusion.PivotAnalysis.Base.SummaryType.DoubleTotalSum });
            return pivotSetting;
        }
    }
}
