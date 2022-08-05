using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // To clear the alert field
            alert.InnerText = "";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // To check if input is number or not
            long number1 = 0;
            bool canConvert = long.TryParse(TextBox1.Text, out number1);
            if(canConvert==true)
            {
               ViewState["number"] = 1+Convert.ToInt32(TextBox1.Text);
               TextBox1.Text = ViewState["number"].ToString();
            }
            // To print alert if input is not number
            else
            {
                alert.InnerText = "please provide numbers only";
            }
        }
    }
}