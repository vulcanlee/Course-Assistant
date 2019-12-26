using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assistant.Models
{
    public class CourseUserRecordModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; } = "";
        public string Roles { get; set; }
    }
}
