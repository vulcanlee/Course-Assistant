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
        public static Course Clone(this Course courseUser)
        {
            Course newCourseUser = new Course()
            {
                Id = courseUser.Id,
                Name = courseUser.Name,
                CourseCode = courseUser.CourseCode,
                Description = courseUser.Description,
                CourseUsers = new List<CourseUser>()
            };

            foreach (var item in courseUser.CourseUsers)
            {
                var user = item.Clone();
                newCourseUser.CourseUsers.Add(user);
            }
            return newCourseUser;
        }
    }
}
