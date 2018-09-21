using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace syncfusion_payc.Utilidades
{
    public class ExecSQL
    {
        public static string ExecSelect1Dato(string select, out int cod_ret)
        {   // Ejecuta un select q devuelve un solo dato. R.E.V.
            // Devuelve en cod_ret 0 si no hubo error y -1 si hubo error y en 
            // resultado el texto del error.
            string result, connectString;
            cod_ret = 0;
            try
            {
                // Traer conexión
                ConnectionStringSettings settings;
                settings = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection1"];
                connectString = settings.ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    result = "";
                    SqlCommand command = new SqlCommand(select, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        result = reader[0].ToString();
                        break;
                    }
                    reader.Close(); // Always call Close when done reading.
                }
            }
            catch (Exception ex)
            {
                cod_ret = -1;
                result = ex.Message;
            }
            return result;
        }
    }
}