<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SeleccionarProductos.aspx.cs" Inherits="TP6Grupo18.Ejercicio2.SeleccionarProductos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="gvSeleccionar" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="True" AutoGenerateSelectButton="True" OnSelectedIndexChanged="Page_Load" PageSize="13" OnPageIndexChanging="gvSeleccionar_PageIndexChanging">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="ID de Producto">
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_idProdu" runat="server" Text='<%# Bind("IdProducto") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nombre de Producto">
                        <ItemTemplate>
                            <asp:Label ID="lb_it_NombreProd" runat="server" Text='<%# Bind("NombreProducto") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ID de Proveedor">
                        <ItemTemplate>
                            <asp:Label ID="lb_it_Prov" runat="server" Text='<%# Bind("IdProveedor") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Precio">
                        <ItemTemplate>
                            <asp:Label ID="lb_it_PrecioU" runat="server" Text='<%# Bind("PrecioUnidad") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
        </div>
    </form>
</body>
</html>
