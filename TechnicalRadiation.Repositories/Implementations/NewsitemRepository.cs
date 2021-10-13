using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalRadiation.Models.Dtos;
using TechnicalRadiation.Models.Entities;
using TechnicalRadiation.Models.InputModels;
using TechnicalRadiation.Repositories.Contexts;
using TechnicalRadiation.Repositories.Helper;
using TechnicalRadiation.Repositories.Interfaces;

namespace TechnicalRadiation.Repositories.Implementations
{
    public class NewsitemRepository : INewsitemRepository
    {
        private readonly NewsDbContext _newsDbContext;

        public NewsitemRepository(NewsDbContext newsDbContext)
        {
            _newsDbContext = newsDbContext;
        }
        public NewsItemDetailDto CreateNewsItem(NewsItemInputModel newsItem)
        {
            var newNewsItem = new NewsItem
            {
                Title = newsItem.Title,
                ImgSource = newsItem.ImgSource,
                ShortDescription = newsItem.ShortDescription,
                LongDescription = newsItem.LongDescription,
                PublishDate = newsItem.PublishDate
            };

            _newsDbContext.NewsItems.Add(newNewsItem);
            _newsDbContext.SaveChanges();

            return new NewsItemDetailDto
            {
                Id = newNewsItem.Id,
                ImgSource = newNewsItem.ImgSource,
                ShortDescription = newNewsItem.ShortDescription,
                LongDescription = newNewsItem.LongDescription,
                PublishDate = newNewsItem.PublishDate
            };

           
        }

        public void DeleteNewsItemById(int id)
        {
            var oneNewsItem = _newsDbContext
                .NewsItems
                .Find(id);

            _newsDbContext.NewsItems.Remove(oneNewsItem);
            _newsDbContext.SaveChanges();
            
        }

        public IEnumerable<NewsItemDto> GetAllNewsItems()
        {
            var allNewsItems1 = _newsDbContext
                .NewsItems
                .OrderByDescending(N =>N.PublishDate);

            var allNewsItems2 = allNewsItems1
                .Select(N => new NewsItemDto
                {
                    Id = N.Id,
                    Title = N.Title,
                    ImgSource = N.ImgSource,
                    ShortDescription = N.ShortDescription,
                    Links = new HyperMediaHelper().Newsitem(N)
                });



            return allNewsItems2;
        }

        public NewsItemDetailDto GetNewsItemById(int id)
        {
            var oneNewsItem = _newsDbContext
                .NewsItems
                .Where(N => N.Id == id)
                .Select(N => new NewsItemDetailDto
                {
                    Id = N.Id,
                    Title = N.Title,
                    ImgSource = N.ImgSource,
                    ShortDescription = N.ShortDescription,
                    LongDescription = N.LongDescription,
                    PublishDate = N.PublishDate,
                    Links = new HyperMediaHelper().Newsitem(N)
                }).FirstOrDefault();
            return oneNewsItem;
        }

        public void UpdateNewsItemById(int id, NewsItemInputModel newsItem)
        {
            var oneNewsItem = _newsDbContext
                .NewsItems
                .Find(id);

            oneNewsItem.Title = newsItem.Title;
            oneNewsItem.ImgSource = newsItem.ImgSource;
            oneNewsItem.ShortDescription = newsItem.ShortDescription;
            oneNewsItem.LongDescription = newsItem.LongDescription;
            oneNewsItem.PublishDate = newsItem.PublishDate;

            _newsDbContext.SaveChanges();
            
        }
    }
}
