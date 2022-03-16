using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProvaCaminhao.Data;
using ProvaCaminhao.Models;

namespace ProvaCaminhao.Controllers.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelosController : ControllerBase
    {
        private readonly ApiDbContext _context;
        private readonly IModeloRepository _modeloRepository;
        public ModelosController(ApiDbContext context           ,
                        IModeloRepository modeloRepository
            )
        {
            _context = context;
            _modeloRepository = modeloRepository;
        }
            
        // GET: api/Modelos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Modelo>>> GetModelo()
        {
           // var modelo = await _context.Modelo.ToListAsync();
            var modelos = await _modeloRepository.ObterTodos();            
            return modelos.ToList();
        }

        // GET: api/Modelos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Modelo>> GetModelo(int id)
        {
            //var modelo = await _context.Modelo.FindAsync(id);
            var modelo = await _modeloRepository.ObterPorId(id);

            if (modelo == null)
            {
                return NotFound();
            }

            return modelo;
        }

        // PUT: api/Modelos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModelo(int id, Modelo modelo)
        {
            if (id != modelo.ID)
            {
                return BadRequest();
            }
            _modeloRepository.Atualizar(modelo);
           // _modeloRepository.SalvarTodos();

            try
            {
                _modeloRepository.SalvarTodos();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModeloExists(id))
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

        // POST: api/Modelos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Modelo>> PostModelo(Modelo modelo)
        {
            _modeloRepository.Adicionar(modelo);
            _modeloRepository.SalvarTodos();

            return CreatedAtAction("GetModelo", new { id = modelo.ID }, modelo);
        }

        // DELETE: api/Modelos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModelo(int id)
        {
            var modelo = await _modeloRepository.ObterPorId(id);
            if (modelo == null)
            {
                return NotFound();
            }

            _context.Modelo.Remove(modelo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ModeloExists(int id)
        {
            return _context.Modelo.Any(e => e.ID == id);
        }
    }
}
