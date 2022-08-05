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
    public partial class Item : System.Web.UI.Page
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


            DataTable dtbl = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM items", sqlCon);
                sqlDa.Fill(dtbl);
            }
            if (dtbl.Rows.Count > 0)
            {
                gvitemslist.DataSource = dtbl;
                gvitemslist.DataBind();
            }
            else
            {
                dtbl.Rows.Add(dtbl.NewRow());
                gvitemslist.DataSource = dtbl;
                gvitemslist.DataBind();
                gvitemslist.Rows[0].Cells.Clear();
                gvitemslist.Rows[0].Cells.Add(new TableCell());
                gvitemslist.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count;
                gvitemslist.Rows[0].Cells[0].Text = "No Data Found ..!";
                gvitemslist.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }
            gvitemslist.UseAccessibleHeader = true;
            gvitemslist.HeaderRow.TableSection = TableRowSection.TableHeader;

        }

        protected void gvitemslist_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("AddNew"))
                {

                    using (SqlConnection sqlCon = new SqlConnection(connectionString))
                    {
                        sqlCon.Open();
                        string query = "INSERT INTO items (ItemNumber,ItemName,Vendor,Price) VALUES (@ItemNumber,@ItemName,@Vendor,@Price)";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.Parameters.AddWithValue("@ItemNumber", (gvitemslist.FooterRow.FindControl("txtItemNumberFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@ItemName", (gvitemslist.FooterRow.FindControl("txtItemNameFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Vendor", (gvitemslist.FooterRow.FindControl("txtVendorFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Price", (gvitemslist.FooterRow.FindControl("txtPriceFooter") as TextBox).Text.Trim());
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

        protected void gvitemslist_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvitemslist.EditIndex = e.NewEditIndex;
            PopulateGridview();
        }

        protected void gvitemslist_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvitemslist.EditIndex = -1;
            PopulateGridview();
        }

        protected void gvitemslist_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {


                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    string query = "UPDATE items SET ItemNumber=@ItemNumber,ItemName=@ItemName,Vendor=@Vendor,Price=@Price WHERE ID = @id";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@ItemNumber", (gvitemslist.FooterRow.FindControl("txtItemNumberFooter") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@ItemName", (gvitemslist.FooterRow.FindControl("txtItemNameFooter") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Vendor", (gvitemslist.FooterRow.FindControl("txtVendorFooter") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Price", (gvitemslist.FooterRow.FindControl("txtPriceFooter") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@id", Convert.ToInt32(gvitemslist.DataKeys[e.RowIndex].Value.ToString()));
                    sqlCmd.ExecuteNonQuery();
                    gvitemslist.EditIndex = -1;
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

        protected void gvitemslist_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {

                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    string query = "DELETE FROM items WHERE ID = @id";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@id", Convert.ToInt32(gvitemslist.DataKeys[e.RowIndex].Value.ToString()));
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