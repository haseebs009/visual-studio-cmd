using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using System.Data;
using System.Runtime.Caching;





namespace second.Controllers
{
    public class studentController : ApiController
    {
        //Students 
        string connectionString = @"Data Source=CMDLHRDB01;Initial Catalog=4097-Haseeb_Shahzad;Persist Security Info=True;User ID=sa;Password=CureMD2022";
        [Route("list")]
        public List<Students> Getstudents()

        {
            ObjectCache cache = MemoryCache.Default;
            if (cache["cacstudents"] == null)

            {
                var cacheItemPolicy = new CacheItemPolicy
                {
                    AbsoluteExpiration = DateTimeOffset.Now.AddDays(2),
                };

                //List to be used
                List<Students> student = new List<Students>();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                   // string query = "Select * from student";
                  //  "sp_record"
                    using (SqlCommand cmd = new SqlCommand("sp_record", connection))
                    {
                        connection.Open();

                        SqlDataReader sdr = cmd.ExecuteReader();


                        while (sdr.Read())
                        {
                            Students st = new Students();
                            st.Name = sdr["Name"].ToString().Trim();
                            st.StudentNumber = sdr["StudentNumber"].ToString().Trim();
                            st.Address = sdr["Address"].ToString().Trim();
                            student.Add(st);
                        }


                    }

                    var cacheItem = new CacheItem("cacstudents", student);
                    cache.Add(cacheItem, cacheItemPolicy);

                    return (List<Students>)cache.Get("cacstudents");
                }
            }

            else
            {
                return (List<Students>)cache.Get("cacstudents");
            }
        }
    }


}

