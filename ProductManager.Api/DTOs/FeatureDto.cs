using System.ComponentModel.DataAnnotations;

namespace ProductManger.Api.Dtos
{
    public class FeatureDto
    {
        public int Id {get; set;}
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Title { get; set; } = string.Empty;
        [Required]
        [StringLength(200, MinimumLength = 10)]
        public string Description { get; set; } = string.Empty;
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Priority { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
    }
}