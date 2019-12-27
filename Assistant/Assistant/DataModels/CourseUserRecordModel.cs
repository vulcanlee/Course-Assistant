using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assistant.DataModels
{
    public class CourseUserRecordModel
    {
        public int Id { get; set; }
        [Required]
        public string Account { get; set; }
        [Required]
        public string Name { get; set; }
        public string Password { get; set; } = "";
        public string Roles { get; set; }
        public bool IsAdmin { get; set; }
        public int OrderCode { get; set; }
    }
}
