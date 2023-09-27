<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AgregarMensajePrivado.aspx.cs" Inherits="AgregarMensajePrivado" %>

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
        .auto-style10 {
            width: 785px;
            color: #336600;
            height: 25px;
        }
        .auto-style11 {
            width: 150px;
            color: #FFFFFF;
            text-align: left;
            background-color: #336600;
            height: 79px;
        }
        .auto-style12 {
            width: 144px;
            text-align: center;
            height: 79px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="1" align="center">
        <tr>
            <th class="style3"></th>
            <th class="auto-style10">Agregar Mensaje Privado</th>
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
            <td class="style3">Fecha de Caducación</td>
            <td class="style4">
                <asp:TextBox ID="txtFechaCad" runat="server"></asp:TextBox>
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
            <td class="auto-style11">Opciones</td>
            <td class="auto-style12">
                <asp:Button ID="btnEnviar" runat="server" OnClick="btnEnviar_Click" Text="Enviar" />
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

