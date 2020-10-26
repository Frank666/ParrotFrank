using Microsoft.EntityFrameworkCore;
using ParrotFrankEntities.parrot_frank;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParrotFrankData.Tokens
{
    public class UsersRepository : EFRepository<Users, MySQLContext>
    {
        private readonly MySQLContext context;
        public UsersRepository(MySQLContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<Users> GetByNick(string nick)
        {
            return await context.Set<Users>().SingleOrDefaultAsync(x => x.Nick == nick);
        }

        public async Task<Users> GetUser(string nick, string secret)
        {
            return await context.Set<Users>().FirstOrDefaultAsync(u => u.Nick == nick && u.Secret == secret);
        }
    }
}
