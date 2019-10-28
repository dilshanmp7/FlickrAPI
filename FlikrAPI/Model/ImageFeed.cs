using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FlikrAPI.Model
{

    public class ImageFeed
    {
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("link")]
        public string Link { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("modified")]
        public string Modified { get; set; }
        [JsonProperty("generator")]
        public string Generator { get; set; }
        [JsonProperty("items")]
        public List<Item> Items { get; set; }
    }

    public class Item
    {
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("link")]
        public string Link { get; set; }
        [JsonProperty("media")]
        public Dictionary<string,string> Media { get; set; }
        [JsonProperty("date_taken")]
        public string DateTaken { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("published")]
        public string Published { get; set; }
        [JsonProperty("author")]
        public string Author { get; set; }
        [JsonProperty("author_id")]
        public string AuthorID { get; set; }
        [JsonProperty("tags")]
        public string Tags { get; set; }
    }

}
