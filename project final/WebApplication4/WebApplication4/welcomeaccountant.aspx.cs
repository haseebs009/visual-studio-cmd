using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication4
{
    public partial class welcomeaccountant : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("Hello Welcome to the Accountant panel");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustomerList.aspx");
        }


        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Item.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("Getbill.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("Loginpage.aspx");
            Session.Clear();
        }
    }
}