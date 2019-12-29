using Assistant.Helpers;
using Assistant.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assistant.Extensions
{
    public static class CourseAssistantServicetExtensions
    {
        public static void AddCourseAssistantService(this IServiceCollection services)
        {
            services.AddScoped<ICourseUserService, CourseUserService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IQuestionAnswerService, QuestionAnswerService>();
            services.AddScoped<UserIdentity>();
            services.AddSingleton<QuestionBroadcast>();
        }
    }
}
