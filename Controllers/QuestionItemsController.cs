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
    public class QuestionItemsController : ControllerBase
    {
        private readonly ExamApiContext _context;

        public QuestionItemsController(ExamApiContext context)
        {
            _context = context;
        }

        // GET: api/QuestionItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<QuestionItem>>> GetQuestionItem(Guid id)
        {
            var questionItems = await _context.ExamItems.Include(e => e.QuestionItems).ThenInclude(q => q.AnwserItems).Where(w => w.Id.Equals(id)).FirstOrDefaultAsync();

            if (questionItems == null)
            {
                return NotFound();
            }

            return questionItems.QuestionItems.ToArray();
        }

        // PUT: api/QuestionItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuestionItem(Guid id, QuestionItem questionItem)
        {
            if (id != questionItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(questionItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionItemExists(id))
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

        // POST: api/QuestionItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<QuestionItem>> PostQuestionItem(QuestionItem questionItem)
        {
            Guid tempGuid = Guid.NewGuid();
            questionItem.Id = tempGuid;
            foreach(var item in questionItem.AnwserItems) {
                item.QuestionItemId = tempGuid;
            }
            _context.QuestionItems.Add(questionItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuestionItem", new { id = questionItem.Id }, questionItem);
        }

        // DELETE: api/QuestionItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestionItem(Guid id)
        {
            var questionItem = await _context.QuestionItems.FindAsync(id);
            if (questionItem == null)
            {
                return NotFound();
            }

            _context.QuestionItems.Remove(questionItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QuestionItemExists(Guid id)
        {
            return _context.QuestionItems.Any(e => e.Id == id);
        }
    }
}
