using Ark.ResultCheckers.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ark.ResultCheckers.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider, IConfiguration config)
        {
            var logger = serviceProvider.GetRequiredService<ILogger<SeedData>>();
            using (var context = new AppDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()
                ))
            {
                context.Database.Migrate();

                logger.LogInformation("App DB Generated");

                SeedDB(context);

                logger.LogInformation("App DB Seeded");
            }

        }

        private static void SeedDB(AppDbContext context)
        {
            
            if (context.Sessions.Any() == false)
            {
                

                // Session
                var sessions = new List<Session> { new Session { Name = "0000/0000" }, };
                sessions.ForEach(o => o.AddTracker("SeedAdmin"));
                context.Sessions.AddRange(sessions);

                // Semester
                var semesters = new List<Semester>{ new Semester { Name = "0" }, };
                semesters.ForEach(o => o.AddTracker("SeedAdmin"));
                context.Semesters.AddRange(semesters);

                
                // Grade
                var grades = new List<Grade>
                {
                    new Grade{Name="A", Point=5, BeginMark=70, NextBeginMark=101 },
                    new Grade{Name="B", Point=4, BeginMark=60, NextBeginMark=70 },
                    new Grade{Name="C", Point=3, BeginMark=50, NextBeginMark=60 },
                    new Grade{Name="D", Point=2, BeginMark=45, NextBeginMark=50 },
                    new Grade{Name="E", Point=1, BeginMark=40, NextBeginMark=45 },
                    new Grade{Name="F", Point=0, BeginMark=0, NextBeginMark=40 },
                };
                grades.ForEach(o => o.AddTracker("SeedAdmin"));
                context.Grades.AddRange(grades);

               

                // AppSettings
                var appSettings = new List<AppSetting>
                {
                    new AppSetting{Key="AppName", Value="ResultChecker" },
                    new AppSetting{Key="CurrentBatch", Value="1"},
                };
                appSettings.ForEach(o => o.AddTracker("SeedAdmin"));
                context.AppSettings.AddRange(appSettings);

                // Save to DB
                context.SaveChanges();
            }
            

        }


    }
}
