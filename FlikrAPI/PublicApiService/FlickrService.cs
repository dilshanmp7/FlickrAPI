using Newtonsoft.Json;
using FlikrAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FlikrAPI.PublicApiService
{
    public class FlickrService
    {
        public async static Task<string> FetchImageFeedsAsync(string tags="")
        {
            var client = new HttpClient();
            var response = await client.GetAsync($"https://www.flickr.com/services/feeds/photos_public.gne?format=json&tags={tags}&nojsoncallback=1");
            
            var imageFeeds = await response.Content.ReadAsStringAsync();

            var imageFeedObject = JsonConvert.DeserializeObject<ImageFeed>(imageFeeds);
            var anonymousObject = from item in imageFeedObject.Items
                               select new
                               {
                                   title = item.Title,
                                   link = item.Link,
                                   media = item.Media.Values.First(),
                                   tags = item.Tags
                               };

            var jsonFormat = JsonConvert.SerializeObject(anonymousObject);
            return jsonFormat;
        }
    }
}
