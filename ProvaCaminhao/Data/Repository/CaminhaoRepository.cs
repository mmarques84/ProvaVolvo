using Microsoft.EntityFrameworkCore;
using ProvaCaminhao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProvaCaminhao.Data.Repository
{
    public class CaminhaoRepository : ICaminhaoRepository
    {
        private readonly ApiDbContext _context;

        public CaminhaoRepository(ApiDbContext context)
        {
            _context = context;
        }
        public void Adicionar(Caminhao caminhao)
        {
            _context.Caminhao.Add(caminhao);
        }

        public void Atualizar(Caminhao caminhao)
        {
            _context.Caminhao.Update(caminhao);
        }

        public async Task<Caminhao> ObterPorId(int id)
        {
            return await _context.Caminhao.FindAsync(id);
        }

        public async Task<IEnumerable<Caminhao>> ObterTodos()
        {            
            return await _context.Caminhao.Include(x=>x.modelo).AsNoTracking().ToListAsync();
        }
        public void Dispose()
        {
            _context?.Dispose();
        }

        public void SalvarTodos()
        {
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
