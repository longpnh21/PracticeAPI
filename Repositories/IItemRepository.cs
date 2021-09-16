using System;
using PracticeAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PracticeAPI.Repositories
{
    public interface IItemRepository 
    {
        Task<IEnumerable<Item>> GetItemsAsync();
        Task<Item> GetItemAsync(Guid id);
        Task CreateItemAsync(Item item);
        Task UpdateItemAsync(Item item);
        Task DeleteItemAsync(Guid id);
    }
}