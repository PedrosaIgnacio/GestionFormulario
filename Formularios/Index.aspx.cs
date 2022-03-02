using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Formularios
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
            {
                Response.Redirect("Login/Login.aspx");
            }
            setUsernameTittle();
            llenarGVUltimosFormularios();
        }
        public void setUsernameTittle()
        {
            string session = (string)Session["Username"];
            txtUserTittle.InnerText = "Bienvenido " + session;
        }
        public void llenarGVUltimosFormularios()
        {
            List<Formulario> lstFormularios = Logic_Layer.LogicFormulario.Top5Formularios();
            GVUltimosFormularios.DataSource = lstFormularios;
            GVUltimosFormularios.DataBind();
        }
    }
}