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
    
    public partial class SemesterDto : BaseNameEntityDto
    {
        public SemesterDto()
        {
    		
            OnInitialize();
        }
    
        partial void OnInitialize();
    
    	private static Expression<Func<Semester, SemesterDto>> _asSemesterDto;
        public static Expression<Func<Semester, SemesterDto>> AsSemesterDto
        {
            get
            {
                SetConverters();
                return _asSemesterDto;
            }
        }
        
        private static Func<Semester, SemesterDto> _asSemesterDtoFunc;
        public static Func<Semester, SemesterDto> AsSemesterDtoFunc
        {
            get
            {
                SetConverters();
                return _asSemesterDtoFunc;
            }
        }
        
        private static Expression<Func<SemesterDto, Semester>> _asSemester;
        public static Expression<Func<SemesterDto, Semester>> AsSemester
        {
            get
            {
                SetConverters();
                return _asSemester;
            }
        }
        
        private static Func<SemesterDto, Semester> _asSemesterFunc;
        public static Func<SemesterDto, Semester> AsSemesterFunc
        {
            get
            {
                SetConverters();
                return _asSemesterFunc;
            }
        }
    
    	private static Func<Semester, SemesterDto, Semester> _toSemesterFunc;
        public static Func<Semester, SemesterDto, Semester> ToSemesterFunc
        {
            get
            {
                SetConverters();
                return _toSemesterFunc;
            }
        }
    
    	/*
    	private static Expression<Func<Semester, string>> _orderSemester;
        public static Expression<Func<Semester, string>> OrderSemester
        {
            get
            {
                SetConverters();
                return _orderSemester;
            }
        }
    	*/
    
    	private static Expression<Func<Semester, bool>> SearchExpression(string searchString)
        {
            return 
    				w => w.Id.ToString().Contains(searchString) 
    			|| w.Name.Contains(searchString) 
    			;
        }
    
        static IQueryable<Semester> _searchQuery;
        public static IQueryable<Semester> Search(IQueryable<Semester> query, string searchString)
        {
            _searchQuery = query.Where(
    						SearchExpression(searchString)
    					);
    		OnSetSearchQuery(query, searchString);
    		return _searchQuery;
    	}
    
        static IOrderedQueryable<Semester> _orderQuery;
        public static IOrderedQueryable<Semester> OrderBy(IQueryable<Semester> query)
        {
    		_orderQuery = query.OrderBy(o => o.Name);
    		OnSetOrderQuery(query);
            return _orderQuery;
        }
    
        static IOrderedQueryable<SemesterDto> _orderQueryDto;
        public static IOrderedQueryable<SemesterDto> OrderBy(IQueryable<SemesterDto> query)
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
    
        static Expression<Func<Semester, bool>>[] _filters;
        public static Expression<Func<Semester, bool>>[] Filters(string searchString)
        {
            _filters = new Expression<Func<Semester, bool>>[]
    					   {
    							SearchExpression(searchString)
    
    					   };
            OnSetFilters(searchString);
            return _filters;
        }
    
    
    	private static void SetConverters()
        {
            _asSemesterDto = x => new SemesterDto
            {
                
                Id = x.Id,
                
                Name = x.Name,
                // DisplayName = x.DisplayName,
                // Description = x.Description,
                
                IsVisible = x.IsVisible,
                InsertUser = x.InsertUser,
                InsertDateTime = x.InsertDateTime,
                UpdateUser = x.UpdateUser,
                UpdateDateTime = x.UpdateDateTime,
                LastActivityUser = x.LastActivityUser,
                LastActivityDateTime = x.LastActivityDateTime,
                Version = x.Version
            };
    
            _asSemester = x => new Semester
            {
                
                Id = x.Id,
                
                Name = x.Name,
                // DisplayName = x.DisplayName,
                // Description = x.Description,
                
                IsVisible = x.IsVisible,
                InsertUser = x.InsertUser,
                InsertDateTime = x.InsertDateTime,
                UpdateUser = x.UpdateUser,
                UpdateDateTime = x.UpdateDateTime,
                LastActivityUser = x.LastActivityUser,
                LastActivityDateTime = x.LastActivityDateTime,
                Version = x.Version
                 
            };
    
            _toSemesterFunc = (y,x) => {
                
                y.Id = x.Id;
                
                y.Name = x.Name;
                // y.DisplayName = x.DisplayName;
                
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
    
            _asSemesterFunc = _asSemester.Compile();
            _asSemesterDtoFunc = _asSemesterDto.Compile();
        }
    
        static partial void OnSetConverters();
        static partial void OnSetOrderQuery(IQueryable<Semester> query);
        static partial void OnSetOrderQuery(IQueryable<SemesterDto> query);
        static partial void OnSetSearchQuery(IQueryable<Semester> query, string searchString);
        static partial void OnSetOrders();
        static partial void OnSetIncludeNavigations();
        static partial void OnSetFilters(string searchString);
    }
}
