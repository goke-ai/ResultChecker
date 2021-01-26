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
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Ark.ResultCheckers.Data;
using Ark.ResultCheckers.Entities;
using Ark.ResultCheckers.Dtos;
using Ark.ResultCheckers.Dtos.Caches;

namespace Ark.ResultCheckers.Data.Services
{
    public partial class StudentCourseService : BaseService
    {
    
        public StudentCourseService(AppDbContext context)
        : base(context)
        {
           
        }
    
        // +EntityQuery
        public static IQueryable<StudentCourse> EntityQuery(AppDbContext context, string[] includeNavigations, params Expression<Func<StudentCourse, bool>>[] filters)
        {
            var query = context.StudentCourses.AsQueryable();
    
            if (includeNavigations != null && includeNavigations.Count() > 0)
            {
                // include navigation entity
                foreach (var navigation in includeNavigations)
                {
                    query = query.Include(navigation);
                }
            }
    
            if (filters != null && filters.Count() > 0)
            {
                // filter entity
                foreach (var filter in filters)
                {
                    query = query.Where(filter);
                }
            }
    
            return query;
        }
    
        protected IQueryable<StudentCourseDto> StudentCourseQuery(String[] includeNavigations, params Expression<Func<StudentCourse, bool>>[] filters)
        {
            var query = EntityQuery(_context, includeNavigations, filters);
    
            return query.Select(StudentCourseDto.AsStudentCourseDto);
        }        
    
        public async Task<List<StudentCourseDto>> GetStudentCoursesAsync(String[] includeNavigations, params Expression<Func<StudentCourse, bool>>[] filters)
        {
            IQueryable<StudentCourseDto> query = StudentCourseQuery(includeNavigations, filters);
    
            return await query
                        // Use AsNoTracking to disable EF change tracking
                        // Use ToListAsync to avoid blocking a thread
                        .AsNoTracking().ToListAsync();
        }
    
        public async Task<StudentCourseDto> GetStudentCourseAsync(String[] includeNavigations, params Expression<Func<StudentCourse, bool>>[] filters)
        {
            // Get StudentCourse  
            IQueryable<StudentCourseDto> query = StudentCourseQuery(includeNavigations, filters);
    
            return await query
                    // Use AsNoTracking to disable EF change tracking
                    // Use ToListAsync to avoid blocking a thread
                    .AsNoTracking().FirstOrDefaultAsync();
        }
    
        public async Task<StudentCourseDto> GetStudentCourseAsync(int id, String[] includeNavigations, params Expression<Func<StudentCourse, bool>>[] filters)
        {
            // Get StudentCourse  
            IQueryable<StudentCourseDto> query = StudentCourseQuery(includeNavigations, filters);
    
            return await query
                    // Use AsNoTracking to disable EF change tracking
                    // Use ToListAsync to avoid blocking a thread
                    .AsNoTracking().SingleOrDefaultAsync(m => m.Id == id);
        }
        // -EntityQuery
    
        // +DtoQuery
        public static IQueryable<StudentCourseDto> DtoQuery(AppDbContext context, string[] includeNavigations, params Expression<Func<StudentCourseDto, bool>>[] filters)
        {
            var query = context.StudentCourses.AsQueryable();
    
            if (includeNavigations != null && includeNavigations.Count() > 0)
            {
                // include navigation entity
                foreach (var navigation in includeNavigations)
                {
                    query = query.Include(navigation);
                }
            }
    
            var query2 = query.Select(StudentCourseDto.AsStudentCourseDto);
    
            if (filters != null && filters.Count() > 0)
            {
                // filter entity
                foreach (var filter in filters)
                {
                    query2 = query2.Where(filter);
                }
            }
    
            return query2;
        }
    
        protected IQueryable<StudentCourseDto> StudentCourseDtoQuery(String[] includeNavigations, params Expression<Func<StudentCourseDto, bool>>[] filters)
        {
            var query = DtoQuery(_context, includeNavigations, filters);
    
            return query;
        }        
    
        public async Task<List<StudentCourseDto>> GetStudentCourseDtoesAsync(String[] includeNavigations, params Expression<Func<StudentCourseDto, bool>>[] filters)
        {
    
            IQueryable<StudentCourseDto> query = StudentCourseDtoQuery(includeNavigations, filters);
    
            return await query
                        // Use AsNoTracking to disable EF change tracking
                        // Use ToListAsync to avoid blocking a thread
                        .AsNoTracking().ToListAsync();
        }
    
        public async Task<StudentCourseDto> GetStudentCourseDtoAsync(String[] includeNavigations, params Expression<Func<StudentCourseDto, bool>>[] filters)
        {
            // Get StudentCourse  
            IQueryable<StudentCourseDto> query = StudentCourseDtoQuery(includeNavigations, filters);
    
            return await query
                    // Use AsNoTracking to disable EF change tracking
                    // Use ToListAsync to avoid blocking a thread
                    .AsNoTracking().FirstOrDefaultAsync();
        }
    
