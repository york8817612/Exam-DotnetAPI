#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExamApi.Models;

namespace ExamApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamItemsController : ControllerBase
    {
        private readonly ExamApiContext _context;

        public ExamItemsController(ExamApiContext context)
        {
            _context = context;
        }

        // GET: api/ExamItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExamItem>>> GetExamItems()
        {
            return await _context.ExamItems.ToListAsync();
        }

        // GET: api/ExamItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExamItem>> GetExamItem(Guid id)
        {
            var examItem = await _context.ExamItems.FindAsync(id);

            if (examItem == null)
            {
                return NotFound();
            }

            return examItem;
        }

        // PUT: api/ExamItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExamItem(Guid id, ExamItem examItem)
        {
            if (id != examItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(examItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExamItemExists(id))
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

        // POST: api/ExamItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ExamItem>> PostExamItem(ExamItem examItem)
        {
            _context.ExamItems.Add(examItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetExamItem), new { id = examItem.Id }, examItem);
        }

        // DELETE: api/ExamItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExamItem(Guid id)
        {
            var examItem = await _context.ExamItems.FindAsync(id);
            if (examItem == null)
            {
                return NotFound();
            }

            _context.ExamItems.Remove(examItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExamItemExists(Guid id)
        {
            return _context.ExamItems.Any(e => e.Id == id);
        }
    }
}
