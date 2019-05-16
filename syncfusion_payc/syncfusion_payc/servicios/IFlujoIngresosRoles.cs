using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using syncfusion_payc;
namespace syncfusion_payc.servicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IFlujoIngresosRoles" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IFlujoIngresosRoles
    {

        [OperationContract]
        Dictionary<string, object> InitializeGrid(string action, object customObject);

        [OperationContract]
        Dictionary<string, object> FetchMembers(string action, string headerTag, string sortedHeaders, string currentReport);

        [OperationContract]
        Dictionary<string, object> Filtering(string action, string filterParams, string sortedHeaders, string currentReport);

        [OperationContract]
        Dictionary<string, object> NodeStateModified(string action, string headerTag, string dropAxis, string sortedHeaders, string filterParams, string currentReport);


        [OperationContract]
        Dictionary<string, object> NodeDropped(string action, string dropAxis, string headerTag, string sortedHeaders, string filterParams, string currentReport);

        [OperationContract]
        Dictionary<string, object> Sorting(string action, string sortedHeaders, string currentReport);

        [OperationContract]
        void Export(System.IO.Stream stream);

        [OperationContract]
        Dictionary<string, object> DeferUpdate(string action, string filterParams, string sortedHeaders, string currentReport);

        [OperationContract]
        Dictionary<string, object> CalculatedField(string action, string headerTag, string currentReport);

        [OperationContract]
        Dictionary<string, object> CellEditing(string action, string index, string valueHeaders, string summaryValues, string currentReport,object customObject);

        [OperationContract]
        Dictionary<string, object> SaveReport(string reportName, string operationalMode, string olapReport, string clientReports);

        [OperationContract]
        Dictionary<string, object> LoadReportFromDB(string reportName, string operationalMode, string olapReport, string clientReports);
    }
}

