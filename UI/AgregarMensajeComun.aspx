<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AgregarMensajeComun.aspx.cs" Inherits="AgregarMensajeComun" %>

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
        .style2
        {
            width: 785px;
        }
        .auto-style4 {
            width: 785px;
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="1" align="center">
        <tr>
            <th class="style1">&nbsp;</th>
            <th class="style6">Agregar Mensaje Comun</th>
        </tr>
        <tr>
            <td class="style3">Cédula Emisor</td>
            <td class="style4">
                <asp:TextBox ID="txtCedulaE" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1">Cédula Receptor</td>
            <td class="style2">
                <asp:TextBox ID="txtCedulaR" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style3">Tipo de Mensaje</td>
            <td class="style4">
                <asp:TextBox ID="txtTipoMensaje" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1">Asunto</td>
            <td class="style2">
                <asp:TextBox ID="txtAsunto" runat="server" Width="789px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1">Texto</td>
            <td class="style2">
                <asp:TextBox ID="txtTexto" runat="server" Width="789px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1">&nbsp;</td>
            <td class="style2">&nbsp;</td>
        </tr>
        <tr>
            <td class="style1">Opciones</td>
            <td class="auto-style4">
                <asp:Button ID="btnEnviar" runat="server" onclick="btnEnviar_Click" Text="Enviar" />
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

