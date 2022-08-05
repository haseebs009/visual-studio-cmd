using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace project
{
    public class Employee
    {
        List<Items> ItemList = new List<Items>();
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
        //To create list of Items
        public List<Items> GetItems()
        {
           ItemList.Add(new Items("106" , "calculator"));
            return ItemList;
        }
        //To create list of customers
        public List<Customer> GetCustomer()
        {
            CustomerList.Add(new Customer ("106", "Ali"));
            CustomerList.Add(new Customer("191", "Hassan"));
            return CustomerList;
        }

    }
}