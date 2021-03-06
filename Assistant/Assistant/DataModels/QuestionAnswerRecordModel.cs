﻿using Assistant.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assistant.DataModels
{
    public class QuestionAnswerRecordModel
    {
        public int Id { get; set; }
        [Required]
        public string QuestionTitle { get; set; }
        public string QuestionDescription { get; set; }
        public string Answer { get; set; }
        public bool HasAnswer { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Closed { get; set; }
    }
}
