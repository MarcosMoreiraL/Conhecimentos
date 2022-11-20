using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevTest.Domain.Services
{
    public interface IDataService<T>
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> GetByID(int cod);

        Task<T> Create(T entity);

        Task<T> Update(int cod, T entity);

        Task<bool> Delete(int cod);
    }
}