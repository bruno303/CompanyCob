using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompanyCob.Domain.Model.Interface
{
    public interface IRepository<TType, TKey> where TType : class
    {
        Task<IList<TType>> GetAll();

        Task<TType> Get(TKey id);

        Task Save(TType entity);

        Task Update(TType entity);

        Task Delete(TType entity);
    }
}