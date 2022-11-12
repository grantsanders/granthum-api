using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using granthum_api.Data;
using granthum_api.Models;
using Microsoft.Azure.Cosmos;

namespace granthum_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvoiceRecordsController : Controller
    {
        private readonly DataContext _context;
        
        private readonly ILogger<InvoiceRecordsController> _logger;
        public InvoiceRecordsController(DataContext context, ILogger<InvoiceRecordsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: InvoiceRecords
        [HttpGet(Name = "GetInvoiceRecords")]
        public async Task<IActionResult> Get()
        {
            await _context.FindAsync<InvoiceRecord>();

            return View();
        }

        //// GET: InvoiceRecords/Details/5
        //public async Task<IActionResult> Details(string id)
        //{
        //    if (id == null || _context.InvoiceRecords == null)
        //    {
        //        return NotFound();
        //    }

        //    var invoiceRecord = await _context.InvoiceRecords
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (invoiceRecord == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(invoiceRecord);
        //}

        //// GET: InvoiceRecords/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: InvoiceRecords/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost(Name = "CreateRecord")]
        public async Task OnGet([Bind("Id,ImportedSuccessfully,Name")] InvoiceRecord invoiceRecord)
        {
            invoiceRecord.Id = "2";
            invoiceRecord.Name = "test";
            invoiceRecord.ImportedSuccessfully = true;

             _context.invoices.Add(invoiceRecord);

            await _context.SaveChangesAsync();

            //return null;
        }

        //// GET: InvoiceRecords/Edit/5
        //public async Task<IActionResult> Edit(string id)
        //{
        //    if (id == null || _context.InvoiceRecords == null)
        //    {
        //        return NotFound();
        //    }

        //    var invoiceRecord = await _context.InvoiceRecords.FindAsync(id);
        //    if (invoiceRecord == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(invoiceRecord);
        //}

        //// POST: InvoiceRecords/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(string id, [Bind("Id,ImportedSuccessfully,Name")] InvoiceRecord invoiceRecord)
        //{
        //    if (id != invoiceRecord.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(invoiceRecord);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!InvoiceRecordExists(invoiceRecord.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(invoiceRecord);
        //}

        //// GET: InvoiceRecords/Delete/5
        //public async Task<IActionResult> Delete(string id)
        //{
        //    if (id == null || _context.InvoiceRecords == null)
        //    {
        //        return NotFound();
        //    }

        //    var invoiceRecord = await _context.InvoiceRecords
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (invoiceRecord == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(invoiceRecord);
        //}

        //// POST: InvoiceRecords/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(string id)
        //{
        //    if (_context.InvoiceRecords == null)
        //    {
        //        return Problem("Entity set 'DataContext.InvoiceRecords'  is null.");
        //    }
        //    var invoiceRecord = await _context.InvoiceRecords.FindAsync(id);
        //    if (invoiceRecord != null)
        //    {
        //        _context.InvoiceRecords.Remove(invoiceRecord);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool InvoiceRecordExists(string id)
        //{
        //  return _context.InvoiceRecords.Any(e => e.Id == id);
        //}
    }
}
