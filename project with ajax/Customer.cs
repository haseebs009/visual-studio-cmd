using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace project
{
    public class Customer
    {
        public string customerId { get; set; }
        public string Name { get; set; }

        public Customer(string empId, string name)
        {
            this.customerId = empId;
            this.Name = name;
        }
        public Customer()
        {

        }
        
    }
}