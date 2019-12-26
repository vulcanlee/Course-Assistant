using Assistant.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assistant.Services
{
    public class CourseUserService : ICourseUserService
    {
        private readonly MyDbContext myDbContext;

        public CourseUserService(MyDbContext myDbContext)
        {
            this.myDbContext = myDbContext;
        }

        public async Task<List<CourseUser>> RetriveAsync()
        {
            return await myDbContext.CourseUsers.ToListAsync();
        }
        public async Task<CourseUser> RetriveAsync(int id)
        {
            return await myDbContext.CourseUsers.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task CreateAsync(CourseUser courseUser)
        {
            await myDbContext.CourseUsers.AddAsync(courseUser);
            await myDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var fooItem = await RetriveAsync(id);
            if (fooItem != null)
            {
                myDbContext.CourseUsers.Remove(fooItem);
                await myDbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(int id, CourseUser courseUser)
        {
            var fooItem = await RetriveAsync(id);
            if (fooItem != null)
            {
                fooItem.Name = courseUser.Name;
                fooItem.PasswordHash = courseUser.PasswordHash;
                fooItem.Roles = courseUser.Roles;
                fooItem.Salt = courseUser.Salt;
                await myDbContext.SaveChangesAsync();
            }
        }
    }
}
