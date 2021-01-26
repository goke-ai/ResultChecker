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

namespace Ark.ResultCheckers.Api2.Controllers
{
    [Route("api2/[controller]")]    
    [ApiController]
    // [Produces("application/json")]
    // [Route("api/Semesters")]    
    // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize]
    public partial class SemestersController : ApiController
    {
        SemesterService semesterService;
    
        public SemestersController(AppDbContext context, IWebHostEnvironment env, IMemoryCache memoryCache, SemesterService semesterService) : base(context, env, memoryCache)
        {
            this.semesterService = semesterService;
        }
    
        // GET: api/Semesters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SemesterDto>>> GetSemesters(string searchText = null
    		/*, int pageNumber=1, int pageSize=7*/)
        {
    
            // var semesters = _context.Semesters.Select(SemesterDto.AsSemesterDto);
            List<Expression<Func<SemesterDto, bool>>> filters = null; 
    
            if (String.IsNullOrEmpty(searchText)
    		)
            {
                // return null;
            }
            else
            {
                filters = new List<Expression<Func<SemesterDto, bool>>>(); 
    
    		    if (!String.IsNullOrEmpty(searchText))
                {
    			    if (searchText.CompareTo("*") != 0 && searchText.CompareTo("%") != 0)
    			    {
    				    filters.Add(x => x.Id.ToString().Contains(searchText));
    			    }
                }
            }
    
            //sort
            //return semesters.OrderBy(o => o.Id).Skip(((pageNumber - 1) * pageSize)).Take(pageSize);
    
    		// OnSelectQuery(ref semesters);
    
            // return await semesters.ToListAsync();
    
            if (filters == null)
            {
                return await semesterService.GetSemesterDtoesAsync(SemesterDto.IncludeNavigations());
            }
            else
            {
                return await semesterService.GetSemesterDtoesAsync(SemesterDto.IncludeNavigations(), filters.ToArray());
            }
    
        }
    
    	partial void OnSelectQuery(ref IQueryable<SemesterDto> semesters);
    
    
        // GET: api/Semesters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SemesterDto>> GetSemester(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
    
            var semester = await semesterService.GetSemesterDtoAsync(id, SemesterDto.IncludeNavigations());
    
            if (semester == null)
            {
                return NotFound();
            }
    
            return semester;
        }
    
        // PUT: api/Semesters/5
        [HttpPut("{id}")]
    	public async Task<IActionResult> PutSemester(int id, SemesterDto semester)
    	{
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
    
            if (id != semester.Id)
            {
                return BadRequest();
            }
    
            try
            {
    
                var updated = await semesterService.UpdateSemesterAsync(semester, User.Identity.Name);
                
                if (updated)
                {
                    this.RemoveCache(CacheKeys.Semester);
                }
                else
                {
                    return BadRequest("Update failed!.");
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SemesterExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
    
            return NoContent();
    		// return Ok(semester);
        }
    
        // POST: api/Semesters
        [HttpPost]
        public async Task<ActionResult<SemesterDto>> PostSemester(SemesterDto semester)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
    
            SemesterDto semesterDto;
            try
            {
                
                semesterDto = await semesterService.CreateSemesterAsync(semester, User.Identity.Name);            
            
                if (semesterDto != null)
                {
                    this.RemoveCache(CacheKeys.Semester);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }   
    
            // var semesterDto = await _context.Semesters.Select(SemesterDto.AsSemesterDto).SingleOrDefaultAsync(m => m.Id == semester.Id);
    
            return CreatedAtAction("GetSemester", new { id = semesterDto.Id }, semesterDto);
        }
    
        // DELETE: api/Semesters/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SemesterDto>> DeleteSemester(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
    
            var semesterDto = await _context.Semesters.Select(SemesterDto.AsSemesterDto).SingleOrDefaultAsync(m => m.Id == id);
           
            if (semesterDto == null)
            {
                return NotFound();
            }
    
            // var semester = SemesterDto.AsSemesterFunc(semesterDto);
    
            // _context.Semesters.Remove(semester);
    
            // await SaveChangesAndRemoveCacheAsync(CacheKeys.Semester);
            try
            {
                var deleted = await semesterService.DeleteSemesterAsync(semesterDto);
    
                if (deleted)
                {
                    this.RemoveCache(CacheKeys.Semester);
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
    
            return semesterDto;
        }
    
        private bool SemesterExists(int id)
        {
            return _context.Semesters.Any(e => e.Id == id);
        }
    
    	
    	// GET: api/Semesters/Cache
        [AllowAnonymous]
        [HttpGet("Cache")]
        public IEnumerable<SemesterCache> GetCacheSemesters()
        {
            return this.CacheSemesters();
        }
        
        
    }
}