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
            Console.WriteLine("Importando información Noova");
            string details = CallRestMethod("http://polifonia.com.co:8080/servicios2/test.svc/asigna_informes");
            Newtonsoft.Json.Linq.JObject jObject = Newtonsoft.Json.Linq.JObject.Parse(details);
            Console.WriteLine(jObject["value"]);
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
