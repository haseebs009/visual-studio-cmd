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
        List<Employee> EmployeeList = new List<Employee>();

        protected void Page_Load(object sender, EventArgs e)
        {
            //to bind data initially and to set it in session
            if (!IsPostBack)
            {
                GetList();
                Session["fixlist"] = EmployeeList;
                gridEmployees.DataSource = EmployeeList;
                gridEmployees.DataBind();
            }
        }
        public List<Employee> GetList()
        {

            for (int i = 0; i < 1000; i++)
            {
                EmployeeList.Add(new Employee("106" + i.ToString(), "Ahmad" + i.ToString(), "10-A mall road" + i.ToString()));

            }
            return EmployeeList;

        }
        //to change index in pagination
        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridEmployees.PageIndex = e.NewPageIndex;
            this.DataBind();
        }
        //to edit row
        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            List<Employee> emplist = (List<Employee>)Session["fixlist"];
            gridEmployees.EditIndex = e.NewEditIndex;
            gridEmployees.DataSource = emplist;
            gridEmployees.DataBind();
        }
        //to delete row
        protected void OnDelete(object sender, GridViewDeleteEventArgs e)
        {
            List<Employee> emplist = (List<Employee>)Session["fixlist"];
            //List<Employee> emplist = GetList();
            emplist.RemoveAt(e.RowIndex);
            gridEmployees.DataSource = emplist;
            gridEmployees.DataBind();
        }
        //to cancel editing
        protected void canceledit(object sender, GridViewCancelEditEventArgs e)
        {
            List<Employee> emplist = (List<Employee>)Session["fixlist"];
            gridEmployees.EditIndex = -1;
            gridEmployees.DataSource = emplist;
            gridEmployees.DataBind();
        }
        //to update row

        protected void gridEmployees_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            List<Employee> emplist = (List<Employee>)Session["fixlist"];
            TextBox empId = gridEmployees.Rows[e.RowIndex].FindControl("emplID") as TextBox;
            emplist[e.RowIndex].empId = empId.Text;
                     gridEmployees.EditIndex = -1;
            gridEmployees.DataSource = emplist;
            gridEmployees.DataBind();

        }


        protected void gridEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {

            // emplID.Text = gridEmployees.SelectedRow.Cells[1].Text;
            //txtname.Text = gridEmployees.SelectedRow.Cells[2].Text;
            //txtmarks.Text = gridEmployees.SelectedRow.Cells[3].Text;

        }
    }
}