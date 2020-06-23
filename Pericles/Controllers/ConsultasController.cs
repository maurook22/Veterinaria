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
    public class ConsultasController : Controller
    {
        private readonly PericlesContext _context;

        public ConsultasController(PericlesContext context)
        {
            _context = context;
        }

        // GET: Consultas
        public async Task<IActionResult> Index()
        {
            var periclesContext = _context.consultas.Include(c => c.Mascota).Include(c => c.Veterinario);
            return View(await periclesContext.ToListAsync());
        }

        // GET: Consultas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consulta = await _context.consultas
                .Include(c => c.Mascota)
                .Include(c => c.Veterinario)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (consulta == null)
            {
                return NotFound();
            }

            return View(consulta);
        }

        // GET: Consultas/Create
        public IActionResult Create()
        {
            ViewData["MascotaID"] = new SelectList(_context.mascotas, "ID", "Nombre");
            ViewData["VeterinarioID"] = new SelectList(_context.veterinarios, "ID", "Apellido");
            return View();
        }

        // POST: Consultas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Fecha,Diagnostico,MascotaID,VeterinarioID")] Consulta consulta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consulta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MascotaID"] = new SelectList(_context.mascotas, "ID", "Nombre", consulta.MascotaID);
            ViewData["VeterinarioID"] = new SelectList(_context.veterinarios, "ID", "Apellido", consulta.VeterinarioID);
            return View(consulta);
        }

        // GET: Consultas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consulta = await _context.consultas.FindAsync(id);
            if (consulta == null)
            {
                return NotFound();
            }
            ViewData["MascotaID"] = new SelectList(_context.mascotas, "ID", "Nombre", consulta.MascotaID);
            ViewData["VeterinarioID"] = new SelectList(_context.veterinarios, "ID", "Apellido", consulta.VeterinarioID);
            return View(consulta);
        }

        // POST: Consultas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Fecha,Diagnostico,MascotaID,VeterinarioID")] Consulta consulta)
        {
            if (id != consulta.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consulta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsultaExists(consulta.ID))
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
            ViewData["MascotaID"] = new SelectList(_context.mascotas, "ID", "Nombre", consulta.MascotaID);
            ViewData["VeterinarioID"] = new SelectList(_context.veterinarios, "ID", "Apellido", consulta.VeterinarioID);
            return View(consulta);
        }

        // GET: Consultas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consulta = await _context.consultas
                .Include(c => c.Mascota)
                .Include(c => c.Veterinario)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (consulta == null)
            {
                return NotFound();
            }

            return View(consulta);
        }

        // POST: Consultas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var consulta = await _context.consultas.FindAsync(id);
            _context.consultas.Remove(consulta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConsultaExists(int id)
        {
            return _context.consultas.Any(e => e.ID == id);
        }
    }
}
