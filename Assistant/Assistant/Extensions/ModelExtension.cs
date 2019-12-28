using Assistant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assistant.Extensions
{
    public static class ModelExtension
    {
        public static CourseUser Clone(this CourseUser courseUser)
        {
            CourseUser newCourseUser = new CourseUser()
            {
                Id = courseUser.Id,
                Name = courseUser.Name,
                PasswordHash = courseUser.PasswordHash,
                Roles = courseUser.Roles,
                Salt = courseUser.Salt,
            };
            newCourseUser.Name = courseUser.Name;
            return newCourseUser;
        }
        public static CourseCourseUser Clone(this CourseCourseUser courseUser)
        {
            CourseCourseUser newCourseUser = new CourseCourseUser()
            {
                Course = courseUser.Course.Clone(),
                CourseUser = courseUser.CourseUser.Clone(),
                CourseUserId = courseUser.CourseUserId,
                CourseId = courseUser.CourseId,
            };
            return newCourseUser;
        }
        public static Course Clone(this Course courseUser)
        {
            Course newCourseUser = new Course()
            {
                Id = courseUser.Id,
                Name = courseUser.Name,
                CourseCode = courseUser.CourseCode,
                Description = courseUser.Description,
                CourseCourseUsers = new List<CourseCourseUser>()
            };

            foreach (var item in courseUser.CourseCourseUsers)
            {
                var user = item.Clone();
                newCourseUser.CourseCourseUsers.Add(user);
            }
            return newCourseUser;
        }
    }
}
