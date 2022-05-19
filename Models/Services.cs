using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeauStudioService.Models
{
    public class Services
    {
        [JsonProperty("id")]
        public long ID { get; set; }
        [JsonProperty("service_name")]
        public string ServiceName { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("category_id")]
        public long CategoryID { get; set; }
        [JsonProperty("category")]
        public string Category { get; set; }
        [JsonProperty("price")]
        public double Price { get; set; }
    }
    public class Category
    {
        [JsonProperty("id")]
        public int ID { get; set; }
        [JsonProperty("name")]
        public string CategoryName { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }

    }
}