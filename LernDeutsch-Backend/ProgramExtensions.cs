using LernDeutsch_Backend.Data;
using LernDeutsch_Backend.Models.Identity;
using LernDeutsch_Backend.Repositories;
using LernDeutsch_Backend.Repositories.Implementation;
using LernDeutsch_Backend.Services;
using LernDeutsch_Backend.Services.Implementation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using LernDeutsch_Backend.Services.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using LernDeutsch_Backend.Repositories.Identity;
using Stripe;
using LernDeutsch_Backend.Services.Stripe;

namespace LernDeutsch_Backend
{
    public static class ProgramExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, ConfigurationManager configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDatabaseContext>(x => x.UseSqlServer(connectionString));
            services.AddIdentity<BaseUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDatabaseContext>().AddDefaultTokenProviders();

            services.AddTransient<IAnswerRepository, AnswerRepository>();
            services.AddTransient<IQuizRepository, QuizRepository>();
            services.AddTransient<IQuestionRepository, QuestionRepository>();
            services.AddTransient<ICourseRepository, CourseRepository>();
            services.AddTransient<ICourseStudentRepository, CourseStudentRepository>();
            services.AddTransient<ILessonRepository, LessonRepository>();
            services.AddTransient<ITransactionRepository, TransactionRepository>();
            services.AddScoped<IUserRepository, UserRepositoryImplementation>();
            return services;
        }

        public static IServiceCollection AddStripeInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            StripeConfiguration.ApiKey = configuration.GetValue<string>("StripeSettings:SecretKey");

            return services
                .AddScoped<CustomerService>()
                .AddScoped<ChargeService>()
                .AddScoped<TokenService>()
                .AddScoped<IStripeService, StripeService>();
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
            services.AddScoped<IUserService, UserServiceImplementation>();
            return services;
        }

        public static IServiceCollection AddJwt(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = configuration["JWT:Audience"],
                    ValidIssuer = configuration["JWT:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
                };
            });

            return services;
        }

        public static IServiceCollection AddSwaggerSecurity(this IServiceCollection services)
        {
            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo { Title = "LernDeutscheApi", Version = "v1" });
                opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "bearer"
                });
                opt.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });
            });

            return services;
        }

        public static IServiceCollection ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options => options.AddPolicy(name: "FrontendOrigins", policy =>
                {
                    policy.WithOrigins("http://localhost:3000").AllowAnyMethod().AllowAnyHeader();
                }));

            return services;
        }
    }
}
