using System.Linq;
namespace Catalog.Controllers
{
    using System;
    using System.Collections.Generic;
    using Catalog.Dtos;
    using Catalog.Repositories;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IInMemItemsRepository repository;


        public ItemsController(IInMemItemsRepository repository) => this.repository = repository;

        [HttpGet]
        public ActionResult<IEnumerable<ItemDto>> GetItems()
        {
            var items = repository.GetItems().Select(item => item.AsDto());

            if (items == null)
            {
                return NotFound();
            }
            return Ok(items);
        }

        [HttpGet("{id}")]
        public ActionResult<ItemDto> GetItem(Guid id)
        {

            var item = repository.GetItem(id);
            if (item is null)
            {
                return NotFound();
            }
            return Ok(item.AsDto());
        }
    }

}