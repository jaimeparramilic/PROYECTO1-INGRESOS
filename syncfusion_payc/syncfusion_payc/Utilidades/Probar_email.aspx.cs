using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace syncfusion_payc.Utilidades
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            TextBox9.Text = "";
            TextBox9.Text = Email.EnviarEmail(TextBox1.Text, Convert.ToInt32(TextBox2.Text), 
                TextBox3.Text, TextBox4.Text, TextBox5.Text, TextBox6.Text, 
                TextBox7.Text, TextBox8.Text);
        }
    }
}