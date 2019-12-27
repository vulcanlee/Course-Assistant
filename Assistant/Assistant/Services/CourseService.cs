using Assistant.DataModels;
using Assistant.Extensions;
using Assistant.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assistant.Services
{
    public class CourseService : ICourseService
    {
        private readonly MyDbContext myDbContext;

        public CourseService(MyDbContext myDbContext)
        {
            this.myDbContext = myDbContext;
        }

        public async Task<List<Course>> RetriveAsync()
        {
            return await myDbContext.Courses.Include(x=>x.CourseUsers).ToListAsync();
        }
        public async Task<Course> RetriveAsync(int id)
        {
            return await myDbContext.Courses.Include(x => x.CourseUsers).FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<PagedResult<Course>> GetPagedAsync(int page, int pageSize)
        {
            return await myDbContext.Courses.Include(x => x.CourseUsers).GetPaged(page, pageSize);
        }
        public async Task CreateAsync(Course courseUser)
        {
            await myDbContext.Courses.AddAsync(courseUser);
            await myDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var fooItem = await RetriveAsync(id);
            if (fooItem != null)
            {
                myDbContext.Courses.Remove(fooItem);
                await myDbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(int id, Course courseUser)
        {
            var fooItem = await RetriveAsync(id);
            if (fooItem != null)
            {
                fooItem.Name = courseUser.Name;
                fooItem.CourseCode = courseUser.CourseCode;
                fooItem.Description = courseUser.Description;
                fooItem.CourseUsers = courseUser.CourseUsers;
                await myDbContext.SaveChangesAsync();
            }
        }

    }
}
