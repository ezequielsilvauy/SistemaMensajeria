using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using Logica;
using Persistencia;

public partial class ListadoMensajesPrivadosDeUnUsuario : System.Web.UI.Page
{
    
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarUsuarios();
            }
        }

        private void CargarUsuarios()
        {
            List<Usuarios> usuarios = LogicaUsuarios.ListarUsuarios();

            ddlUsuarios.DataSource = usuarios;
            ddlUsuarios.DataTextField = "Nombre";
            ddlUsuarios.DataValueField = "Cedula";
            ddlUsuarios.DataBind();

            ddlUsuarios.Items.Insert(0, new ListItem("Seleccione un usuario", ""));
        }

        protected void ddlUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ddlUsuarios.SelectedValue))
            {
                CargarMensajesPrivados();
            }
            else
            {
                lblError.Text = "Selecciona un usuario.";
                gridMensajes.DataSource = null;
                gridMensajes.DataBind();
            }
        }

        protected void rblMensajeTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ddlUsuarios.SelectedValue))
            {
                CargarMensajesPrivados();
            }
        }

        private void CargarMensajesPrivados()
        {
            try
            {
                int cedulaUsuario = Convert.ToInt32(ddlUsuarios.SelectedValue);
                string tipoMensaje = rblMensajeTipo.SelectedValue;

                List<Comun> mensajes = new List<Comun>();

                Usuarios usuario = LogicaUsuarios.Buscar(cedulaUsuario);

                if (usuario != null)
                {
                    List<Mensajes> mensajesMensajes = new List<Mensajes>();

                    if (tipoMensaje == "enviados")
                    {
                        mensajesMensajes = LogicaMensajes.ListarEnviados(usuario);
                    }
                    else if (tipoMensaje == "recibidos")
                    {
                        mensajesMensajes = LogicaMensajes.ListarRecibidos(usuario);
                    }

                    foreach (Mensajes mensaje in mensajesMensajes)
                    {
                        if (mensaje is Comun)
                        {
                            mensajes.Add((Comun)mensaje);
                        }
                    }
                }

                gridMensajes.DataSource = mensajes;
                gridMensajes.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
    }
