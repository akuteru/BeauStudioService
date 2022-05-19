using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeauStudioService.Models
{
    public class Members
    {
        [JsonProperty("id")]
        public long ID { get; set; }
        [JsonProperty("client_code")]
        public string ClientCode { get; set; }
        [JsonProperty("last_name")]
        public string LastName { get; set; }
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        [JsonProperty("mi")]
        public string MI { get; set; }
        [JsonProperty("address")]
        public string Address { get; set; }
        [JsonProperty("contact_number")]
        public string ContactNumber { get; set; }
        [JsonProperty("email_address")]
        public string EmailAddress { get; set; }
        [JsonProperty("membership_date")]
        public DateTime MembershipDate { get; set; }
        [JsonProperty("isActive")]
        public string IsActive { get; set; }
    }
}