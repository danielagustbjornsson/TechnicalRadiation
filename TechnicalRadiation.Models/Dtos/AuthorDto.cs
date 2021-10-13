using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalRadiation.Models.Dtos
{
    public class AuthorDto: HyperMediaModel
    {
        public int Id {  get; set; }
        public string Name {  get; set; }
    }
}
