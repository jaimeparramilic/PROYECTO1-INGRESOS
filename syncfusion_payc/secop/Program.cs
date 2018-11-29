using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Configuration;


namespace importacion_noova
{
    class Program
    {
        static string connecString1 = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection3"].ConnectionString;
        static void Main(string[] args)
        {
            //Decalaración del Database Context
            secopEntities db = new secopEntities();
            
            //Mensaje de inicio
            Console.WriteLine("Importando información Secop");


            //Traer información del web service para clientes y deserializarla
            string details = CallRestMethod("https://api.colombiacompra.gov.co/releases/");
            dynamic results = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(details);


            //Almanar la información que nos interesa para la prueba
            var values = results.releases;

            //Recorrer elementos
            foreach (var a in values)
            {
                contratos p = new contratos();
                //Console.WriteLine( a.releases[0]);
                p.cod_secop = a.releases[0].tender.id;
                string temp = (string) a.releases[0].tender.id;
                Console.WriteLine("********************************************************");
                var procesos = db.contratos.Where(b => b.cod_secop == temp);
                foreach (var proceso in procesos)
                {
                    db.contratos.Remove(proceso);
                }
                Console.WriteLine("Id secop: " + a.releases[0].tender.id);
                p.objeto = a.releases[0].tender.description;
                Console.WriteLine("Objeto: " + DecodeServerName((string) a.releases[0].tender.description));
                p.tipo_proceso = a.releases[0].procurement_type;
                p.estado_proceso = a.releases[0].tender.complete;
                p.link_invitacion = a.releases[0].uri;
                p.entidad = a.releases[0].buyer.name;
                Console.WriteLine("Entidad: " + a.releases[0].buyer.name);
                p.dept_muni = a.releases[0].buyer.locality;
                p.depto = a.releases[0].buyer.region;
                p.clasificacion_unsp = a.releases[0].tender.items[0].description;
                p.regimen_contratacion = a.releases[0].procurement_type;
                Console.WriteLine("Tipo proceso: " + a.releases[0].procurement_type);
                p.cuantia = a.releases[0].tender.value.amount;
                Console.WriteLine("Cuantía: " + a.releases[0].tender.value.amount);
                p.moneda = a.releases[0].tender.value.currency;
                p.cod_secop = a.releases[0].num_constancia;
                p.id_unsp = a.releases[0].tender.items[0].id;

                try
                {
                    p.fecha_ini = a.releases[0].tender.tenderPeriod.startDate;
                }
                catch 
                {

                }
                p.estado_proceso = a.releases[0].tender.status;
                db.contratos.Add(p);
                db.SaveChanges();
                long cod_contrato = p.cod_contrato;
                var documentos = a.releases[0].tender.documents;
                //Recorrer documentos
                foreach (var docu in documentos)
                {
                    documentos_procesos d = new documentos_procesos();
                    d.descripcion = docu.description;
                    d.datemodified= docu.dateModified;
                    d.datepublished = docu.datePublished;
                    d.url = docu.url;
                    d.proceso = cod_contrato;
                    db.documentos_procesos.Add(d);
                }
                //Console.WriteLine("********************************************************");
            }
            db.SaveChanges();
                    

                

         
            //Console.ReadLine();
        }
        public static string EncodeServerName(string serverName)
        {
            return "";
        }

        public static string DecodeServerName(string encodedServername)
        {
            return Encoding.UTF8.GetString(Encoding.Default.GetBytes(encodedServername));
        }
        public static string CallRestMethod(string url)
        {

            //Crear el httprequest
            HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(url);
            //Crear Encabezado para get y recibir json
            webrequest.Method = "GET";
            //webrequest.Accept = "application/json, text/javascript, */*; q=0.01";
            //Usuarios cuando debamos enviarlos
            webrequest.ContentType = "application/json, charset=utf-8";
            
            //Envío de solicitud
            HttpWebResponse webresponse = (HttpWebResponse)webrequest.GetResponse();
            Encoding enc = System.Text.Encoding.GetEncoding("iso-8859-1");
            StreamReader responseStream = new StreamReader(webresponse.GetResponseStream(), enc);
            string result = string.Empty;
            result = responseStream.ReadToEnd();
            webresponse.Close();
            return result;
        }
    }
}
