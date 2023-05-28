﻿using LernDeutsch_Backend.Dtos;
using LernDeutsch_Backend.Models;
using LernDeutsch_Backend.Services.Core;

namespace LernDeutsch_Backend.Services
{
    public interface ICourseService : IBaseService<Course>
    {
        Course Create(CourseCreateDto  dto);
        Dictionary<string, List<Course>> GetCoursesByLevels();
        Quiz GetFinalQuiz(Guid id);
    }
}
