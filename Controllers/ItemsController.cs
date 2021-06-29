using System.Threading.Tasks;
using System.Linq;
namespace Catalog.Controllers
{
    using System;
    using System.Collections.Generic;
    using Catalog.Dtos;
    using Catalog.Entities;
    using Catalog.Repositories;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/v1/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsRepository repository;


        public ItemsController(IItemsRepository repository) => this.repository = repository;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemDto>>> GetItemsAsync()
        {
            var items = (await repository.GetItemsAsync()).Select(item => item.AsDto());

            if (items is null)
            {
                return NotFound();
            }
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDto>> GetItemAsync(Guid id)
        {

            var item = await repository.GetItemAsync(id);
            if (item is null)
            {
                return NotFound();
            }
            return Ok(item.AsDto());
        }

        [HttpPost]
        public async Task<ActionResult<ItemDto>> CreateItemAsync([FromForm] CreateItemDto itemDto)
        {
            Item item = new Item()
            {
                Id = Guid.NewGuid(),
                Name = itemDto.Name,
                Price = itemDto.Price,
                CreatedDate = DateTimeOffset.UtcNow,
            };

            await repository.CreateItemAsync(item);
            return CreatedAtAction(nameof(GetItemAsync), new { id = item.Id }, item.AsDto());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateItemAsync(Guid id, [FromForm] UpdateItemDto itemDto)
        {
            Item existingItem = await repository.GetItemAsync(id);

            if (existingItem is null) return NotFound();

            Item updateItem = new Item()
            {
                Id = existingItem.Id,
                Name = itemDto.Name,
                Price = itemDto.Price,
                CreatedDate = existingItem.CreatedDate,
            };

            await repository.UpdateItemAsync(updateItem);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteItemAsync(Guid id)
        {
            Item existingItem = await repository.GetItemAsync(id);
            if (existingItem is null) return NotFound();


            await repository.DeleteItemAsync(existingItem.Id);
            return NoContent();
        }
    }

}