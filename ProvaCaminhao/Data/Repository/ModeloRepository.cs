using Microsoft.EntityFrameworkCore;
using ProvaCaminhao.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProvaCaminhao.Data.Repository
{

    public class ModeloRepository : IModeloRepository
    {
        private readonly ApiDbContext _context;

        public ModeloRepository(ApiDbContext context)
        {
            _context = context;
        }
       

        public void Adicionar(Modelo modelo)
        {
            _context.Modelo.Add(modelo);
        }

        public void Atualizar(Modelo modelo)
        {
            _context.Entry(modelo).State = EntityState.Modified;
           
        }
        public void SalvarTodos()
        {
            _context.SaveChanges();
        }
        public void Dispose()
        {
            _context?.Dispose();
        }

        public async Task<Modelo> ObterPorId(int id)
        {
            return await _context.Modelo.FindAsync(id);
        }

        public async Task<IEnumerable<Modelo>> ObterTodos()
        {  
           
            return await _context.Modelo.Where(c=>c.descricao.Contains("FH") || c.descricao.Contains("FM")).AsNoTracking().ToListAsync();
        }
    }
}
