using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalRadiation.Models.Dtos;
using TechnicalRadiation.Models.Entities;
using TechnicalRadiation.Models.InputModels;
using TechnicalRadiation.Repositories.Contexts;
using TechnicalRadiation.Services.Interfaces;

namespace TechnicalRadiation.Repositories.Implementations
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly NewsDbContext _newsDbContext;

        public AuthorRepository(NewsDbContext newsDbContext)
        {
            _newsDbContext = newsDbContext;
        }

        public AuthorDetailDto CreateAuthor(AuthorInputModel author)
        {
            var newAuthor = new Author
            {
                Name = author.Name,
                ProfileImgSource = author.ProfileImgSource,
                Bio = author.Bio

            };

            _newsDbContext.Authors.Add(newAuthor);
            _newsDbContext.SaveChanges();

            return new AuthorDetailDto
            {
                Id = newAuthor.Id,
                Name = author.Name,
                Bio = author.Bio,
                ProfileImgSource = author.ProfileImgSource
            };
            
        }

        public void DealeteAutherById(int id)
        {
            var oneAuthor = _newsDbContext
                .Authors
                .Find(id);

            _newsDbContext.Authors.Remove(oneAuthor);
            _newsDbContext.SaveChanges();
            
        }

        public IEnumerable<AuthorDto> GetAllAuthors()
        {
            var allAuthors = _newsDbContext
                .Authors
                .Select(A => new AuthorDto
                {
                    Id = A.Id,
                    Name = A.Name
                });
            return allAuthors;
            
        }

        public AuthorDetailDto GetAllAuthorsById(int id)
        {
            var oneAuthor = _newsDbContext
                .Authors
                .Find(id);
            return new AuthorDetailDto
            {
                Id = oneAuthor.Id,
                Name = oneAuthor.Name,
                ProfileImgSource = oneAuthor.ProfileImgSource,
                Bio = oneAuthor.Bio
            };
            
        }

        public IEnumerable<NewsItemDto> GetNewsItemsOfAuthorById(int id)
        {
            var onewAuthor = _newsDbContext
                .Authors
                .Select(A => new
                {
                    A.Id,
                    A.NewsItems
                }).FirstOrDefault();

            var allNewsItemsOfAuthor = onewAuthor
                .NewsItems
                .Select(N => new NewsItemDto
                {
                    Id = N.Id,
                    Title = N.Title,
                    ImgSource = N.ImgSource,
                    ShortDescription = N.ShortDescription
                });
            return allNewsItemsOfAuthor;
        }

        public void LinkNewsItemAndAutherById(int authorId, int newsItemId)
        {
            // Geting the Author with the given id
            var oneAuthor = _newsDbContext
                .Authors
                .Select(A => new
                {
                    A.Id,
                    A.Name,
                    A.ProfileImgSource,
                    A.Bio,
                    A.NewsItems
                                
                }).FirstOrDefault();

            // Geting the NewsItem with the given id
            var oneNewsItem = _newsDbContext
                .NewsItems
                .Select(N => new
                {
                    N.Id,
                    N.Title,
                    N.ImgSource,
                    N.ShortDescription,
                    N.LongDescription,
                    N.PublishDate,
                    N.Authors
                }).FirstOrDefault();

            // adding the NewsItem part to Author part 
            oneAuthor.NewsItems.Add(new NewsItem
            {
                Id = oneNewsItem.Id,
                Title = oneNewsItem.Title,
                ImgSource = oneNewsItem.ImgSource,
                ShortDescription = oneNewsItem.ShortDescription,
                LongDescription = oneNewsItem.LongDescription,
                PublishDate = oneNewsItem.PublishDate,
                Authors = oneNewsItem.Authors
            });

            // adding the Author part to the NewsItem part
            oneNewsItem.Authors.Add(new Author
            {
                Id = oneAuthor.Id,
                Name = oneAuthor.Name,
                ProfileImgSource = oneAuthor.ProfileImgSource,
                Bio = oneAuthor.Bio

            });
            _newsDbContext.SaveChanges();
        }

        public void UpdateAuthorById(AuthorInputModel author, int id)
        {
            var oneAuthor = _newsDbContext
                .Authors
                .Find(id);

            oneAuthor.Name = author.Name;
            oneAuthor.ProfileImgSource = author.ProfileImgSource;
            oneAuthor.Bio = author.Bio;

            _newsDbContext.SaveChanges();
            
        }
    }
}
