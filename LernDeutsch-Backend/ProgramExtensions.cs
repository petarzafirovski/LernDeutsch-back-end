using LernDeutsch_Backend.Data;
using LernDeutsch_Backend.Models.Identity;
using LernDeutsch_Backend.Repositories;
using LernDeutsch_Backend.Repositories.Implementation;
using LernDeutsch_Backend.Services;
using LernDeutsch_Backend.Services.Implementation;
using Microsoft.EntityFrameworkCore;

namespace LernDeutsch_Backend
{
    public static class ProgramExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, ConfigurationManager configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDatabaseContext>(x => x.UseSqlServer(connectionString));
            services.AddIdentityCore<BaseUser>().AddEntityFrameworkStores<ApplicationDatabaseContext>();

            services.AddTransient<IAnswerRepository, AnswerRepository>();
            services.AddTransient<IQuizRepository, QuizRepository>();
            services.AddTransient<IQuestionRepository, QuestionRepository>();
            services.AddTransient<ICourseRepository, CourseRepository>();
            services.AddTransient<ICourseStudentRepository, CourseStudentRepository>();
            services.AddTransient<ILessonRepository, LessonRepository>();
            services.AddTransient<ITransactionRepository, TransactionRepository>();
            return services;
        }


        public static IServiceCollection Configure(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
            return services;
        }


        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAnswerService, AnswerService>();
            services.AddScoped<IQuestionService, QuestionService>();
            services.AddScoped<IQuizService, QuizService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<ICourseStudentService, CourseStudentService>();
            services.AddScoped<ILessonService, LessonService>();
            services.AddScoped<ITransactionService, TransactionService>();
            return services;
        }
    }
}
