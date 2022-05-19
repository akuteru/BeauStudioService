using BeauStudioService.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace BeauStudioService.Controllers
{
    public class CategoriesController : ApiController
    {
        // GET: Categories
        SqlConnection con = new SqlConnection(@"server=.\SQLSERVER2K14;database=beautystudio;User Id=sa;Password=ig@dm!n;");

        //Get api/categories
        //String property for json
        public string Get()
        {
            string sql = "EXEC services.GetCategories 0";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                var categories = new List<Category>();
                foreach (DataRow row in dt.Rows)
                {
                    var category = new Category
                    {
                        ID = Convert.ToInt32(row["id"]),
                        CategoryName = row["name"].ToString(),
                        Description = row["description"].ToString()
                    };
                    categories.Add(category);
                }
                return JsonConvert.SerializeObject(categories.AsEnumerable());
            }
            else
            {
                return "No data found";
            }
        }
        public string Get(int id)
        {
            string sql = string.Format("EXEC services.GetCategories '{0}", id);
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                var categories = new List<Category>();
                foreach (DataRow row in dt.Rows)
                {
                    var category = new Category
                    {
                        ID = Convert.ToInt32(row["id"]),
                        CategoryName = row["name"].ToString(),
                        Description = row["description"].ToString()
                    };
                    categories.Add(category);
                }
                return JsonConvert.SerializeObject(categories.AsEnumerable());
            }
            else
            {
                return "No data found";
            }
        }
    }
}