using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PracticeAPI.DTOs;
using PracticeAPI.Models;
using PracticeAPI.Repositories;
using PracticeAPI.Utils;

namespace PracticeAPI.Controllers 
{

    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : ControllerBase 
    {
        private readonly IItemRepository repository;

        public ItemsController(IItemRepository repository) 
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<ItemDTO>> GetItemsAsync()
        {
            var items = (await repository.GetItemsAsync())
                        .Select(item => item.asDTO());
                        
            return items;                    
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDTO>> GetItemAsync(Guid id) 
        {
            var item = await repository.GetItemAsync(id);

            if (item == null)
                return NotFound();

            return item.asDTO();
        }

        [HttpPost]
        public async Task<ActionResult<ItemDTO>> CreateItem(CreateItemDTO createItemDTO)
        {
            Item item = new()
            {
                Id = Guid.NewGuid(),
                Name = createItemDTO.Name,
                Price = createItemDTO.Price,
                CreatedDate = DateTimeOffset.UtcNow
            };

            await repository.CreateItemAsync(item);
            return CreatedAtAction(nameof(GetItemAsync), new {Id = item.Id}, item.asDTO());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateItemAsync(Guid id, UpdateItemDTO itemDTO)
        {
            var existingItem = await repository.GetItemAsync(id);

            if (existingItem == null)
                return NotFound();

            Item updatedItem = existingItem with 
            {
                Name = itemDTO.Name,
                Price = itemDTO.Price
            };

            await repository.UpdateItemAsync(updatedItem);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteItem(Guid id)
        {
            var existingItem = await repository.GetItemAsync(id);

            if (existingItem == null)
                return NotFound();

            await repository.DeleteItemAsync(id);
            return NoContent();
        }
    }
}