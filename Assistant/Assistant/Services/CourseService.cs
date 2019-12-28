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

        public ICourseUserService CourseUserService { get; }

        public CourseService(MyDbContext myDbContext, ICourseUserService courseUserService)
        {
            this.myDbContext = myDbContext;
            CourseUserService = courseUserService;
        }

        public async Task<List<Course>> RetriveAsync()
        {
            return await myDbContext.Courses
                .OrderByDescending(x => x.Created)
                .Include(x => x.CourseCourseUsers).ToListAsync();
        }
        public async Task<List<Course>> RetriveByUserAsync(int CouserUserId)
        {
            return await myDbContext.Courses.Where(x => x.CourseCourseUsers.FirstOrDefault(y=>y.CourseUserId == CouserUserId)!=null)
                .OrderByDescending(x => x.Created)
                .Include(x => x.CourseCourseUsers).ToListAsync();
        }
        public async Task<PagedResult<Course>> GetPagedByUserAsync(int CouserUserId, int page, int pageSize)
        {
            return await myDbContext.Courses.Where(x => x.CourseCourseUsers.FirstOrDefault(y => y.CourseUserId == CouserUserId) != null)
                .OrderByDescending(x => x.Created).Include(x => x.CourseCourseUsers).GetPaged(page, pageSize);
        }
        public async Task<Course> RetriveAsync(int id)
        {
            return await myDbContext.Courses.Include(x => x.CourseCourseUsers).FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<PagedResult<Course>> GetPagedAsync(int page, int pageSize)
        {
            return await myDbContext.Courses.OrderByDescending(x => x.Created).Include(x => x.CourseCourseUsers).GetPaged(page, pageSize);
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
            //myDbContext.Entry(courseUser).State = EntityState.Modified;
            //await myDbContext.SaveChangesAsync();
            //return;


            var fooItem = await RetriveAsync(id);
            if (fooItem != null)
            {
                fooItem.Name = courseUser.Name;
                fooItem.CourseCode = courseUser.CourseCode;
                fooItem.Description = courseUser.Description;
                fooItem.CourseCourseUsers = courseUser.CourseCourseUsers;
                //List<int> fooUserIds = new List<int>();
                //foreach (var item in fooItem.CourseUsers)
                //{
                //    fooUserIds.Add(item.Id);
                //}
                //var fooUserList = fooItem.CourseUsers;
                //fooItem.CourseUsers.Clear();
                //foreach (var item in fooUserIds)
                //{
                //    fooItem.CourseUsers.Add(await CourseUserService.RetriveAsync(item));
                //}
                //myDbContext.Entry(fooItem).State = EntityState.Modified;
                await myDbContext.SaveChangesAsync();

            }
        }

    }
}
