using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace syncfusion_payc.Utilidades
{
    public partial class ProbarExecSQL : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int cod_ret;
            string resul = ExecSQL.ExecSelect1Dato(TextBox1.Text, out cod_ret);
            TextBox2.Text = "Código retorno: " + cod_ret;
            TextBox2.Text = TextBox2.Text + "\r\n" + resul;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int ret = 0;
            string error = "";
            // Insertar facturas q falten en tabla CARTERA
            error = Utilidades.Cartera.IniciarCartera(out ret);
            TextBox2.Text = error;
        }
    }
}