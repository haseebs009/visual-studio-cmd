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
    public partial class WebForm1 : System.Web.UI.Page
    {
        public static List<string> GetTables()
        {
            string connectionString = @"Data Source=CMDLHRDB01;Initial Catalog=4097-Haseeb_Shahzad;Persist Security Info=True;User ID=sa;Password=CureMD2022";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DataTable schema = connection.GetSchema("Tables");
                List<string> TableNames = new List<string>();
                foreach (DataRow row in schema.Rows)
                {
                    TableNames.Add(row[2].ToString());
                }
                return TableNames;
            }
        }

        [WebMethod]
        [System.Web.Script.Services.ScriptMethod(UseHttpGet = true, ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        public static string Customerdata()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Serialize(GetTables());
        }




        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateGridview();
            }
        }

        void PopulateGridview()
        {
            string connectionString = @"Data Source=CMDLHRDB01;Initial Catalog=4097-Haseeb_Shahzad;Persist Security Info=True;User ID=sa;Password=CureMD2022";

          
            DataTable dtbl = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM customerslist", sqlCon);
                sqlDa.Fill(dtbl);
            }
            if (dtbl.Rows.Count > 0)
            {
                gvcustomerslist.DataSource = dtbl;
                gvcustomerslist.DataBind();
            }
            else
            {
                dtbl.Rows.Add(dtbl.NewRow());
                gvcustomerslist.DataSource = dtbl;
                gvcustomerslist.DataBind();
                gvcustomerslist.Rows[0].Cells.Clear();
                gvcustomerslist.Rows[0].Cells.Add(new TableCell());
                gvcustomerslist.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count;
                gvcustomerslist.Rows[0].Cells[0].Text = "No Data Found ..!";
                gvcustomerslist.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }
            gvcustomerslist.UseAccessibleHeader = true;
            gvcustomerslist.HeaderRow.TableSection = TableRowSection.TableHeader;

        }

        protected void gvcustomerslist_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("AddNew"))
                {
                    string connectionString = @"Data Source=CMDLHRDB01;Initial Catalog=4097-Haseeb_Shahzad;Persist Security Info=True;User ID=sa;Password=CureMD2022";

                    using (SqlConnection sqlCon = new SqlConnection(connectionString))
                    {
                        sqlCon.Open();
                        string query = "INSERT INTO customerslist (Name,Contact,Email) VALUES (@Name,@Contact,@Email)";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.Parameters.AddWithValue("@FirstName", (gvcustomerslist.FooterRow.FindControl("txtFirstNameFooter") as TextBox).Text.Trim());
                      //  sqlCmd.Parameters.AddWithValue("@LastName", (gvcustomerslist.FooterRow.FindControl("txtLastNameFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Contact", (gvcustomerslist.FooterRow.FindControl("txtContactFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Email", (gvcustomerslist.FooterRow.FindControl("txtEmailFooter") as TextBox).Text.Trim());
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

        protected void gvcustomerslist_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvcustomerslist.EditIndex = e.NewEditIndex;
            PopulateGridview();
        }

        protected void gvcustomerslist_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvcustomerslist.EditIndex = -1;
            PopulateGridview();
        }

        protected void gvcustomerslist_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                string connectionString = @"Data Source=CMDLHRDB01;Initial Catalog=4097-Haseeb_Shahzad;Persist Security Info=True;User ID=sa;Password=CureMD2022";

               
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    string query = "UPDATE customerslist SET Name=@Name,Contact=@Contact,Email=@Email WHERE customerslistID = @id";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@Name", (gvcustomerslist.Rows[e.RowIndex].FindControl("txtName") as TextBox).Text.Trim());
                 //   sqlCmd.Parameters.AddWithValue("@LastName", (gvcustomerslist.Rows[e.RowIndex].FindControl("txtLastName") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Contact", (gvcustomerslist.Rows[e.RowIndex].FindControl("txtContact") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Email", (gvcustomerslist.Rows[e.RowIndex].FindControl("txtEmail") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@id", Convert.ToInt32(gvcustomerslist.DataKeys[e.RowIndex].Value.ToString()));
                    sqlCmd.ExecuteNonQuery();
                    gvcustomerslist.EditIndex = -1;
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

        protected void gvcustomerslist_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string connectionString = @"Data Source=CMDLHRDB01;Initial Catalog=4097-Haseeb_Shahzad;Persist Security Info=True;User ID=sa;Password=CureMD2022";

                  using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    string query = "DELETE FROM customerslist WHERE customerslistID = @id";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@id", Convert.ToInt32(gvcustomerslist.DataKeys[e.RowIndex].Value.ToString()));
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
            if ( "accountant" == Session["role"].ToString())
            {
                Response.Redirect("welcomeaccountant.aspx");
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