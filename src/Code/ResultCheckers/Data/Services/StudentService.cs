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
    public partial class StudentService : BaseService
    {
    
        public StudentService(AppDbContext context)
        : base(context)
        {
           
        }
    
        // +EntityQuery
        public static IQueryable<Student> EntityQuery(AppDbContext context, string[] includeNavigations, params Expression<Func<Student, bool>>[] filters)
        {
            var query = context.Students.AsQueryable();
    
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
    
        protected IQueryable<StudentDto> StudentQuery(String[] includeNavigations, params Expression<Func<Student, bool>>[] filters)
        {
            var query = EntityQuery(_context, includeNavigations, filters);
    
            return query.Select(StudentDto.AsStudentDto);
        }        
    
        public async Task<List<StudentDto>> GetStudentsAsync(String[] includeNavigations, params Expression<Func<Student, bool>>[] filters)
        {
            IQueryable<StudentDto> query = StudentQuery(includeNavigations, filters);
    
            return await query
                        // Use AsNoTracking to disable EF change tracking
                        // Use ToListAsync to avoid blocking a thread
                        .AsNoTracking().ToListAsync();
        }
    
        public async Task<StudentDto> GetStudentAsync(String[] includeNavigations, params Expression<Func<Student, bool>>[] filters)
        {
            // Get Student  
            IQueryable<StudentDto> query = StudentQuery(includeNavigations, filters);
    
            return await query
                    // Use AsNoTracking to disable EF change tracking
                    // Use ToListAsync to avoid blocking a thread
                    .AsNoTracking().FirstOrDefaultAsync();
        }
    
        public async Task<StudentDto> GetStudentAsync(int id, String[] includeNavigations, params Expression<Func<Student, bool>>[] filters)
        {
            // Get Student  
            IQueryable<StudentDto> query = StudentQuery(includeNavigations, filters);
    
            return await query
                    // Use AsNoTracking to disable EF change tracking
                    // Use ToListAsync to avoid blocking a thread
                    .AsNoTracking().SingleOrDefaultAsync(m => m.Id == id);
        }
        // -EntityQuery
    
        // +DtoQuery
        public static IQueryable<StudentDto> DtoQuery(AppDbContext context, string[] includeNavigations, params Expression<Func<StudentDto, bool>>[] filters)
        {
            var query = context.Students.AsQueryable();
    
            if (includeNavigations != null && includeNavigations.Count() > 0)
            {
                // include navigation entity
                foreach (var navigation in includeNavigations)
                {
                    query = query.Include(navigation);
                }
            }
    
            var query2 = query.Select(StudentDto.AsStudentDto);
    
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
    
        protected IQueryable<StudentDto> StudentDtoQuery(String[] includeNavigations, params Expression<Func<StudentDto, bool>>[] filters)
        {
            var query = DtoQuery(_context, includeNavigations, filters);
    
            return query;
        }        
    
        public async Task<List<StudentDto>> GetStudentDtoesAsync(String[] includeNavigations, params Expression<Func<StudentDto, bool>>[] filters)
        {
    
            IQueryable<StudentDto> query = StudentDtoQuery(includeNavigations, filters);
    
            return await query
                        // Use AsNoTracking to disable EF change tracking
                        // Use ToListAsync to avoid blocking a thread
                        .AsNoTracking().ToListAsync();
        }
    
        public async Task<StudentDto> GetStudentDtoAsync(String[] includeNavigations, params Expression<Func<StudentDto, bool>>[] filters)
        {
            // Get Student  
            IQueryable<StudentDto> query = StudentDtoQuery(includeNavigations, filters);
    
            return await query
                    // Use AsNoTracking to disable EF change tracking
                    // Use ToListAsync to avoid blocking a thread
                    .AsNoTracking().FirstOrDefaultAsync();
        }
    
        public async Task<StudentDto> GetStudentDtoAsync(int id, String[] includeNavigations, params Expression<Func<StudentDto, bool>>[] filters)
        {
            // Get Student  
            IQueryable<StudentDto> query = StudentDtoQuery(includeNavigations, filters);
    
            return await query
                    // Use AsNoTracking to disable EF change tracking
                    // Use ToListAsync to avoid blocking a thread
                    .AsNoTracking().SingleOrDefaultAsync(m => m.Id == id);
        }
        // -DtoQuery
    
        public async Task<StudentDto> CreateStudentAsync(StudentDto studentDto, string username)
        {
    
    
            OnCreate(studentDto, username);
    
            var entity = StudentDto.AsStudentFunc(studentDto);
            
            ToEntity(ref entity, studentDto);
            //entity.InsertUser = entity.LastActivityUser = username;
            //entity.InsertDateTime = entity.LastActivityDateTime = DateTime.UtcNow;
            entity.AddTracker(username);
    
            _context.Students.Add(entity);
    
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
    
            // studentDto = StudentDto.AsStudentDtoFunc(entity);
            studentDto = await GetStudentDtoAsync(entity.Id, StudentDto.IncludeNavigations());
        
            return studentDto;
        }
        partial void OnCreate(StudentDto studentDto, string username);
        partial void OnBeforeCreate(Student entity, string username);
        partial void OnAfterCreate(Student entity, string username);
    
        public async Task<bool> UpdateStudentAsync(StudentDto studentDto, string username/*, String[] includeNavigations, params Expression<Func<Student, bool>>[] filters*/)
        {
            OnUpdate(studentDto, username);
            
            // Get Student  
            var entity = EntityQuery(_context, StudentDto.IncludeNavigations())
                                    .FirstOrDefault(x => x.Id == studentDto.Id);
    
            if (entity != null)
            {
                entity = StudentDto.ToStudentFunc(entity, studentDto);
    
                ToEntity(ref entity, studentDto);
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
        partial void OnUpdate(StudentDto studentDto, string username);
        partial void OnBeforeUpdate(Student entity, string username);
        partial void OnAfterUpdate(Student entity, string username);
    
        public async Task<bool> DeleteStudentAsync(StudentDto studentDto)
        {
            OnDelete(studentDto);
    
            var entity = _context.Students
                                .Where(x => x.Id == studentDto.Id)
                                .FirstOrDefault();
    
            if (entity != null)
            {
                _context.Students.Remove(entity);
    
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
                            errorMessage = $"Must delete {table} records before deleting Student";
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
        partial void OnDelete(StudentDto studentDto);
        partial void OnBeforeDelete(Student entity);
        partial void OnAfterDelete(Student entity);
    
        public async Task<List<StudentCache>> GetStudentCachesAsync()
        {
            var list = await _context.Students.Select(StudentCache.AsStudentCache)
                        
                        // Use AsNoTracking to disable EF change tracking
                        // Use ToListAsync to avoid blocking a thread
                        .AsNoTracking().ToListAsync();
            return list.OrderBy(o => o.Name).ToList();
        }
    
        partial void ToEntity(ref Student entity, StudentDto studentDto);    
    }
}
