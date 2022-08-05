using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.Services;
using System.Web.Script.Serialization;


namespace WebApplication4
{
    public partial class Loginpage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // For focus on Username
            TextBox1.Focus();
            Session.Remove("validate");
        }



        protected void Button1_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=CMDLHRDB01;Initial Catalog=4097-Haseeb_Shahzad;Persist Security Info=True;User ID=sa;Password=CureMD2022";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "Select * from employlist";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    connection.Open();

                    SqlDataReader sdr = cmd.ExecuteReader();


                    while (sdr.Read())
                    {
                        string Email = sdr["Email"].ToString().Trim();
                        string password = sdr["Password"].ToString().Trim();
                        string role = sdr ["role"].ToString().Trim();
                        if (Email.Equals(TextBox1.Text) && password.Equals(TextBox2.Text)&& role.ToLower().Equals("admin"))
                        {
                            Session["role"] = "admin";
                            Response.Redirect("welcomeadmin.aspx");
                            Session["validate"] = "done";
                            
                        }
                        else if (Email.Equals(TextBox1.Text) && password.Equals(TextBox2.Text) && role.ToLower().Equals("accountant"))
                        {
                            Session["role"] = "accountant";
                            Response.Redirect("welcomeaccountant.aspx");
                            Session["validate"] = "done";
                           
                        }
                       
                    }

                    
                        if (Convert.ToString(Session["validate"])!= "done")
                    {
                        //Error handling
                        alert.InnerText = "Invalid username or password";
                    }

                   
                }


            }
        }
    }
}