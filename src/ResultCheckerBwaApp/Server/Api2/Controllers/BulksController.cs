//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Ark.ResultCheckers.Data;
using Ark.ResultCheckers.Data.Services;
using Ark.ResultCheckers.Entities;
using Ark.ResultCheckers.Dtos;
using Ark.ResultCheckers.Dtos.Caches;

namespace Ark.ResultCheckers.Api2.Controllers
{
    [Route("api2/[controller]")]
    [ApiController]
    // [Produces("application/json")]
    // [Route("api/Bulks")]    
    // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize]
    public partial class BulksController : ApiController
    {
        //BulkService bulkService;

        public BulksController(AppDbContext context, IWebHostEnvironment env, IMemoryCache memoryCache)
            : base(context, env, memoryCache)
        {
            //this.bulkService = bulkService;
        }


        // POST: api/Bulks
        [HttpPost("StudentCourses")]
        public async Task<ActionResult<BulkStudentCourseDto>> PostBulkStudentCourses(List<BulkStudentCourseDto> bulkStudentCourseDtos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BulkStudentCourseDto bulkDto = new BulkStudentCourseDto();

            try
            {
                // get valid 

                foreach (var b in bulkStudentCourseDtos)
                {
                    var studentCourse = await _context.StudentCourses
                        // .Select(BulkStudentCourseDto.AsBulkStudentCourseDto)
                        .FirstOrDefaultAsync(
                        x => x.Session.Name == b.Session
                        && x.Semester.Name == b.Semester
                        && x.Course.Code == b.Code
                        && x.Student.MatricNo == b.MatricNo
                        );

                    if (studentCourse != null)
                    {
                        continue;
                    }

                    studentCourse = new StudentCourse { Score = b.Score };

                    // get session
                    var session = await _context.Sessions.FirstOrDefaultAsync(f => f.Name == b.Session);
                    if (session != null)
                    {
                        studentCourse.SessionId = session.Id;
                    }
                    else
                    {
                        var entity = new Session { Name = b.Session };
                        entity.AddTracker(User.Identity.Name);
                        await _context.Sessions.AddAsync(entity);

                        studentCourse.Session = entity;
                    }

                    // get semester
                    var semester = await _context.Semesters.FirstOrDefaultAsync(f => f.Name == b.Semester);
                    if (semester != null)
                    {
                        studentCourse.SemesterId = semester.Id;
                    }
                    else
                    {
                        var entity = new Semester { Name = b.Semester };
                        entity.AddTracker(User.Identity.Name);
                        await _context.Semesters.AddAsync(entity);

                        studentCourse.Semester = entity;
                    }

                    // get course
                    var course = await _context.Courses.FirstOrDefaultAsync(f => f.Code == b.Code);
                    if (course != null)
                    {
                        studentCourse.CourseId = course.Id;
                    }
                    else
                    {
                        var entity = new Course
                        {
                            Code = b.Code,
                            Title = b.Code,
                        };
                        entity.AddTracker(User.Identity.Name);
                        await _context.Courses.AddAsync(entity);

                        studentCourse.Course = entity;
                    }

                    // get student
                    var student = await _context.Students.FirstOrDefaultAsync(f => f.MatricNo == b.MatricNo);
                    if (student != null)
                    {
                        studentCourse.StudentId = student.Id;
                    }
                    else
                    {
                        var entity = new Student
                        {
                            MatricNo = b.MatricNo,
                            Lastname = b.MatricNo,
                            Firstname = b.MatricNo,
                        };
                        entity.AddTracker(User.Identity.Name);
                        await _context.Students.AddAsync(entity);

                        studentCourse.Student = entity;
                    }

                    studentCourse.AddTracker(User.Identity.Name);

                    await _context.StudentCourses.AddAsync(studentCourse);

                    int rows = await _context.SaveChangesAsync();

                    bulkDto.Id = studentCourse.Id;

                }

                //if (bulkDto != null)
                //{
                //    this.RemoveCache(CacheKeys.Bulk);
                //}
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return CreatedAtAction("GetStudentCourses", "StudentCourses", new { id = bulkDto.Id }, bulkDto);
        }

    }
}
