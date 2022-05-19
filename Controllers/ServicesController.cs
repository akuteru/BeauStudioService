using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;
using System.Web.Http;
using BeauStudioService.Models;

namespace BeauStudioService.Controllers
{
    public class ServicesController : ApiController
    {
        SqlConnection con = new SqlConnection(@"server=.\SQLSERVER2K14;database=beautystudio;User Id=sa;Password=ig@dm!n;");

        //Get api/services
        //String property for json
        public string Get()
        {
            string sql = "EXEC services.GetServices 0";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                var services = new List<Services>();
                foreach (DataRow row in dt.Rows)
                {
                    var service = new Services
                    {
                        ID = Convert.ToInt32(row["id"]),
                        ServiceName = row["service_name"].ToString(),
                        Description = row["description"].ToString(),
                        CategoryID = Convert.ToInt32(row["category_id"]),
                        Category = row["category"].ToString(),
                        Price = Double.Parse(row["price"].ToString())
                    };
                    services.Add(service);
                }
                return JsonConvert.SerializeObject(services.AsEnumerable());
            }
            else
            {
                return "No data found";
            }
        }
        public string Get(int id)
        {
            string sql = string.Format("EXEC services.GetServices '{0}", id);
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                var services = new List<Services>();
                foreach (DataRow row in dt.Rows)
                {
                    var service = new Services
                    {
                        ID = Convert.ToInt32(row["id"]),
                        ServiceName = row["service_name"].ToString(),
                        Description = row["description"].ToString(),
                        CategoryID = Convert.ToInt32(row["category_id"]),
                        Category = row["category"].ToString(),
                        Price = Double.Parse(row["price"].ToString())
                    };
                    services.Add(service);
                }
                return JsonConvert.SerializeObject(services.AsEnumerable());
            }
            else
            {
                return "No data found";
            }
        }
    }
}