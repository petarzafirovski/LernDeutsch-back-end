﻿using LernDeutsch_Backend.Models;
using LernDeutsch_Backend.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LernDeutsch_Backend.Data
{
    public class ApplicationDatabaseContext : IdentityDbContext<BaseUser>
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Tutor> Tutors { get; set; }

        public DbSet<Quiz> Quizzes { get; set; }
        
        public DbSet<Question> Questions { get; set; }

        public DbSet<Answer> Answers { get; set; }
        
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseStudent> CourseStudents { get; set; }

        public ApplicationDatabaseContext(DbContextOptions<ApplicationDatabaseContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Answer>()
                .HasOne(e => e.Question)
                .WithMany( e => e.Answers);

            builder.Entity<Course>()
                .HasOne(e => e.Tutor)
                .WithMany(e => e.Courses)
                .IsRequired(false); // TODO: Clean up after implementing Tutors properly

            builder.Entity<Lesson>()
                .HasOne(e => e.Course)
                .WithMany(e => e.Lessons);

            builder.Entity<Question>()
                .HasOne(e => e.Quiz)
                .WithMany(e => e.Questions);

            builder.Entity<Quiz>()
                .HasOne(e => e.Lesson)
                .WithMany(e => e.Quizzes);

            builder.Entity<Quiz>()
                .Property(e => e.QuizType)
                .HasConversion<string>();


            builder.Entity<Lesson>()
                .Property(e => e.LessonType)
                .HasConversion<string>();

            builder.Entity<Transaction>()
                .HasOne(e => e.BoughtBy)
                .WithMany();

            builder.Entity<Transaction>()
                .HasOne(e => e.Course)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
