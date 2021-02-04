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
using System.IO;
using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Ark.ResultCheckers.Data;
using Ark.ResultCheckers.Data.Services;
using Ark.ResultCheckers.Entities;
using Ark.ResultCheckers.Dtos;
using Ark.ResultCheckers.Dtos.Caches;

namespace Ark.ResultCheckers.Api1.Controllers
{
    [Route("api1/[controller]")]    
    [ApiController]
    // [Produces("application/json")]
    // [Route("api/AppSettings")]    
    // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize]
    public partial class AppSettingsController : ApiController
    {
        AppSettingService appSettingService;
    
        public AppSettingsController(AppDbContext context, IWebHostEnvironment env, IMemoryCache memoryCache, AppSettingService appSettingService) : base(context, env, memoryCache)
        {
            this.appSettingService = appSettingService;
        }
    
        // GET: api/AppSettings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppSettingDto>>> GetAppSettings(string searchText = null
            , string key  = null
            , string value  = null
    		/*, int pageNumber=1, int pageSize=7*/)
        {
    
            // var appSettings = _context.AppSettings.Select(AppSettingDto.AsAppSettingDto);
            List<Expression<Func<AppSettingDto, bool>>> filters = null; 
    
            if (String.IsNullOrEmpty(searchText)
                && (String.IsNullOrEmpty(key))
                && (String.IsNullOrEmpty(value))
    		
            )
            {
                // return null;
            }
            else
            {
                filters = new List<Expression<Func<AppSettingDto, bool>>>(); 
    
    		    if (!String.IsNullOrEmpty(searchText))
                {
    			    if (searchText.CompareTo("*") != 0 && searchText.CompareTo("%") != 0)
    			    {
    				    filters.Add(x => x.Id.ToString().Contains(searchText));
    			    }
                }
                
                if(!String.IsNullOrEmpty(key))
                { 
                    filters.Add(x => x.Key == key);  
                }
                
                if(!String.IsNullOrEmpty(value))
                { 
                    filters.Add(x => x.Value == value);  
                }
    		
            }
    
            //sort
            //return appSettings.OrderBy(o => o.Id).Skip(((pageNumber - 1) * pageSize)).Take(pageSize);
    
    		// OnSelectQuery(ref appSettings);
    
            // return await appSettings.ToListAsync();
    
            if (filters == null)
            {
                return await appSettingService.GetAppSettingDtoesAsync(AppSettingDto.IncludeNavigations());
            }
            else
            {
                return await appSettingService.GetAppSettingDtoesAsync(AppSettingDto.IncludeNavigations(), filters.ToArray());
            }
    
        }
    
    	partial void OnSelectQuery(ref IQueryable<AppSettingDto> appSettings);
    
    
        // GET: api/AppSettings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AppSettingDto>> GetAppSetting(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
    
            var appSetting = await appSettingService.GetAppSettingDtoAsync(id, AppSettingDto.IncludeNavigations());
    
            if (appSetting == null)
            {
                return NotFound();
            }
    
            return appSetting;
        }
    
        // PUT: api/AppSettings/5
        [HttpPut("{id}")]
    	public async Task<IActionResult> PutAppSetting(int id, AppSettingDto appSetting)
    	{
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
    
            if (id != appSetting.Id)
            {
                return BadRequest();
            }
    
            try
            {
    
                var updated = await appSettingService.UpdateAppSettingAsync(appSetting, User.Identity.Name);
                
                if (updated)
                {
                    this.RemoveCache(CacheKeys.AppSetting);
                }
                else
                {
                    return BadRequest("Update failed!.");
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppSettingExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
    
            return NoContent();
    		// return Ok(appSetting);
        }
    
        // POST: api/AppSettings
        [HttpPost]
        public async Task<ActionResult<AppSettingDto>> PostAppSetting(AppSettingDto appSetting)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
    
            AppSettingDto appSettingDto;
            try
            {
                
                appSettingDto = await appSettingService.CreateAppSettingAsync(appSetting, User.Identity.Name);            
            
                if (appSettingDto != null)
                {
                    this.RemoveCache(CacheKeys.AppSetting);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }   
    
            // var appSettingDto = await _context.AppSettings.Select(AppSettingDto.AsAppSettingDto).SingleOrDefaultAsync(m => m.Id == appSetting.Id);
    
            return CreatedAtAction("GetAppSetting", new { id = appSettingDto.Id }, appSettingDto);
        }
    
        // DELETE: api/AppSettings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AppSettingDto>> DeleteAppSetting(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
    
            var appSettingDto = await _context.AppSettings.Select(AppSettingDto.AsAppSettingDto).SingleOrDefaultAsync(m => m.Id == id);
           
            if (appSettingDto == null)
            {
                return NotFound();
            }
    
            // var appSetting = AppSettingDto.AsAppSettingFunc(appSettingDto);
    
            // _context.AppSettings.Remove(appSetting);
    
            // await SaveChangesAndRemoveCacheAsync(CacheKeys.AppSetting);
            try
            {
                var deleted = await appSettingService.DeleteAppSettingAsync(appSettingDto);
    
                if (deleted)
                {
                    this.RemoveCache(CacheKeys.AppSetting);
                }
                else
                {
                    return BadRequest("Delete failed!.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }  
    
            return appSettingDto;
        }
    
        private bool AppSettingExists(int id)
        {
            return _context.AppSettings.Any(e => e.Id == id);
        }
    
    	
    	// GET: api/AppSettings/Cache
        [AllowAnonymous]
        [HttpGet("Cache")]
        public IEnumerable<AppSettingCache> GetCacheAppSettings()
        {
            return this.CacheAppSettings();
        }
        
        
    }
}
