using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalRadiation.Models.Dtos;
using TechnicalRadiation.Models.InputModels;

namespace TechnicalRadiation.Repositories.Interfaces
{
    public interface INewsitemRepository
    {
        IEnumerable<NewsItemDto> GetAllNewsItems();
        NewsItemDetailDto GetNewsItemById(int id);
        NewsItemDetailDto CreateNewsItem(NewsItemInputModel newsItem);
        void UpdateNewsItemById(int id, NewsItemInputModel newsItem);
        void DeleteNewsItemById(int id);

    }
}
