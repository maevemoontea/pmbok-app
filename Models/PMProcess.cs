using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace PmbokApp.Models
{
    public class PMProcess
    {
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        public List<string> Inputs { get; set; }
        public List<string> Outputs { get; set; }
        public List<string> Techniques { get; set; }
        public List<Comment> Comments { get; set; }
    }
}