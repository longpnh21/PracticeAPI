using System.ComponentModel.DataAnnotations;

namespace PracticeAPI.DTOs
{
    public record UpdateItemDTO
    {
        [Required]
        public string Name { get; init; }
        [Required]
        [Range(1,99999)]
        public decimal Price { get; set; }
    }
}