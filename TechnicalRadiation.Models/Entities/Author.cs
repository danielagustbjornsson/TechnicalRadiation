using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalRadiation.Models.Entities
{
    public class Author: BaseEntity
    {
        public int Id {  get; set; }
        public string Name {  get; set; }
        public string ProfileImgSource {  get; set; }
        public string Bio {  get; set; }
        public ICollection<NewsItem> NewsItems {  get; set; }
    }
}
