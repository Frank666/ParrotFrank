using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParrotFrankData;
using ParrotFrankData.Products;
using ParrotFrankEntities.parrot_frank;
using ParrotFrankInterfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParrotFrankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : MainController<Categories, ProductsRepository>
    {
        public CategoriesController(ProductsRepository repository) : base(repository)
        {

        }
    }
}
