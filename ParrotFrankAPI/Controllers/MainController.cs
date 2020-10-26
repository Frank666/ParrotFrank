using Microsoft.AspNetCore.Mvc;
using ParrotFrankInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParrotFrankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class MainController<TEntity, TRepository> : ControllerBase
        where TEntity : class, IEntity
        where TRepository : IRepository<TEntity>
    {
        private readonly TRepository repository;

        public MainController(TRepository repository)
        {
            this.repository = repository;
        }


        // GET: api/[controller]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TEntity>>> Get()
        {
            return await repository.GetAll();
        }

        // GET: api/[controller]/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<TEntity>> Get(int id)
        //{
        //    var movie = await repository.Get(id);
        //    if (movie == null)
        //    {
        //        return NotFound();
        //    }
        //    return movie;
        //}

        // PUT: api/[controller]/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> Put(int id, TEntity movie)
        //{
        //    if (id != movie.Id)
        //    {
        //        return BadRequest();
        //    }
        //    await repository.Update(movie);
        //    return NoContent();
        //}


    }
}
