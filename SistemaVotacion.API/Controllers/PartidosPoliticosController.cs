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
    public class PartidosPoliticosController : ControllerBase
    {
        private readonly SistemaVotacionAPIContext _context;

        public PartidosPoliticosController(SistemaVotacionAPIContext context)
        {
            _context = context;
        }

        // GET: api/PartidosPoliticos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PartidoPolitico>>> GetPartidoPolitico()
        {
            return await _context.PartidosPoliticos.ToListAsync();
        }

        // GET: api/PartidosPoliticos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PartidoPolitico>> GetPartidoPolitico(int id)
        {
            var partidoPolitico = await _context.PartidosPoliticos.FindAsync(id);

            if (partidoPolitico == null)
            {
                return NotFound();
            }

            return partidoPolitico;
        }

        // PUT: api/PartidosPoliticos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPartidoPolitico(int id, PartidoPolitico partidoPolitico)
        {
            if (id != partidoPolitico.Id)
            {
                return BadRequest();
            }

            _context.Entry(partidoPolitico).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartidoPoliticoExists(id))
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

        // POST: api/PartidosPoliticos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PartidoPolitico>> PostPartidoPolitico(PartidoPolitico partidoPolitico)
        {
            _context.PartidosPoliticos.Add(partidoPolitico);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPartidoPolitico", new { id = partidoPolitico.Id }, partidoPolitico);
        }

        // DELETE: api/PartidosPoliticos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePartidoPolitico(int id)
        {
            var partidoPolitico = await _context.PartidosPoliticos.FindAsync(id);
            if (partidoPolitico == null)
            {
                return NotFound();
            }

            _context.PartidosPoliticos.Remove(partidoPolitico);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PartidoPoliticoExists(int id)
        {
            return _context.PartidosPoliticos.Any(e => e.Id == id);
        }
    }
}
