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

    public partial class Getbill : System.Web.UI.Page
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
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM bill", sqlCon);
                sqlDa.Fill(dtbl1);
            }

            if (dtbl1.Rows.Count > 0)
            {
                gvGetbill.DataSource = dtbl1;
                gvGetbill.DataBind();
            }
            else
            {
                dtbl1.Rows.Add(dtbl1.NewRow());
                gvGetbill.DataSource = dtbl1;
                gvGetbill.DataBind();
                gvGetbill.Rows[0].Cells.Clear();
                gvGetbill.Rows[0].Cells.Add(new TableCell());
                gvGetbill.Rows[0].Cells[0].ColumnSpan = dtbl1.Columns.Count;
                gvGetbill.Rows[0].Cells[0].Text = "No Data Found ..!";
                gvGetbill.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }
            gvGetbill.UseAccessibleHeader = true;
            gvGetbill.HeaderRow.TableSection = TableRowSection.TableHeader;

        }

        protected void gvGetbill_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("AddNew"))
                {
                    using (SqlConnection sqlCon = new SqlConnection(connectionString))
                    {
                        sqlCon.Open();
                        string query = "INSERT INTO bill (ItemNumber) VALUES (@ItemNumber)";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.Parameters.AddWithValue("@ItemNumber", (gvGetbill.FooterRow.FindControl("txtItemNumberFooter") as TextBox).Text.Trim());
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

        protected void gvGetbill_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvGetbill.EditIndex = e.NewEditIndex;
            PopulateGridview();
        }

        protected void gvGetbill_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvGetbill.EditIndex = -1;
            PopulateGridview();
        }

        protected void gvGetbill_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    string query = "UPDATE bill SET ItemNumber=@ItemNumber WHERE  = @id";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@ItemNumber", (gvGetbill.Rows[e.RowIndex].FindControl("txtItemNumber") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@id", Convert.ToInt32(gvGetbill.DataKeys[e.RowIndex].Value.ToString()));
                    sqlCmd.ExecuteNonQuery();
                    gvGetbill.EditIndex = -1;
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

        protected void gvGetbill_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    string query = "DELETE FROM bill WHERE ID = @id";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@id", Convert.ToInt32(gvGetbill.DataKeys[e.RowIndex].Value.ToString()));
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

        protected void gvGetbill_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //public static List<Customers>  EditCustomer(int data)
        protected void Button1_Click(object sender, EventArgs e)
        {
            int Total = 0;

            List<bill> customer = new List<bill>();
            string connectionString = @"Data Source=CMDLHRDB01;Initial Catalog=4097-Haseeb_Shahzad;Persist Security Info=True;User ID=sa;Password=CureMD2022";
            {

                SqlConnection con = new SqlConnection(connectionString);
                string sql = "Select * from bill";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();

                cmd.CommandType = CommandType.Text;
                
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {

                    bill custom = new bill();

                   // custom.Id = Convert.ToInt32(dr["id"].ToString());
                    custom.ItemNumber = dr["ItemNumber"].ToString();
                                       
                    customer.Add(custom);

                }
                con.Close();
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "Select * from items";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    connection.Open();

                    SqlDataReader sdr = cmd.ExecuteReader();


                    while (sdr.Read())
                    {
                        string itemnumber = sdr["ItemNumber"].ToString().Trim();
                        string name = sdr["ItemName"].ToString().Trim();
                        int price = int.Parse(sdr["Price"].ToString().Trim());
                        
                          foreach (var item in customer)
                        {
                            if (itemnumber.Equals(item.ItemNumber))
                            {
                                Total = Total + price;
                            }
                            
                        }

                       //else if (Email.Equals(TextBox1.Text) && password.Equals(TextBox2.Text) && role.ToLower().Equals("accountant"))
                       // {
                       //     Response.Redirect("welcomeaccountant.aspx");
                       //     Session["validate"] = "done";
                       // }

                    }

                    //if (Convert.ToString(Session["validate"]) != "done")
                    //{
                    //    //Error handling
                    //    alert.InnerText = "Invalid username or password";
                    //}

                }


            }
            total.Text = "Rs."+Convert.ToString(Total)  ;

            //using (SqlConnection sqlCon = new SqlConnection(connectionString))
            //{
            //    sqlCon.Open();
            //    string query = "INSERT INTO billrecord (Name,Total) VALUES (@Name,@Total)";
            //    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
            //    sqlCmd.Parameters.AddWithValue("@Name", (TextBox1.Text).Trim());
            //    sqlCmd.Parameters.AddWithValue("@Total",Total);
            //    sqlCmd.ExecuteNonQuery();
            //}

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=CMDLHRDB01;Initial Catalog=4097-Haseeb_Shahzad;Persist Security Info=True;User ID=sa;Password=CureMD2022";

            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "INSERT INTO customerslist (Name,Contact,Email) VALUES (@Name,@Contact,@Email)";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@Name", (TextBox1.Text).Trim());
            //    sqlCmd.Parameters.AddWithValue("@LastName", (TextBox1.Text).Trim());
                sqlCmd.Parameters.AddWithValue("@Email", (TextBox3.Text).Trim());
                sqlCmd.Parameters.AddWithValue("@Contact", (TextBox4.Text).Trim());

                sqlCmd.ExecuteNonQuery();
            }
        }

    }
}