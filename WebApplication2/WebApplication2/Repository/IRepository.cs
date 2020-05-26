using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Repository
{
    public interface IRepository<T> where T:class
    {
        Task AddAsync(T item);
        Task<T> GetByIdAsync(int Id);
        Task<List<T>> GetAllAsync();
        Task DeleteAsync(int id);
        Task<bool> UpdateAsync(Good item);
    }
}
