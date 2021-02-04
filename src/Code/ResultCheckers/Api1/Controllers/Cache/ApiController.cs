//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ark.ResultCheckers.Api1.Controllers
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Caching.Memory;
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Ark.ResultCheckers.Dtos.Caches;
    
    public partial class ApiController : ControllerBase
    {
    
        protected static ConcurrentDictionary<string, DateTime> _cacheItems = new ConcurrentDictionary<string, DateTime>();
    
    	#region Cache
    
    	protected void RemoveCache(string key)
        {
    		_cache.Remove(key);
        }
    
    	
    	protected List<AppSettingCache> CacheAppSettings()
        {
            //get
            {
                List<AppSettingCache> list;
    
                if (!_cache.TryGetValue(CacheKeys.AppSetting, out list))
                {
    
                    var query = _context.AppSettings.Where(w => w.IsVisible).Select(AppSettingCache.AsAppSettingCache);
                    OnCacheQuery(ref query);
                    list = query.ToList();
                    // Set cache options.
                    var cacheOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(600));
    
                    _cache.Set(CacheKeys.AppSetting, list, cacheOptions);
                    _cacheItems.TryAdd(CacheKeys.AppSetting, DateTime.UtcNow);
                }
                return list;
            }
        }
    	partial void OnCacheQuery(ref IQueryable<AppSettingCache> query);
    	
    	protected List<CardCache> CacheCards()
        {
            //get
            {
                List<CardCache> list;
    
                if (!_cache.TryGetValue(CacheKeys.Card, out list))
                {
    
                    var query = _context.Cards.Where(w => w.IsVisible).Select(CardCache.AsCardCache);
                    OnCacheQuery(ref query);
                    list = query.ToList();
                    // Set cache options.
                    var cacheOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(600));
    
                    _cache.Set(CacheKeys.Card, list, cacheOptions);
                    _cacheItems.TryAdd(CacheKeys.Card, DateTime.UtcNow);
                }
                return list;
            }
        }
    	partial void OnCacheQuery(ref IQueryable<CardCache> query);
    	
    	protected List<CourseCache> CacheCourses()
        {
            //get
            {
                List<CourseCache> list;
    
                if (!_cache.TryGetValue(CacheKeys.Course, out list))
                {
    
                    var query = _context.Courses.Where(w => w.IsVisible).Select(CourseCache.AsCourseCache);
                    OnCacheQuery(ref query);
                    list = query.ToList();
                    // Set cache options.
                    var cacheOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(600));
    
                    _cache.Set(CacheKeys.Course, list, cacheOptions);
                    _cacheItems.TryAdd(CacheKeys.Course, DateTime.UtcNow);
                }
                return list;
            }
        }
    	partial void OnCacheQuery(ref IQueryable<CourseCache> query);
    	
    	protected List<GradeCache> CacheGrades()
        {
            //get
            {
                List<GradeCache> list;
    
                if (!_cache.TryGetValue(CacheKeys.Grade, out list))
                {
    
                    var query = _context.Grades.Where(w => w.IsVisible).Select(GradeCache.AsGradeCache);
                    OnCacheQuery(ref query);
                    list = query.ToList();
                    // Set cache options.
                    var cacheOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(600));
    
                    _cache.Set(CacheKeys.Grade, list, cacheOptions);
                    _cacheItems.TryAdd(CacheKeys.Grade, DateTime.UtcNow);
                }
                return list;
            }
        }
    	partial void OnCacheQuery(ref IQueryable<GradeCache> query);
    	
    	protected List<SemesterCache> CacheSemesters()
        {
            //get
            {
                List<SemesterCache> list;
    
                if (!_cache.TryGetValue(CacheKeys.Semester, out list))
                {
    
                    var query = _context.Semesters.Where(w => w.IsVisible).Select(SemesterCache.AsSemesterCache);
                    OnCacheQuery(ref query);
                    list = query.ToList();
                    // Set cache options.
                    var cacheOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(600));
    
                    _cache.Set(CacheKeys.Semester, list, cacheOptions);
                    _cacheItems.TryAdd(CacheKeys.Semester, DateTime.UtcNow);
                }
                return list;
            }
        }
    	partial void OnCacheQuery(ref IQueryable<SemesterCache> query);
    	
    	protected List<SessionCache> CacheSessions()
        {
            //get
            {
                List<SessionCache> list;
    
                if (!_cache.TryGetValue(CacheKeys.Session, out list))
                {
    
                    var query = _context.Sessions.Where(w => w.IsVisible).Select(SessionCache.AsSessionCache);
                    OnCacheQuery(ref query);
                    list = query.ToList();
                    // Set cache options.
                    var cacheOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(600));
    
                    _cache.Set(CacheKeys.Session, list, cacheOptions);
                    _cacheItems.TryAdd(CacheKeys.Session, DateTime.UtcNow);
                }
                return list;
            }
        }
    	partial void OnCacheQuery(ref IQueryable<SessionCache> query);
    	
    	protected List<StudentCache> CacheStudents()
        {
            //get
            {
                List<StudentCache> list;
    
                if (!_cache.TryGetValue(CacheKeys.Student, out list))
                {
    
                    var query = _context.Students.Where(w => w.IsVisible).Select(StudentCache.AsStudentCache);
                    OnCacheQuery(ref query);
                    list = query.ToList();
                    // Set cache options.
                    var cacheOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(600));
    
                    _cache.Set(CacheKeys.Student, list, cacheOptions);
                    _cacheItems.TryAdd(CacheKeys.Student, DateTime.UtcNow);
                }
                return list;
            }
        }
    	partial void OnCacheQuery(ref IQueryable<StudentCache> query);
    	
    	protected List<StudentCourseCache> CacheStudentCourses()
        {
            //get
            {
                List<StudentCourseCache> list;
    
                if (!_cache.TryGetValue(CacheKeys.StudentCourse, out list))
                {
    
                    var query = _context.StudentCourses.Where(w => w.IsVisible).Select(StudentCourseCache.AsStudentCourseCache);
                    OnCacheQuery(ref query);
                    list = query.ToList();
                    // Set cache options.
                    var cacheOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(600));
    
                    _cache.Set(CacheKeys.StudentCourse, list, cacheOptions);
                    _cacheItems.TryAdd(CacheKeys.StudentCourse, DateTime.UtcNow);
                }
                return list;
            }
        }
    	partial void OnCacheQuery(ref IQueryable<StudentCourseCache> query);
        #endregion
    
    	
    }
}
