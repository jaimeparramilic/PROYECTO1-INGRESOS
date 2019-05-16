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
            repositorio_noovaEntities db = new repositorio_noovaEntities();
            
            //Mensaje de inicio
            Console.WriteLine("Importando información Noova");

            //Buscar IDs sin confirmación
            string query = @"SELECT TOP (1000) [ID_MAESTRO]
                              ,[ID_FACTURA]
                              ,[ID_DOCUMENTO]
                          FROM [repositorio_noova].[dbo].[FALTANTES_CONFIRMACION]";

            string existececo = "NO";
            using (SqlConnection connection = new SqlConnection(connecString1))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    existececo = dr.GetValue(0).ToString();
                    //Traer información del web service para clientes y deserializarla
                    string details = CallRestMethod("https://capi.noova.com.co/api/facfacturasc?e=860077099&id=" + existececo + "&t=E");
                    dynamic results = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(details);

                    int id_maestro= Convert.ToInt32(existececo);
                    //Almanar la información que nos interesa para la prueba
                    var values = results.ReporteRespuesta;

                    //Recorrer elementos
                    foreach (var a in values)
                    {
                        Console.WriteLine(a);
                        aceptacion_cliente p = new aceptacion_cliente();
                        p.NVACE_FECH = a.Nvace_fech;
                        p.NVENV_ESTN = a.Nvenv_estn;
                        p.NVING_FECH = a.Nvenv_fech;
                        p.NVREC_CODI = a.Nvrec_codi;
                        p.NVREC_DESC = a.Nvrec_desc;
                        p.NVREC_FECH = a.Nvrec_fech;
                        p.NVREC_OBSE = a.Nvrec_obse;
                        p.ID_MAESTRO = Convert.ToInt32(existececo);
                        db.aceptacion_cliente.Add(p);
                        db.SaveChanges();
                    }

                    string details1 = CallRestMethod("https://capi.noova.com.co/api/facfacturas?e=860077099&id=" + existececo + "&t=E");
                    dynamic results1 = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(details1);


                    //Almanar la información que nos interesa para la prueba
                    var values1 = results1.ReporteRespuesta;

                    //Recorrer elementos
                    foreach (var a in values1)
                    {
                        Console.WriteLine(a);
                        aceptacion_dian p = new aceptacion_dian();
                        if (db.aceptacion_dian.Any(o => o.ID_MAESTRO == id_maestro))
                        {
                            p = db.aceptacion_dian.SingleOrDefault(o => o.ID_MAESTRO == id_maestro);

                            p.description = a.Nvenv_come;
                            p.NVENV_FECH = a.Nvenv_fech;
                            p.NVENV_RESP = a.Nvenv_resp;
                            p.NVENV_ESTA = a.Nvenv_esta;
                            p.NVENV_CFEC = a.Nvenv_cfec;
                            p.ID_MAESTRO = Convert.ToInt32(existececo);
                        }
                        else {
                            p.description = a.Nvenv_come;
                            p.NVENV_FECH = a.Nvenv_fech;
                            p.NVENV_RESP = a.Nvenv_resp;
                            p.NVENV_ESTA = a.Nvenv_esta;
                            p.NVENV_CFEC = a.Nvenv_cfec;
                            p.ID_MAESTRO = Convert.ToInt32(existececo);
                            db.aceptacion_dian.Add(p);
                            
                        }
                        envios_noova p1 = new envios_noova();
                        if (db.envios_noova.Any(o => o.ID_MAESTRO == id_maestro))
                        {
                            p1 = db.envios_noova.SingleOrDefault(o => o.ID_MAESTRO == id_maestro);
                            p1.ID_MAESTRO = Convert.ToInt32(existececo);
                            p1.ID_DOCUMENTO = a.Nvfac_nume.ToString().Replace("F00", "");
                            p1.ID_FACTURA = a.Nvfac_nume;
                            p1.ESTADO_CLIENTE = a.Nvenv_esta;
                            p1.ESTADO_DIAN = a.Nvenv_resp;
                        }
                        else
                        {
                            p1.ID_MAESTRO = Convert.ToInt32(existececo);
                            p1.ID_DOCUMENTO = a.Nvfac_nume.ToString().Replace("F00", "");
                            p1.ID_FACTURA = a.Nvfac_nume;
                            p1.ESTADO_CLIENTE = a.Nvenv_esta;
                            p1.ESTADO_DIAN = a.Nvenv_resp;
                            db.envios_noova.Add(p1);
                        }

                        db.SaveChanges();
                    }

                

            }



                connection.Close();
                

            }
            //Console.ReadLine();
        }

        public static string CallRestMethod(string url)
        {

            //Crear el httprequest
            HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(url);
            //Crear Encabezado para get y recibir json
            webrequest.Method = "GET";
            webrequest.Accept = "application/json, text/javascript, */*; q=0.01";
            //Usuarios cuando debamos enviarlos
            String username = "860077099WS";
            String password = "MWcGSQqPf9";
            String encoded = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(username + ":" + password));
            webrequest.Headers.Add("Authorization", "Basic " + encoded);

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
