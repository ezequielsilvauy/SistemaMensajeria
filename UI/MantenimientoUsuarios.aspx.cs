using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EntidadesCompartidas;
using Persistencia;
using Logica;
public partial class MantenimientoUsuarios : System.Web.UI.Page
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

        txtCedula.Enabled = true;

        txtCedula.Text = "0";
        txtNombre.Text = "";
        txtNombreUsuario.Text = "";
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
        int cedula = 0;

        try
        {
            cedula = Convert.ToInt32(txtCedula.Text);
        }
        catch
        {
            lblError.Text = "La cédula no es correcta";
            return;
        }

        try
        {
            Usuarios c = LogicaUsuarios.Buscar(cedula);

            if (c != null)
            {
                txtCedula.Text = c.Cedula.ToString();
                txtNombre.Text = c.Nombre;
                txtNombreUsuario.Text = c.NomUsuario;

                Session["UnUsuario"] = c;

                btnEliminar.Enabled = true;
                btnModificar.Enabled = true;
            }
            else
            {
                btnAlta.Enabled = true;
                Session["UnUsuario"] = null;
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
        int cedula = 0;

        try
        {
            cedula = Convert.ToInt32(txtCedula.Text);
        }
        catch
        {
            oMensaje = "La cédula debe ser un número";
        }

        string nombre = txtNombre.Text;
        string nomUsuario = txtNombreUsuario.Text;

        if (oMensaje != "")
        {
            lblError.Text = oMensaje;
        }
        else
        {
            Usuarios u = new Usuarios(cedula, nombre, nomUsuario);

            try
            {
                LogicaUsuarios.Alta(u);

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
            int cedula = Convert.ToInt32(txtCedula.Text);
            string nombre = txtNombre.Text;
            string nomUsuario = txtNombreUsuario.Text;

            Usuarios u = (Usuarios)Session["UnUsuario"];
            u.Cedula = cedula;
            u.Nombre = nombre;
            u.NomUsuario = nomUsuario;

            LogicaUsuarios.Modificar(u);
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
            Usuarios u = (Usuarios)Session["UnUsuario"];

            LogicaUsuarios.Eliminar(u);
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