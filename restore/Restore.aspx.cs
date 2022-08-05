using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace restore
{
    public partial class Restore : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {// To bring focus to textbox
            TextBox1.Focus();
        }

        protected void Button2_Click(object sender, EventArgs e)
        { //to get data from hidden field to textbox
            TextBox1.Text = hiddenfield1.Value;
            TextBox2.Text = hiddenfield2.Value;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            //to get data from view state to textbox
            if (ViewState["first_name"] != null)
            {
                TextBox1.Text = ViewState["first_name"].ToString();
            }
            if (ViewState["last_name"] != null)
            {
                TextBox2.Text = ViewState["last_name"].ToString();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //to save data in hidden field and view state
            alert.InnerText = "";
            if (TextBox1.Text.Length != 0 && TextBox2.Text.Length != 0)
            {
                ViewState["first_name"] = TextBox1.Text;
                ViewState["last_name"] = TextBox2.Text;
                hiddenfield2.Value = TextBox2.Text;
                hiddenfield1.Value = TextBox1.Text;
                TextBox1.Text = "";
                TextBox2.Text = "";
            }
            // Error handling
            else
            {
                alert.InnerText = "Fill all fields";
            }
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {




        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {


        }
    }
}