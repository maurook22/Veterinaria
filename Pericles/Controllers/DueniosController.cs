using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pericles.Context;
using Pericles.Models;

namespace Pericles.Controllers
{
    public class DueniosController : Controller
    {
        private readonly PericlesContext _context;

        public DueniosController(PericlesContext context)
        {
            _context = context;
        }

        // GET: Duenios
        public async Task<IActionResult> Index()
        {
            return View(await _context.duenios.ToListAsync());
        }

        // GET: Duenios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var duenio = await _context.duenios
                .FirstOrDefaultAsync(m => m.ID == id);
            if (duenio == null)
            {
                return NotFound();
            }

            return View(duenio);
        }

        // GET: Duenios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Duenios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nombre,Apellido,Direccion,Dni,Telefono,Mail")] Duenio duenio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(duenio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(duenio);
        }

        // GET: Duenios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var duenio = await _context.duenios.FindAsync(id);
            if (duenio == null)
            {
                return NotFound();
            }
            return View(duenio);
        }

        // POST: Duenios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nombre,Apellido,Direccion,Dni,Telefono,Mail")] Duenio duenio)
        {
            if (id != duenio.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(duenio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DuenioExists(duenio.ID))
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
            return View(duenio);
        }

        // GET: Duenios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var duenio = await _context.duenios
                .FirstOrDefaultAsync(m => m.ID == id);
            if (duenio == null)
            {
                return NotFound();
            }

            return View(duenio);
        }

        // POST: Duenios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var duenio = await _context.duenios.FindAsync(id);
            _context.duenios.Remove(duenio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DuenioExists(int id)
        {
            return _context.duenios.Any(e => e.ID == id);
        }
    }
}
