using Assistant.DataModels;
using Assistant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assistant.Services
{
    public interface ICourseService : IStandardService<Course>
    {
        Task<List<Course>> RetriveByUserAsync(int CouserUserId);
        Task<PagedResult<Course>> GetPagedByUserAsync(int CouserUserId,int page, int pageSize);
    }
}
