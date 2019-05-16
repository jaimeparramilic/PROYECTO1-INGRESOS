<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProbarExecSQL.aspx.cs" Inherits="syncfusion_payc.Utilidades.ProbarExecSQL" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 328px">
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Probar Ejecución SQL"></asp:Label>
        </div>
        <asp:TextBox ID="TextBox1" runat="server" Height="109px" TextMode="MultiLine" Width="731px"></asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Ejecutar SQL" />
        &nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Iniciar cartera" />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Resultado:"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox2" runat="server" Height="103px" TextMode="MultiLine" Width="722px"></asp:TextBox>
    </form>
</body>
</html>
