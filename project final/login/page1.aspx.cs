using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace login
{
    public partial class page1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // For focus on Username
            TextBox1.Focus();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text == "polar" && TextBox2.Text == "vezli")
            {
                Session["UserName"] = TextBox1.Text;
                Session["Password"] = TextBox1.Text;
                Response.Redirect("page2.aspx");

            }
            else
            {
                //Error handling
                alert.InnerText="Invalid username or password";
            }
        }
    }
}