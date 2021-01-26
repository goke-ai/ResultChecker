//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ark.ResultCheckers.Dtos.Caches
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq.Expressions;
    using Ark.ResultCheckers.Entities;
    
    public partial class SemesterCache : BaseNameEntityCache
    {
        public SemesterCache()
        {
            OnInitialize();
        }
    
        partial void OnInitialize();
    
    
        private static Expression<Func<Semester, string>> _orderSemester;
        public static Expression<Func<Semester, string>> OrderSemester
        {
            get
            {
                SetConverters();
                return _orderSemester;
            }
        }
        
    	private static Expression<Func<Semester, SemesterCache>> _asSemesterCache;
        public static Expression<Func<Semester, SemesterCache>> AsSemesterCache
        {
            get
            {
                SetConverters();
                return _asSemesterCache;
            }
        }
        
        private static Func<Semester, SemesterCache> _asSemesterCacheFunc;
        public static Func<Semester, SemesterCache> AsSemesterCacheFunc
        {
            get
            {
                SetConverters();
                return _asSemesterCacheFunc;
            }
        }
        
    	private static void SetConverters()
        {
            _orderSemester = x => x.Name;
    
            _asSemesterCache = x => new SemesterCache
            {
    			Id = x.Id,
                
                Name = x.Name,
    			
            };
    
            OnSetConverters();
    
            _asSemesterCacheFunc = _asSemesterCache.Compile();
        }
    
        static partial void OnSetConverters();
    
    
    	
    }
}
