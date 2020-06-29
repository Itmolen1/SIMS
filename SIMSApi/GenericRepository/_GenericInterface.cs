using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIMSApi.GenericRepository
{
    public interface _GenericInterface<T> where T: class {  
        Task<List<T>> GetAll();
        Task<T> GetEntity(int Id);
        //void Insert(T entity);
        //void Update(T entity);
        //void Delete(T entity);
    }  
}
