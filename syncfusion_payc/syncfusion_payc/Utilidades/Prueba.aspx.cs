using syncfusion_payc.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace syncfusion_payc.Utilidades
{
    public partial class Prueba : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            List<VISTA_COSTOS_FLUJO_INGR> vista_cos = new List<VISTA_COSTOS_FLUJO_INGR>();
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection1"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string comSql = "SELECT FILA, COD_CONTRATO_PROYECTO, DESCRIPCION, " +
                  "FECHA, VALOR_TOTAL FROM VISTA_COSTOS_FLUJO_INGR WHERE " +
                  "COD_CONTRATO_PROYECTO = " + 228 + ";";
                SqlCommand command = new SqlCommand(comSql, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                // ??? vista_cos = vista_cos.ToList();
                if (reader.HasRows)
                {
                    int x = -1;
                    while (reader.Read())
                    {
                        x = x + 1;
                        vista_cos.Add(new VISTA_COSTOS_FLUJO_INGR() { FILA = (long)reader["FILA"],
                            COD_CONTRATO_PROYECTO = (long)reader["COD_CONTRATO_PROYECTO"],
                            DESCRIPCION = (string)reader["DESCRIPCION"],
                            FECHA = (DateTime)reader["FECHA"],
                            VALOR_TOTAL = (Decimal)reader["VALOR_TOTAL"]
                        });
                        //vista_cos[x].FILA = (long)reader.GetFloat(0);//reader["FILA"];
                        //vista_cos[x].COD_CONTRATO_PROYECTO = (int)reader["COD_CONTRATO_PROYECTO"];
                        //vista_cos[x].DESCRIPCION = (string)reader["DESCRIPCION"];
                        //vista_cos[x].FECHA = (DateTime)reader["FECHA"];
                        //vista_cos[x].VALOR_TOTAL = (long)reader["VALOR_TOTAL"];
                    }
                }
                reader.Close();
            }
            var costos_flujo = vista_cos;
            // ****************
             //------------ 
            string texto = ""; int k = -1;
            TextBox1.Text = "";
            foreach (var fila in costos_flujo)
            {
                k = k + 1;
                texto = texto + "k:;"+k+"FILA ;" + costos_flujo[k].FILA.ToString()+";";
                texto = texto + "DESCRIPCION ;" + fila.DESCRIPCION.ToString() + ";";
                texto = texto + "FECHA ;" + fila.FECHA.ToString() + ";";
                texto = texto + "VALOR_TOTAL ;" + fila.VALOR_TOTAL.ToString() + ";" + "*&";
            };
            //string cuantos = Utilidades.ExecSQL.ExecNoQuery("INSERT INTO xTEMPO (texto) VALUES ('" + texto + "')", out cod_ret);
            TextBox1.Text = TextBox1.Text + texto;
             //------------ 

            //dict = htmlHelper.GetJsonData(action, costos_flujo);
        }
    }
}