using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace login
{
    public partial class page2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
            if (Session["UserName"]!= null && Session["Password"]!= null)
            {
                // To print message to user
                greet.InnerText = "Hi " + Session["UserName"].ToString() + " Welcome";
            }
            else
            {
                // Error handling in case user has not loged in
                Response.Redirect("page1.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // To remove session and to redirect to previous page
            Session.Remove("UserName");
            Session.Remove("Password");
            Response.Redirect("page1.aspx");
        }
    }
}