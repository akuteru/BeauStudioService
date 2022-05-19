using BeauStudioService.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace BeauStudioService.Controllers
{
    public class ClientsController : ApiController
    {
        SqlConnection con = new SqlConnection(@"server=.\SQLSERVER2K14;database=beautystudio;User Id=sa;Password=ig@dm!n;");

        public string Get()
        {
            string sql = "EXEC users.GetClient";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                var clients = new List<Members>();
                foreach(DataRow dr in dt.Rows)
                {
                    var client = new Members
                    {
                        ID = Convert.ToInt32(dr["id"]),
                        ClientCode = dr["client_code"].ToString(),
                        LastName = dr["last_name"].ToString(),
                        FirstName = dr["first_name"].ToString(),
                        MI = dr["mi"].ToString(),
                        Address = dr["address"].ToString(),
                        ContactNumber = dr["contact_number"].ToString(),


                    };
                    clients.Add(client);
                }
                return JsonConvert.SerializeObject(clients.AsEnumerable());
            }
            else
            {
                return "No data found";
            }
        }
        public string Get(int id)
        {
            string sql = "EXEC users.GetClient '" + id.ToString() +"'";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                var clients = new List<Members>();
                foreach (DataRow dr in dt.Rows)
                {
                    var client = new Members
                    {
                        ID = Convert.ToInt32(dr["id"]),
                        ClientCode = dr["client_code"].ToString(),
                        LastName = dr["last_name"].ToString(),
                        FirstName = dr["first_name"].ToString(),
                        MI = dr["mi"].ToString(),
                        Address = dr["address"].ToString(),
                        ContactNumber = dr["contact_number"].ToString(),


                    };
                    clients.Add(client);
                }
                return JsonConvert.SerializeObject(clients.AsEnumerable());
            }
            else
            {
                return "No data found";
            }
        }
        public HttpResponseMessage Post([FromBody]Members value)
        {
            string allowedCharacter = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            var builder = new StringBuilder();
            var randomCode = new Random();
            for (int i = 1; i <= 3; i++)
            {
                int index = randomCode.Next(0, allowedCharacter.Length);
                var randomChar = allowedCharacter[index];
                builder.Append(randomChar);
            }
            string monthDay = DateTime.Now.ToString("MMdd");
            string generatedCode = "BSMEM-" + monthDay + builder.ToString();

            var client = value;
            string sql = string.Format("EXEC users.SaveClient       '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}'",
                0,
                generatedCode,
                client.LastName,
                client.FirstName,
                client.MI,
                client.Address,
                client.ContactNumber,
                client.EmailAddress,
                DateTime.Now,
                true,
                "I"
                );
            SqlCommand cmd = new SqlCommand(sql, con);
            if (con.State == ConnectionState.Closed) con.Open();
            var result = cmd.ExecuteNonQuery();
            if(result >= 1)
            {
                return Request.CreateResponse(HttpStatusCode.Created, generatedCode);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "ERROR");
            }
        }
    }
}