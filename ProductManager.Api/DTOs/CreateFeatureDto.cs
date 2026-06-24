using System.ComponentModel.DataAnnotations;

namespace ProductManger.Api.Dtos
{
    public class CreateFeatureDto
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Title {get; set;} = string.Empty;
        [Required]
        [StringLength(200, MinimumLength = 10)]
        public string Description {get; set;} = string.Empty;
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Priority {get; set;} = string.Empty;
    }
}