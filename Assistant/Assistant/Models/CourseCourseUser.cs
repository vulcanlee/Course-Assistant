using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assistant.Models
{
    public class CourseCourseUser
    {
        public int CourseUserId { get; set; }
        public CourseUser CourseUser { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
