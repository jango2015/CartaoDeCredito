using System.Collections.Generic;
using System.Threading.Tasks;

namespace CartaoCredito.Domain.Interfaces.Repository
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        Task<IEnumerable<TEntity>> GetAllAsync();        
        void Update(TEntity obj);
        void Remove(TEntity obj);
        void Dispose();
    }
}
