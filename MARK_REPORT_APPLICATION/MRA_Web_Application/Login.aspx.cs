using MRA_Web_Application.Controller;
using MRA_Web_Application.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MRA_Web_Application {
    public partial class Login : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            labelIncorrect.Visible = false;
        }

        protected void ButtonLogin_Click(object sender, EventArgs e) {
            string username = UsernameTextBox.Text.Trim();
            string password = PasswordTextBox.Text.Trim();
            Student student = LoginController.GetUser(username, password);
            if (student != null) {
                Session["student"] = student;
                Response.Redirect("Home.aspx");
            } else {
                labelIncorrect.Visible = true;
            }
        }
    }
}