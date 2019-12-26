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
    }
}
