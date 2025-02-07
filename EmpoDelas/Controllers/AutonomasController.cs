﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmpoDelas.Data;
using empodelas.Models;

namespace EmpoDelas.Controllers
{
    public class AutonomasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AutonomasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Autonomas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Autonoma.ToListAsync());
        }

        // GET: Autonomas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autonoma = await _context.Autonoma
                .FirstOrDefaultAsync(m => m.Id_autonoma == id);
            if (autonoma == null)
            {
                return NotFound();
            }

            return View(autonoma);
        }

        // GET: Autonomas/Create
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Comprovante()
        {
            return View();
        }

        // POST: Autonomas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_autonoma,Nome_autonoma,Sobrenome_autonoma,Email_autonoma,DataNasc_autonoma,NumTelefone_autonoma,Endereco_autonoma,Cep_autonoma,NomeNegocio_autonoma,ContatoNegocio_autonoma,CategoriaNegocio_autonoma,DescricaoNegocio_autonoma,ComprovanteResid_autonoma")] Autonoma autonoma)
        {
            if (ModelState.IsValid)
            {
                _context.Add(autonoma);
                await _context.SaveChangesAsync();
                return RedirectToAction("Comprovante");
            }
            return View(autonoma);
        }

        // GET: Autonomas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autonoma = await _context.Autonoma.FindAsync(id);
            if (autonoma == null)
            {
                return NotFound();
            }
            return View(autonoma);
        }

        // POST: Autonomas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_autonoma,Nome_autonoma,Sobrenome_autonoma,Email_autonoma,DataNasc_autonoma,NumTelefone_autonoma,Endereco_autonoma,Cep_autonoma,NomeNegocio_autonoma,ContatoNegocio_autonoma,CategoriaNegocio_autonoma,DescricaoNegocio_autonoma,ComprovanteResid_autonoma")] Autonoma autonoma)
        {
            if (id != autonoma.Id_autonoma)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(autonoma);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutonomaExists(autonoma.Id_autonoma))
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
            return View(autonoma);
        }

        // GET: Autonomas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autonoma = await _context.Autonoma
                .FirstOrDefaultAsync(m => m.Id_autonoma == id);
            if (autonoma == null)
            {
                return NotFound();
            }

            return View(autonoma);
        }

        // POST: Autonomas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var autonoma = await _context.Autonoma.FindAsync(id);
            _context.Autonoma.Remove(autonoma);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AutonomaExists(int id)
        {
            return _context.Autonoma.Any(e => e.Id_autonoma == id);
        }
    }
}
