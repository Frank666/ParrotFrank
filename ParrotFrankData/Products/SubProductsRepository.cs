using ParrotFrankEntities.parrot_frank;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParrotFrankData.SubProducts
{
    public class SubProductsRepository : EFRepository<Subcategories, MySQLContext>
    {
        public SubProductsRepository(MySQLContext context) : base(context)
        {

        }
    }
}
