﻿using PipeLine.Context;

namespace PipeLine.Extensions
{
    public static class WebApplicationExtension
    {
        public static void ConfigureWebApp(this WebApplication app)
        {
            app.ConfigureWebAppCors();
            app.ConfigureInMemoryTestData();
        }

        private static void ConfigureWebAppCors(this WebApplication app)
        {
            app.UseCors();
        }

        public static void ConfigureInMemoryTestData(this WebApplication app)
        {
            using (var scope = app.Services.CreateAsyncScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<PipeLineInMemoryContext>();

                dbContext.Database.EnsureCreated();
            }
        }
    }
}