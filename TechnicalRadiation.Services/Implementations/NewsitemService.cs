using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalRadiation.Models.Dtos;
using TechnicalRadiation.Models.InputModels;
using TechnicalRadiation.Repositories.Interfaces;
using TechnicalRadiation.Services.Interfaces;

namespace TechnicalRadiation.Services.Implementations
{
    internal class NewsitemService : INewsitemService
    {
        private readonly INewsitemRepository _newsitemRepository;

        public NewsitemService(INewsitemRepository newsitemRepository)
        {
            _newsitemRepository = newsitemRepository;
        }
        public NewsItemDetailDto CreateNewsItem(NewsItemInputModel newsItem)
        {
            return _newsitemRepository.CreateNewsItem(newsItem);
        }

        public void DeleteNewsItemById(int id)
        {
            _newsitemRepository.DeleteNewsItemById(id);
        }

        public IEnumerable<NewsItemDto> GetAllNewsItems()
        {
            return _newsitemRepository.GetAllNewsItems();
        }

        public NewsItemDetailDto GetNewsItemById(int id)
        {
            return _newsitemRepository.GetNewsItemById(id);
        }

        public void UpdateNewsItemById(int id, NewsItemInputModel newsItem)
        {
            _newsitemRepository.UpdateNewsItemById(id, newsItem);
        }
    }
}
