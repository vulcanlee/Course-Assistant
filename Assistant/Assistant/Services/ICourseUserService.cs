using Assistant.Models;
using Assistant.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assistant.Services
{
    public interface ICourseUserService : IStandardService<CourseUser>
    {
        Task<CourseUser> LoginAsync(string account, string password);
        Task<CourseUser> RetriveAsync(int id);
        //Task CreateAsync(CourseUser courseUser);
        //Task DeleteAsync(int id);
        //Task<List<CourseUser>> RetriveAsync();
        //Task UpdateAsync(int id, CourseUser courseUser);
        //Task<PagedResult<CourseUser>> GetPaged<CourseUser>(int page, int pageSize);
        //PagedResult<MyClass> GetPaged<CourseUser>(int page, int pageSize);
    }
}
