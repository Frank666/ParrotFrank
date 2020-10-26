using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParrotFrankInterfaces
{
    public interface IRepository<T> where T : class, IEntity
    {
        Task<List<T>> GetAll();
        Task<T> Get(int id);
        Task<T> Update(T entity);
    }
}
