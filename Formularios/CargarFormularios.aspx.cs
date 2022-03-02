using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Entities;
using HtmlElement = System.Windows.Forms.HtmlElement;

namespace Formularios
{
    public partial class CargarFormularios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarCboFormularios();
            }
        }
        private void cargarCboFormularios()
        {
            List<Formulario> lst = Logic_Layer.LogicFormulario.ListaFormularios();
            cboFormularios.DataSource = lst;
            cboFormularios.DataTextField = "name";
            cboFormularios.DataValueField = "id";
            cboFormularios.DataBind();
            cboFormularios.Items.Insert(0, new ListItem("< Seleccione Formulario >", "0"));
        }

        protected void btnTest_Click(object sender, EventArgs e)
        {
            if (cboFormularios.SelectedIndex != 0)
            {
                int id = int.Parse(cboFormularios.SelectedValue);
                List<DetalleFormulario> dt = Logic_Layer.LogicFormulario.DetallesDeUnFormulario(id);

                List<string> dtName = new List<string>();

                for (int i = 0; i < dt.Count; i++)
                {
                    dtName.Add(dt[i].name);
                }

                string dtNameString = string.Join("-", dtName);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "inputs('" + dtNameString + "');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "wrongAlert('Error')", true);
            }
        }

        protected void cargarFormulario_Click(object sender, EventArgs e)
        {
            if (cboFormularios.SelectedIndex != 0)
            {
                int id = int.Parse(cboFormularios.SelectedValue);

                List<DetalleFormulario> dt = Logic_Layer.LogicFormulario.DetallesDeUnFormulario(id);
                ViewState["lstDet"] = dt;

                int cantDivs;
                if (dt.Count % 3 == 0)
                {
                    cantDivs = dt.Count / 3;
                }
                else
                {
                    cantDivs = dt.Count / 3 + 1;
                }

                List<HtmlGenericControl> lstDivs = new List<HtmlGenericControl>();

                for (int i = 0; i < cantDivs; i++)
                {
                    var div = new HtmlGenericControl("Div");
                    div.Attributes["class"] = "col-auto";
                    div.Attributes["id"] = "divForm" + i.ToString();
                    lstDivs.Add(div);
                }

                int y = 1;
                int r = 3;

                for (int i = 0; i < dt.Count; i++)
                {
                    var label = new HtmlGenericControl("Label") { InnerText = dt[i].name };
                    var input = new HtmlGenericControl("Input");
                    bool booleanValue = false;

                    label.Attributes["class"] = "form-label mt-3";
                    label.Attributes["runat"] = "server";

                    input.Attributes["runat"] = "server";
                    input.Attributes["id"] = dt[i].name;
                    input.Attributes["class"] = "form-control";

                    if (dt[i].datatype == "Texto" || dt[i].datatype == "Valor Numérico")
                    {
                        input.Attributes["type"] = "text";
                    }
                    if (dt[i].datatype == "Fecha")
                    {
                        input.Attributes["type"] = "date";
                    }
                    var booleanValueDiv = new HtmlGenericControl("Div");
                    var booleanValueDiv2 = new HtmlGenericControl("Div");
                    var label0 = new HtmlGenericControl("Label");

                    if (dt[i].datatype == "Valor Booleano")
                    {
                        booleanValueDiv.Attributes["class"] = "form-check";
                        booleanValueDiv2.Attributes["class"] = "form-check";

                        var label2 = new HtmlGenericControl("Label");
                        var input2 = new HtmlGenericControl("Input");

                        label0.InnerText = dt[i].name;
                        label0.Attributes["class"] = "formc-label mt-3";

                        label.InnerText = "Si";
                        label.Attributes["class"] = "form-check-label";
                        label.Attributes["for"] = "flexRadioDefault1";
                        label.Attributes["name"] = "flexRadioDefault";

                        label2.InnerText = "No";
                        label2.Attributes["class"] = "form-check-label";
                        label2.Attributes["runat"] = "server";
                        label2.Attributes["for"] = "flexRadioDefault2";
                        label.Attributes["name"] = "flexRadioDefault";


                        input.Attributes["class"] = "form-check-input";
                        input.Attributes["type"] = "radio";
                        input.Attributes["name"] = dt[i].name;
                        input.Attributes["value"] = "1";
                        input.Attributes["id"] = "flexRadioDefault1";
                        input.Attributes["name"] = dt[i].name;

                        input2.Attributes["class"] = "form-check-input";
                        input2.Attributes["runat"] = "server";
                        input2.Attributes["type"] = "radio";
                        input2.Attributes["name"] = dt[i].name + "2";
                        input2.Attributes["value"] = "0";
                        input2.Attributes["id"] = "flexRadioDefault2";
                        input2.Attributes["name"] = dt[i].name;

                        booleanValueDiv.Controls.Add(input);
                        booleanValueDiv.Controls.Add(label);
                        booleanValueDiv2.Controls.Add(input2);
                        booleanValueDiv2.Controls.Add(label2);

                        booleanValue = true;
                    }

                    if (i < 3 * y)
                    {
                        if (booleanValue)
                        {
                            lstDivs[y - 1].Controls.Add(label0);
                            lstDivs[y - 1].Controls.Add(booleanValueDiv);
                            lstDivs[y - 1].Controls.Add(booleanValueDiv2);

                        }
                        else
                        {
                            lstDivs[y - 1].Controls.Add(label);
                            lstDivs[y - 1].Controls.Add(input);
                        }
                    }
                    if (i + 1 == r)
                    {
                        y += 1;
                        r += 3;
                    }
                }
                for (int i = 0; i < lstDivs.Count; i++)
                {
                    contentArea.Controls.Add(lstDivs[i]);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "wrongAlert('Debe seleccionar un formulario antes de cargarlo')", true);
            }
        }

        protected void guardarDatos_Click(object sender, EventArgs e)
        {
            List<DetalleFormulario> lstDet = (List<DetalleFormulario>)ViewState["lstDet"];


            for (int i = 0; i < lstDet.Count; i++)
            {
                RegistroFormulario rg = new RegistroFormulario();
                rg.idFormulario = lstDet[i].idForm;
                rg.idDetalleFormulario = lstDet[i].id;

            }

        }
    }
}