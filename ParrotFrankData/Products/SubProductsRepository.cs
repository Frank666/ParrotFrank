using Microsoft.EntityFrameworkCore;
using ParrotFrankEntities.parrot_frank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParrotFrankData.SubProducts
{
    public class SubProductsRepository : EFRepository<Subcategories, MySQLContext>
    {
        private readonly MySQLContext context;
        public SubProductsRepository(MySQLContext context) : base(context)
        {
            this.context = context;
        }
        public async Task<List<Subcategories>> GetByCategoryId(int productId)
        {
            return await context.Set<Subcategories>().Where(x => x.CategoryId == productId).ToListAsync();
        }

    }
}
