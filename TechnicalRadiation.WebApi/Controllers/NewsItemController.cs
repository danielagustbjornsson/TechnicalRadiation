using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechnicalRadiation.Models;
using TechnicalRadiation.Models.Dtos;
using TechnicalRadiation.Models.InputModels;
using TechnicalRadiation.Services.Interfaces;

namespace TechnicalRadiation.WebApi.Controllers
{
    [ApiController]
    [Route("api")]
    public class NewsItemController : Controller
    {
        private readonly INewsitemService _newsitemService;

        public NewsItemController(INewsitemService newsitemService)
        {
            _newsitemService = newsitemService;
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetAllNewsItem([FromQuery] int pageSize = 25, [FromQuery] int pageNumber = 1)
        {
            var NewsItems = _newsitemService.GetAllNewsItems();
            
            
            var envelope = new Envelope<NewsItemDto>(pageNumber, pageSize, NewsItems);
            return Ok(envelope.Items);
        }
        [HttpGet]
        [Route("/{newsItemId:int}", Name = "GetNewsItemById")]
        public IActionResult GetNewsItemById(int newsItemId)
        {
            return Ok(_newsitemService.GetNewsItemById(newsItemId);
        }
        [Authorize]
        [HttpPost]
        [Route("")]
        public IActionResult CreateNewsItem([FromBody] NewsItemInputModel NewsItem)
        {
            var createdNewsItem =  _newsitemService.CreateNewsItem(NewsItem);
            return CreatedAtRoute("GetNewsItemById", new {newsItemId = createdNewsItem.Id}, createdNewsItem);
        }
        [Authorize]
        [HttpPut]
        [Route("/{newsItemId:int}")]
        public IActionResult UpdateNewsItemById(int newsItemId, [FromBody] NewsItemInputModel NewsItem)
        {
            _newsitemService.UpdateNewsItemById(newsItemId, NewsItem);
            return NoContent();
        }
        [Authorize]
        [HttpDelete]
        [Route("/{newsItemId:int}")]
        public IActionResult DeleteNewsItemById(int newsItemId)
        {
            _newsitemService.DeleteNewsItemById(newsItemId);
            return NoContent();
        }

    }
}
