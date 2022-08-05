using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace gridview2
{
    public partial class page : System.Web.UI.Page
    {

        public class Student
        {
            public string rollNo { get; set; }
            public string name { get; set; }
            public string address { get; set; }

            public Student(string rollNo, string name, string address)
            {
                this.rollNo = rollNo;
                this.name = name;
                this.address = address;
            }
            public Student()
            {

            }
            //Function to return a list of students 
            public List<Student> GetList()
            {
                List<Student> StudentList = new List<Student>();
                StudentList.Add(new Student("101", "Haseeb", "5-A mall road"));
                StudentList.Add(new Student("102", "Usman", "6-A mall road"));
                StudentList.Add(new Student("103", "Ali", "7-A mall road"));
                StudentList.Add(new Student("104", "Shahzad", "8-A mall road"));
                StudentList.Add(new Student("105", "Hassan", "9-A mall road"));
                StudentList.Add(new Student("106", "Ahmad", "10-A mall road"));
                StudentList.Add(new Student("107", "Abdulla", "11-A mall road"));
                StudentList.Add(new Student("108", "Arslan", "12-A mall road"));
                return StudentList;

            }
    
            
        }
       
        protected void Page_Load(object sender, EventArgs e)
        {
            // bind list with gridview
            Student s = new Student();
            gridStudents.DataSource = s.GetList();
            gridStudents.DataBind();
        }

        protected void gridStudents_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

}