﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SurveyApp.Data;
using SurveyApp.Models;

namespace SurveyApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResponsesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ResponsesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Responses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Response>>> GetResponses()
        {
          if (_context.Responses == null)
          {
              return NotFound();
          }
            return await _context.Responses.ToListAsync();
        }

        // GET: api/Responses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> GetResponse(int id)
        {
          if (_context.Responses == null)
          {
              return NotFound();
          }
            var response = await _context.Responses.FindAsync(id);

            if (response == null)
            {
                return NotFound();
            }

            return response;
        }

        // PUT: api/Responses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutResponse(int id, Response response)
        {
            if (id != response.ResponseID)
            {
                return BadRequest();
            }

            _context.Entry(response).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResponseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Responses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Response>> PostResponse(Response response)
        {
          if (_context.Responses == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Responses'  is null.");
          }
            _context.Responses.Add(response);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetResponse", new { id = response.ResponseID }, response);
        }

        // DELETE: api/Responses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResponse(int id)
        {
            if (_context.Responses == null)
            {
                return NotFound();
            }
            var response = await _context.Responses.FindAsync(id);
            if (response == null)
            {
                return NotFound();
            }

            _context.Responses.Remove(response);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ResponseExists(int id)
        {
            return (_context.Responses?.Any(e => e.ResponseID == id)).GetValueOrDefault();
        }
    }
}
