using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Web.Services;
using System.Web.Script.Serialization;

namespace WebApplication4
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }

        public Customer(string FirstName, string LastName, string Contact, string Email)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.LastName = Contact;
            this.LastName = Email;
        }
        public Customer()
        {

        }
        public static List<string> GetTables()
        {
            string connectionString = @"Data Source=CMDLHRDB01;Initial Catalog=4097-Haseeb_Shahzad;Persist Security Info=True;User ID=sa;Password=CureMD2022";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DataTable schema = connection.GetSchema("Tables");
                List<string> TableNames = new List<string>();
                foreach (DataRow row in schema.Rows)
                {

                    TableNames.Add(row[2].ToString());
                }
                return TableNames;
            }
        }
    }
    
}