using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.Script.Serialization;

namespace project
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        List<Customer> CustomerList = new List<Customer>();
        protected void Page_Load(object sender, EventArgs e)
        {
       
            Employee cus = new Employee();
            gridEmployees.DataSource = cus.GetCustomer();
            gridEmployees.DataBind();


        }




    }
}