<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Probar_email.aspx.cs" Inherits="syncfusion_payc.Utilidades.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Probar envio de emails"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="SMTP"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox1" runat="server">smtp.gmail.com</asp:TextBox>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Puerto"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox2" runat="server">587</asp:TextBox>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Usuario"></asp:Label>
&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox3" runat="server" Width="351px">centro.costo.estado.payc@gmail.com</asp:TextBox>
            <br />
            <asp:Label ID="Label5" runat="server" Text="Passw"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox4" runat="server">1234payc</asp:TextBox>
            <br />
            <asp:Label ID="Label6" runat="server" Text="De"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox5" runat="server" Width="355px">centro.costo.estado.payc@gmail.com</asp:TextBox>
            <br />
            <asp:Label ID="Label7" runat="server" Text="Para"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox6" runat="server" Width="359px"></asp:TextBox>
            <br />
            <asp:Label ID="Label8" runat="server" Text="Asunto"></asp:Label>
&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox7" runat="server" Width="360px">Asunto mensaje de prueba</asp:TextBox>
            <br />
            <asp:Label ID="Label9" runat="server" Text="Cuerpo del mensaje"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox8" runat="server" Height="124px" TextMode="MultiLine" Width="435px">Cuerpo del mensaje de prueba. Saludos.</asp:TextBox>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Enviar" />
            <br />
            <asp:Label ID="Label10" runat="server" Text="Error"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox9" runat="server" Height="51px" TextMode="MultiLine" Width="700px"></asp:TextBox>
        </div>
    </form>
</body>
</html>
