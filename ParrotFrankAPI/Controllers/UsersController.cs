using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParrotFrankAPI.parrot_frank;

namespace ParrotFrankAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly parrot_frankContext _context;

        public UsersController(parrot_frankContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> Get(int? skip, int? take)
        {
            var Users = _context.Users.AsQueryable();
            //testing parameters...
            if (skip != null)
            {
                Users = Users.Skip((int)skip);
            }

            if (take != null)
            {
                Users = Users.Take((int)take);
            }

            return await Users.ToListAsync();
        }

        // GET: api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> GetUsers(int id)
        {
            var users = await _context.Users.FindAsync(id);

            if (users == null)
            {
                return NotFound();
            }

            return users;
        }
        

    }
}
