﻿using System.ComponentModel.DataAnnotations;
using LernDeutsch_Backend.Dtos.Types;

namespace LernDeutsch_Backend.Models
{
    public class Lesson
    {
        [Key]
        public Guid LessonId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }

        public LessonType LessonType { get; set; }
        public Course Course { get; set; }

        public virtual List<Quiz> Quizzes { get; set; } = new List<Quiz>();

        
    }
}
