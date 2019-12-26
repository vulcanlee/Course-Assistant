using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assistant.Models
{
    public class CourseUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Guid Salt { get; set; } 
        public string PasswordHash { get; set; }
        public string Roles { get; set; }
    }
}
