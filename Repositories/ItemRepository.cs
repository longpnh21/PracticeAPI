using System;
using System.Collections.Generic;
using System.Linq;
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
        public void CreateItem(Item item) => items.Add(item);

        public void DeleteItem(Guid id)
        {
            var index = items.FindIndex(existingItem => existingItem.Id == id);
            items.RemoveAt(index);
        }

        public Item GetItem(Guid id) => items.Where(item => item.Id == id).SingleOrDefault();

        public IEnumerable<Item> GetItems() => items;

        public void UpdateItem(Item item)
        {
            var index = items.FindIndex(existingItem => existingItem.Id == item.Id);
            items[index] = item;
        }
    }
}