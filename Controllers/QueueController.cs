using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;
using System.Text;
using BeauStudioService.Models;
using System.Net.Http;
using System.Net;

namespace BeauStudioService.Controllers
{
    public class QueueController : ApiController
    {
        SqlConnection con = new SqlConnection(@"server=.\SQLSERVER2K14;database=beautystudio;User Id=sa;Password=ig@dm!n;");
        //POST api/queue
        public HttpResponseMessage Post([FromBody]Queue value)
        {
            string allowedCharacter = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            var builder = new StringBuilder();
            var randomCode = new Random();
            for(int i = 1; i <= 3; i++)
            {
                int index =  randomCode.Next(0, allowedCharacter.Length);
                var randomChar = allowedCharacter[index];
                builder.Append(randomChar);
            }
            string monthDay = DateTime.Now.ToString("MMdd");
            string generatedCode = "Q-" + monthDay + builder.ToString();

            var queue = value;
            string sql = string.Format("EXEC postings.SaveQueue '{0}','{1}','{2}','{3}' \n",
                            generatedCode,
                            queue.MemberID,
                            queue.LastName,
                            queue.FirstName);
            foreach(QueueDetails details in queue.Details)
            {
                sql += string.Format("EXEC postings.SaveQueueDetails '{0}','{1}','{2}','{3}' \n",
                            generatedCode,
                            details.ServiceID,
                            details.EmployeeID,
                            details.Quantity);
            }
            SqlCommand cmd = new SqlCommand(sql, con);
            if (con.State == ConnectionState.Closed) con.Open();
            var result = cmd.ExecuteNonQuery();
            if(result >= 1)
            {
                return Request.CreateResponse(HttpStatusCode.Created, generatedCode);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Save failed");
            }
        }
    }
}