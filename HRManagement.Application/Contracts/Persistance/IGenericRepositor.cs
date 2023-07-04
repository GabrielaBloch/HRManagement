using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.Application.Contracts.Persistance
{
    internal interface IGenericRepositor<T> where T : class
    {
        Task<T> GetAsync(int id);
        Task<T> CreateAsync(T entity);
        Task<T> GetByIdAync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);

    }


}
