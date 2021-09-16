using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PracticeAPI.Models;

namespace PracticeAPI.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly List<Item> items = new()
        {
            new Item {Id = Guid.NewGuid(), Name = "Car", Price = 8000, CreatedDate = DateTimeOffset.UtcNow},
            new Item {Id = Guid.NewGuid(), Name = "Steering Wheel", Price = 1500, CreatedDate = DateTimeOffset.UtcNow},
            new Item {Id = Guid.NewGuid(), Name = "Tire", Price = 1000, CreatedDate = DateTimeOffset.UtcNow}
        };
        public async Task CreateItemAsync(Item item) 
        {
            items.Add(item);
            await Task.CompletedTask;
        }

        public async Task DeleteItemAsync(Guid id)
        {
            var index = items.FindIndex(existingItem => existingItem.Id == id);
            items.RemoveAt(index);
            await Task.CompletedTask;
        }

        public async Task<Item> GetItemAsync(Guid id) 
        {
            var item = items.Where(item => item.Id == id).SingleOrDefault();
            return await Task.FromResult(item);
        }

        public async Task<IEnumerable<Item>> GetItemsAsync()
        {
            return await Task.FromResult(items);
        }

        public async Task UpdateItemAsync(Item item)
        {
            var index = items.FindIndex(existingItem => existingItem.Id == item.Id);
            items[index] = item;
            await Task.CompletedTask;
        }
    }
}