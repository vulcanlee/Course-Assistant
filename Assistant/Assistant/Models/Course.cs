using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assistant.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required]
        public string CourseCode { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public List<CourseCourseUser> CourseCourseUsers { get; set; }
    }
}
