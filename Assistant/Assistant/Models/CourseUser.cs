using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assistant.Models
{
    public class CourseUser
    {
        public int Id { get; set; }
        [Required]
        public string Account { get; set; }
        [Required]
        public string Name { get; set; }
        public Guid Salt { get; set; } 
        public string PasswordHash { get; set; }
        public string Roles { get; set; }
        public bool IsAdmin { get; set; }
        public DateTime Created { get; set; }
        public int OrderCode { get; set; }
        public List<CourseCourseUser> CourseCourseUsers { get; set; }
    }
}
