using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaymentInstruction.Models;

namespace PaymentInstruction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentInstructionsController : ControllerBase
    {
        private readonly PaymentInstructionContext _context;

        public PaymentInstructionsController(PaymentInstructionContext context)
        {
            _context = context;
        }

        // GET: api/PaymentInstructions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentInstruction.Models.PaymentInstruction>>> GetPaymentInstruction([FromQuery] PageFilter filter)
        {
            return await _context.PaymentInstruction
                    .Skip((filter.page - 1)*filter.pageSize)
                    .Take(filter.pageSize).ToListAsync();
            //return await _context.PaymentInstruction.ToListAsync();
        }

        // GET: api/PaymentInstructions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentInstruction.Models.PaymentInstruction>> GetPaymentInstruction(int id)
        {
            var paymentInstruction = await _context.PaymentInstruction.FindAsync(id);

            if (paymentInstruction == null)
            {
                return NotFound();
            }

            return paymentInstruction;
        }

        // PUT: api/PaymentInstructions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentInstruction(int id, PaymentInstruction.Models.PaymentInstruction paymentInstruction)
        {
            if (id != paymentInstruction.Id)
            {
                return BadRequest();
            }

            _context.Entry(paymentInstruction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentInstructionExists(id))
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

        // POST: api/PaymentInstructions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PaymentInstruction.Models.PaymentInstruction>> PostPaymentInstruction(PaymentInstruction.Models.PaymentInstruction paymentInstruction)
        {
            _context.PaymentInstruction.Add(paymentInstruction);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaymentInstruction", new { id = paymentInstruction.Id }, paymentInstruction);
        }

        // DELETE: api/PaymentInstructions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaymentInstruction(int id)
        {
            var paymentInstruction = await _context.PaymentInstruction.FindAsync(id);
            if (paymentInstruction == null)
            {
                return NotFound();
            }

            _context.PaymentInstruction.Remove(paymentInstruction);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PaymentInstructionExists(int id)
        {
            return _context.PaymentInstruction.Any(e => e.Id == id);
        }
    }
}

public class PageFilter
{
    public int page { get; set; }
    public int pageSize { get; set; }
}
