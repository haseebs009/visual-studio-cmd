using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace project
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // For focus on Username
            TextBox1.Focus();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["UserName"] = TextBox1.Text;
            Session["Password"] = TextBox2.Text;
            Admin emp = new Admin();
            emp.getEmployeeList();

            foreach (var valid in emp.getEmployeeList())
            {
                if (valid.EmpName.Equals(TextBox1.Text)&& valid.password.Equals(TextBox2.Text))
                {
                    
                    Session["Designation"] = valid.role;
                    Response.Redirect("welcomepage.aspx");
                }
            }

            //if (TextBox1.Text == "polar" && TextBox2.Text == "vezli")
            //{
            //    Session["UserName"] = TextBox1.Text;
            //    Session["Password"] = TextBox1.Text;
            //    Response.Redirect("page2.aspx");
            //}
            //else
            //{
            //    //Error handling
            //    alert.InnerText = "Invalid username or password";
            //}
        }
    }
}