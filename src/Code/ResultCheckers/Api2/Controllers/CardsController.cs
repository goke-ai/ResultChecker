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
    // [Route("api/Cards")]    
    // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize]
    public partial class CardsController : ApiController
    {
        CardService cardService;
    
        public CardsController(AppDbContext context, IWebHostEnvironment env, IMemoryCache memoryCache, CardService cardService) : base(context, env, memoryCache)
        {
            this.cardService = cardService;
        }
    
        // GET: api/Cards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CardDto>>> GetCards(string searchText = null
    			, string pinText = null
    		/*, int pageNumber=1, int pageSize=7*/)
        {
    
            // var cards = _context.Cards.Select(CardDto.AsCardDto);
            List<Expression<Func<CardDto, bool>>> filters = null; 
    
            if (String.IsNullOrEmpty(searchText)
    			&& String.IsNullOrEmpty(pinText)
    		)
            {
                // return null;
            }
            else
            {
                filters = new List<Expression<Func<CardDto, bool>>>(); 
    
    		    if (!String.IsNullOrEmpty(searchText))
                {
    			    if (searchText.CompareTo("*") != 0 && searchText.CompareTo("%") != 0)
    			    {
    				    filters.Add(x => x.Id.ToString().Contains(searchText));
    			    }
                }
    		    if (!String.IsNullOrEmpty(pinText))
    		    {
    			    filters.Add(x => x.Pin == pinText);
    		    }
            }
    
            //sort
            //return cards.OrderBy(o => o.Id).Skip(((pageNumber - 1) * pageSize)).Take(pageSize);
    
    		// OnSelectQuery(ref cards);
    
            // return await cards.ToListAsync();
    
            if (filters == null)
            {
                return await cardService.GetCardDtoesAsync(CardDto.IncludeNavigations());
            }
            else
            {
                return await cardService.GetCardDtoesAsync(CardDto.IncludeNavigations(), filters.ToArray());
            }
    
        }
    
    	partial void OnSelectQuery(ref IQueryable<CardDto> cards);
    
    
        // GET: api/Cards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CardDto>> GetCard(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
    
            var card = await cardService.GetCardDtoAsync(id, CardDto.IncludeNavigations());
    
            if (card == null)
            {
                return NotFound();
            }
    
            return card;
        }
    
        // PUT: api/Cards/5
        [HttpPut("{id}")]
    	public async Task<IActionResult> PutCard(int id, CardDto card)
    	{
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
    
            if (id != card.Id)
            {
                return BadRequest();
            }
    
            try
            {
    
                var updated = await cardService.UpdateCardAsync(card, User.Identity.Name);
                
                if (updated)
                {
                    this.RemoveCache(CacheKeys.Card);
                }
                else
                {
                    return BadRequest("Update failed!.");
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CardExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
    
            return NoContent();
    		// return Ok(card);
        }
    
        // POST: api/Cards
        [HttpPost]
        public async Task<ActionResult<CardDto>> PostCard(CardDto card)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
    
            CardDto cardDto;
            try
            {
                
                cardDto = await cardService.CreateCardAsync(card, User.Identity.Name);            
            
                if (cardDto != null)
                {
                    this.RemoveCache(CacheKeys.Card);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }   
    
            // var cardDto = await _context.Cards.Select(CardDto.AsCardDto).SingleOrDefaultAsync(m => m.Id == card.Id);
    
            return CreatedAtAction("GetCard", new { id = cardDto.Id }, cardDto);
        }
    
        // DELETE: api/Cards/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CardDto>> DeleteCard(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
    
            var cardDto = await _context.Cards.Select(CardDto.AsCardDto).SingleOrDefaultAsync(m => m.Id == id);
           
            if (cardDto == null)
            {
                return NotFound();
            }
    
            // var card = CardDto.AsCardFunc(cardDto);
    
            // _context.Cards.Remove(card);
    
            // await SaveChangesAndRemoveCacheAsync(CacheKeys.Card);
            try
            {
                var deleted = await cardService.DeleteCardAsync(cardDto);
    
                if (deleted)
                {
                    this.RemoveCache(CacheKeys.Card);
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
    
            return cardDto;
        }
    
        private bool CardExists(int id)
        {
            return _context.Cards.Any(e => e.Id == id);
        }
    
    	
    	// GET: api/Cards/Cache
        [AllowAnonymous]
        [HttpGet("Cache")]
        public IEnumerable<CardCache> GetCacheCards()
        {
            return this.CacheCards();
        }
        
        
    }
}
