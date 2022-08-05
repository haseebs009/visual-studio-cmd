using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication4
{
    public partial class welcome : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {

                Response.Write("Hello Welcome to the Admin panel");
        }
      
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustomerList.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("employeelist.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Item.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("Loginpage.aspx");
            Session.Clear();
        }
    }
}