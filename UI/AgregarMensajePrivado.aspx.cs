using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EntidadesCompartidas;
using Persistencia;
using Logica;
public partial class AgregarMensajePrivado : System.Web.UI.Page
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
        txtFechaCad.Text = "";
        txtAsunto.Text = "";
        txtTexto.Text = "";
    }

    protected void btnEnviar_Click(object sender, EventArgs e)
    {
        try
        {
            string asunto = txtAsunto.Text;
            string texto = txtTexto.Text;
            DateTime fechaCad = Convert.ToDateTime(txtFechaCad.Text);

            int cedulaE = Convert.ToInt32(txtCedulaE.Text);
            int cedulaR = Convert.ToInt32(txtCedulaR.Text);

            Usuarios emisor = LogicaUsuarios.Buscar(cedulaE);
            Usuarios receptor = LogicaUsuarios.Buscar(cedulaR);

            DateTime fechaHora = DateTime.Now;

            Privado mensajePrivado = new Privado(asunto, texto, emisor, receptor, fechaCad, 0, fechaHora);

            LogicaMensajes.Alta(mensajePrivado);

            txtAsunto.Text = "";
            txtTexto.Text = "";
            txtFechaCad.Text = "";

            lblError.Text = "Mensaje privado enviado con éxito.";
        }
        catch (Exception ex)
        {
            lblError.Text = "Error al enviar el mensaje: " + ex.Message;
        }
    }
}
