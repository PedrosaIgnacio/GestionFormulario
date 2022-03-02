using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entities;
using Logic_Layer;
namespace Formularios
{
    public partial class GestionarFormularios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["ListaDetalles"] = new List<DetalleFormulario>();
            }
        }

        public List<DetalleFormulario> ListaDetalles()
        {
            DetalleFormulario det = new DetalleFormulario();
            List<DetalleFormulario> lst = (List<DetalleFormulario>)ViewState["ListaDetalles"];
            det.name = txtNombreCampo.Text;

            if (cboDatos.SelectedIndex == 0)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "error", "wrongAlert('Debe seleccionar un tipo de dato')", true);
                return lst;
            }
            else
            {
                det.datatype = cboDatos.SelectedItem.Text;
                if (lst.Count == 0)
                {
                    det.id = 1;
                }
                else
                {
                    det.id = lst.Count + 1;
                }

                lst.Add(det);
                return lst;
            }

        }

        protected void btnAgregarDetalle_Click(object sender, EventArgs e)
        {
            List<DetalleFormulario> lst = ListaDetalles();
            GVDetallesForm.DataSource = lst;
            GVDetallesForm.DataBind();
            txtNombreCampo.Text = "";
            cboDatos.SelectedIndex = 0;
        }

        public void limpiarGrilla()
        {
            List<DetalleFormulario> lst = null;
            GVDetallesForm.DataSource = lst;
            GVDetallesForm.DataBind();
        }
        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            List<DetalleFormulario> DetList = (List<DetalleFormulario>)ViewState["ListaDetalles"];
            if (DetList.Count < 1)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "error", "wrongAlert('Debe cargar al menos 1 campo antes de generar el formulario')", true);
            }
            else
            {
                int? id = Logic_Layer.LogicFormulario.InsertFormulario(txtNombreForm.Text);
                if (id != null)
                {
                    List<DetalleFormulario> lst = (List<DetalleFormulario>)ViewState["ListaDetalles"];
                    int idNotNull = int.Parse(id.ToString());
                    bool success = Logic_Layer.LogicFormulario.InsertarDetallesEnFormulario(lst, idNotNull);
                    if (success)
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "Bien!", "okAlert('Formulario Creado con Éxito')", true);

                        limpiarGrilla();
                        txtNombreCampo.Text = "";
                        cboDatos.SelectedIndex = 0;
                    }
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "error", "wrongAlert('Error')", true);
                }
            }
        }
        protected void btnTest_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "inputs('Nombre')", true);
        }



    }
}