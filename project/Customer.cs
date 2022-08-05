using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace project
{
    public class Customer
    {
        public string customerId { get; set; }
        public string Name { get; set; }

        public Customer(string customerId, string Name)
        {
            this.customerId = customerId;
            this.Name = Name;
        }
        public Customer()
        {

        }


    }
}