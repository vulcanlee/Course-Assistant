using Assistant.DataModels;
using Assistant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assistant.Services
{
    public interface IStandardService<T> where T : class
    {
        Task CreateAsync(T courseUser);
        Task DeleteAsync(int id);
        Task<List<T>> RetriveAsync();
        Task UpdateAsync(int id, T courseUser);
        Task<PagedResult<T>> GetPagedAsync(int page, int pageSize);
    }
}
