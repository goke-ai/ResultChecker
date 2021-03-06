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
    public partial class GradeService : BaseService
    {
    
        public GradeService(AppDbContext context)
        : base(context)
        {
           
        }
    
        // +EntityQuery
        public static IQueryable<Grade> EntityQuery(AppDbContext context, string[] includeNavigations, params Expression<Func<Grade, bool>>[] filters)
        {
            var query = context.Grades.AsQueryable();
    
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
    
        protected IQueryable<GradeDto> GradeQuery(String[] includeNavigations, params Expression<Func<Grade, bool>>[] filters)
        {
            var query = EntityQuery(_context, includeNavigations, filters);
    
            return query.Select(GradeDto.AsGradeDto);
        }        
    
        public async Task<List<GradeDto>> GetGradesAsync(String[] includeNavigations, params Expression<Func<Grade, bool>>[] filters)
        {
            IQueryable<GradeDto> query = GradeQuery(includeNavigations, filters);
    
            return await query
                        // Use AsNoTracking to disable EF change tracking
                        // Use ToListAsync to avoid blocking a thread
                        .AsNoTracking().ToListAsync();
        }
    
        public async Task<GradeDto> GetGradeAsync(String[] includeNavigations, params Expression<Func<Grade, bool>>[] filters)
        {
            // Get Grade  
            IQueryable<GradeDto> query = GradeQuery(includeNavigations, filters);
    
            return await query
                    // Use AsNoTracking to disable EF change tracking
                    // Use ToListAsync to avoid blocking a thread
                    .AsNoTracking().FirstOrDefaultAsync();
        }
    
        public async Task<GradeDto> GetGradeAsync(int id, String[] includeNavigations, params Expression<Func<Grade, bool>>[] filters)
        {
            // Get Grade  
            IQueryable<GradeDto> query = GradeQuery(includeNavigations, filters);
    
            return await query
                    // Use AsNoTracking to disable EF change tracking
                    // Use ToListAsync to avoid blocking a thread
                    .AsNoTracking().SingleOrDefaultAsync(m => m.Id == id);
        }
        // -EntityQuery
    
        // +DtoQuery
        public static IQueryable<GradeDto> DtoQuery(AppDbContext context, string[] includeNavigations, params Expression<Func<GradeDto, bool>>[] filters)
        {
            var query = context.Grades.AsQueryable();
    
            if (includeNavigations != null && includeNavigations.Count() > 0)
            {
                // include navigation entity
                foreach (var navigation in includeNavigations)
                {
                    query = query.Include(navigation);
                }
            }
    
            var query2 = query.Select(GradeDto.AsGradeDto);
    
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
    
        protected IQueryable<GradeDto> GradeDtoQuery(String[] includeNavigations, params Expression<Func<GradeDto, bool>>[] filters)
        {
            var query = DtoQuery(_context, includeNavigations, filters);
    
            return query;
        }        
    
        public async Task<List<GradeDto>> GetGradeDtoesAsync(String[] includeNavigations, params Expression<Func<GradeDto, bool>>[] filters)
        {
    
            IQueryable<GradeDto> query = GradeDtoQuery(includeNavigations, filters);
    
            return await query
                        // Use AsNoTracking to disable EF change tracking
                        // Use ToListAsync to avoid blocking a thread
                        .AsNoTracking().ToListAsync();
        }
    
        public async Task<GradeDto> GetGradeDtoAsync(String[] includeNavigations, params Expression<Func<GradeDto, bool>>[] filters)
        {
            // Get Grade  
            IQueryable<GradeDto> query = GradeDtoQuery(includeNavigations, filters);
    
            return await query
                    // Use AsNoTracking to disable EF change tracking
                    // Use ToListAsync to avoid blocking a thread
                    .AsNoTracking().FirstOrDefaultAsync();
        }
    
        public async Task<GradeDto> GetGradeDtoAsync(int id, String[] includeNavigations, params Expression<Func<GradeDto, bool>>[] filters)
        {
            // Get Grade  
            IQueryable<GradeDto> query = GradeDtoQuery(includeNavigations, filters);
    
            return await query
                    // Use AsNoTracking to disable EF change tracking
                    // Use ToListAsync to avoid blocking a thread
                    .AsNoTracking().SingleOrDefaultAsync(m => m.Id == id);
        }
        // -DtoQuery
    
        public async Task<GradeDto> CreateGradeAsync(GradeDto gradeDto, string username)
        {
    
            if (_context.Grades.Any(a => a.Name == gradeDto.Name) == true)
            {
                throw new Exception("Record exist and caused a conflict!");
            }
    
            OnCreate(gradeDto, username);
    
            var entity = GradeDto.AsGradeFunc(gradeDto);
            
            ToEntity(ref entity, gradeDto);
            //entity.InsertUser = entity.LastActivityUser = username;
            //entity.InsertDateTime = entity.LastActivityDateTime = DateTime.UtcNow;
            entity.AddTracker(username);
    
            _context.Grades.Add(entity);
    
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
    
            // gradeDto = GradeDto.AsGradeDtoFunc(entity);
            gradeDto = await GetGradeDtoAsync(entity.Id, GradeDto.IncludeNavigations());
        
            return gradeDto;
        }
        partial void OnCreate(GradeDto gradeDto, string username);
        partial void OnBeforeCreate(Grade entity, string username);
        partial void OnAfterCreate(Grade entity, string username);
    
        public async Task<bool> UpdateGradeAsync(GradeDto gradeDto, string username/*, String[] includeNavigations, params Expression<Func<Grade, bool>>[] filters*/)
        {
            OnUpdate(gradeDto, username);
            
            // Get Grade  
            var entity = EntityQuery(_context, GradeDto.IncludeNavigations())
                                    .FirstOrDefault(x => x.Id == gradeDto.Id);
    
            if (entity != null)
            {
                entity = GradeDto.ToGradeFunc(entity, gradeDto);
    
                ToEntity(ref entity, gradeDto);
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
        partial void OnUpdate(GradeDto gradeDto, string username);
        partial void OnBeforeUpdate(Grade entity, string username);
        partial void OnAfterUpdate(Grade entity, string username);
    
        public async Task<bool> DeleteGradeAsync(GradeDto gradeDto)
        {
            OnDelete(gradeDto);
    
            var entity = _context.Grades
                                .Where(x => x.Id == gradeDto.Id)
                                .FirstOrDefault();
    
            if (entity != null)
            {
                _context.Grades.Remove(entity);
    
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
                            errorMessage = $"Must delete {table} records before deleting Grade";
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
        partial void OnDelete(GradeDto gradeDto);
        partial void OnBeforeDelete(Grade entity);
        partial void OnAfterDelete(Grade entity);
    
        public async Task<List<GradeCache>> GetGradeCachesAsync()
        {
            var list = await _context.Grades.Select(GradeCache.AsGradeCache)
                        
                        // Use AsNoTracking to disable EF change tracking
                        // Use ToListAsync to avoid blocking a thread
                        .AsNoTracking().ToListAsync();
            return list.OrderBy(o => o.Name).ToList();
        }
    
        partial void ToEntity(ref Grade entity, GradeDto gradeDto);    
    }
}
