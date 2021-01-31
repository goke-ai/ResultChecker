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
            /*
            if (context.Countries.Any() == false)
            {
                // Country
                var testCountries = new Bogus.Faker<Country>()
                    .RuleFor(c => c.Name, f => f.Address.Country())
                    .RuleFor(c => c.Code, f => f.Address.CountryCode())
                    .FinishWith((f, c) => Console.WriteLine($"Country post created. Name={c.Name}"));

                var countries = testCountries.Generate(3);
                countries.ForEach(o => o.AddTracker("SeedAdmin"));
                context.Countries.AddRange(countries);

                // Session
                var testSessions = new Bogus.Faker<Session>()
                    .RuleFor(c => c.Name, f => "2001/2002")
                    .FinishWith((f, c) => Console.WriteLine($"Session post created. Name={c.Name}"));

                var sessions = testSessions.Generate(1);
                sessions.ForEach(o => o.AddTracker("SeedAdmin"));
                context.Sessions.AddRange(sessions);

                // Semester
                var index = 0;
                var testSemesters = new Bogus.Faker<Semester>()
                    .RuleFor(c => c.Name, f => (++index).ToString())
                    .FinishWith((f, c) => Console.WriteLine($"Semester post created. Name={c.Name}"));

                var semesters = testSemesters.Generate(2);
                semesters.ForEach(o => o.AddTracker("SeedAdmin"));
                context.Semesters.AddRange(semesters);

                // Batch
                index = 0;
                var testBatches = new Bogus.Faker<Batch>()
                    .RuleFor(p => p.Session, f => sessions[0])
                    .RuleFor(p => p.Semester, f => semesters[index++])
                    .RuleFor(p => p.Name, (f, p) => $"{p.Session.Name}/{p.Semester.Name}")
                    .FinishWith((f, p) => Console.WriteLine($"Batch post created. Name={p.Name}"));

                var batches = testBatches.Generate(2);
                batches.ForEach(o => o.AddTracker("SeedAdmin"));
                context.Batches.AddRange(batches);

                // Department
                var departments = new List<Department>
                {
                    new Department{Name="MY SCHOOL", },
                };
                departments.ForEach(o => o.AddTracker("SeedAdmin"));
                context.Departments.AddRange(departments);

                // Level
                var levels = new List<Level>
                {
                    new Level{Name="1", },
                    new Level{Name="2", },
                };
                levels.ForEach(o => o.AddTracker("SeedAdmin"));
                context.Levels.AddRange(levels);

                // GradeSystem
                var gradeSystems = new List<GradeSystem>
                {
                    new GradeSystem{Name="Default", },
                };
                gradeSystems.ForEach(o => o.AddTracker("SeedAdmin"));
                context.GradeSystems.AddRange(gradeSystems);

                // Grade
                var grades = new List<Grade>
                {
                    new Grade{Name="A", Point=5, BeginMark=70, NextBeginMark=101, GradeSystem=gradeSystems[0] },
                    new Grade{Name="B", Point=4, BeginMark=60, NextBeginMark=70, GradeSystem=gradeSystems[0] },
                    new Grade{Name="C", Point=3, BeginMark=50, NextBeginMark=60, GradeSystem=gradeSystems[0] },
                    new Grade{Name="D", Point=2, BeginMark=45, NextBeginMark=50, GradeSystem=gradeSystems[0] },
                    new Grade{Name="E", Point=1, BeginMark=40, NextBeginMark=45, GradeSystem=gradeSystems[0] },
                    new Grade{Name="F", Point=0, BeginMark=0, NextBeginMark=40, GradeSystem=gradeSystems[0] },
                };
                grades.ForEach(o => o.AddTracker("SeedAdmin"));
                context.Grades.AddRange(grades);

                // Clasx
                index = 0;
                var clasxes = new List<Clasx>
                {
                    new Clasx{Name="CLASS 1A", Department=departments[0], Level=levels[0]},
                    new Clasx{Name="CLASS 2A", Department=departments[0], Level=levels[1]},
                };
                clasxes.ForEach(o => o.AddTracker("SeedAdmin"));
                context.Clasxes.AddRange(clasxes);

                // Subject
                var subjects = new List<Subject>
                {
                    new Subject{Name="Introduction to English", Code="ENG101", Unit=3},
                    new Subject{Name="Introduction to mATHEMATICS", Code="MATH101", Unit=2},
                };
                subjects.ForEach(o => o.AddTracker("SeedAdmin"));
                context.Subjects.AddRange(subjects);

                //// Student
                //index = 0;
                //var testStudents = new Bogus.Faker<Student>()
                //     .RuleFor(p => p.UniqueId, f => f.Random.Guid().ToString())
                //     .RuleFor(p => p.Gender, f => f.PickRandom<Gender>())
                //     .RuleFor(p => p.FirstName, (f, p) => f.Name.FirstName())
                //     .RuleFor(p => p.LastName, (f, p) => f.Name.LastName())
                //     .RuleFor(p => p.Email, (f, p) => f.Internet.Email(p.FirstName, p.LastName))
                //     .RuleFor(p => p.Phone, f => f.Phone.PhoneNumberFormat())
                //     .RuleFor(p => p.Country, f => f.PickRandom(countries))
                //     .RuleFor(p => p.Address, f => f.Address.StreetAddress())
                //     .RuleFor(p => p.BirthDate, f => f.Person.DateOfBirth)

                //     .RuleFor(p => p.Batch, f => f.PickRandom(batches))

                //     .RuleFor(p => p.MatricNumber, f => $"ST01{++index:d3}")
                //     .RuleFor(p => p.EnrolledDate, f => f.Date.Recent())
                //     .RuleFor(p => p.GradeSystem, f => gradeSystems[0])

                //     .FinishWith((f, p) => Console.WriteLine($"Student post created. Id={p.MatricNumber}"));

                //var students = testStudents.Generate(3);
                //students.ForEach(o => o.AddTracker("SeedAdmin"));
                //context.Students.AddRange(students);

                //// ClasxSubject
                //var clasxSubjects = new List<ClasxSubject>
                //{
                //    new ClasxSubject{Batch=batches[0], Clasx = clasxes[0], Subject=subjects[0] },
                //    new ClasxSubject{Batch=batches[0], Clasx = clasxes[0], Subject=subjects[1] },
                //};
                //clasxSubjects.ForEach(o => o.AddTracker("SeedAdmin"));
                //context.ClasxSubjects.AddRange(clasxSubjects);

                //// ClasxStudent
                //var clasxStudents = new List<ClasxStudent>
                //{
                //    new ClasxStudent{Batch=batches[0], Clasx = clasxes[0], Student=students[0] },
                //    new ClasxStudent{Batch=batches[0], Clasx = clasxes[0], Student=students[1] },
                //};
                //clasxStudents.ForEach(o => o.AddTracker("SeedAdmin"));
                //context.ClasxStudents.AddRange(clasxStudents);

                //// Staff
                //index = 0;
                //var testStaffs = new Bogus.Faker<Staff>()
                //     .RuleFor(p => p.UniqueId, f => f.Random.Guid().ToString())
                //     .RuleFor(p => p.Gender, f => f.PickRandom<Gender>())
                //     .RuleFor(p => p.FirstName, (f, p) => f.Name.FirstName())
                //     .RuleFor(p => p.LastName, (f, p) => f.Name.LastName())
                //     .RuleFor(p => p.Email, (f, p) => f.Internet.Email(p.FirstName, p.LastName))
                //     .RuleFor(p => p.Phone, f => f.Phone.PhoneNumberFormat())
                //     .RuleFor(p => p.Country, f => f.PickRandom(countries))
                //     .RuleFor(p => p.Address, f => f.Address.StreetAddress())
                //     .RuleFor(p => p.BirthDate, f => f.Person.DateOfBirth)

                //     .RuleFor(p => p.HiredDate, f => f.Date.Past())
                //     .RuleFor(p => p.StaffNumber, f => $"TT{++index:d3}")

                //     .FinishWith((f, p) => Console.WriteLine($"Staff post created. Id={p.StaffNumber}"));

                //var staffs = testStaffs.Generate(2);
                //staffs.ForEach(o => o.AddTracker("SeedAdmin"));
                //context.Staffs.AddRange(staffs);

                //// Learn
                //var learns = new List<Learn>
                //{
                //    new Learn{Name="Learn: Introduction to English", DisplayName="ENG101", DurationInMinutes=10},
                //    new Learn{Name="Learn: Introduction to Mathematics", DisplayName="MATH101", DurationInMinutes=10},
                //};
                //learns.ForEach(o => o.AddTracker("SeedAdmin"));
                //context.Learns.AddRange(learns);

                //// Test
                //var tests = new List<Test>
                //{
                //    new Test{Name="Test 1: Introduction to English", DisplayName="T1: ENG101", DurationInMinutes=10},
                //    new Test{Name="Test 1: Introduction to Mathematics", DisplayName="MATH101", DurationInMinutes=30},
                //};
                //tests.ForEach(o => o.AddTracker("SeedAdmin"));
                //context.Tests.AddRange(tests);

                //// SubjectCurriculum
                //var subjectCurricula = new List<SubjectCurriculum>
                //{
                //    new SubjectCurriculum{Batch=batches[0], Subject=subjects[0], Learn=learns[0], CurriculumType=CurriculumType.Learn, Order=1 },
                //    new SubjectCurriculum{Batch=batches[0], Subject=subjects[0], Test=tests[0], CurriculumType=CurriculumType.Test, Order=2 },
                //};
                //subjectCurricula.ForEach(o => o.AddTracker("SeedAdmin"));
                //context.SubjectCurricula.AddRange(subjectCurricula);

                // AppSettings
                var appSettings = new List<AppSetting>
                {
                    new AppSetting{Key="AppName", Value="iSKool" },
                    new AppSetting{Key="CurrentBatch", Value="1"},
                };
                appSettings.ForEach(o => o.AddTracker("SeedAdmin"));
                context.AppSettings.AddRange(appSettings);

                // Save to DB
                context.SaveChanges();
            }
            */

        }


    }
}
