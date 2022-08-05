using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace project
{
    public class Accountant: Employee
    {
        public Accountant(string empId, string name, string role)
        {
            this.EmpID = empId;
            this.EmpName = name;
            role = "Accountant";
        }
        public Accountant()
        {

        }
    }
}
