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
    public partial class customer_List : System.Web.UI.Page
    {
        List<Customer> CustomerList = new List<Customer>();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string Customerdata()
        {
            Employee cus = new Employee();
            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Serialize(cus.GetCustomer());

            //foreach (var stu in studentsList)
            //{
            //    if (stu.id == inputValue)
            //    {

            //        return js.Serialize(stu);
            //    }
            //}
            //return "";
        }


    }
}