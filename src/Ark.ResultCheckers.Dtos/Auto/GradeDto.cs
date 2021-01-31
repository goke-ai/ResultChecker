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
    
    public partial class GradeDto : BaseNameEntityDto
    {
        public GradeDto()
        {
    		
            OnInitialize();
        }
    
        partial void OnInitialize();
    
        [Display(Name = "Begin Mark")]
    	public double BeginMark { get; set; }
        [Display(Name = "Next Begin Mark")]
    	public double NextBeginMark { get; set; }
        [Display(Name = "Point")]
    	public double Point { get; set; }
    	private static Expression<Func<Grade, GradeDto>> _asGradeDto;
        public static Expression<Func<Grade, GradeDto>> AsGradeDto
        {
            get
            {
                SetConverters();
                return _asGradeDto;
            }
        }
        
        private static Func<Grade, GradeDto> _asGradeDtoFunc;
        public static Func<Grade, GradeDto> AsGradeDtoFunc
        {
            get
            {
                SetConverters();
                return _asGradeDtoFunc;
            }
        }
        
        private static Expression<Func<GradeDto, Grade>> _asGrade;
        public static Expression<Func<GradeDto, Grade>> AsGrade
        {
            get
            {
                SetConverters();
                return _asGrade;
            }
        }
        
        private static Func<GradeDto, Grade> _asGradeFunc;
        public static Func<GradeDto, Grade> AsGradeFunc
        {
            get
            {
                SetConverters();
                return _asGradeFunc;
            }
        }
    
    	private static Func<Grade, GradeDto, Grade> _toGradeFunc;
        public static Func<Grade, GradeDto, Grade> ToGradeFunc
        {
            get
            {
                SetConverters();
                return _toGradeFunc;
            }
        }
    
    	/*
    	private static Expression<Func<Grade, string>> _orderGrade;
        public static Expression<Func<Grade, string>> OrderGrade
        {
            get
            {
                SetConverters();
                return _orderGrade;
            }
        }
    	*/
    
    	private static Expression<Func<Grade, bool>> SearchExpression(string searchString)
        {
            return 
    				w => w.Id.ToString().Contains(searchString) 
    			|| w.Name.Contains(searchString) 
    			;
        }
    
        static IQueryable<Grade> _searchQuery;
        public static IQueryable<Grade> Search(IQueryable<Grade> query, string searchString)
        {
            _searchQuery = query.Where(
    						SearchExpression(searchString)
    					);
    		OnSetSearchQuery(query, searchString);
    		return _searchQuery;
    	}
    
        static IOrderedQueryable<Grade> _orderQuery;
        public static IOrderedQueryable<Grade> OrderBy(IQueryable<Grade> query)
        {
    		_orderQuery = query.OrderBy(o => o.Name);
    		OnSetOrderQuery(query);
            return _orderQuery;
        }
    
        static IOrderedQueryable<GradeDto> _orderQueryDto;
        public static IOrderedQueryable<GradeDto> OrderBy(IQueryable<GradeDto> query)
        {
    		_orderQueryDto = query.OrderBy(o => o.Name);
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
    
        static Expression<Func<Grade, bool>>[] _filters;
        public static Expression<Func<Grade, bool>>[] Filters(string searchString)
        {
            _filters = new Expression<Func<Grade, bool>>[]
    					   {
    							SearchExpression(searchString)
    
    					   };
            OnSetFilters(searchString);
            return _filters;
        }
    
    
    	private static void SetConverters()
        {
            _asGradeDto = x => new GradeDto
            {
                
                Id = x.Id,
                
                Name = x.Name,
                // DisplayName = x.DisplayName,
                // Description = x.Description,
    			// +simplex
    			BeginMark = x.BeginMark,
    			NextBeginMark = x.NextBeginMark,
    			Point = x.Point,
                
                IsVisible = x.IsVisible,
                InsertUser = x.InsertUser,
                InsertDateTime = x.InsertDateTime,
                UpdateUser = x.UpdateUser,
                UpdateDateTime = x.UpdateDateTime,
                LastActivityUser = x.LastActivityUser,
                LastActivityDateTime = x.LastActivityDateTime,
                Version = x.Version
            };
    
            _asGrade = x => new Grade
            {
                
                Id = x.Id,
                
                Name = x.Name,
                // DisplayName = x.DisplayName,
                // Description = x.Description,
    			// +simple
    			BeginMark = x.BeginMark,
    			NextBeginMark = x.NextBeginMark,
    			Point = x.Point,
                
                IsVisible = x.IsVisible,
                InsertUser = x.InsertUser,
                InsertDateTime = x.InsertDateTime,
                UpdateUser = x.UpdateUser,
                UpdateDateTime = x.UpdateDateTime,
                LastActivityUser = x.LastActivityUser,
                LastActivityDateTime = x.LastActivityDateTime,
                Version = x.Version
                 
            };
    
            _toGradeFunc = (y,x) => {
                
                y.Id = x.Id;
                
                y.Name = x.Name;
                // y.DisplayName = x.DisplayName;
    			// +simple
    			y.BeginMark = x.BeginMark;
    			y.NextBeginMark = x.NextBeginMark;
    			y.Point = x.Point;
                
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
    
            _asGradeFunc = _asGrade.Compile();
            _asGradeDtoFunc = _asGradeDto.Compile();
        }
    
        static partial void OnSetConverters();
        static partial void OnSetOrderQuery(IQueryable<Grade> query);
        static partial void OnSetOrderQuery(IQueryable<GradeDto> query);
        static partial void OnSetSearchQuery(IQueryable<Grade> query, string searchString);
        static partial void OnSetOrders();
        static partial void OnSetIncludeNavigations();
        static partial void OnSetFilters(string searchString);
    }
}
