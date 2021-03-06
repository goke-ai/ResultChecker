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
    
    public partial class BulkStudentCourseDto : BulkEntityDto
    {
        public BulkStudentCourseDto()
        {
    		
            OnInitialize();
        }
    
        partial void OnInitialize();
    
        [Required(ErrorMessage = "The Session is a mandatory Field.")]
    	[Display(Name = "Session")]
    	public string Session { get; set; }
        [Required(ErrorMessage = "The Semester is a mandatory Field.")]
    	[Display(Name = "Semester")]
    	public string Semester { get; set; }
        [Required(ErrorMessage = "The Code is a mandatory Field.")]
    	[Display(Name = "Code")]
    	public string Code { get; set; }
        [Required(ErrorMessage = "The Matric No is a mandatory Field.")]
    	[Display(Name = "Matric No")]
    	public string MatricNo { get; set; }
        [Display(Name = "Score")]
    	public double Score { get; set; }
        [Required(ErrorMessage = "The Username is a mandatory Field.")]
    	[Display(Name = "Username")]
    	public string Username { get; set; }
    	private static Expression<Func<BulkStudentCourse, BulkStudentCourseDto>> _asBulkStudentCourseDto;
        public static Expression<Func<BulkStudentCourse, BulkStudentCourseDto>> AsBulkStudentCourseDto
        {
            get
            {
                SetConverters();
                return _asBulkStudentCourseDto;
            }
        }
        
        private static Func<BulkStudentCourse, BulkStudentCourseDto> _asBulkStudentCourseDtoFunc;
        public static Func<BulkStudentCourse, BulkStudentCourseDto> AsBulkStudentCourseDtoFunc
        {
            get
            {
                SetConverters();
                return _asBulkStudentCourseDtoFunc;
            }
        }
        
        private static Expression<Func<BulkStudentCourseDto, BulkStudentCourse>> _asBulkStudentCourse;
        public static Expression<Func<BulkStudentCourseDto, BulkStudentCourse>> AsBulkStudentCourse
        {
            get
            {
                SetConverters();
                return _asBulkStudentCourse;
            }
        }
        
        private static Func<BulkStudentCourseDto, BulkStudentCourse> _asBulkStudentCourseFunc;
        public static Func<BulkStudentCourseDto, BulkStudentCourse> AsBulkStudentCourseFunc
        {
            get
            {
                SetConverters();
                return _asBulkStudentCourseFunc;
            }
        }
    
    	private static Func<BulkStudentCourse, BulkStudentCourseDto, BulkStudentCourse> _toBulkStudentCourseFunc;
        public static Func<BulkStudentCourse, BulkStudentCourseDto, BulkStudentCourse> ToBulkStudentCourseFunc
        {
            get
            {
                SetConverters();
                return _toBulkStudentCourseFunc;
            }
        }
    
    	/*
    	private static Expression<Func<BulkStudentCourse, string>> _orderBulkStudentCourse;
        public static Expression<Func<BulkStudentCourse, string>> OrderBulkStudentCourse
        {
            get
            {
                SetConverters();
                return _orderBulkStudentCourse;
            }
        }
    	*/
    
    	private static Expression<Func<BulkStudentCourse, bool>> SearchExpression(string searchString)
        {
            return 
    				w => w.Id.ToString().Contains(searchString) 
    			|| w.Session.Contains(searchString) //@string
    			|| w.Semester.Contains(searchString) //@string
    			|| w.Code.Contains(searchString) //@string
    			|| w.MatricNo.Contains(searchString) //@string
    			|| w.Username.Contains(searchString) //@string
    			;
        }
    
        static IQueryable<BulkStudentCourse> _searchQuery;
        public static IQueryable<BulkStudentCourse> Search(IQueryable<BulkStudentCourse> query, string searchString)
        {
            _searchQuery = query.Where(
    						SearchExpression(searchString)
    					);
    		OnSetSearchQuery(query, searchString);
    		return _searchQuery;
    	}
    
        static IOrderedQueryable<BulkStudentCourse> _orderQuery;
        public static IOrderedQueryable<BulkStudentCourse> OrderBy(IQueryable<BulkStudentCourse> query)
        {
    		_orderQuery = query.OrderBy(o => o.Id);
    		OnSetOrderQuery(query);
            return _orderQuery;
        }
    
        static IOrderedQueryable<BulkStudentCourseDto> _orderQueryDto;
        public static IOrderedQueryable<BulkStudentCourseDto> OrderBy(IQueryable<BulkStudentCourseDto> query)
        {
    		_orderQueryDto = query.OrderBy(o => o.Id);
            OnSetOrderQuery(query);
            return _orderQueryDto;
        }
    
    	static string[] _includeNavigations;
        public static string[] IncludeNavigations()
        {
            _includeNavigations = new string[] { 
    		};
            OnSetIncludeNavigations();
            return _includeNavigations;
        }
    
        static Expression<Func<BulkStudentCourse, bool>>[] _filters;
        public static Expression<Func<BulkStudentCourse, bool>>[] Filters(string searchString)
        {
            _filters = new Expression<Func<BulkStudentCourse, bool>>[]
    					   {
    							SearchExpression(searchString)
    
    					   };
            OnSetFilters(searchString);
            return _filters;
        }
    
    
    	private static void SetConverters()
        {
            _asBulkStudentCourseDto = x => new BulkStudentCourseDto
            {
                
                Id = x.Id,
                
                // UserName = x.UserName,
    			// +simplex
    			Session = x.Session,
    			Semester = x.Semester,
    			Code = x.Code,
    			MatricNo = x.MatricNo,
    			Score = x.Score,
    			Username = x.Username,
            };
    
            _asBulkStudentCourse = x => new BulkStudentCourse
            {
                
                Id = x.Id,
                
                // UserName = x.UserName,
    			// +simple
    			Session = x.Session,
    			Semester = x.Semester,
    			Code = x.Code,
    			MatricNo = x.MatricNo,
    			Score = x.Score,
    			Username = x.Username,
                 
            };
    
            _toBulkStudentCourseFunc = (y,x) => {
                
                y.Id = x.Id;
                
                // y.UserName = x.UserName;
    			// +simple
    			y.Session = x.Session;
    			y.Semester = x.Semester;
    			y.Code = x.Code;
    			y.MatricNo = x.MatricNo;
    			y.Score = x.Score;
    			y.Username = x.Username;
          
    			return y;
            };
    
            OnSetConverters();
    
            _asBulkStudentCourseFunc = _asBulkStudentCourse.Compile();
            _asBulkStudentCourseDtoFunc = _asBulkStudentCourseDto.Compile();
        }
    
        static partial void OnSetConverters();
        static partial void OnSetOrderQuery(IQueryable<BulkStudentCourse> query);
        static partial void OnSetOrderQuery(IQueryable<BulkStudentCourseDto> query);
        static partial void OnSetSearchQuery(IQueryable<BulkStudentCourse> query, string searchString);
        static partial void OnSetOrders();
        static partial void OnSetIncludeNavigations();
        static partial void OnSetFilters(string searchString);
    }
}
