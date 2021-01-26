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
    
    public partial class BulkEntityDto
    {
        public BulkEntityDto()
        {
    		
            OnInitialize();
        }
    
        partial void OnInitialize();
    
        [Key]
    	[Display(Name = "Id")]
    	public int Id { get; set; }
    	private static Expression<Func<BulkEntity, BulkEntityDto>> _asBulkEntityDto;
        public static Expression<Func<BulkEntity, BulkEntityDto>> AsBulkEntityDto
        {
            get
            {
                SetConverters();
                return _asBulkEntityDto;
            }
        }
        
        private static Func<BulkEntity, BulkEntityDto> _asBulkEntityDtoFunc;
        public static Func<BulkEntity, BulkEntityDto> AsBulkEntityDtoFunc
        {
            get
            {
                SetConverters();
                return _asBulkEntityDtoFunc;
            }
        }
        
        private static Expression<Func<BulkEntityDto, BulkEntity>> _asBulkEntity;
        public static Expression<Func<BulkEntityDto, BulkEntity>> AsBulkEntity
        {
            get
            {
                SetConverters();
                return _asBulkEntity;
            }
        }
        
        private static Func<BulkEntityDto, BulkEntity> _asBulkEntityFunc;
        public static Func<BulkEntityDto, BulkEntity> AsBulkEntityFunc
        {
            get
            {
                SetConverters();
                return _asBulkEntityFunc;
            }
        }
    
    	private static Func<BulkEntity, BulkEntityDto, BulkEntity> _toBulkEntityFunc;
        public static Func<BulkEntity, BulkEntityDto, BulkEntity> ToBulkEntityFunc
        {
            get
            {
                SetConverters();
                return _toBulkEntityFunc;
            }
        }
    
    	/*
    	private static Expression<Func<BulkEntity, string>> _orderBulkEntity;
        public static Expression<Func<BulkEntity, string>> OrderBulkEntity
        {
            get
            {
                SetConverters();
                return _orderBulkEntity;
            }
        }
    	*/
    
    	private static Expression<Func<BulkEntity, bool>> SearchExpression(string searchString)
        {
            return 
    				w => w.Id.ToString().Contains(searchString) 
    			;
        }
    
        static IOrderedQueryable<BulkEntity> _orderQuery;
        public static IOrderedQueryable<BulkEntity> OrderBy(IQueryable<BulkEntity> query)
        {
    		_orderQuery = query.OrderBy(o => o.Id);
    		OnSetOrderQuery(query);
            return _orderQuery;
        }
    
        static IOrderedQueryable<BulkEntityDto> _orderQueryDto;
        public static IOrderedQueryable<BulkEntityDto> OrderBy(IQueryable<BulkEntityDto> query)
        {
    		_orderQueryDto = query.OrderBy(o => o.Id);
            OnSetOrderQuery(query);
            return _orderQueryDto;
        }
    
    
    	private static void SetConverters()
        {
            _asBulkEntityDto = x => new BulkEntityDto
            {
    			// +simplex
    			Id = x.Id,
            };
    
            _asBulkEntity = x => new BulkEntity
            {
    			// +simple
    			Id = x.Id,
                 
            };
    
            _toBulkEntityFunc = (y,x) => {
    			// +simple
    			y.Id = x.Id;
          
    			return y;
            };
    
            OnSetConverters();
    
            _asBulkEntityFunc = _asBulkEntity.Compile();
            _asBulkEntityDtoFunc = _asBulkEntityDto.Compile();
        }
    
        static partial void OnSetConverters();
        static partial void OnSetOrderQuery(IQueryable<BulkEntity> query);
        static partial void OnSetOrderQuery(IQueryable<BulkEntityDto> query);
        static partial void OnSetSearchQuery(IQueryable<BulkEntity> query, string searchString);
        static partial void OnSetOrders();
        static partial void OnSetIncludeNavigations();
        static partial void OnSetFilters(string searchString);
    }
}