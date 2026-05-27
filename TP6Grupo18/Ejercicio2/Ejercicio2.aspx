<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ejercicio2.aspx.cs" Inherits="TP6Grupo18.Ejercicio2.Ejercicio2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Inicio</h1>
        </div>
        <asp:HyperLink ID="hlSeleccionarProd" runat="server" NavigateUrl="~/Ejercicio2/SeleccionarProductos.aspx" ViewStateMode="Disabled">Seleccionar Producto</asp:HyperLink>
        <p>
            <asp:LinkButton ID="lbEliminarProductosSeleccionados" runat="server">Eliminar Productos seleccionados</asp:LinkButton>
        </p>
        <p>
            <asp:HyperLink ID="hlMostrarProductos" runat="server" NavigateUrl="~/Ejercicio2/MostrarProductos.aspx">Mostrar Productos</asp:HyperLink>
        </p>
    </form>
</body>
</html>
