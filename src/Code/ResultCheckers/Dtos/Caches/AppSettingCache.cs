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
    
    public partial class AppSettingCache : BaseEntityCache
    {
        public AppSettingCache()
        {
            OnInitialize();
        }
    
        partial void OnInitialize();
    
    
        private static Expression<Func<AppSetting, string>> _orderAppSetting;
        public static Expression<Func<AppSetting, string>> OrderAppSetting
        {
            get
            {
                SetConverters();
                return _orderAppSetting;
            }
        }
        
    	private static Expression<Func<AppSetting, AppSettingCache>> _asAppSettingCache;
        public static Expression<Func<AppSetting, AppSettingCache>> AsAppSettingCache
        {
            get
            {
                SetConverters();
                return _asAppSettingCache;
            }
        }
        
        private static Func<AppSetting, AppSettingCache> _asAppSettingCacheFunc;
        public static Func<AppSetting, AppSettingCache> AsAppSettingCacheFunc
        {
            get
            {
                SetConverters();
                return _asAppSettingCacheFunc;
            }
        }
        
    	private static void SetConverters()
        {
            _orderAppSetting = x => x.Id.ToString();
    
            _asAppSettingCache = x => new AppSettingCache
            {
    			Id = x.Id,
                
                Name = null, //[x.Name],
    			
            };
    
            OnSetConverters();
    
            _asAppSettingCacheFunc = _asAppSettingCache.Compile();
        }
    
        static partial void OnSetConverters();
    
    
    	
    }
}