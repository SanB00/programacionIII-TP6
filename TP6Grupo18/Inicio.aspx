<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="TP6Grupo18.Inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Grupo n18</h1>
            <asp:HyperLink ID="lnkEjercicio1" runat="server" Text="Ejercicio 1" NavigateUrl="~/Ejercicio1/Ejercicio1.aspx" />
            <br />
            <br />
            <asp:HyperLink ID="lnkEjercicio2" runat="server" Text="Ejercicio 2" NavigateUrl="~/Ejercicio2/Ejercicio2.aspx" />
        </div>
    </form>
</body>
</html>
