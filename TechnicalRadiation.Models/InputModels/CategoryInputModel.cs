using System.ComponentModel.DataAnnotations;

namespace TechnicalRadiation.Models.InputModels
{
    public class CategoryInputModel
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
