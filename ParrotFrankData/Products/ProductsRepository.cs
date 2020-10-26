using ParrotFrankEntities.parrot_frank;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParrotFrankData.Products
{ 
    public class ProductsRepository : EFRepository<Categories, MySQLContext>
    {
        public ProductsRepository(MySQLContext context) : base(context)
        {

        }
    }
}
