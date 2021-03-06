using System.Collections.Generic;
using System.Threading.Tasks;
using CompanyCob.Repository.Data;
using Microsoft.EntityFrameworkCore;
using CompanyCob.Domain.Model.Interface.Repository;

namespace CompanyCob.Repository
{
    public abstract class AbstractRepository<TType, TKey> :
        IRepository<TType, TKey>
        where TType : class
    {
        private readonly CobDbContext _context;

        public AbstractRepository(CobDbContext context)
        {
            this._context = context;
        }

        public virtual async Task<IList<TType>> GetAllAsync()
        {
            /*
            AsNoTracking retira algumas informações internas do EF, evitando rastreios desnecessários
            Útil em casos onde a informação não será gravada de volta
            */

            return await _context.Set<TType>().AsNoTracking().ToListAsync();
        }

        public virtual async Task<TType> GetAsync(TKey id)
        {
            var entity = await _context.Set<TType>().FindAsync(id);
            _context.Entry(entity).State = EntityState.Detached;
            return entity;
        }

        public virtual async Task SaveAsync(TType entity)
        {
            await _context.Set<TType>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(TType entity)
        {
            _context.Entry<TType>(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TType entity) 
        {
            _context.Set<TType>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}