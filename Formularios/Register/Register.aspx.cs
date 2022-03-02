using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Formularios.Register
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_ServerClick(object sender, EventArgs e)
        {
            if (Logic_Layer.LogicRegister.RegistrarUsuario(txtUser.Value, txtPassword.Value))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "okAlert('Usuario Creado con Éxito')", true);
                Response.Redirect("../Login/Login.aspx");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "wrongAlert('Error')", true);
            }
            
        }
    }
}