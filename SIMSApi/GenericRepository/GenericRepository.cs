using Microsoft.EntityFrameworkCore;
using SIMSApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIMSApi.GenericRepository
{
    public class GenericRepository<T> : IGenericInterface<T> where T : class
    {
        SIMSContext db;
        private DbSet<T> table;

        public GenericRepository(SIMSContext _db)
        {
            db = _db;
            table = db.Set<T>();
        }

        public async Task<List<T>> GetAll()
        {
            if(db != null)
            {
                return await table.ToListAsync();
            }

            return null;
        }

        public async Task<T> GetEntity(int Id)
        {
            try
            {
                if(db != null)
                {
                    return await table.FindAsync(Id);
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<T> Insert(T entity)
        {
            try
            {
                if(db != null)
                {
                  await table.AddAsync(entity);
                  await db.SaveChangesAsync();
                }
                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<T> Update(T entity)
        {
            try
            {
                table.Update(entity);
                await db.SaveChangesAsync();

                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<T> Delete(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
