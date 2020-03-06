using System.Collections.Generic;
using System.Threading.Tasks;
using CompanyCob.Repository.Data;
using CompanyCob.Repository.Interface;
using Microsoft.EntityFrameworkCore;

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

        public virtual async Task<IEnumerable<TType>> Get()
        {
            /*
            AsNoTracking retira algumas informações internas do EF, deixando a consulta mais "leve"
            Útil em casos onde a informação não será gravada de volta
            */

            return await _context.Set<TType>().AsNoTracking().ToListAsync();
        }

        public virtual async Task<TType> Get(TKey id)
        {
            return await _context.Set<TType>().FindAsync(id);
        }

        public virtual async Task Save(TType entity)
        {
            await _context.Set<TType>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task Update(TType entity)
        {
            _context.Entry<TType>(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(TType entity) 
        {
            _context.Set<TType>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}