using System;
using PracticeAPI.Models;
using System.Collections.Generic;

namespace PracticeAPI.Repositories
{
    public interface IItemRepository 
    {
        IEnumerable<Item> GetItems();
        Item GetItem(Guid id);
        void CreateItem(Item item);
        void UpdateItem(Item item);
        void DeleteItem(Guid id);
    }
}