using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalRadiation.Models.Dtos;
using TechnicalRadiation.Models.InputModels;

namespace TechnicalRadiation.Services.Interfaces
{
    public interface IAuthorService
    {
        IEnumerable<AuthorDto> GetAllAuthors();
        AuthorDetailDto GetAllAuthorsById(int id);
        IEnumerable<NewsItemDto> GetNewsItemsOfAuthorById(int id);
        AuthorDetailDto CreateAuthor(AuthorInputModel author);
        void UpdateAuthorById(AuthorInputModel author, int id);
        void DealeteAutherById(int id);
        void LinkNewsItemAndAutherById(int authorId, int newsItemId);
    }
}
