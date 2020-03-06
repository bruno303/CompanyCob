using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompanyCob.Repository.Interface
{
    public interface IRepository<TType, TKey> where TType : class
    {
        Task<IEnumerable<TType>> Get();

        Task<TType> Get(TKey id);

        Task Save(TType entity);

        Task Update(TType entity);

        Task Delete(TType entity);
    }
}