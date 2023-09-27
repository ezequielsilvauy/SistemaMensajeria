<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ListadoMensajesPrivadosDeUnUsuario.aspx.cs" Inherits="ListadoMensajesPrivadosDeUnUsuario"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceholder1" runat="server">
    <h2>Listado de Mensajes Privados de un Usuario</h2>
    <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
    <div>
        <label>Selecciona un usuario:</label>
        <asp:DropDownList ID="ddlUsuarios" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlUsuarios_SelectedIndexChanged">
            <asp:ListItem Text="Seleccione un usuario" Value=""></asp:ListItem>
        </asp:DropDownList>
    </div>
    <div>
        <label>Selecciona el tipo de mensajes:</label>
        <asp:RadioButtonList ID="rblMensajeTipo" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rblMensajeTipo_SelectedIndexChanged">
            <asp:ListItem Text="Mensajes Enviados" Value="enviados"></asp:ListItem>
            <asp:ListItem Text="Mensajes Recibidos" Value="recibidos"></asp:ListItem>
        </asp:RadioButtonList>
    </div>
    <br />
    <asp:GridView ID="gridMensajes" runat="server" AutoGenerateColumns="True">
    </asp:GridView>
</asp:Content>
