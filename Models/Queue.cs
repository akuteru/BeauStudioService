using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeauStudioService.Models
{
    public class Queue
    {
        [JsonProperty("id")]
        public long ID { get; set; }
        [JsonProperty("memberId")]
        public string MemberID { get; set; }
        [JsonProperty("queueNumber")]
        public string QueueNumber { get; set; }
        [JsonProperty("lastName")]
        public string LastName { get; set; }
        [JsonProperty("firstName")]
        public string FirstName { get; set; }
        [JsonProperty("dateRequested")]
        public DateTime DateRequested { get; set; }
        [JsonProperty("details")]
        public IEnumerable<QueueDetails> Details { get; set; }
    }
    public class QueueDetails
    {
        [JsonProperty("id")]
        public long ID { get; set; }
        [JsonProperty("queueId")]
        public long QueueID { get; set; }
        [JsonProperty("serviceId")]
        public long ServiceID { get; set; }
        [JsonProperty("employeeId")]
        public long EmployeeID { get; set; }
        [JsonProperty("quantity")]
        public int Quantity { get; set; }
    }
}