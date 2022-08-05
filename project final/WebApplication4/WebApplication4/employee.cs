using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4
{
    public class Employee
    {
        List<Customer> CustomerList = new List<Customer>();
        public string EmpID { get; set; }
        public string EmpName { get; set; }
        public string password { get; set; }
        public string role { get; set; }

        public Employee(string empId, string empname, string Role, string Password)
        {
            this.EmpID = empId;
            this.EmpName = empname;
            this.password = Password;
            this.role = Role;
        }
        public Employee()
        {

        }

    }
}