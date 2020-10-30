using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParrotFrankData.SubProducts;
using ParrotFrankEntities.parrot_frank;

namespace ParrotFrankAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoriesController : MainController<Subcategories, SubProductsRepository>
    {
        private readonly SubProductsRepository _repository;
        public SubCategoriesController(SubProductsRepository repository) : base(repository)
        {
            _repository = repository;
        }
        [Route("GetByCategory/{productId}")]
        [HttpGet]
        
        public async Task<ActionResult<List<Subcategories>>> GetByCategoryId(int productId)
        {
            return await _repository.GetByCategoryId(productId);
        }


    }
}
