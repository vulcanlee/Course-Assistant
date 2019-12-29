using Assistant.DataModels;
using Assistant.Extensions;
using Assistant.Helpers;
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
        public async Task<CourseUser> LoginAsync(string account, string password)
        {
            CourseUser user = await myDbContext.CourseUsers.FirstOrDefaultAsync(x => x.Account == account);
            if (user != null)
            {
                string passwordHash = PasswordHelper.GetPassowrdHash(user.Salt, password);
                if(user.PasswordHash!= passwordHash)
                {
                    user = null;
                }
            }
            else
            {
                user = null;
            }

            return user;
        }
        public async Task<List<CourseUser>> RetriveAsync()
        {
            return await myDbContext.CourseUsers.OrderBy(x=>x.OrderCode).ThenByDescending(x=>x.Created).ToListAsync();
        }
        public async Task<CourseUser> RetriveAsync(int id)
        {
            return await myDbContext.CourseUsers.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<PagedResult<CourseUser>> GetPagedAsync(int page, int pageSize)
        {
            var bar = await  myDbContext.CourseUsers.CountAsync();
            var foo = await myDbContext.CourseUsers.OrderByDescending(x => x.OrderCode).ThenByDescending(x => x.Created).CountAsync();
            return await myDbContext.CourseUsers.OrderByDescending(x => x.OrderCode).ThenByDescending(x => x.Created).GetPaged(page, pageSize);
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
                fooItem.Account = courseUser.Account;
                fooItem.IsAdmin = courseUser.IsAdmin;
                fooItem.IsOnlyAddQuestion = courseUser.IsOnlyAddQuestion;
                fooItem.OrderCode = courseUser.OrderCode;
                fooItem.Created = courseUser.Created;
                await myDbContext.SaveChangesAsync();
            }
        }
    }
}
