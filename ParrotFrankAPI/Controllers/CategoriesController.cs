using Microsoft.AspNetCore.Mvc;
using ParrotFrankEntities.parrot_frank;

namespace ParrotFrankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly parrot_frankContext _context;
        public CategoriesController(parrot_frankContext context)
        {
            _context = context;
        }

        //[HttpPost]
        //public Task<IActionResult> Create(Categories model)
        //{
        //    return Ok();
        //}
    }
}
