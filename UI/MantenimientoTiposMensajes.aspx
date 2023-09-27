<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MantenimientoTiposMensajes.aspx.cs" Inherits="MantenimientoTiposMensajes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">

        .style1
        {
            width: 150px;
            color: #FFFFFF;
            text-align: left;
            background-color: #336600;
        }
        .style6
        {
            width: 785px;
            color: #336600;
        }
        .style3
        {
            width: 150px;
            height: 25px;
            text-align: left;
            color: #FFFFFF;
            background-color: #336600;
        }
        .style4
        {
            width: 785px;
            height: 25px;
        }
        .style7
        {
            width: 150px;
            color: #FFFFFF;
            text-align: left;
            height: 28px;
            background-color: #336600;
        }
        .style8
        {
            width: 785px;
            height: 28px;
        }
        .style2
        {
            width: 785px;
        }
        .auto-style11 {
            width: 150px;
            color: #FFFFFF;
            background-color: #336600;
            height: 32px;
        }
        .auto-style12 {
            width: 785px;
            text-align: center;
            height: 32px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="1" align="center">
        <tr>
            <th class="style1">&nbsp;</th>
            <th class="style6">Mantenimiento Tipos Mensajes</th>
        </tr>
        <tr>
            <td class="style3">Código Interno</td>
            <td class="style4">
                <asp:TextBox ID="txtCodigoInterno" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style7">Nombre del Tipo</td>
            <td class="style8">
                <asp:TextBox ID="txtNombreTipo" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style3"></td>
            <td class="style4"></td>
        </tr>
        <tr>
            <td class="auto-style11">Opciones</td>
            <td class="auto-style12">
                <asp:Button ID="btnBuscar" runat="server" onclick="btnBuscar_Click" 
                Text="Buscar" />
                <asp:Button ID="btnAlta" runat="server" Text="Alta" OnClick="btnAlta_Click" />
                <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" />
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
            </td>
        </tr>
        <tr>
            <td class="style1">&nbsp;</td>
            <td class="style2">
                <asp:Label ID="lblError" runat="server" Text="[lblError]"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>

