using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Formularios
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogin_ServerClick(object sender, EventArgs e)
        {
            string successUsername = Logic_Layer.LogicLogin.VerificarUsuario(txtUser.Value, txtPassword.Value);
            if (successUsername != null)
            {
                Session["Username"] = successUsername;
                Response.Redirect("../Index.aspx");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "wrongAlert('Error')", true);
            }
        }
    }
}