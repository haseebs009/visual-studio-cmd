using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace project
{
    public partial class welcomepage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            Response.Write("Hello Your designation is:" + Session["Designation"].ToString());
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("customerList.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("customerList.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {

        }
    }
}