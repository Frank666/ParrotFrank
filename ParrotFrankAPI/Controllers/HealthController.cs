using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParrotFrankAPI.parrot_frank;

namespace ParrotFrankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        private readonly parrot_frankContext _context;
        public HealthController(parrot_frankContext context)
        {
            _context = context;
        }
        [HttpGet]
        public JsonResult Check()
        {
            try
            {
                if (!_context.Database.CanConnect())
                {
                    return new JsonResult(new Models.HealthResponse() { Status = "500", Component = "DB Parrot Frank API is offline", Desc = "OK", ServerTime = new DateTime().Date });
                }
            }
            catch(Exception ex)
            {
                return new JsonResult(new Models.HealthResponse() { Status = "500", Component = "Something's wrong with DB Parrot Frank API", Desc = "Internal Server error", ServerTime = new DateTime().Date });
            }
            return new JsonResult(new Models.HealthResponse() { Status = "200", Component = "Parrot Frank API", Desc = "OK", ServerTime = new DateTime().Date });
        }
    }
}
