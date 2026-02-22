using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaVotacion01;

namespace SistemaVotacion.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class listasController : ControllerBase
    {
        private readonly SistemaVotacionAPIContext _context;

        public listasController(SistemaVotacionAPIContext context)
        {
            _context = context;
        }

        // GET: api/listas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<lista>>> Getlista()
        {
            return await _context.listas.ToListAsync();
        }

        // GET: api/listas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<lista>> Getlista(int id)
        {
            var lista = await _context.listas.FindAsync(id);

            if (lista == null)
            {
                return NotFound();
            }

            return lista;
        }

        // PUT: api/listas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putlista(int id, lista lista)
        {
            if (id != lista.Id)
            {
                return BadRequest();
            }

            _context.Entry(lista).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!listaExists(id))
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

        // POST: api/listas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<lista>> Postlista(lista lista)
        {
            _context.listas.Add(lista);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getlista", new { id = lista.Id }, lista);
        }

        // DELETE: api/listas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletelista(int id)
        {
            var lista = await _context.listas.FindAsync(id);
            if (lista == null)
            {
                return NotFound();
            }

            _context.listas.Remove(lista);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool listaExists(int id)
        {
            return _context.listas.Any(e => e.Id == id);
        }
    }
}
