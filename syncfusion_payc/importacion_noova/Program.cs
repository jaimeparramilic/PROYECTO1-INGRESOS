using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft;
namespace importacion_noova
{
    class Program
    {
        
        static void Main(string[] args)
        {
            //Decalaración del Database Context
            repositorio_noovaEntities db = new repositorio_noovaEntities();

            //Mensaje de inicio
            Console.WriteLine("Importando información Noova");

            //Traer información del web service y deserializarla
            string details = CallRestMethod("http://polifonia.com.co:8080/servicios2/test.svc/asigna_informes");
            dynamic results = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(details);


            //Almanar la información que nos interesa para la prueba
            var values = results.value;

            //Recorrer elementos
            foreach(var a in values)
            {
                Console.WriteLine(a);
                pruebas p = new pruebas();
                p.asignacion = a.asignacion;
                p.color = a.color;
                p.dias_envio= a.dia_envio;
                p.dias_para_envio = a.dia_para_envio;
                p.dia_envio_num = a.dia_envio_num;
                p.estado = a.estado;
                p.fecha_proximo_envio = a.fecha_proximo_envio;
                p.fecha_ultimo_envio = a.fecha_ultimo_envio;
                p.hora_envio = a.hora_envio;
                p.nombre = a.nombre;
                p.nombre_usuario = a.nombre_usuario;
                p.periodicidad = a.periodicidad;
                p.periodicidad_num = a.periodicidad_num;
                p.ultimo_informe = a.ultimo_informe;
                p.usuario = a.usuario;
                db.pruebas.Add(p);
                db.SaveChanges();
            }
            Console.ReadLine();
        }

        public static string CallRestMethod(string url)
        {

            //Crear el httprequest
            HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(url);
            //Crear Encabezado para get y recibir json
            webrequest.Method = "GET";
            webrequest.Accept = "application/json, text/javascript, */*; q=0.01";
            //Usuarios cuando debamos enviarlos
            //webrequest.Headers.Add("Username", "xyz");
            //webrequest.Headers.Add("Password", "abc");

            //Envío de solicitud
            HttpWebResponse webresponse = (HttpWebResponse)webrequest.GetResponse();
            Encoding enc = System.Text.Encoding.GetEncoding("utf-8");
            StreamReader responseStream = new StreamReader(webresponse.GetResponseStream(), enc);
            string result = string.Empty;
            result = responseStream.ReadToEnd();
            webresponse.Close();
            return result;
        }
    }
}
