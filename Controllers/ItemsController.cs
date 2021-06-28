namespace Catalog.Controllers
{
    using System;
    using System.Collections.Generic;
    using Catalog.Entities;
    using Catalog.Repositories;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IInMemItemsRepository repository;


        public ItemsController(IInMemItemsRepository repository) => this.repository = repository;

        [HttpGet]
        public IEnumerable<Item> GetItems()
        {
            var items = repository.GetItems();
            return items;
        }

        [HttpGet("/{id}")]
        public ActionResult<Item> GetItem(Guid id)
        {

            var item = repository.GetItem(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }
    }

}