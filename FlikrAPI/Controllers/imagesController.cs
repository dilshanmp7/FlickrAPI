using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using FlikrAPI.PublicApiService;


namespace FlikrAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        
        [HttpGet]
        public async Task<IActionResult> GetImages()
        {
            return await GetImagesAsync();
        }
        
        [HttpGet("{tags}")]
        public async  Task<IActionResult> GetImagesByTag(string tags)
        {
            return await GetImagesAsync(tags);
        }

        private async Task<IActionResult> GetImagesAsync(string tags="")
        {
            try
            {
                var imageFeeds = await FlickrService.FetchImageFeedsAsync(tags);
                return Ok(imageFeeds);
            }
            catch (HttpRequestException httpRequestException)
            {
                return BadRequest($"Error: {httpRequestException.Message}");
            }
        }

    }
}
