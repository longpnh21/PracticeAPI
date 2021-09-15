using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
        public IEnumerable<ItemDTO> GetItems() => repository.GetItems().Select(item => item.asDTO());

        [HttpGet("{id}")]
        public ActionResult<ItemDTO> GetItem(Guid id) 
        {
            var itemDTO = repository.GetItem(id).asDTO();
            if (itemDTO == null)
                return NotFound();
            return itemDTO;
        }

        [HttpPost]
        public ActionResult<ItemDTO> CreateItem(CreateItemDTO createItemDTO)
        {
            Item item = new()
            {
                Id = Guid.NewGuid(),
                Name = createItemDTO.Name,
                Price = createItemDTO.Price,
                CreatedDate = DateTimeOffset.UtcNow
            };
            repository.CreateItem(item);
            return CreatedAtAction(nameof(GetItem), new {Id = item.Id}, item.asDTO());
        }

        [HttpPut("{id}")]
        public ActionResult UpdateItem(Guid id, UpdateItemDTO itemDTO)
        {
            var existingItem = repository.GetItem(id);
            if (existingItem == null)
                return NotFound();
            Item updatedItem = existingItem with 
            {
                Name = itemDTO.Name,
                Price = itemDTO.Price
            };

            repository.UpdateItem(updatedItem);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteItem(Guid id)
        {
            var existingItem = repository.GetItem(id);
            if (existingItem == null)
                return NotFound();
            repository.DeleteItem(id);
            return NoContent();
        }
    }
}