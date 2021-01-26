//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ark.ResultCheckers.Dtos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Linq.Expressions;
    using Ark.ResultCheckers.Entities;
    
    public partial class StudentCourseDto : BaseEntityDto
    {
        public StudentCourseDto()
        {
    		
            OnInitialize();
        }
    
        partial void OnInitialize();
    
        [ForeignKey("Session")]
    	[Display(Name = "Session")]
    	public int? SessionId { get; set; }
        [ForeignKey("Semester")]
    	[Display(Name = "Semester")]
    	public int? SemesterId { get; set; }
        [ForeignKey("Student")]
    	[Display(Name = "Student")]
    	public int StudentId { get; set; }
        [ForeignKey("Course")]
    	[Display(Name = "Course")]
    	public int CourseId { get; set; }
        [Display(Name = "Score")]
    	public double Score { get; set; }
    	// +navigation
        // +Student
    	[Display(Name = "Student Matric No")]
    	public string StudentMatricNo { get; set; }
    	[Display(Name = "Student Name")]
    	public string StudentName { get; set; } //Basic-Nav-Property
    	// -Student
        // +Course
    	[Display(Name = "Course Code")]
    	public string CourseCode { get; set; }
    	[Display(Name = "Course Name")]
    	public string CourseName { get; set; } //Basic-Nav-Property
    	// -Course
        // +Session
    	[Display(Name = "Session Name")]
    	public string SessionName { get; set; }
    	// -Session
        // +Semester
    	[Display(Name = "Semester Name")]
    	public string SemesterName { get; set; }
    	// -Semester
    	// -navigation
    	private static Expression<Func<StudentCourse, StudentCourseDto>> _asStudentCourseDto;
        public static Expression<Func<StudentCourse, StudentCourseDto>> AsStudentCourseDto
        {
            get
            {
                SetConverters();
                return _asStudentCourseDto;
            }
        }
        
        private static Func<StudentCourse, StudentCourseDto> _asStudentCourseDtoFunc;
        public static Func<StudentCourse, StudentCourseDto> AsStudentCourseDtoFunc
        {
            get
            {
                SetConverters();
                return _asStudentCourseDtoFunc;
            }
        }
        
        private static Expression<Func<StudentCourseDto, StudentCourse>> _asStudentCourse;
        public static Expression<Func<StudentCourseDto, StudentCourse>> AsStudentCourse
        {
            get
            {
                SetConverters();
                return _asStudentCourse;
            }
        }
        
        private static Func<StudentCourseDto, StudentCourse> _asStudentCourseFunc;
        public static Func<StudentCourseDto, StudentCourse> AsStudentCourseFunc
        {
            get
            {
                SetConverters();
                return _asStudentCourseFunc;
            }
        }
    
    	private static Func<StudentCourse, StudentCourseDto, StudentCourse> _toStudentCourseFunc;
        public static Func<StudentCourse, StudentCourseDto, StudentCourse> ToStudentCourseFunc
        {
            get
            {
                SetConverters();
                return _toStudentCourseFunc;
            }
        }
    
    	/*
    	private static Expression<Func<StudentCourse, string>> _orderStudentCourse;
        public static Expression<Func<StudentCourse, string>> OrderStudentCourse
        {
            get
            {
                SetConverters();
                return _orderStudentCourse;
            }
        }
    	*/
    
    	private static Expression<Func<StudentCourse, bool>> SearchExpression(string searchString)
        {
            return 
    				w => w.Id.ToString().Contains(searchString) 
    				|| w.Session.Id.ToString().Contains(searchString) //null
    				|| w.Semester.Id.ToString().Contains(searchString) //null
    				|| w.Student.MatricNo.Contains(searchString) //MatricNo
    				|| w.Course.Code.Contains(searchString) //Code
    			;
        }
    
        static IQueryable<StudentCourse> _searchQuery;
        public static IQueryable<StudentCourse> Search(IQueryable<StudentCourse> query, string searchString)
        {
            _searchQuery = query.Where(
    						SearchExpression(searchString)
    					);
    		OnSetSearchQuery(query, searchString);
    		return _searchQuery;
    	}
    
        static IOrderedQueryable<StudentCourse> _orderQuery;
        public static IOrderedQueryable<StudentCourse> OrderBy(IQueryable<StudentCourse> query)
        {
    		_orderQuery = query.OrderBy(o => o.Id);
    		OnSetOrderQuery(query);
            return _orderQuery;
        }
    
        static IOrderedQueryable<StudentCourseDto> _orderQueryDto;
        public static IOrderedQueryable<StudentCourseDto> OrderBy(IQueryable<StudentCourseDto> query)
        {
    		_orderQueryDto = query.OrderBy(o => o.Id);
            OnSetOrderQuery(query);
            return _orderQueryDto;
        }
    
    	static string[] _includeNavigations;
        public static string[] IncludeNavigations()
        {
            _includeNavigations = new string[] { 
    		// +navigation
    			"Student",
    			"Course",
    			"Session",
    			"Semester",
    		};
            OnSetIncludeNavigations();
            return _includeNavigations;
        }
    
        static Expression<Func<StudentCourse, bool>>[] _filters;
        public static Expression<Func<StudentCourse, bool>>[] Filters(string searchString)
        {
            _filters = new Expression<Func<StudentCourse, bool>>[]
    					   {
    							SearchExpression(searchString)
    
    					   };
            OnSetFilters(searchString);
            return _filters;
        }
    
    
    	private static void SetConverters()
        {
            _asStudentCourseDto = x => new StudentCourseDto
            {
                
                Id = x.Id,
    			// +simplex
    			SessionId = x.SessionId,
    			SemesterId = x.SemesterId,
    			StudentId = x.StudentId,
    			CourseId = x.CourseId,
    			Score = x.Score,
    			// +navigation
    			StudentName = x.Student == null ? default : x.Student.StudentName,
    			CourseName = x.Course == null ? default : x.Course.CourseName,
    			SessionName = x.Session != null ? x.Session.Name : default,
    			SemesterName = x.Semester != null ? x.Semester.Name : default,
                
                IsVisible = x.IsVisible,
                InsertUser = x.InsertUser,
                InsertDateTime = x.InsertDateTime,
                UpdateUser = x.UpdateUser,
                UpdateDateTime = x.UpdateDateTime,
                LastActivityUser = x.LastActivityUser,
                LastActivityDateTime = x.LastActivityDateTime,
                Version = x.Version
            };
    
            _asStudentCourse = x => new StudentCourse
            {
                
                Id = x.Id,
    			// +simple
    			SessionId = x.SessionId,
    			SemesterId = x.SemesterId,
    			StudentId = x.StudentId,
    			CourseId = x.CourseId,
    			Score = x.Score,
    			// +navigation
                
                IsVisible = x.IsVisible,
                InsertUser = x.InsertUser,
                InsertDateTime = x.InsertDateTime,
                UpdateUser = x.UpdateUser,
                UpdateDateTime = x.UpdateDateTime,
                LastActivityUser = x.LastActivityUser,
                LastActivityDateTime = x.LastActivityDateTime,
                Version = x.Version
                 
            };
    
            _toStudentCourseFunc = (y,x) => {
                
                y.Id = x.Id;
    			// +simple
    			y.SessionId = x.SessionId;
    			y.SemesterId = x.SemesterId;
    			y.StudentId = x.StudentId;
    			y.CourseId = x.CourseId;
    			y.Score = x.Score;
    			// +navigation
    			/* y.Student.MatricNo = x.StudentMatricNo; */
    			/* y.Course.Code = x.CourseCode; */
    			/* y.Session.Name = x.SessionName; */
    			/* y.Semester.Name = x.SemesterName; */
                
                y.IsVisible = x.IsVisible;
                y.InsertUser = x.InsertUser;
                y.InsertDateTime = x.InsertDateTime;
                y.UpdateUser = x.UpdateUser;
                y.UpdateDateTime = x.UpdateDateTime;
                y.LastActivityUser = x.LastActivityUser;
                y.LastActivityDateTime = x.LastActivityDateTime;
                // y.Version = x.Version;
          
    			return y;
            };
    
            OnSetConverters();
    
            _asStudentCourseFunc = _asStudentCourse.Compile();
            _asStudentCourseDtoFunc = _asStudentCourseDto.Compile();
        }
    
        static partial void OnSetConverters();
        static partial void OnSetOrderQuery(IQueryable<StudentCourse> query);
        static partial void OnSetOrderQuery(IQueryable<StudentCourseDto> query);
        static partial void OnSetSearchQuery(IQueryable<StudentCourse> query, string searchString);
        static partial void OnSetOrders();
        static partial void OnSetIncludeNavigations();
        static partial void OnSetFilters(string searchString);
    }
}