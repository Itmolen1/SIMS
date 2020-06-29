using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIMSApi.GenericRepository
{
    public interface IGenericInterface<T> where T: class {  
        Task<List<T>> GetAll();
        Task<T> GetEntity(int Id);
        Task<T> Insert(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(int Id);
    }  
}
