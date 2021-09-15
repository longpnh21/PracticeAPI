using PracticeAPI.DTOs;
using PracticeAPI.Models;

namespace PracticeAPI.Utils 
{
    public static class Extensions
    {
        public static ItemDTO asDTO (this Item item) => new ItemDTO
        {
            Id = item.Id,
            Name = item.Name,
            Price = item.Price,
            CreatedDate = item.CreatedDate
        };
    }
}