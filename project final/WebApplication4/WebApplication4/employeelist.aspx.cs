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
    public partial class WebForm2 : System.Web.UI.Page
    {
      

        string connectionString = @"Data Source=CMDLHRDB01;Initial Catalog=4097-Haseeb_Shahzad;Persist Security Info=True;User ID=sa;Password=CureMD2022";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateGridview();
            }
        }

        void PopulateGridview()
        {
            DataTable dtbl1 = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM employlist", sqlCon);
                sqlDa.Fill(dtbl1);
            }

            if (dtbl1.Rows.Count > 0)
            {
                gvemployeelist.DataSource = dtbl1;
                gvemployeelist.DataBind();
            }
            else
            {
                dtbl1.Rows.Add(dtbl1.NewRow());
                gvemployeelist.DataSource = dtbl1;
                gvemployeelist.DataBind();
                gvemployeelist.Rows[0].Cells.Clear();
                gvemployeelist.Rows[0].Cells.Add(new TableCell());
                gvemployeelist.Rows[0].Cells[0].ColumnSpan = dtbl1.Columns.Count;
                gvemployeelist.Rows[0].Cells[0].Text = "No Data Found ..!";
                gvemployeelist.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }
            gvemployeelist.UseAccessibleHeader = true;
            gvemployeelist.HeaderRow.TableSection = TableRowSection.TableHeader;

        }

        protected void gvemployeelist_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("AddNew"))
                {
                    using (SqlConnection sqlCon = new SqlConnection(connectionString))
                    {
                        sqlCon.Open();
                        string query = "INSERT INTO employlist (FirstName,LastName,Role,Email,Password) VALUES (@FirstName,@LastName,@Role,@Email,@Password)";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.Parameters.AddWithValue("@FirstName", (gvemployeelist.FooterRow.FindControl("txtFirstNameFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@LastName", (gvemployeelist.FooterRow.FindControl("txtLastNameFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Role", (gvemployeelist.FooterRow.FindControl("txtRoleFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Email", (gvemployeelist.FooterRow.FindControl("txtEmailFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Password", (gvemployeelist.FooterRow.FindControl("txtPasswordFooter") as TextBox).Text.Trim());
                        sqlCmd.ExecuteNonQuery();
                        PopulateGridview();
                        lblSuccessMessage.Text = "New Record Added";
                        lblErrorMessage.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }
        }

        protected void gvemployeelist_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvemployeelist.EditIndex = e.NewEditIndex;
            PopulateGridview();
        }

        protected void gvemployeelist_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvemployeelist.EditIndex = -1;
            PopulateGridview();
        }

        protected void gvemployeelist_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    string query = "UPDATE employlist SET FirstName=@FirstName,LastName=@LastName,Role=@Role,Email=@Email,Password=@Password WHERE  = @id";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@FirstName", (gvemployeelist.Rows[e.RowIndex].FindControl("txtFirstName") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@LastName", (gvemployeelist.Rows[e.RowIndex].FindControl("txtLastName") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Role", (gvemployeelist.Rows[e.RowIndex].FindControl("txtRole") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Email", (gvemployeelist.Rows[e.RowIndex].FindControl("txtEmail") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Password", (gvemployeelist.Rows[e.RowIndex].FindControl("txtPassword") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@id", Convert.ToInt32(gvemployeelist.DataKeys[e.RowIndex].Value.ToString()));
                    sqlCmd.ExecuteNonQuery();
                    gvemployeelist.EditIndex = -1;
                    PopulateGridview();
                    lblSuccessMessage.Text = "Selected Record Updated";
                    lblErrorMessage.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }
        }

        protected void gvemployeelist_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    string query = "DELETE FROM employlist WHERE employeelistID = @id";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@id", Convert.ToInt32(gvemployeelist.DataKeys[e.RowIndex].Value.ToString()));
                    sqlCmd.ExecuteNonQuery();
                    PopulateGridview();
                    lblSuccessMessage.Text = "Selected Record Deleted";
                    lblErrorMessage.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Loginpage.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            
                if ("accountant" == Session["role"].ToString())
                {
                    Response.Redirect("Loginpage.aspx");
                }
                else if (Session["role"].ToString() == "admin")
                {
                    Response.Redirect("welcomeadmin.aspx");
                }
                else
                {
                    Response.Redirect("Loginpage.aspx");
                }
            
        }
    }
}