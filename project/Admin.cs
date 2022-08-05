using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace project
{
    public class Admin: Employee
    {
        List<Employee> EmployeeList = new List<Employee>();
        //public Admin(string empId, string name, string role)
        //{
        //    this.EmpID = empId;
        //    this.EmpName = name;
        //    role = "Admin";
        //}
        //public Admin()
        //{

        //}


        public List<Employee> getEmployeeList()
        {

            EmployeeList.Add(new Employee("106" , "Ahmad" , "Admin","hello"));
            EmployeeList.Add(new Employee("176" , "Ali" , "Accountant","hello1"));
            EmployeeList.Add(new Employee("196" , "Sultan" , "Accountant", "hello2"));
            EmployeeList.Add(new Employee("126" , "Qasim" , "Accountant","hello3"));

            return EmployeeList;
        }


    }
}