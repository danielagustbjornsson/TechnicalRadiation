using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalRadiation.Models.Entities
{
    public class NewsItem : BaseEntity
    {
        public int Id {  get; set; }
        public string Title {  get; set; }
        public string ImgSource {  get; set; }
        public string ShortDescription {  get; set; }
        public string LongDescription {  get; set; } 
        public DateTime PublishDate {  get; set; }
        public ICollection<Author> Authors {  get; set; }
        public ICollection<Category> Categories { get; set; }

    }
}
