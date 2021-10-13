using Microsoft.AspNetCore.Mvc;
using TechnicalRadiation.Models.InputModels;
using TechnicalRadiation.Services.Interfaces;

namespace TechnicalRadiation.WebApi.Controllers
{
    [ApiController]
    [Route("/api/authors")]
    public class AuthorsControler : Controller
    {
        private readonly IAuthorService _authorService;

        public AuthorsControler(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetAllAuthors()
        {
            return Ok(_authorService.GetAllAuthors());
        }

        [HttpGet]
        [Route("{authorId: int}")]
        public IActionResult GetAllAuthorsById(int authorId)
        {
            return Ok(_authorService.GetAllAuthorsById(authorId));
        }

        [HttpGet]
        [Route("{authorId: int}/newsItems")]
        public IActionResult GetNewsItemsOfAuthorById(int authorId)
        {
            return Ok(_authorService.GetNewsItemsOfAuthorById(authorId));
        }

        [HttpPost]
        [Route("")]
        public IActionResult CreateAuthor([FromBody] AuthorInputModel author)
        {
            var author2 = _authorService.CreateAuthor(author);
            return CreatedAtRoute("Make",new {authorId = author2.Id }, author2);
        }

        [HttpPut]
        [Route("{authorId}")]
        public IActionResult UpdateAuthorById([FromBody] AuthorInputModel author, int authorId)
        {
            _authorService.UpdateAuthorById(author, authorId);
            return NoContent();
        }

        [HttpDelete]
        [Route("{authorId}")]
        public IActionResult DealeteAutherById(int authorId)
        {
            _authorService.DealeteAutherById(authorId);
            return NoContent();
        }

        [HttpPatch]
        [Route("{authorId}/newsItems/{newsItemId}")]
        public IActionResult LinkNewsItemAndAutherById(int authorId, int newsItemId)
        {
            _authorService.LinkNewsItemAndAutherById(authorId, newsItemId);
            return NoContent();
        }
    }
}
