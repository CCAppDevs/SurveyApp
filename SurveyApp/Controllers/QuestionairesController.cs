using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SurveyApp.Data;
using SurveyApp.Models;

namespace SurveyApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionairesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public QuestionairesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Questionaires
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Questionaire>>> GetQuestionaire()
        {
          if (_context.Questionaire == null)
          {
              return NotFound();
          }
            return await _context.Questionaire.ToListAsync();
        }

        // GET: api/Questionaires/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Questionaire>> GetQuestionaire(int id)
        {
          if (_context.Questionaire == null)
          {
              return NotFound();
          }
            var questionaire = await _context.Questionaire.FindAsync(id);

            if (questionaire == null)
            {
                return NotFound();
            }

            return questionaire;
        }

        // PUT: api/Questionaires/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuestionaire(int id, Questionaire questionaire)
        {
            if (id != questionaire.QuestionaireID)
            {
                return BadRequest();
            }

            _context.Entry(questionaire).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionaireExists(id))
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

        // POST: api/Questionaires
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Questionaire>> PostQuestionaire(Questionaire questionaire)
        {
          if (_context.Questionaire == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Questionaire'  is null.");
          }
            _context.Questionaire.Add(questionaire);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuestionaire", new { id = questionaire.QuestionaireID }, questionaire);
        }

        // DELETE: api/Questionaires/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestionaire(int id)
        {
            if (_context.Questionaire == null)
            {
                return NotFound();
            }
            var questionaire = await _context.Questionaire.FindAsync(id);
            if (questionaire == null)
            {
                return NotFound();
            }

            _context.Questionaire.Remove(questionaire);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QuestionaireExists(int id)
        {
            return (_context.Questionaire?.Any(e => e.QuestionaireID == id)).GetValueOrDefault();
        }
    }
}