        public async Task<StudentCourseDto> GetStudentCourseDtoAsync(int id, String[] includeNavigations, params Expression<Func<StudentCourseDto, bool>>[] filters)
        {
            // Get StudentCourse  
            IQueryable<StudentCourseDto> query = StudentCourseDtoQuery(includeNavigations, filters);
    
            return await query
                    // Use AsNoTracking to disable EF change tracking
                    // Use ToListAsync to avoid blocking a thread
                    .AsNoTracking().SingleOrDefaultAsync(m => m.Id == id);
        }
        // -DtoQuery
    
        public async Task<StudentCourseDto> CreateStudentCourseAsync(StudentCourseDto studentCourseDto, string username)
        {
    
    
            OnCreate(studentCourseDto, username);
    
            var entity = StudentCourseDto.AsStudentCourseFunc(studentCourseDto);
            
            ToEntity(ref entity, studentCourseDto);
            //entity.InsertUser = entity.LastActivityUser = username;
            //entity.InsertDateTime = entity.LastActivityDateTime = DateTime.UtcNow;
            entity.AddTracker(username);
    
            _context.StudentCourses.Add(entity);
    
            OnBeforeCreate(entity, username);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                // _context.Entry(entity).State = EntityState.Detached;
                throw new Exception("Add error", ex);
            }
            finally
            {
                // _context.Entry(entity).State = EntityState.Detached;
            }
            OnAfterCreate(entity, username);
    
            // studentCourseDto = StudentCourseDto.AsStudentCourseDtoFunc(entity);
            studentCourseDto = await GetStudentCourseDtoAsync(entity.Id, StudentCourseDto.IncludeNavigations());
        
            return studentCourseDto;
        }
        partial void OnCreate(StudentCourseDto studentCourseDto, string username);
        partial void OnBeforeCreate(StudentCourse entity, string username);
        partial void OnAfterCreate(StudentCourse entity, string username);
    
        public async Task<bool> UpdateStudentCourseAsync(StudentCourseDto studentCourseDto, string username/*, String[] includeNavigations, params Expression<Func<StudentCourse, bool>>[] filters*/)
        {
            OnUpdate(studentCourseDto, username);
            
            // Get StudentCourse  
            var entity = EntityQuery(_context, StudentCourseDto.IncludeNavigations())
                                    .FirstOrDefault(x => x.Id == studentCourseDto.Id);
    
            if (entity != null)
            {
                entity = StudentCourseDto.ToStudentCourseFunc(entity, studentCourseDto);
    
                ToEntity(ref entity, studentCourseDto);
                //entity.UpdateUser = entity.LastActivityUser = username;
                //entity.UpdateDateTime = entity.LastActivityDateTime = DateTime.UtcNow;
                entity.EditTracker(username);
    
                OnBeforeUpdate(entity, username);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch(Exception ex)
                {
                    // _context.Entry(entity).State = EntityState.Detached;
                    throw new Exception("Update error", ex);
                }
                finally
                {
                    // _context.Entry(entity).State = EntityState.Detached;
                }
                OnAfterUpdate(entity, username);        
            }
            else
            {
                return false;
            }
    
            return true;
        }
        partial void OnUpdate(StudentCourseDto studentCourseDto, string username);
        partial void OnBeforeUpdate(StudentCourse entity, string username);
        partial void OnAfterUpdate(StudentCourse entity, string username);
    
        public async Task<bool> DeleteStudentCourseAsync(StudentCourseDto studentCourseDto)
        {
            OnDelete(studentCourseDto);
    
            var entity = _context.StudentCourses
                                .Where(x => x.Id == studentCourseDto.Id)
                                .FirstOrDefault();
    
            if (entity != null)
            {
                _context.StudentCourses.Remove(entity);
    
                OnBeforeDelete(entity);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException ex)
                {
                    // _context.Entry(entity).State = EntityState.Detached;
    
                    var sqlException = ex.GetBaseException() as SqlException;
    
                    if (sqlException != null)
                    {
                        var errorMessage = "deleting error";
    
                        var number = sqlException.Number;
        
                        if (number == 547)
                        {
                            string table = GetErrorTable(sqlException) ?? "descendant";
                            errorMessage = $"Must delete {table} records before deleting Student Course";
                        }
    
                        throw new Exception(errorMessage, ex);
                    }
                }
                finally
                {
                    // _context.Entry(entity).State = EntityState.Detached;
                }
                OnAfterDelete(entity);    
            }
            else
            {
                return false;
            }
    
            return true;
        }
        partial void OnDelete(StudentCourseDto studentCourseDto);
        partial void OnBeforeDelete(StudentCourse entity);
        partial void OnAfterDelete(StudentCourse entity);
    
        public async Task<List<StudentCourseCache>> GetStudentCourseCachesAsync()
        {
            var list = await _context.StudentCourses.Select(StudentCourseCache.AsStudentCourseCache)
                        
                        // Use AsNoTracking to disable EF change tracking
                        // Use ToListAsync to avoid blocking a thread
                        .AsNoTracking().ToListAsync();
            return list.OrderBy(o => o.Name).ToList();
        }
    
        partial void ToEntity(ref StudentCourse entity, StudentCourseDto studentCourseDto);    
    }
}
