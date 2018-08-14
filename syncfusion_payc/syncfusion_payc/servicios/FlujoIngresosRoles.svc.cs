using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.Entity;
using System.Net;
using System.Web;
using System.Web.Mvc;
using syncfusion_payc.Models;
using System.IO;
using Syncfusion.JavaScript;
using Syncfusion.JavaScript.DataSources;
using System.Diagnostics;
using System.Configuration;
using System.ServiceModel.Activation;
using System.Web.Script.Serialization;
using System.Data.SqlServerCe;
using Syncfusion.Olap;
using Syncfusion.Olap.Reports;
using Syncfusion.Olap.Common;
using OLAPUTILS = Syncfusion.JavaScript.Olap;
using Syncfusion.PivotAnalysis.Base;
using syncfusion_payc;
using System.Globalization;
using System.Threading;
namespace syncfusion_payc.servicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "FlujoIngresosRoles" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione FlujoIngresosRoles.svc o FlujoIngresosRoles.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class objeto_custom
    {
       public long id { get; set; }
    }
    public static class RetryHelper
    {
       

       
    }

    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class FlujoIngresosRoles : IFlujoIngresosRoles
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
            customObject1= new string(customObject1.Where(c => char.IsDigit(c)).ToArray());
            
            long contrato = Convert.ToInt64(customObject1);
            var refresh = false;
            int reintentos = 1;
            while (!refresh && reintentos<10)
            {
                try
                {
                    Debug.WriteLine(contrato.ToString());
                    contrato = Convert.ToInt64(contrato);
                    var flujo_contrato = db.VISTA_FLUJO_INGRESOS.Where(c => c.COD_CONTRATO_PROYECTO == contrato).ToList();
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
            dict = htmlHelper.GetJsonData(action, db.VISTA_FLUJO_INGRESOS.ToList(), headerTag, sortedHeaders);
            return dict;
        }

        //Filtrado
        public Dictionary<string, object> Filtering(string action, string filterParams, string sortedHeaders, string currentReport)
        {
            htmlHelper.PopulateData(currentReport);
            dict = htmlHelper.GetJsonData(action, db.VISTA_FLUJO_INGRESOS.ToList(), filterParams, sortedHeaders);
            return dict;
        }

        //Modificación estados
        public Dictionary<string, object> NodeStateModified(string action, string headerTag, string dropAxis, string sortedHeaders, string filterParams, string currentReport)
        {
            htmlHelper.PopulateData(currentReport);
            dict = htmlHelper.GetJsonData(action, db.VISTA_FLUJO_INGRESOS.ToList(), headerTag, dropAxis, filterParams, sortedHeaders);
            return dict;
        }

        //Nodo vaciado
        public Dictionary<string, object> NodeDropped(string action, string dropAxis, string headerTag, string sortedHeaders, string filterParams, string currentReport)
        {
            htmlHelper.PopulateData(currentReport);
            dict = htmlHelper.GetJsonData(action, db.VISTA_FLUJO_INGRESOS.ToList(), dropAxis, headerTag, filterParams, sortedHeaders);
            return dict;
        }

        //Ordenar
        public Dictionary<string, object> Sorting(string action, string sortedHeaders, string currentReport)
        {
            htmlHelper.PopulateData(currentReport);
            dict = htmlHelper.GetJsonData(action, db.VISTA_FLUJO_INGRESOS.ToList(), sortedHeaders);
            return dict;
        }

        //Campos Calculados
        public Dictionary<string, object> CalculatedField(string action, string headerTag, string currentReport)
        {
            htmlHelper.PopulateData(currentReport);
            dict = htmlHelper.GetJsonData(action, db.VISTA_FLUJO_INGRESOS.ToList(), null, headerTag);
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
            htmlHelper.ExportPivotGrid(db.VISTA_FLUJO_INGRESOS.ToList(), args, fileName, System.Web.HttpContext.Current.Response);
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
                dictionary = htmlHelper.GetJsonData("loadOperation", db.VISTA_FLUJO_INGRESOS.ToList(), "Load Report", reportName);
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
            dict = htmlHelper.GetJsonData(action, db.VISTA_FLUJO_INGRESOS.ToList(), null, null, null, sortedHeaders, filterParams);
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
            try
            {
                VISTA_FLUJO_INGRESOS table = db.VISTA_FLUJO_INGRESOS.Single(o => o.FECHA_FORMA_PAGO == temp && o.DESCRIPCION == columna && o.COD_CONTRATO_PROYECTO == id_contrato_proyecto);
                long id_flujo_ingresos_rol = table.COD_FLUJO_INGRESOS_ROL;
                FLUJO_INGRESOS_ROL table1 = db.FLUJO_INGRESOS_ROL.Single(o => o.COD_FLUJO_INGRESOS_ROL == id_flujo_ingresos_rol);
                FLUJO_INGRESOS_ROL tabletemp = table1;
                tabletemp.VALOR_FACTOR_MULTIPLICADOR = float.Parse(summaryValues.Replace("$", "").Replace(",", ""));
                db.Entry(table1).CurrentValues.SetValues(tabletemp);
                db.SaveChanges();
                htmlHelper.PopulateData(currentReport);
            }
            catch
            {
                
            }
            var flujo_contrato = db.VISTA_FLUJO_INGRESOS.Where(c => c.COD_CONTRATO_PROYECTO == id_contrato_proyecto).ToList();
            dict = htmlHelper.GetJsonData(action, flujo_contrato, index, summaryValues, valueHeaders);
            return dict;
        }

        //Configuración inicial
        private PivotReport BindDefaultData()
        {
            PivotReport pivotSetting = new PivotReport();
            SortElement sortElement = new SortElement(AxisPosition.Slicer, Syncfusion.Olap.Reports.SortOrder.DESC, true);
            
            pivotSetting.PivotRows.Add(new PivotItem { FieldMappingName = "DESCRIPCION", FieldHeader = "ROLES", TotalHeader = "Total" });
            
            pivotSetting.PivotColumns.Add(new PivotItem { FieldMappingName = "FECHA_FORMA_PAGO", FieldHeader = "FECHAS", TotalHeader = "Total", Format = "dd/MM/yyyy",Comparer= new DateComparer("dd/MM/yyyy") });
           
            pivotSetting.PivotCalculations.Add(new PivotComputationInfo { CalculationName = "SUMA TOTAL", Description = "VALOR TOTAL",FieldName = "VALOR_FACTOR_MULTIPLICADOR", Format = "c0", SummaryType = Syncfusion.PivotAnalysis.Base.SummaryType.DoubleTotalSum });
            return pivotSetting;
        }

      
    }

    //Funciones auxiliares para ordenamiento de elements pivot grid
    public class MonthOrderComparer : IComparer
    {
        #region IComparer Members   
        Dictionary<string, int> month;
        public MonthOrderComparer(Dictionary<string, int> month)
        {
            this.month = month;
        }
        public int Compare(object x, object y)
        {
            if (x == null && y == null)
                return 0;
            else if (y == null)
                return 1;
            else if (x == null)
                return -1;
            else
            {
                string keyX = x.ToString();
                string keyY = y.ToString();
                if (month[keyX] < month[keyY])
                {
                    return 0;
                }
                else
                    return month[keyX];
            }
        }
        #endregion
    }

    public class DayComparer : IComparer
    {
        /// <summary> 
        /// Compare for DateTime objects. 
        /// </summary> 
        /// <param name="x">object.</param> 
        /// <param name="y">object.</param> 
        /// <returns>integer</returns> 
        public int Compare(object x, object y)
        {
            DateTime dummyX, dummyY;
            if (x == null && y == null)
                return 0;
            else if (y == null)
                return 1;
            else if (x == null)
                return -1;
            else if (DateTime.TryParseExact(x.ToString(), "dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dummyX) && DateTime.TryParseExact(y.ToString(), "dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dummyY))
                return DateTime.Compare(dummyX.Date, dummyY.Date);
            else
                return 0;
        }
    }

    public class DateComparer : IComparer

    {

        Dictionary<string, int> lookUp = null;

        string fmt = string.Empty;

        public DateComparer(string format)

        {

            fmt = string.Format("{0}", format);

            lookUp = new Dictionary<string, int>();

            DateTime dt0 = Convert.ToDateTime("2010/12/01");

            DateTime dt1 = Convert.ToDateTime("2030/01/08");

            double days = (dt1 - dt0).TotalDays;

            for (int j = 0; j <= days; j++)

            {

                DateTime dt = dt0.AddDays(j);

                if (!lookUp.ContainsKey(dt.ToString(fmt)))

                {

                    lookUp.Add(dt.ToString(fmt), j);

                }

            }

        }

        public int Compare(object x, object y)

        {

            DateTime x1, y1;

            if (DateTime.TryParse(x.ToString(), out x1) && DateTime.TryParse(y.ToString(), out y1))

            {

                x = x1.ToString(fmt);

                y = y1.ToString(fmt);

            }

            return lookUp[x.ToString()].CompareTo(lookUp[(y.ToString())]);

        }

    }

    

}
