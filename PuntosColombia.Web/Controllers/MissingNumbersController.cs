using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PuntosColombia.Web.Data;
using PuntosColombia.Web.Data.Entities;
using PuntosColombia.Bussiness;

namespace PuntosColombia.Web.Controllers
{
    public class MissingNumbersController : Controller
    {
        private readonly DataContext _context;
        private readonly IMissingNumbers _missingNumbers;

        public MissingNumbersController(DataContext context, IMissingNumbers missingNumbers)
        {
            _context = context;
            _missingNumbers = missingNumbers;
        }

        // GET: MissingNumbers
        public async Task<IActionResult> Index()
        {
            return View(await _context.MissingNumbers.ToListAsync());
        }

        // GET: MissingNumbers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var missingNumber = await _context.MissingNumbers
                .FirstOrDefaultAsync(m => m.MissingNumberId == id);
            if (missingNumber == null)
            {
                return NotFound();
            }

            return View(missingNumber);
        }

        // GET: MissingNumbers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MissingNumbers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MissingNumber missingNumber)
        {

            var n = missingNumber.QuantityListA;
            var m = missingNumber.QuantityListB;
            string[] arrayA= missingNumber.ListA.Trim().Split(' ');
            var arr = Array.ConvertAll(arrayA, Int32.Parse).ToList();
            string[] arrayB = missingNumber.ListB.Trim().Split(' ');
            var brr = Array.ConvertAll(arrayB, Int32.Parse).ToList();

            
            var resultList = _missingNumbers.SearchMissingNumbers(n, m, arr, brr);
            
            if (!resultList.Contains("Error_"))
            {
                missingNumber.ListResult = resultList;
                if (ModelState.IsValid)
                {
                    _context.Add(missingNumber);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            else
            {
                ViewBag.Message = resultList;
            }

           
            return View(missingNumber);
        }

        // GET: MissingNumbers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var missingNumber = await _context.MissingNumbers.FindAsync(id);
            if (missingNumber == null)
            {
                return NotFound();
            }
            return View(missingNumber);
        }

        // POST: MissingNumbers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MissingNumberId,QuantityListA,ListA,QuantityListB,ListB,ListResult")] MissingNumber missingNumber)
        {
            if (id != missingNumber.MissingNumberId)
            {
                return NotFound();
            }

           

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(missingNumber);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MissingNumberExists(missingNumber.MissingNumberId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(missingNumber);
        }

        // GET: MissingNumbers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var missingNumber = await _context.MissingNumbers
                .FirstOrDefaultAsync(m => m.MissingNumberId == id);
            if (missingNumber == null)
            {
                return NotFound();
            }

            return View(missingNumber);
        }

        // POST: MissingNumbers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var missingNumber = await _context.MissingNumbers.FindAsync(id);
            _context.MissingNumbers.Remove(missingNumber);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MissingNumberExists(int id)
        {
            return _context.MissingNumbers.Any(e => e.MissingNumberId == id);
        }
    }
}
