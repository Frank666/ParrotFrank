using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ParrotFrankData.Products;
using ParrotFrankEntities.parrot_frank;

namespace ParrotFrankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthController : MainController<Categories, ProductsRepository>
    {
        public readonly ProductsRepository _repository;
        public HealthController(ProductsRepository repository) : base(repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("Check")]
        public async Task<IActionResult> Check()
        {
            try
            {
                var status = await _repository.IsConnected();
                if (!status)
                {
                    return new JsonResult(new Models.HealthResponse() { Status = "500", Component = "DB Parrot Frank API is offline", Desc = "DB Parrot Frank API is offline", ServerTime = new DateTime().Date });
                }
            }
            catch (Exception ex)
            {
                return new JsonResult(new Models.HealthResponse() { Status = "500", Component = "Something's wrong with DB Parrot Frank API", Desc = "Internal Server error", ServerTime = new DateTime().Date });
            }
            return new JsonResult(new Models.HealthResponse() { Status = "200", Component = "Parrot Frank API", Desc = "OK", ServerTime = new DateTime().Date });
        }
    }
}
