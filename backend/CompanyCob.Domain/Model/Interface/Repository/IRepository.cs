using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompanyCob.Domain.Model.Interface.Repository
{
    public interface IRepository<TType, TKey> where TType : class
    {
        Task<IList<TType>> GetAllAsync();

        Task<TType> GetAsync(TKey id);

        Task SaveAsync(TType entity);

        Task UpdateAsync(TType entity);

        Task DeleteAsync(TType entity);
    }
}