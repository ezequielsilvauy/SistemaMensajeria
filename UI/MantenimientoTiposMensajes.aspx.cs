using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EntidadesCompartidas;
using Persistencia;
using Logica;

public partial class MantenimientoTiposMensajes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.LimpioFormulario();
            this.DesactivoBotones();
        }
    }

    private void LimpioFormulario()
    {
        btnAlta.Enabled = false;
        btnModificar.Enabled = false;
        btnEliminar.Enabled = false;

        btnBuscar.Enabled = true;

        txtCodigoInterno.Enabled = true;

        txtCodigoInterno.Text = "";
        txtNombreTipo.Text = "";
    }

    private void DesactivoBotones()
    {
        btnAlta.Enabled = false;
        btnModificar.Enabled = false;
        btnEliminar.Enabled = false;

        btnBuscar.Enabled = true;
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        string codigoInterno = "";

        try
        {
            codigoInterno = txtCodigoInterno.Text;
        }
        catch
        {
            lblError.Text = "El código interno no es coerrecto";
            return;
        }

        try
        {
            TipoMensaje t = LogicaTipoMensaje.Buscar(codigoInterno);

            if (t != null)
            {
                txtCodigoInterno.Text = t.codigoInterno;
                txtNombreTipo.Text = t.nombreTipo;

                Session["UnTipo"] = t;

                btnEliminar.Enabled = true;
                btnModificar.Enabled = true;
            }
            else
            {
                btnAlta.Enabled = true;
                Session["UnTipo"] = null;
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void btnAlta_Click(object sender, EventArgs e)
    {
        string oMensaje = "";
        string codigoInterno = "";

        try
        {
            codigoInterno = txtCodigoInterno.Text;
        }
        catch
        {
            oMensaje = "El código debe contener 3 letras";
        }

        string nombreTipo = txtNombreTipo.Text;

        if (oMensaje != "")
        {
            lblError.Text = oMensaje;
        }
        else
        {
            TipoMensaje t = new TipoMensaje(codigoInterno, nombreTipo);

            try
            {
                LogicaTipoMensaje.Alta(t);

                lblError.Text = "Alta con éxito";

                this.LimpioFormulario();
                this.DesactivoBotones();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
        
    }

    protected void btnModificar_Click(object sender, EventArgs e)
    {
        try
        {
            string codigoInterno = txtCodigoInterno.Text;
            string nombreTipo = txtNombreTipo.Text;

            TipoMensaje t = (TipoMensaje)Session["UnTipo"];
            t.codigoInterno = codigoInterno;
            t.nombreTipo = nombreTipo;

            LogicaTipoMensaje.Modificar(t);
            lblError.Text = "Modificación exitosa";

            this.LimpioFormulario();
            this.DesactivoBotones();
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        try
        {
            TipoMensaje t = (TipoMensaje)Session["UnTipo"];

            LogicaTipoMensaje.Eliminar(t);
            lblError.Text = "Eliminación exitosa";

            this.LimpioFormulario();
            this.DesactivoBotones();
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
}