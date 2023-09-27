using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EntidadesCompartidas;
using Logica;
using Persistencia;
public partial class AgregarMensajeComun : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.LimpioFormulario();
            btnEnviar.Enabled = true;
        }
    }

    private void LimpioFormulario()
    {
        btnEnviar.Enabled = false;

        txtCedulaE.Text = "0";
        txtCedulaR.Text = "0";
        txtTipoMensaje.Text = "";
        txtAsunto.Text = "";
        txtTexto.Text = "";
    }

    protected void btnEnviar_Click(object sender, EventArgs e)
    {
        try
        {
            string asunto = txtAsunto.Text;
            string texto = txtTexto.Text;
            string tipoMensaje = txtTipoMensaje.Text;
            int cedulaE = Convert.ToInt32(txtCedulaE.Text);
            int cedulaR = Convert.ToInt32(txtCedulaR.Text);

            Usuarios emisor = LogicaUsuarios.Buscar(cedulaE);
            Usuarios receptor = LogicaUsuarios.Buscar(cedulaR);

            DateTime fechaHora = DateTime.Now;

            TipoMensaje TipoMensaje = LogicaTipoMensaje.Buscar(tipoMensaje);

            if (tipoMensaje == null)
            {
                lblError.Text = "El tipo de mensaje ingresado no es válido.";
                return;
            }


            Comun mensajeComun = new Comun(asunto, texto, emisor, receptor, 0, fechaHora, TipoMensaje);

            LogicaMensajes.Alta(mensajeComun);

            LimpioFormulario();

            lblError.Text = "Mensaje común enviado con éxito.";
        }
        catch (Exception ex)
        {
            lblError.Text = "Error al enviar el mensaje: " + ex.Message;
        }
    }
}
