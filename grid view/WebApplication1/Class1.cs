using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gridview
{
    public class Employee
    {
        public string empId { get; set; }
        public string name { get; set; }
        public string role { get; set; }

        public Employee(string empId, string name, string role)
        {
            this.empId = empId;
            this.name = name;
            this.role = role;
        }
        public Employee()
        {

        }
    }
}