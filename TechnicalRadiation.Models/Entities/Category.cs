using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalRadiation.Models.Entities
{
    public class Category: BaseEntity
    {
        public int Id {  get; set; }
        public string Name {  get; set; }
        public string Slug {  get; set; }
        public ICollection<NewsItem> NewsItems { get; set; }
    }
}
