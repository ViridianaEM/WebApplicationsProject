using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Final2.Models.Entities;

namespace Final2.Controllers
{
    public class DataController : Controller
    {
        private readonly StudentsContext _context;

        public DataController(StudentsContext context)
        {
            _context = context;
        }

        // GET: Data
        public async Task<IActionResult> Index()
        {
            return View(await _context.Datas.ToListAsync());
        }

        // GET: Data/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @data = await _context.Datas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@data == null)
            {
                return NotFound();
            }

            return View(@data);
        }

        // GET: Data/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Data/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Fname,Lname,Birthday,Email,Major,Address,Quarter,Password")] Data @data)
        {
            if (ModelState.IsValid)
            {
                _context.Add(@data);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(@data);
        }

        // GET: Data/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @data = await _context.Datas.FindAsync(id);
            if (@data == null)
            {
                return NotFound();
            }
            return View(@data);
        }

        // POST: Data/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Fname,Lname,Birthday,Email,Major,Address,Quarter,Password")] Data @data)
        {
            if (id != @data.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@data);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DataExists(@data.Id))
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
            return View(@data);
        }

        // GET: Data/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @data = await _context.Datas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@data == null)
            {
                return NotFound();
            }

            return View(@data);
        }

        // POST: Data/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @data = await _context.Datas.FindAsync(id);
            _context.Datas.Remove(@data);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DataExists(int id)
        {
            return _context.Datas.Any(e => e.Id == id);
        }
    }
}
