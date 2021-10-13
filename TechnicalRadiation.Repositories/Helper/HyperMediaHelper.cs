using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalRadiation.Models;
using TechnicalRadiation.Models.Dtos;
using TechnicalRadiation.Models.Entities;
using TechnicalRadiation.Models.Extensions;

namespace TechnicalRadiation.Repositories.Helper
{
    public class HyperMediaHelper
    {
        public HyperMediaModel Item;
        public string Base_NewsItem = "/api/";
        public string Base_Category = "/api/categories/";
        public string Base_Author = "/api/authors/";


        private void Reset()
        {
            this.Item = new HyperMediaModel();
        }

        public ExpandoObject Newsitem(NewsItem newsItem)
        {
            this.Reset();
            this.Item.Links.AddReference("self", new { href = $"{this.Base_NewsItem}{newsItem.Id}" });
            this.Item.Links.AddReference("edit", new { href = $"{this.Base_NewsItem}{newsItem.Id}" });
            this.Item.Links.AddReference("delete", new { href = $"{this.Base_NewsItem}{newsItem.Id}" });
            this.Item.Links.AddReference("Authors", new { href = $"{this.Base_Author}{newsItem.Id}" });


            List<Object> category_list = new List<Object>();

            foreach (Category category in newsItem.Categories)
            {
                category_list.Add(new { herf = $"{this.Base_Category}{category.Id}" });
                
            }

            this.Item.Links.AddListReference("categories", category_list);

            return this.Item.Links;

        }

        

        public ExpandoObject Author(Author author)
        {
            this.Reset();
            this.Item.Links.AddReference("self", new { herf = $"{this.Base_Author}{author.Id}" });
            this.Item.Links.AddReference("edit", new { herf = $"{this.Base_Author}{author.Id}" });
            this.Item.Links.AddReference("delete", new { herf = $"{this.Base_Author}{author.Id}" });

            return this.Item.Links;
        }

        public ExpandoObject Category(Category category)
        {
            this.Reset();
            this.Item.Links.AddReference("self", new {herf = $"{Base_Category}{category.Id}" });
            this.Item.Links.AddReference("edit", new { herf = $"{Base_Category}{category.Id}" });
            this.Item.Links.AddReference("delete", new { herf = $"{Base_Category}{category.Id}" });

            return this.Item.Links;
        }
    }
}
