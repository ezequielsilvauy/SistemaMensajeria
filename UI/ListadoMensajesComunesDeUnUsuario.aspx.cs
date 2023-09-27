using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using Logica;

public partial class ListadoMensajesComunesDeUnUsuario : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CargarTiposMensajes();
            CargarUsuarios();
        }
    }

    private void CargarTiposMensajes()
    {
        try
        {
            List<TipoMensaje> tiposMensaje = LogicaTipoMensaje.ListarTipoMensaje("");

            ddlTiposMensaje.DataSource = tiposMensaje;
            ddlTiposMensaje.DataTextField = "nombreTipo";
            ddlTiposMensaje.DataValueField = "codigoInterno";
            ddlTiposMensaje.DataBind();

            ddlTiposMensaje.Items.Insert(0, new ListItem("Seleccione un tipo de mensaje", ""));
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    private void CargarUsuarios()
    {
        try
        {
            List<Usuarios> usuarios = LogicaUsuarios.ListarUsuarios();

            ddlUsuarios.DataSource = usuarios;
            ddlUsuarios.DataTextField = "Nombre";
            ddlUsuarios.DataValueField = "Cedula";
            ddlUsuarios.DataBind();

            ddlUsuarios.Items.Insert(0, new ListItem("Seleccione un usuario", ""));
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void btnFiltrar_Click(object sender, EventArgs e)
    {
        try
        {
            string tipoMensaje = ddlTiposMensaje.SelectedValue;
            string cedulaUsuario = ddlUsuarios.SelectedValue;
            string sentReceived = rblSentReceived.SelectedValue;

            Usuarios usuario = LogicaUsuarios.Buscar(Convert.ToInt32(cedulaUsuario));
            TipoMensaje tipo = LogicaTipoMensaje.Buscar(tipoMensaje);

            if (usuario != null && tipo != null)
            {
                List<Mensajes> mensajesMensajes = new List<Mensajes>();

                if (sentReceived == "enviados")
                {
                    mensajesMensajes = LogicaMensajes.ListarExT(usuario, tipo);
                }
                else if (sentReceived == "recibidos")
                {
                    mensajesMensajes = LogicaMensajes.ListarRxT(usuario, tipo);
                }

                // Filtrar los objetos de tipo Mensajes para quedarnos con los Comun
                List<Comun> mensajes = new List<Comun>();
                foreach (Mensajes mensaje in mensajesMensajes)
                {
                    if (mensaje is Comun)
                    {
                        mensajes.Add((Comun)mensaje);
                    }
                }

                gridMensajes.DataSource = mensajes;
                gridMensajes.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
}
