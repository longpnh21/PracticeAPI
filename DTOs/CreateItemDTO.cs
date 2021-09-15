using System.ComponentModel.DataAnnotations;

namespace PracticeAPI.DTOs
{
    public record CreateItemDTO
    {
        [Required]
        public string Name { get; init; }
        [Required]
        [Range(1, 99999)]
        public decimal Price { get; init; }
    }
}