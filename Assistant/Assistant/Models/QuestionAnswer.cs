﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assistant.Models
{
    public class QuestionAnswer
    {
        public int Id { get; set; }
        public string QuestionTitle { get; set; }
        public string QuestionDescription { get; set; }
        public DateTime Created { get; set; }
        public DateTime Closed { get; set; }
    }
}
