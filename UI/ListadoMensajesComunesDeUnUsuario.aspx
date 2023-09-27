<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ListadoMensajesComunesDeUnUsuario.aspx.cs" Inherits="ListadoMensajesComunesDeUnUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Listado de Mensajes Comunes de un Usuario</h2>
    
    <label>Tipo de Mensaje:</label>
    <asp:DropDownList ID="ddlTiposMensaje" runat="server">
        <asp:ListItem Text="Seleccione un tipo de mensaje" Value="" />
    </asp:DropDownList>
    <br />

    <label>Usuario:</label>
    <asp:DropDownList ID="ddlUsuarios" runat="server">
        <asp:ListItem Text="Seleccione un usuario" Value="" />
    </asp:DropDownList>
    <br />

    <label>Seleccionar mensajes:</label>
    <asp:RadioButtonList ID="rblSentReceived" runat="server">
        <asp:ListItem Text="Enviados" Value="enviados" />
        <asp:ListItem Text="Recibidos" Value="recibidos" />
    </asp:RadioButtonList>
    <br />

    <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" OnClick="btnFiltrar_Click" />
    <br />

    <asp:GridView ID="gridMensajes" runat="server" AutoGenerateColumns="True">
    </asp:GridView>

    <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
</asp:Content>
