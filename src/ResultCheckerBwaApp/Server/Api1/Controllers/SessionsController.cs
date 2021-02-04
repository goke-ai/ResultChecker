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
    // [Route("api/Sessions")]    
    // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize]
    public partial class SessionsController : ApiController
    {
        SessionService sessionService;
    
        public SessionsController(AppDbContext context, IWebHostEnvironment env, IMemoryCache memoryCache, SessionService sessionService) : base(context, env, memoryCache)
        {
            this.sessionService = sessionService;
        }
    
        // GET: api/Sessions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SessionDto>>> GetSessions(string searchText = null
    		/*, int pageNumber=1, int pageSize=7*/)
        {
    
            // var sessions = _context.Sessions.Select(SessionDto.AsSessionDto);
            List<Expression<Func<SessionDto, bool>>> filters = null; 
    
            if (String.IsNullOrEmpty(searchText)
    		
            )
            {
                // return null;
            }
            else
            {
                filters = new List<Expression<Func<SessionDto, bool>>>(); 
    
    		    if (!String.IsNullOrEmpty(searchText))
                {
    			    if (searchText.CompareTo("*") != 0 && searchText.CompareTo("%") != 0)
    			    {
    				    filters.Add(x => x.Id.ToString().Contains(searchText));
    			    }
                }
    		
            }
    
            //sort
            //return sessions.OrderBy(o => o.Id).Skip(((pageNumber - 1) * pageSize)).Take(pageSize);
    
    		// OnSelectQuery(ref sessions);
    
            // return await sessions.ToListAsync();
    
            if (filters == null)
            {
                return await sessionService.GetSessionDtoesAsync(SessionDto.IncludeNavigations());
            }
            else
            {
                return await sessionService.GetSessionDtoesAsync(SessionDto.IncludeNavigations(), filters.ToArray());
            }
    
        }
    
    	partial void OnSelectQuery(ref IQueryable<SessionDto> sessions);
    
    
        // GET: api/Sessions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SessionDto>> GetSession(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
    
            var session = await sessionService.GetSessionDtoAsync(id, SessionDto.IncludeNavigations());
    
            if (session == null)
            {
                return NotFound();
            }
    
            return session;
        }
    
        // PUT: api/Sessions/5
        [HttpPut("{id}")]
    	public async Task<IActionResult> PutSession(int id, SessionDto session)
    	{
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
    
            if (id != session.Id)
            {
                return BadRequest();
            }
    
            try
            {
    
                var updated = await sessionService.UpdateSessionAsync(session, User.Identity.Name);
                
                if (updated)
                {
                    this.RemoveCache(CacheKeys.Session);
                }
                else
                {
                    return BadRequest("Update failed!.");
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SessionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
    
            return NoContent();
    		// return Ok(session);
        }
    
        // POST: api/Sessions
        [HttpPost]
        public async Task<ActionResult<SessionDto>> PostSession(SessionDto session)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
    
            SessionDto sessionDto;
            try
            {
                
                sessionDto = await sessionService.CreateSessionAsync(session, User.Identity.Name);            
            
                if (sessionDto != null)
                {
                    this.RemoveCache(CacheKeys.Session);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }   
    
            // var sessionDto = await _context.Sessions.Select(SessionDto.AsSessionDto).SingleOrDefaultAsync(m => m.Id == session.Id);
    
            return CreatedAtAction("GetSession", new { id = sessionDto.Id }, sessionDto);
        }
    
        // DELETE: api/Sessions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SessionDto>> DeleteSession(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
    
            var sessionDto = await _context.Sessions.Select(SessionDto.AsSessionDto).SingleOrDefaultAsync(m => m.Id == id);
           
            if (sessionDto == null)
            {
                return NotFound();
            }
    
            // var session = SessionDto.AsSessionFunc(sessionDto);
    
            // _context.Sessions.Remove(session);
    
            // await SaveChangesAndRemoveCacheAsync(CacheKeys.Session);
            try
            {
                var deleted = await sessionService.DeleteSessionAsync(sessionDto);
    
                if (deleted)
                {
                    this.RemoveCache(CacheKeys.Session);
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
    
            return sessionDto;
        }
    
        private bool SessionExists(int id)
        {
            return _context.Sessions.Any(e => e.Id == id);
        }
    
    	
    	// GET: api/Sessions/Cache
        [AllowAnonymous]
        [HttpGet("Cache")]
        public IEnumerable<SessionCache> GetCacheSessions()
        {
            return this.CacheSessions();
        }
        
        
    }
}
