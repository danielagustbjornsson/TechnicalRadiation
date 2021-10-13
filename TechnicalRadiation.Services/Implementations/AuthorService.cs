using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalRadiation.Models.Dtos;
using TechnicalRadiation.Models.InputModels;
using TechnicalRadiation.Repositories.Implementations;
using TechnicalRadiation.Services.Interfaces;

namespace TechnicalRadiation.Services.Implementations
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _AuthorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _AuthorRepository = authorRepository;
        }

        public AuthorDetailDto CreateAuthor(AuthorInputModel author)
        {
            return _AuthorRepository.CreateAuthor(author);
        }

        public void DealeteAutherById(int id)
        {
            _AuthorRepository.DealeteAutherById(id);
        }

        public IEnumerable<AuthorDto> GetAllAuthors()
        {
            return _AuthorRepository.GetAllAuthors();
        }

        public AuthorDetailDto GetAllAuthorsById(int id)
        {
            return _AuthorRepository.GetAllAuthorsById(id);
        }

        public IEnumerable<NewsItemDto> GetNewsItemsOfAuthorById(int id)
        {
            return _AuthorRepository.GetNewsItemsOfAuthorById(id);
        }

        public void LinkNewsItemAndAutherById(int authorId, int newsItemId)
        {
            _AuthorRepository.LinkNewsItemAndAutherById(authorId, newsItemId);
        }

        public void UpdateAuthorById(AuthorInputModel author, int id)
        {
            _AuthorRepository.UpdateAuthorById(author, id);
        }
    }
}
