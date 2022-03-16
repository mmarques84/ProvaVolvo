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
    public class CaminhaoController : ControllerBase
    {
        private readonly ApiDbContext _context;
        private readonly ICaminhaoRepository _caminhaoRepository;

        public CaminhaoController(ApiDbContext context, ICaminhaoRepository caminhaoRepository)
        {
            _context = context;
            _caminhaoRepository = caminhaoRepository;
        }

        // GET: api/Caminhao
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Caminhao>>> GetCaminhao()
        {
            var caminhao = await _caminhaoRepository.ObterTodos();
            if (caminhao == null)
            {
                return NotFound("NÃO EXISTE CAMINHAO CADASTRADO");
            }
            return caminhao.ToList();
        }

        // GET: api/Caminhao/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Caminhao>> GetCaminhao(int id)
        {
           // var caminhao = await _context.Caminhao.FindAsync(id);
            var caminhao = await _caminhaoRepository.ObterPorId(id);

            if (caminhao == null)
            {
                return NotFound();
            }

            return caminhao;
        }

        // PUT: api/Caminhao/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCaminhao(int id, Caminhao caminhao)
        {
            if (id != caminhao.ID)
            {
                return BadRequest();
            }
            _caminhaoRepository.Atualizar(caminhao);
           // _context.Entry(caminhao).State = EntityState.Modified;

            try
            {
                _caminhaoRepository.SalvarTodos();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CaminhaoExists(id))
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

        // POST: api/Caminhao
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Caminhao>> PostCaminhao(Caminhao caminhao)
        {
            _caminhaoRepository.Adicionar(caminhao);
            _caminhaoRepository.SalvarTodos();

            return CreatedAtAction("GetCaminhao", new { id = caminhao.ID }, caminhao);
        }

        // DELETE: api/Caminhao/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCaminhao(int id)
        {
            var caminhao = await _caminhaoRepository.ObterPorId(id);      
            if (caminhao == null)
            {
                return NotFound();
            }

            _context.Caminhao.Remove(caminhao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CaminhaoExists(int id)
        {
            return _context.Caminhao.Any(e => e.ID == id);
        }
    }
}
