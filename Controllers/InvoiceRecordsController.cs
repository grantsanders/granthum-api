using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using granthum_api.Data;
using granthum_api.Models;

namespace granthum_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceRecordsController : ControllerBase
    {
        private readonly DataContext _context;

        public InvoiceRecordsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/InvoiceRecords
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvoiceRecord>>> GetInvoiceRecords()
        {
            return await _context.InvoiceRecords.ToListAsync();
        }

        // GET: api/InvoiceRecords/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InvoiceRecord>> GetInvoiceRecord(string id)
        {
            var invoiceRecord = await _context.InvoiceRecords.FindAsync(id);

            if (invoiceRecord == null)
            {
                return NotFound();
            }

            return invoiceRecord;
        }

        // PUT: api/InvoiceRecords/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvoiceRecord(string id, InvoiceRecord invoiceRecord)
        {
            if (id != invoiceRecord.Id)
            {
                return BadRequest();
            }

            _context.Entry(invoiceRecord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvoiceRecordExists(id))
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

        // POST: api/InvoiceRecords
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InvoiceRecord>> PostInvoiceRecord(InvoiceRecord invoiceRecord)
        {
            _context.InvoiceRecords.Add(invoiceRecord);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (InvoiceRecordExists(invoiceRecord.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetInvoiceRecord", new { id = invoiceRecord.Id }, invoiceRecord);
        }

        // DELETE: api/InvoiceRecords/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvoiceRecord(string id)
        {
            var invoiceRecord = await _context.InvoiceRecords.FindAsync(id);
            if (invoiceRecord == null)
            {
                return NotFound();
            }

            _context.InvoiceRecords.Remove(invoiceRecord);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InvoiceRecordExists(string id)
        {
            return _context.InvoiceRecords.Any(e => e.Id == id);
        }
    }
}
