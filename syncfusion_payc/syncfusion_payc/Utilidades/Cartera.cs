using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace syncfusion_payc.Utilidades
{
    public class Cartera
    {
        public static string IniciarCartera(out int cod_ret)
        {   // Llena la tabla CARTERA con las facturas q falten. R.E.V.
            // Devuelve en cod_ret 0 si no hubo error y -1 si hubo error y en 
            // resultado el texto del error.
            string result= "", resu2 = "", connectString, ins_car;
            int retor = 0;
            cod_ret = 0;
            try
            {
                // Traer conexión
                ConnectionStringSettings settings;
                settings = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection1"];
                connectString = settings.ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectString))
                {
                    string comSql = "SELECT COD_FACTURA FROM FACTURAS WHERE "
                        +"COD_ESTADO_FACTURA = 5 AND NOT EXISTS  ( "
                        + "SELECT * FROM CARTERA WHERE COD_FACTURA = "
                        + "FACTURAS.COD_FACTURA  )" + ";";
                    SqlCommand command = new SqlCommand(comSql, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Int64 fact = (Int64)reader["COD_FACTURA"];
                            ins_car = "INSERT INTO CARTERA (COD_FACTURA, ESTADO_CARTERA) "
                                +"VALUES(" + fact + ", 1)";
                            resu2 = Utilidades.ExecSQL.ExecNoQuery(ins_car, out retor);
                        }
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
                cod_ret = -1;
            }
            return result;
        }
    }

}