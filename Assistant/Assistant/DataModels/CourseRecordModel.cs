using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assistant.DataModels
{
    public class CourseRecordModel
    {
        public int Id { get; set; }
        public string CourseCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class GuestbookEntry
    {
        public string Name { get; set; }

        public string Text { get; set; }
    }
}
